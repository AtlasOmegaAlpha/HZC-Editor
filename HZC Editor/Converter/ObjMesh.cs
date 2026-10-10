using System.Numerics;

namespace HZC_Editor.Converter
{
    public class ObjFace
    {
        public int vertexA;
        public int vertexB;
        public int vertexC;
    }

    public class ObjGroup
    {
        public string name = "";
        public List<ObjFace> faces = new List<ObjFace>();
    }

    public class ObjMesh
    {
        public List<Vector3> positions = new List<Vector3>();
        public List<ObjGroup> groups = new List<ObjGroup>();
        public List<string> warnings = new List<string>();

        public (Vector3 minimum, Vector3 maximum) ComputeAABB()
        {
            if (this.positions.Count == 0)
                return (Vector3.Zero, Vector3.Zero);

            Vector3 minimum = new Vector3(float.MaxValue);
            Vector3 maximum = new Vector3(float.MinValue);

            foreach (Vector3 position in positions)
            {
                minimum = Vector3.Min(minimum, position);
                maximum = Vector3.Max(maximum, position);
            }

            return (minimum, maximum);
        }

        public int GetTotalFaces()
        {
            int faceCount = 0;
            foreach (ObjGroup group in groups)
            {
                faceCount += group.faces.Count;
            }

            return faceCount;
        }
    }
}
