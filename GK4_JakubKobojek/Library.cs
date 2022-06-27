using System.Numerics;

namespace Cpu3DEngine
{
    public static class Library
    {
        public static Vector4 Multiply(this Matrix4x4 m, Vector4 v)
        {
            Matrix4x4 m2 = m * new Matrix4x4(v.X, 0, 0, 0, v.Y, 0, 0, 0, v.Z, 0, 0, 0, v.W, 0, 0, 0);
            return new Vector4(m2.M11, m2.M21, m2.M31, m2.M41);
        }
    }
}

