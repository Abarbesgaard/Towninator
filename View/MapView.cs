
namespace TowninatorCLI
{
    public class MapView
    {
        private readonly MapRepository _mapRepository;

        public MapView(MapRepository mapRepository)
        {
            _mapRepository = mapRepository;
        }
        // TODO: Needs to have the icons in the database for easy access across the application
        public void DisplayMapLegend()
        {
            Console.WriteLine("┌───────────────────────┐");
            Console.WriteLine("│       Map Legend      │");
            Console.WriteLine("├───────────────────────┤");
            Console.WriteLine("│ ~  - Desert           │");
            Console.WriteLine("│ ♣ ♠ - Forest          │");
            Console.WriteLine("│ . ⁿ - Grassland       │");
            Console.WriteLine("│ ♣ Γ - Jungle          │");
            Console.WriteLine("│ ⌂  - Low Mountain     │");
            Console.WriteLine("│ ▲  - Medium Mountain  │");
            Console.WriteLine("│ ∆  - High Mountain    │");
            Console.WriteLine("│ ≈  - Ocean            │");
            Console.WriteLine("│ S  - Savannah         │");
            Console.WriteLine("│ ⌠  - Swamp            │");
            Console.WriteLine("│ U  - Tundra           │");
            Console.WriteLine("└───────────────────────┘");
        }

        public void DisplayMap(long mapId)
        {
            try
            {
                Map map = _mapRepository.LoadMap(mapId);

                if (map == null)
                {
                    Console.WriteLine($"Map with ID {mapId} not found.");
                    return;
                }

                MapTile[,] mapTiles = map.GetTiles();

                if (mapTiles == null)
                {
                    Console.WriteLine($"No tiles found for Map ID {mapId}.");
                    return;
                }

                int width = map.Width;
                int height = map.Height;

                // Display the map
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        MapTile tile = mapTiles[x, y];

                        // Check if this tile has the same terrain type as the one to the left
                        bool sameAsLeft = (x > 0 && mapTiles[x - 1, y].Terrain == tile.Terrain);
                        // Check if this tile has the same terrain type as the one above
                        bool sameAsAbove = (y > 0 && mapTiles[x, y - 1].Terrain == tile.Terrain);

                        // Determine the symbol to display
                        string symbol = tile.ToString();

                        // If same as left or above, adjust the symbol
                        if (sameAsLeft || sameAsAbove)
                        {
                            symbol = tile.ToString();
                        }

                        Console.Write(symbol + " ");
                    }
                    Console.WriteLine(); // Move to next line after each row
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}

