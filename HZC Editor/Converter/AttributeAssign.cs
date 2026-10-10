using Horizon;

namespace HZC_Editor.Converter
{
    public static class AttributeAssign
    {
        public static Dictionary<int, string?> GetAttributes(ObjMesh mesh, IReadOnlyList<ColAttribute> currentAttributes)
        {
            Dictionary<int, string?> result = new Dictionary<int, string?>();

            for (int i = 0; i < mesh.groups.Count; i++)
            {
                string name = mesh.groups[i].name;

                if (string.IsNullOrWhiteSpace(name) || string.Equals(name, HZC.DEFAULT_COLLISION_NAME, StringComparison.OrdinalIgnoreCase))
                {
                    result[i] = null;
                    continue;
                }

                string? matchKey = null;
                foreach (ColAttribute attribute in currentAttributes)
                {
                    if (!string.Equals(attribute.Key, name, StringComparison.OrdinalIgnoreCase))
                        continue;

                    matchKey = attribute.Key;
                    break;
                }

                result[i] = matchKey ?? name;
            }

            return result;
        }
    }
}
