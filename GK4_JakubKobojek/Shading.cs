using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Cpu3DEngine
{
    public static class Shading
    {
        public static Color Phong(Vector3 position, Vector3 normal, Color01 color01, LightParams mesh,
            List<Light> lights, Vector3 cameraPosition, FogGenerator? fog)
        {
            var resultColor = new Color01 {R = 0, G = 0, B = 0};

            //ambient
            resultColor.R += color01.R * mesh.Ka;
            resultColor.G += color01.G * mesh.Ka;
            resultColor.B += color01.B * mesh.Ka;

            foreach (var light in lights)
            {
                if (light.Off == true)
                    continue;

                double spotlightFactor = 1;

                var L = Vector3.Normalize(light.TransformedPosition - position);

                if (light.IsSpotlight)
                {
                    var D = light.TransformedDirection;
                    var cos = Vector3.Dot(-D, L);
                    spotlightFactor = cos > 0 ? Math.Pow(cos, light.P) : 0;
                }

                //diffuse
                var lightNormalAngle = Vector3.Dot(normal, L);
                var diffuseR = mesh.Kd * lightNormalAngle * spotlightFactor;
                if (lightNormalAngle < 0) continue;

                resultColor = ColorMultiply(resultColor, color01, diffuseR);

                //specular
                var V = Vector3.Normalize(-position);

                var R = Vector3.Normalize(2 * lightNormalAngle * normal - L);

                var cameraAngle = Vector3.Dot(R, V);

                if (cameraAngle < 0) continue;

                var specularR = mesh.Ks * Math.Pow(cameraAngle, mesh.M) * spotlightFactor;

                resultColor.R += specularR;
                resultColor.G += specularR;
                resultColor.B += specularR;
            }

            if (fog != null)
                resultColor = fog.ApplyFogToColor(resultColor, position, cameraPosition);

            if (resultColor.R > 1) resultColor.R = 1;
            if (resultColor.G > 1) resultColor.G = 1;
            if (resultColor.B > 1) resultColor.B = 1;

            return ScaleTo0255(resultColor);
        }


        public static Color01 ScaleTo01(Color color)
        {
            return new Color01 {R = color.R / 255.0, G = color.G / 255.0, B = color.B / 255.0};
        }

        public static Color01 ColorMultiply(Color01 baseColor,Color01 c, double factor)
        {
            var resultColor = new Color01 { R = baseColor.R, G = baseColor.G, B = baseColor.B };
            resultColor.R += c.R * factor;
            resultColor.G += c.G * factor;
            resultColor.B += c.B * factor;
            return resultColor;
        }

        public static Color ScaleTo0255(Color01 color)
        {
            return Color.FromArgb((int) (color.R * 255), (int) (color.G * 255), (int) (color.B * 255));
        }

        public static float TriangleDenominator(Point v1, Point v2, Point v3)
        {
            var triangleDenominator = (v2.Y - v3.Y) * (v1.X - v3.X) + (v3.X - v2.X) * (v1.Y - v3.Y);
            if (triangleDenominator == 0)
                triangleDenominator = 1;

            return triangleDenominator;
        }

        public static (float w1, float w2, float w3) BarycentricCoordinates(int pX, int pY, Point v1, Point v2, Point v3,
            float denominator)
        {
            var w1 = ((v2.Y - v3.Y) * (pX - v3.X) + (v3.X - v2.X) * (pY - v3.Y)) / denominator;

            w1 = w1 >= 0 ? w1 : 0;

            var w2 = ((v3.Y - v1.Y) * (pX - v3.X) + (v1.X - v3.X) * (pY - v3.Y)) / denominator;
            w2 = w2 >= 0 ? w2 : 0;

            var w3 = 1 - w1 - w2;
            if (w3 < 0)
            {
                w3 = 0;
                w2 = 1 - w1;
            }

            return (w1, w2, w3);
        }
    }
}

public class Edge
{
    public double InvertM;
    public double X;
    public int YMax;
}

public struct Color01
{
    public double R;
    public double G;
    public double B;
}

public enum Axis
{
    X,
    Y,
    Z
}

public struct LightParams
{
    public float Ka;
    public float Kd;
    public float Ks;
    public int M;
}

public enum ShadingMode
{
    Flat,
    Gouraud,
    Phong
}