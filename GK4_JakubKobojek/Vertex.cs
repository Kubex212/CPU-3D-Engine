using System.Numerics;

namespace Cpu3DEngine
{
    public class Vertex
    {
        private readonly float x0;
        private readonly float y0;
        private readonly float z0;

        public float X;
        public float Y;
        public float Z;

        public Vertex(float x, float y, float z)
        {
            x0 = x;
            y0 = y;
            z0 = z;
        }

        public Vector4 Vector => new(X, Y, Z, 1);
        public Vector4 TransformedNormal { get; set; }
        public Vector4 Normal { get; set; }

        public void Reset()
        {
            X = x0;
            Y = y0;
            Z = z0;
        }

        public void Transform(Matrix4x4 matrix, bool useNormals)
        {
            var transformed = matrix.Multiply(new Vector4(X, Y, Z, 1));

            transformed *= 1 / transformed.W;
            X = transformed.X;
            Y = transformed.Y;
            Z = transformed.Z;

            if (useNormals)
            {
                Matrix4x4.Invert(matrix, out matrix);
                var transposed = Matrix4x4.Transpose(matrix);
                var pNormal = transposed.Multiply(Normal);
                TransformedNormal = Vector4.Normalize(pNormal);
            }
        }
    }
}

