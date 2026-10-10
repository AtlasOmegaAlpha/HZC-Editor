using System.ComponentModel;

namespace Horizon
{
    public class ColGrid
    {
        [Browsable(false)]
        public HZC? Hzc { get; set; }

        [Category("Dimensions")]
        [DisplayName("X")]
        public int DimensionsX { get; set; } = 100;

        [Category("Dimensions")]
        [DisplayName("Y")]
        public int DimensionsY { get; set; } = 1;

        [Category("Dimensions")]
        [DisplayName("Z")]
        public int DimensionsZ { get; set; } = 100;

        [Category("Bounds")]
        [DisplayName("Origin X")]
        public float OriginX { get; set; }

        [Category("Bounds")]
        [DisplayName("Origin Y")]
        public float OriginY { get; set; }

        [Category("Bounds")]
        [DisplayName("Origin Z")]
        public float OriginZ { get; set; }

        [Category("Bounds")]
        [DisplayName("Extent X")]
        public float ExtentX { get; set; }

        [Category("Bounds")]
        [DisplayName("Extent Y")]
        public float ExtentY { get; set; }

        [Category("Bounds")]
        [DisplayName("Extent Z")]
        public float ExtentZ { get; set; }

        [Category("Info")]
        [DisplayName("Unknown (0x24)")]
        public int Unknown0x24 { get; set; }

        [Category("Info")]
        [ReadOnly(true)]
        [DisplayName("Total Cells")]
        public int TotalCells()
        {
            return DimensionsX * DimensionsY * DimensionsZ;
        }

        [Category("Info")]
        [ReadOnly(true)]
        [DisplayName("Occupied Cells")]
        public int OccupiedCells { get; set; }

        [Category("Info")]
        [ReadOnly(true)]
        [DisplayName("Link Entries")]
        public int LinkEntries { get; set; }

        public override string ToString()
        {
            return $"{DimensionsX} x {DimensionsY} x {DimensionsZ}";
        }

        public void Build(HZC hzc)
        {
            DimensionsX = Math.Max(1, DimensionsX);
            DimensionsY = Math.Max(1, DimensionsY);
            DimensionsZ = Math.Max(1, DimensionsZ);

            if (hzc.Vertices.Count == 0 || hzc.Triangles.Count == 0)
            {
                hzc.GridCells = new ushort[DimensionsX * DimensionsY * DimensionsZ];
                Array.Fill(hzc.GridCells, (ushort)0xFFFF);
                hzc.Links = [];
                return;
            }

            float minX = float.MaxValue, minY = float.MaxValue, minZ = float.MaxValue;
            float maxX = float.MinValue, maxY = float.MinValue, maxZ = float.MinValue;
            foreach (VertexS32 vertex in hzc.Vertices)
            {
                minX = Math.Min(minX, vertex.X);
                minY = Math.Min(minY, vertex.Y);
                minZ = Math.Min(minZ, vertex.Z);
                maxX = Math.Max(maxX, vertex.X);
                maxY = Math.Max(maxY, vertex.Y);
                maxZ = Math.Max(maxZ, vertex.Z);
            }

            float boundX = Math.Max(1e-3f, maxX - minX);
            float boundY = Math.Max(1e-3f, maxY - minY);
            float boundZ = Math.Max(1e-3f, maxZ - minZ);
            float cellX = boundX / DimensionsX, cellY = boundY / DimensionsY, cellZ = boundZ / DimensionsZ;
            float originX = minX - cellX * 0.5f, originY = minY - cellY * 0.5f, originZ = minZ - cellZ * 0.5f;
            float extentX = boundX + cellX, extentY = boundY + cellY, extentZ = boundZ + cellZ;
            cellX = extentX / DimensionsX; cellY = extentY / DimensionsY; cellZ = extentZ / DimensionsZ;

            OriginX = originX;
            OriginY = originY;
            OriginZ = originZ;
            ExtentX = extentX;
            ExtentY = extentY;
            ExtentZ = extentZ;

            ushort[] cells = new ushort[DimensionsX * DimensionsY * DimensionsZ];
            Array.Fill(cells, (ushort)0xFFFF);
            List<(ushort, ushort)> links = new List<(ushort, ushort)>();

            for (int i = 0; i < hzc.Triangles.Count; i++)
            {
                ColTriangle triangle = hzc.Triangles[i];
                if (!InRange(triangle.V0, hzc.Vertices.Count) || !InRange(triangle.V1, hzc.Vertices.Count) || !InRange(triangle.V2, hzc.Vertices.Count))
                    continue;

                VertexS32 vertexA = hzc.Vertices[triangle.V0], vertexB = hzc.Vertices[triangle.V1], vertexC = hzc.Vertices[triangle.V2];
                float triangleMinX = Min3(vertexA.X, vertexB.X, vertexC.X), triangleMaxX = Max3(vertexA.X, vertexB.X, vertexC.X);
                float triangleMinY = Min3(vertexA.Y, vertexB.Y, vertexC.Y), triangleMaxY = Max3(vertexA.Y, vertexB.Y, vertexC.Y);
                float triangleMinZ = Min3(vertexA.Z, vertexB.Z, vertexC.Z), triangleMaxZ = Max3(vertexA.Z, vertexB.Z, vertexC.Z);

                int cellXMin = Clamp((int)MathF.Floor((triangleMinX - originX) / cellX), 0, DimensionsX - 1);
                int cellXMax = Clamp((int)MathF.Floor((triangleMaxX - originX) / cellX), 0, DimensionsX - 1);
                int cellYMin = Clamp((int)MathF.Floor((triangleMinY - originY) / cellY), 0, DimensionsY - 1);
                int cellYMax = Clamp((int)MathF.Floor((triangleMaxY - originY) / cellY), 0, DimensionsY - 1);
                int cellZMin = Clamp((int)MathF.Floor((triangleMinZ - originZ) / cellZ), 0, DimensionsZ - 1);
                int cellZMax = Clamp((int)MathF.Floor((triangleMaxZ - originZ) / cellZ), 0, DimensionsZ - 1);

                for (int cZ = cellZMin; cZ <= cellZMax; cZ++)
                {
                    for (int cY = cellYMin; cY <= cellYMax; cY++)
                    {
                        for (int cX = cellXMin; cX <= cellXMax; cX++)
                        {
                            if (links.Count >= 0xFFFF)
                                throw new InvalidOperationException($"Grid exceeds maximum cell/triangle link limit (65535, on triangle {i})");

                            int cellIndex = GetCellIndex(cX, cY, cZ, DimensionsX, DimensionsY);
                            ushort newLinkIndex = (ushort)links.Count;
                            links.Add(((ushort)i, cells[cellIndex]));
                            cells[cellIndex] = newLinkIndex;
                        }
                    }
                }
            }

            hzc.GridCells = cells;
            hzc.Links = links.ToArray();
        }

        static bool InRange(int index, int count)
        {
            return index >= 0 && index < count;
        }

        static float Min3(float a, float b, float c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        static float Max3(float a, float b, float c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        static int Clamp(int value, int low, int high)
        {
            return value < low ? low : (value > high ? high : value);
        }

        public static int GetCellIndex(int cellX, int cellY, int cellZ, int dimX, int dimY)
        {
            return cellX + cellY * dimX + cellZ * (dimX * dimY);
        }
    }
}
