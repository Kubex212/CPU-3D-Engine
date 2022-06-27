using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace Cpu3DEngine
{
    public class Device
    {
        private FastBitmap directBitmap;
        public FogGenerator? fogGenerator = null;
        public Camera activeCamera;
        private float[,] zBuffer;


        public float K_a { get; set; }
        public float K_d { get; set; }
        public float K_s { get; set; }
        public int M { get; set; }
        public float Near { get; set; }
        public float Far { get; set; }
        public float AspectRatio { get; set; }
        public ShadingMode ShadingMode { get; set; }
        public List<Mesh> Meshes { get; set; } = new();
        public List<Light> Lights { get; set; } = new();
        public Device(FastBitmap bitmap)
        {
            Bitmap = bitmap;
            Near = 0.001f;
            Far = 100;
            var dBmp = directBitmap;
            if (dBmp != null) AspectRatio = (float)dBmp.Height / dBmp.Width;
            K_a = 0.2f;
            K_d = 1f;
            K_s = 0.2f;
            M = 5;
            ShadingMode = ShadingMode.Gouraud;
        }

        public FastBitmap Bitmap
        {
            get => directBitmap;
            set
            {
                directBitmap?.Dispose();

                directBitmap = value;
                AspectRatio = (float)directBitmap.Height / directBitmap.Width;
            }
        }

        private Matrix4x4 GetProjectionMatrix()
        {
            var e = (float)(1 / Math.Tan(activeCamera.Fov * Math.PI / 360));

            return new Matrix4x4
            (
                e, 0, 0, 0,
                0, e / AspectRatio, 0, 0,
                0, 0, -(Far + Near) / (Far - Near), -(2 * Far * Near) / (Far - Near),
                0, 0, -1, 0
            );
        }

        private void ResetZBuffer()
        {
            for (var i = 0; i < directBitmap.Height; i++)
                for (var j = 0; j < directBitmap.Width; j++)
                    zBuffer[j, i] = float.MaxValue;
        }

        public void Render()
        {
            zBuffer = new float[Bitmap.Width, Bitmap.Height];
            var meshLightParameters = new LightParams { Ka = K_a, Kd = K_d, Ks = K_s, M = M };
            ResetZBuffer();

            var projection = GetProjectionMatrix();
            var view = activeCamera.GetViewMatrix();

            foreach (var l in Lights)
                l.Transform(view);

            foreach (var mesh in Meshes)
            {
                foreach (var vertex in mesh.Faces.SelectMany(face => face.Points)) vertex.Reset();

                Matrix4x4 model = mesh.Model;
                Matrix4x4 viewModel = Matrix4x4.Multiply(view, model);

                foreach (var face in mesh.Faces)
                {
                    foreach (var point in face.Points)
                        point.Transform(viewModel, true);

                    var v = face.Position;
                    var n = face.Normal;

                    if (face.Points[0].Z > 0 && face.Points[1].Z > 0 && face.Points[2].Z > 0)
                        continue;

                    if (n.X * v.X + n.Y * v.Y + n.Z * v.Z <= 0)
                        DrawTriangle(projection, meshLightParameters, face);
                }
            }
        }

        public void DrawTriangle(Matrix4x4 projectionMatrix, LightParams meshLightParameters, Face face)
        {
            var positions = face.Points.Select(p => new Vector3(p.X, p.Y, p.Z)).ToList();
            var normals = face.Points.Select(p =>
                    Vector3.Normalize(new Vector3(p.TransformedNormal.X, p.TransformedNormal.Y, p.TransformedNormal.Z))).ToList();

            foreach (var point in face.Points) point.Transform(projectionMatrix, false);

            var projectedPoints = new List<Point>();
            var zPoints = new List<float>();

            foreach (var point in face.Points)
            {
                projectedPoints.Add(new Point((int)((point.X + 1) * Bitmap.Width / 2),
                    (int)((point.Y + 1) * Bitmap.Width / 2)));
                zPoints.Add(point.Z);
            }

            var shadingMode = ShadingMode;

            Fill(projectedPoints, face.Color, zPoints, positions, normals, meshLightParameters, shadingMode);
        }

        public void Fill(List<Point> points, Color color, List<float> zs, List<Vector3> positions, List<Vector3> normals,
            LightParams mesh, ShadingMode shadingMode)
        {
            const int margin = 400;

            var maxX = points.Max(p => p.X);
            if (maxX < -margin || maxX > Bitmap.Width + margin) return;
            var maxY = points.Max(p => p.Y);
            if (maxY < -margin || maxY > Bitmap.Height + margin) return;

            var minX = points.Min(p => p.X);
            if (minX < -margin || minX > Bitmap.Width + margin) return;
            var minY = points.Min(p => p.Y);
            if (minY < -margin || minY > Bitmap.Height + margin) return;

            var ET = new List<Edge>[maxY - minY + 1];
            var denom = Shading.TriangleDenominator(points[0], points[1], points[2]);

            for (var i = 0; i < points.Count; i++)
            {
                var p1 = points[i];
                var p2 = points[i + 1 == points.Count ? 0 : i + 1];
                if (p1.Y == p2.Y) continue;
                if (p1.Y > p2.Y) (p2, p1) = (p1, p2);

                var str = new Edge
                { YMax = p2.Y, X = p1.Y < p2.Y ? p1.X : p2.X, InvertM = (double)(p1.X - p2.X) / (p1.Y - p2.Y) };

                if (ET[p1.Y - minY] == null) ET[p1.Y - minY] = new List<Edge>();
                ET[p1.Y - minY].Add(str);
            }

            var AET = new List<Edge>();
            var y = minY;

            var shadingColor = color;
            var color01 = Shading.ScaleTo01(color);

            if (shadingMode == ShadingMode.Flat)
            {
                var middle = (float)(1.0 / 3) * (positions[0] + positions[1] + positions[2]);
                var faceNormal = Vector3.Normalize(normals[0] + normals[1] + normals[2]);
                shadingColor = Shading.Phong(middle, faceNormal, color01, mesh, Lights, activeCamera.Position, fogGenerator);
            }

            Color c1 = Color.White;
            Color c2 = Color.White;
            Color c3 = Color.White;

            if (shadingMode == ShadingMode.Gouraud)
            {
                c1 = Shading.Phong(positions[0], normals[0], color01, mesh, Lights, activeCamera.Position, fogGenerator);
                c2 = Shading.Phong(positions[1], normals[1], color01, mesh, Lights, activeCamera.Position, fogGenerator);
                c3 = Shading.Phong(positions[2], normals[2], color01, mesh, Lights, activeCamera.Position, fogGenerator);
            }

            while (y <= maxY)
            {
                if (ET[y - minY] != null)
                {
                    var tmp = ET[y - minY];
                    AET.AddRange(tmp);
                }

                AET = AET.OrderBy(x => x.X).ToList();
                for (var i = 0; i < AET.Count; i += 2)
                {
                    if (AET.Count - i == 1) continue;

                    for (var j = (int)AET[i].X; j < AET[i + 1].X; j++)
                    {
                        if (!(j >= 0 && j < Bitmap.Width && y >= 0 && y < Bitmap.Height)) continue;

                        var weights = Shading.BarycentricCoordinates(j, y, points[0], points[1], points[2], denom);

                        if (weights.w1 < 0 || weights.w2 < 0 || weights.w3 < 0) continue;
                        var z = zs[0] * weights.w1 + zs[1] * weights.w2 + zs[2] * weights.w3;

                        if (!(z < zBuffer[j, y])) continue;

                        zBuffer[j, y] = z;

                        if (shadingMode == ShadingMode.Gouraud)
                        {
                            var red = weights.w1 * c1.R + weights.w2 * c2.R + weights.w3 * c3.R;
                            var green = weights.w1 * c1.G + weights.w2 * c2.G + weights.w3 * c3.G;
                            var blue = weights.w1 * c1.B + weights.w2 * c2.B + weights.w3 * c3.B;
                            shadingColor = Color.FromArgb((int)red, (int)green, (int)blue);
                        }
                        else if (shadingMode == ShadingMode.Phong)
                        {
                            var normal = weights.w1 * normals[0] + weights.w2 * normals[1] + weights.w3 * normals[2];
                            normal = Vector3.Normalize(normal);
                            var position = weights.w1 * positions[0] + weights.w2 * positions[1] + weights.w3 * positions[2];
                            shadingColor = Shading.Phong(position, normal, Shading.ScaleTo01(color), mesh,
                                Lights, activeCamera.Position, fogGenerator);
                        }

                        Bitmap.SetPixel(j, y, shadingColor);
                    }
                }

                foreach (var edge in AET.ToList())
                    if (edge.YMax == y + 1)
                        AET.Remove(edge);
                    else
                        edge.X += edge.InvertM;
                y++;
            }
        }
    }
}

