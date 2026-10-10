using System.ComponentModel;

namespace Horizon
{
    public class ColTriangle
    {
        const float EPSILON = 1e-8f;

        [Browsable(false)]
        public HZC? Hzc { get; set; }

        [Category("Indices")]
        [DisplayName("Vertex 0 Index")]
        public int V0 { get; set; }

        [Category("Indices")]
        [DisplayName("Vertex 1 Index")]
        public int V1 { get; set; }

        [Category("Indices")]
        [DisplayName("Vertex 2 Index")]
        public int V2 { get; set; }

        [Category("Normal")]
        [DisplayName("X")]
        public float NormalX { get; set; }

        [Category("Normal")]
        [DisplayName("Y")]
        public float NormalY { get; set; }

        [Category("Normal")]
        [DisplayName("Z")]
        public float NormalZ { get; set; }

        [Category("Attribute")]
        [DisplayName("Custom Attribute")]
        [TypeConverter(typeof(HzcColAttributeIndexConverter))]
        public int AttributeIndex { get; set; } = -1;

        [Category("Grid")]
        [DisplayName("Grid Cell Count")]
        [ReadOnly(true)]
        public int GridCellCount { get; set; }

        public ColTriangle() { }

        public ColTriangle(int v0, int v1, int v2)
        {
            V0 = v0;
            V1 = v1;
            V2 = v2;
        }

        public void ComputeNormal(HZC hzc)
        {
            if (V0 < 0 || V0 >= hzc.Vertices.Count || V1 < 0 || V1 >= hzc.Vertices.Count || V2 < 0 || V2 >= hzc.Vertices.Count)
                return;

            VertexS32 vertexA = hzc.Vertices[V0], vertexB = hzc.Vertices[V1], vertexC = hzc.Vertices[V2];
            float edge1X = vertexB.X - vertexA.X, edge1Y = vertexB.Y - vertexA.Y, edge1Z = vertexB.Z - vertexA.Z;
            float edge2X = vertexC.X - vertexA.X, edge2Y = vertexC.Y - vertexA.Y, edge2Z = vertexC.Z - vertexA.Z;

            float normalX = edge1Y * edge2Z - edge1Z * edge2Y;
            float normalY = edge1Z * edge2X - edge1X * edge2Z;
            float normalZ = edge1X * edge2Y - edge1Y * edge2X;

            float length = MathF.Sqrt(normalX * normalX + normalY * normalY + normalZ * normalZ);
            if (length < EPSILON)
                return;

            NormalX = normalX / length;
            NormalY = normalY / length;
            NormalZ = normalZ / length;
        }

        public override string ToString()
        {
            return $"({V0}, {V1}, {V2})";
        }
    }
}
