using Horizon;
using System.Globalization;
using System.Numerics;

namespace HZC_Editor.Converter
{
    public static class ObjImporter
    {
        public static ObjMesh Load(string path)
        {
            ObjMesh mesh = new ObjMesh();
            Dictionary<string, ObjGroup?> groups = new Dictionary<string, ObjGroup?>(StringComparer.OrdinalIgnoreCase);
            ObjGroup? currentGroup = GetOrCreateGroup(mesh, groups, HZC.DEFAULT_COLLISION_NAME);
            int lineCount = 0;

            foreach (string line in File.ReadLines(path))
            {
                lineCount++;
                string tLine = line.Trim();
                if (tLine.Length == 0 || tLine[0] == '#')
                    continue;

                string[] type = tLine.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
                if (type.Length == 0)
                    continue;

                switch (type[0])
                {
                    case "v":
                        if (type.Length >= 4 && ParseFloat(type[1], out float valueX) && ParseFloat(type[2], out float valueY) && ParseFloat(type[3], out float valueZ))
                            mesh.positions.Add(new Vector3(valueX, valueY, valueZ));
                        else
                            mesh.warnings.Add($"Line {lineCount}: could not parse vertex \"{tLine}\" (skipped)");
                        break;

                    case "g":
                    case "o":
                    case "usemtl":
                        string name = type.Length >= 2 ? string.Join(" ", type, 1, type.Length - 1) : HZC.DEFAULT_COLLISION_NAME;
                        currentGroup = GetOrCreateGroup(mesh, groups, name);
                        break;

                    case "f":
                        List<int> indices = new List<int>();
                        for (int i = 1; i < type.Length; i++)
                        {
                            string part = type[i].Split('/')[0];
                            if (!int.TryParse(part, NumberStyles.Integer, CultureInfo.InvariantCulture, out int rIdx))
                                continue;

                            int idx = rIdx > 0 ? rIdx - 1 : mesh.positions.Count + rIdx;
                            if (idx >= 0 && idx < mesh.positions.Count)
                                indices.Add(idx);
                        }

                        if (indices.Count < 3)
                        {
                            mesh.warnings.Add($"Line {lineCount}: face has less than 3 vertices (skipped)");
                            break;
                        }

                        // triangulate if not a triangle
                        for (int i = 1; i < indices.Count - 1; i++)
                        {
                            currentGroup.faces.Add(new ObjFace
                            {
                                vertexA = indices[0],
                                vertexB = indices[i],
                                vertexC = indices[i + 1]
                            });
                        }
                        break;
                }
            }

            mesh.groups.RemoveAll(g => g.faces.Count == 0);
            return mesh;
        }

        static ObjGroup? GetOrCreateGroup(ObjMesh mesh, Dictionary<string, ObjGroup?> groups, string name)
        {
            if (groups.TryGetValue(name, out ObjGroup? currentGroup))
                return currentGroup;

            ObjGroup group = new ObjGroup
            {
                name = name
            };

            groups[name] = group;
            mesh.groups.Add(group);
            return group;
        }

        static bool ParseFloat(string s, out float value)
        {
            return float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }
    }
}
