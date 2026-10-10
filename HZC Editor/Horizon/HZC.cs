using System.ComponentModel;
using System.Text;

namespace Horizon
{
    public class HZC
    {
        public const string DEFAULT_COLLISION_NAME = "default_col";
        const float FIXED_SCALE = 4096f;

        [Category("Header")]
        [DisplayName("Version Major")]
        [ReadOnly(true)]
        public byte VersionMajor { get; set; } = 1;

        [Category("Header")]
        [DisplayName("Version Minor")]
        [ReadOnly(true)]
        public byte VersionMinor { get; set; } = 3;

        [Browsable(false)]
        public List<VertexS32> Vertices { get; private set; } = new List<VertexS32>();
        public int NrVertices()
        {
            return Vertices.Count;
        }

        [Browsable(false)]
        public List<ColTriangle> Triangles { get; private set; } = new List<ColTriangle>();
        public int NrTriangles()
        {
            return Triangles.Count;
        }

        [Browsable(false)]
        public List<ColAttribute> Attributes { get; private set; } = new List<ColAttribute>();
        public int NrAttributes()
        {
            return Attributes.Count;
        }

        [Browsable(false)]
        public ColGrid Grid { get; private set; } = new ColGrid();

        [Browsable(false)]
        public ushort[] GridCells { get; set; } = [];

        [Browsable(false)]
        public (ushort TriangleIndex, ushort NextIndex)[] Links { get; set; } = [];

        public HZC()
        {
            Grid.Hzc = this;
        }

        public void Read(EndianReader reader)
        {
            VersionMinor = reader.ReadByte();
            VersionMajor = reader.ReadByte();

            if (VersionMajor > 1)
                throw new NotImplementedException($"Unsupported HZC version: {VersionMajor}.{VersionMinor}");

            if (VersionMinor > 3)
                MessageBox.Show("Warning: This HZC version might not be fully supported.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            ushort nrVertices = reader.ReadUInt16();
            ushort nrTriangles = reader.ReadUInt16();
            ushort nrAttributes = reader.ReadUInt16();

            Vertices = new List<VertexS32>(nrVertices);
            for (int i = 0; i < nrVertices; i++)
            {
                int x = reader.ReadInt32(), y = reader.ReadInt32(), z = reader.ReadInt32();
                Vertices.Add(VertexS32.FromS32(x, y, z));
            }

            Triangles = new List<ColTriangle>(nrTriangles);
            for (int i = 0; i < nrTriangles; i++)
            {
                ColTriangle triangle = new ColTriangle(reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16())
                {
                    Hzc = this
                };

                Triangles.Add(triangle);
            }

            foreach (ColTriangle triangle in Triangles)
            {
                triangle.NormalX = reader.ReadInt32() / FIXED_SCALE;
                triangle.NormalY = reader.ReadInt32() / FIXED_SCALE;
                triangle.NormalZ = reader.ReadInt32() / FIXED_SCALE;
            }

            int nrGridCells = reader.ReadInt32();
            if (nrGridCells < 0)
                throw new InvalidOperationException("The grid's cell count must be greater than 0.");

            GridCells = new ushort[nrGridCells];
            for (int i = 0; i < nrGridCells; i++)
            {
                GridCells[i] = reader.ReadUInt16();
            }

            Grid.DimensionsX = reader.ReadInt32();
            Grid.DimensionsY = reader.ReadInt32();
            Grid.DimensionsZ = reader.ReadInt32();

            if (Grid.DimensionsX < 0 || Grid.DimensionsY < 0 || Grid.DimensionsZ < 0)
                throw new InvalidOperationException("The grid dimensions must be greater than 0.");

            Grid.OriginX = reader.ReadInt32() / FIXED_SCALE;
            Grid.OriginY = reader.ReadInt32() / FIXED_SCALE;
            Grid.OriginZ = reader.ReadInt32() / FIXED_SCALE;
            Grid.ExtentX = reader.ReadInt32() / FIXED_SCALE;
            Grid.ExtentY = reader.ReadInt32() / FIXED_SCALE;
            Grid.ExtentZ = reader.ReadInt32() / FIXED_SCALE;
            Grid.Unknown0x24 = reader.ReadInt32();

            int nrLinks = reader.ReadInt32();
            if (nrLinks < 0)
                throw new InvalidOperationException("The linked list count must be greater than 0.");

            Links = new (ushort, ushort)[nrLinks];
            for (uint i = 0; i < nrLinks; i++)
            {
                Links[i] = (reader.ReadUInt16(), reader.ReadUInt16());
            }

            if (nrAttributes > 0)
            {
                for (int i = 0; i < nrTriangles; i++)
                {
                    ushort attribId = reader.ReadUInt16();
                    Triangles[i].AttributeIndex = attribId == 0xFFFF ? -1 : attribId;
                }
            }

            Attributes = new List<ColAttribute>(nrAttributes);
            for (int i = 0; i < nrAttributes; i++)
            {
                ushort keyLength = reader.ReadUInt16();
                string key = keyLength == 0 ? "" : reader.ReadString(keyLength, Encoding.ASCII);
                ushort valueLength = reader.ReadUInt16();
                string value = valueLength == 0 ? "" : reader.ReadString(valueLength, Encoding.ASCII);
                Attributes.Add(new ColAttribute(key, value));
            }

            ComputeGridCellCounts();
        }

        public void Write(EndianWriter writer)
        {
            if (Vertices.Count > 0xFFFF)
                throw new InvalidOperationException($"Vertex count ({Vertices.Count}) exceeds maximum allowed (65535).");

            if (Triangles.Count > 0xFFFF)
                throw new InvalidOperationException($"Triangle count ({Triangles.Count}) exceeds maximum allowed (65535).");

            if (Attributes.Count > 0xFFFF)
                throw new InvalidOperationException($"Attribute count ({Attributes.Count}) exceeds maximum allowed (65535).");

            writer.WriteByte(VersionMinor);
            writer.WriteByte(VersionMajor);
            writer.WriteUInt16((ushort)Vertices.Count);
            writer.WriteUInt16((ushort)Triangles.Count);
            writer.WriteUInt16((ushort)Attributes.Count);

            foreach (VertexS32 vertex in Vertices)
            {
                (int x, int y, int z) = vertex.ToS32();
                writer.WriteInt32(x);
                writer.WriteInt32(y);
                writer.WriteInt32(z);
            }

            foreach (ColTriangle triangle in Triangles)
            {
                writer.WriteUInt16((ushort)triangle.V0);
                writer.WriteUInt16((ushort)triangle.V1);
                writer.WriteUInt16((ushort)triangle.V2);
            }

            foreach (ColTriangle triangle in Triangles)
            {
                writer.WriteInt32((int)MathF.Round(triangle.NormalX * FIXED_SCALE));
                writer.WriteInt32((int)MathF.Round(triangle.NormalY * FIXED_SCALE));
                writer.WriteInt32((int)MathF.Round(triangle.NormalZ * FIXED_SCALE));
            }

            writer.WriteInt32(GridCells.Length);

            foreach (ushort cell in GridCells)
            {
                writer.WriteUInt16(cell);
            }

            writer.WriteInt32(Grid.DimensionsX);
            writer.WriteInt32(Grid.DimensionsY);
            writer.WriteInt32(Grid.DimensionsZ);
            writer.WriteInt32((int)MathF.Round(Grid.OriginX * FIXED_SCALE));
            writer.WriteInt32((int)MathF.Round(Grid.OriginY * FIXED_SCALE));
            writer.WriteInt32((int)MathF.Round(Grid.OriginZ * FIXED_SCALE));
            writer.WriteInt32((int)MathF.Round(Grid.ExtentX * FIXED_SCALE));
            writer.WriteInt32((int)MathF.Round(Grid.ExtentY * FIXED_SCALE));
            writer.WriteInt32((int)MathF.Round(Grid.ExtentZ * FIXED_SCALE));
            writer.WriteInt32(Grid.Unknown0x24);
            writer.WriteInt32(Links.Length);

            foreach ((ushort triangleIndex, ushort next) in Links)
            {
                writer.WriteUInt16(triangleIndex);
                writer.WriteUInt16(next);
            }

            if (Attributes.Count > 0)
            {
                foreach (ColTriangle triangle in Triangles)
                {
                    bool hasAttribute = triangle.AttributeIndex >= 0 && triangle.AttributeIndex < Attributes.Count;
                    writer.WriteUInt16(hasAttribute ? (ushort)triangle.AttributeIndex : (ushort)0xFFFF);
                }
            }

            foreach (ColAttribute attribute in Attributes)
            {
                byte[] keyBytes = Encoding.ASCII.GetBytes(attribute.Key ?? "");
                writer.WriteUInt16((ushort)keyBytes.Length);
                writer.WriteBytes(keyBytes);

                byte[] valueBytes = Encoding.ASCII.GetBytes(attribute.Value ?? "");
                writer.WriteUInt16((ushort)valueBytes.Length);
                writer.WriteBytes(valueBytes);
            }
        }

        public void RebuildGrid()
        {
            Grid.Build(this);
            ComputeGridCellCounts();
        }

        public void ComputeGridCellCounts()
        {
            foreach (ColTriangle triangle in Triangles)
            {
                triangle.GridCellCount = 0;
            }

            int occupied = 0;
            foreach (ushort cell in GridCells)
            {
                if (cell != 0xFFFF)
                    occupied++;

                ushort index = cell;
                HashSet<ushort> seen = new HashSet<ushort>();
                while (index != 0xFFFF && index < Links.Length && seen.Add(index))
                {
                    (ushort triangleIndex, ushort next) = Links[index];
                    if (triangleIndex < Triangles.Count)
                        Triangles[triangleIndex].GridCellCount++;

                    index = next;
                }
            }

            Grid.OccupiedCells = occupied;
            Grid.LinkEntries = Links.Length;
        }

        public int AddAttribute(string key, string value)
        {
            Attributes.Add(new ColAttribute(key, value));
            return Attributes.Count - 1;
        }

        public void RemoveAttribute(int index)
        {
            if (index < 0 || index >= Attributes.Count)
                return;

            Attributes.RemoveAt(index);
            foreach (ColTriangle triangle in Triangles)
            {
                if (triangle.AttributeIndex == index)
                    triangle.AttributeIndex = -1;
                else if (triangle.AttributeIndex > index)
                    triangle.AttributeIndex--;
            }
        }
    }
}
