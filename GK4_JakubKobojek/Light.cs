using System.Numerics;

namespace Cpu3DEngine
{
    public class Light
    {
        public Vector3 Position { get; set; }

        public Vector3 Direction { get; set; }

        public Vector3 TransformedPosition { get; set; }

        public Vector3 TransformedDirection { get; set; }

        public bool IsSpotlight { get; set; }

        public int P { get; set; }

        public bool Off { get; set; } = false;

        public void Transform(Matrix4x4 view)
        {
            var position = new Vector4(Position.X, Position.Y, Position.Z, 1);
            var transformedPosition = view.Multiply(position);
            TransformedPosition = new Vector3(transformedPosition.X, transformedPosition.Y, transformedPosition.Z);

            var direction = new Vector4(Direction.X, Direction.Y, Direction.Z,
                -(Direction.X * Position.X + Direction.Y * Position.Y + Direction.Z * Position.Z));

            Matrix4x4.Invert(view, out view);
            var p = Matrix4x4.Transpose(view);
            var pDirect = p.Multiply(direction);
            TransformedDirection = Vector3.Normalize(new Vector3(pDirect.X, pDirect.Y, pDirect.Z));
        }
    }
}

