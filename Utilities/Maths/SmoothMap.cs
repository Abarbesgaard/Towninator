namespace TowninatorCLI.Utilities.Maths
{
    public class SmoothMap
    {
        public void Initiate(int height, int width, MapTile[,] mapTiles)
        {
            for (var y = 1; y < height - 1; y++)
            {
                for (var x = 1; x < width - 1; x++)
                {
                    var terrain = mapTiles[x, y].Terrain;
                    var neighborTerrainCounts = new Dictionary<MainTerrainType, int>(EqualityComparer<MainTerrainType>.Default);

                    // Count the types of neighboring terrains
                    for (var ny = y - 1; ny <= y + 1; ny++)
                    {
                        for (var nx = x - 1; nx <= x + 1; nx++)
                        {
                            if (nx == x && ny == y) continue;

                            var neighborTerrain = mapTiles[nx, ny].Terrain;
                            if (!neighborTerrainCounts.TryGetValue(neighborTerrain, out var value))
                            {
                                value = 0;
                                neighborTerrainCounts[neighborTerrain] = value;
                            }
                            neighborTerrainCounts[neighborTerrain] = ++value;
                        }
                    }

                    // Find the most common neighbor terrain type
                    var mostCommonNeighborTerrain = terrain;
                    var maxCount = 0;
                    foreach (var kvp in neighborTerrainCounts.Where(kvp => kvp.Value > maxCount))
                    {
                        mostCommonNeighborTerrain = kvp.Key;
                        maxCount = kvp.Value;
                    }

                    // Smooth the terrain type if necessary
                    if (maxCount >= 4) // Adjust this threshold as needed
                    {
                        mapTiles[x, y].Terrain = mostCommonNeighborTerrain;
                    }
                }
            }
        }
    }
}
