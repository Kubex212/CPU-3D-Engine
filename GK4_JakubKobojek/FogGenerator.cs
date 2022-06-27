using System.Drawing;
using System.Numerics;

namespace Cpu3DEngine
{
    public class FogGenerator
    {
        public Color color;
        public float maxDistance;

        public FogGenerator(Color fogColor, float maxDistance)
        {
            color = fogColor;
            this.maxDistance = maxDistance;
        }

        public FogGenerator()
        {
            color = Color.LightGray;
            maxDistance = 10f;
        }

        public Color01 ApplyFogToColor(Color01 color, Vector3 point, Vector3 cameraPosition)
        {
            var distance = Vector3.Distance(point, cameraPosition);
            var f = (maxDistance - distance) / maxDistance;
            color.R = color.R * f + (1 - f) * this.color.R / 255;
            color.G = color.G * f + (1 - f) * this.color.G / 255;
            color.B = color.B * f + (1 - f) * this.color.B / 255;

            return color;
        }
    }
}

