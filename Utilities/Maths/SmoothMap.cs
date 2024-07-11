namespace TowninatorCLI
{
    public class SmoothMap
    {
        public void initiate(int Height, int Width, MapTile[,] _mapTiles)
        {
            for (int y = 1; y < Height - 1; y++)
            {
                for (int x = 1; x < Width - 1; x++)
                {
                    MainTerrainType? terrain = _mapTiles[x, y].Terrain;
                    Dictionary<MainTerrainType?, int> neighborTerrainCounts = new Dictionary<MainTerrainType?, int>(EqualityComparer<MainTerrainType?>.Default);

                    // Count the types of neighboring terrains
                    for (int ny = y - 1; ny <= y + 1; ny++)
                    {
                        for (int nx = x - 1; nx <= x + 1; nx++)
                        {
                            if (nx == x && ny == y) continue;

                            MainTerrainType? neighborTerrain = _mapTiles[nx, ny].Terrain;
                            if (!neighborTerrainCounts.ContainsKey(neighborTerrain))
                            {
                                neighborTerrainCounts[neighborTerrain] = 0;
                            }
                            neighborTerrainCounts[neighborTerrain]++;
                        }
                    }

                    // Find the most common neighbor terrain type
                    MainTerrainType? mostCommonNeighborTerrain = terrain;
                    int maxCount = 0;
                    foreach (var kvp in neighborTerrainCounts)
                    {
                        if (kvp.Value > maxCount)
                        {
                            mostCommonNeighborTerrain = kvp.Key;
                            maxCount = kvp.Value;
                        }
                    }

                    // Smooth the terrain type if necessary
                    if (maxCount >= 4) // Adjust this threshold as needed
                    {
                        _mapTiles[x, y].Terrain = mostCommonNeighborTerrain;
                    }
                }
            }
        }
    }
}
