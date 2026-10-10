using Horizon;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace HZC_Editor.Converter
{
    public static class ObjExporter
    {
        public static void Export(HZC hzc, string path)
        {
            using StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.ASCII);
            writer.WriteLine($"# Exported from HZC Editor v{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion}");
            writer.WriteLine();

            foreach (VertexS32 vertex in hzc.Vertices)
            {
                writer.WriteLine($"v {GetFloat6(vertex.X)} {GetFloat6(vertex.Y)} {GetFloat6(vertex.Z)}");
            }

            writer.WriteLine();

            Dictionary<string, List<ColTriangle>> triangles = new Dictionary<string, List<ColTriangle>>();
            List<string> orderedNames = new List<string>();

            foreach (ColTriangle triangle in hzc.Triangles)
            {
                string colName = HZC.DEFAULT_COLLISION_NAME;
                if (triangle.AttributeIndex >= 0 && triangle.AttributeIndex < hzc.Attributes.Count)
                    colName = SanitizeGroupName(hzc.Attributes[triangle.AttributeIndex].Key);

                if (!triangles.TryGetValue(colName, out List<ColTriangle>? newTriangles))
                {
                    newTriangles = new List<ColTriangle>();
                    triangles[colName] = newTriangles;
                    orderedNames.Add(colName);
                }

                newTriangles.Add(triangle);
            }

            foreach (string colName in orderedNames)
            {
                writer.WriteLine($"g {colName}");
                foreach (ColTriangle triangle in triangles[colName])
                {
                    writer.WriteLine($"f {triangle.V0 + 1} {triangle.V1 + 1} {triangle.V2 + 1}");
                }

                writer.WriteLine();
            }
        }

        static string GetFloat6(float value)
        {
            return value.ToString("F6", CultureInfo.InvariantCulture);
        }

        static string SanitizeGroupName(string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return HZC.DEFAULT_COLLISION_NAME;

            return s.Replace(' ', '_');
        }
    }
}
