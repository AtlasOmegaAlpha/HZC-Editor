using Horizon;
using System.Numerics;

namespace HZC_Editor.Converter
{
    public class GroupAssignment
    {
        public int GroupIndex { get; set; }
        public string? AttributeKey { get; set; }
    }

    public class ObjImportConfig
    {
        public ObjMesh Mesh { get; set; } = new ObjMesh();
        public List<GroupAssignment> Assignments { get; set; } = new List<GroupAssignment>();
        public List<ColAttribute> ExistingAttributes { get; set; } = new List<ColAttribute>();
        public int GridX { get; set; } = 100;
        public int GridY { get; set; } = 1;
        public int GridZ { get; set; } = 100;
    }

    public static class ObjToHzc
    {
        public static HZC Convert(ObjImportConfig config)
        {
            HZC hzc = new HZC();

            foreach (Vector3 vertex in config.Mesh.positions)
            {
                hzc.Vertices.Add(new VertexS32(vertex.X, vertex.Y, vertex.Z));
            }

            foreach (ColAttribute attribute in config.ExistingAttributes)
            {
                hzc.AddAttribute(attribute.Key, attribute.Value);
            }

            Dictionary<int, string?> groupKeys = new Dictionary<int, string?>();
            foreach (GroupAssignment assign in config.Assignments)
            {
                groupKeys[assign.GroupIndex] = assign.AttributeKey;
            }

            for (int i = 0; i < config.Mesh.groups.Count; i++)
            {
                ObjGroup group = config.Mesh.groups[i];
                groupKeys.TryGetValue(i, out string? key);
                int attributeIndex = -1;

                if (!string.IsNullOrWhiteSpace(key) && !string.Equals(key, HZC.DEFAULT_COLLISION_NAME, StringComparison.OrdinalIgnoreCase))
                {
                    attributeIndex = hzc.Attributes.FindIndex(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase));
                    if (attributeIndex < 0)
                        attributeIndex = hzc.AddAttribute(key!, "float(SurfaceType)=0.000000");
                }

                foreach (ObjFace face in group.faces)
                {
                    ColTriangle triangle = new ColTriangle(face.vertexA, face.vertexB, face.vertexC)
                    {
                        Hzc = hzc,
                        AttributeIndex = attributeIndex
                    };

                    triangle.ComputeNormal(hzc);
                    hzc.Triangles.Add(triangle);
                }
            }

            hzc.Grid.DimensionsX = Math.Max(1, config.GridX);
            hzc.Grid.DimensionsY = Math.Max(1, config.GridY);
            hzc.Grid.DimensionsZ = Math.Max(1, config.GridZ);
            hzc.RebuildGrid();

            return hzc;
        }
    }
}
