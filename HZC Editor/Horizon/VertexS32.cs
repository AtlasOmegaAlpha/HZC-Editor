using System.ComponentModel;

namespace Horizon
{
    public class VertexS32
    {
        const float FIXED_SCALE = 4096f;

        [DisplayName("X")]
        public float X { get; set; }

        [DisplayName("Y")]
        public float Y { get; set; }

        [DisplayName("Z")]
        public float Z { get; set; }

        public VertexS32() { }

        public VertexS32(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static VertexS32 FromS32(int x, int y, int z)
        {
            return new VertexS32(x / FIXED_SCALE, y / FIXED_SCALE, z / FIXED_SCALE);
        }

        public (int x, int y, int z) ToS32()
        {
            return ((int)MathF.Round(X * FIXED_SCALE), (int)MathF.Round(Y * FIXED_SCALE), (int)MathF.Round(Z * FIXED_SCALE));
        }

        public override string ToString()
        {
            return $"({X:F2}, {Y:F2}, {Z:F2})";
        }
    }
}
