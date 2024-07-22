using TowninatorCLI.Controller;
using TowninatorCLI.Model.MapModels;
using TowninatorCLI.Repositories;
using TowninatorCLI.Utilities.Lists;
using TowninatorCLI.Utilities.misc;
using TowninatorCLI.Utilities.Maths;

namespace TowninatorCLI.Utilities.MapUtilities
{
    public class MapUtilities(string dbFileName, bool debug = false)
    {
        private readonly Random _random = new Random();
        private readonly SmoothMap _smoothMap = new SmoothMap();
        private readonly NoiseMap _noiseMap = new(debug);
        private MapRepository? _mapRepository = new(dbFileName);

        public Map GenerateMap(int townX, int townY, int width, int height)
        {
            if (debug) Debugging.WriteNColor($"[] MapUtilities.GenerateMap(townX {townX}, townY {townY}, width {width}, height {height})", ConsoleColor.Green);

            var map = new Map(width, height);
            var mapTiles = map.GetTiles();

            var noiseMap = _noiseMap.GenerateNoiseMap(width, height, 0.3f, 5);

            // Initialize the map with initial noise-based terrain types
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var terrain = GetTerrainFromNoiseValue(noiseMap[x, y]);
                    mapTiles[x, y] = new MapTile(x, y, terrain, SecondaryTerrainType.None, null);
                }
            }

            // Smooth the map to ensure more natural transitions between terrain types
            _smoothMap.Initiate(height, width, mapTiles);
            AddTownToMap(townX, townY, mapTiles);
            // Add random events
            for (var i = 0; i < 3; i++)
            {
                var x = _random.Next(width);
                var y = _random.Next(height);
                mapTiles[x, y].Event = new MapEvent("A mysterious encounter");
            }
            return map;

        }

        private static MainTerrainType GetTerrainFromNoiseValue(float noiseValue)
        {
            return noiseValue switch
            {
                < 0.25f => MainTerrainType.Fjord,           // More fjords
                < 0.3f => MainTerrainType.Coastal,          // Coastal areas
                < 0.4f => MainTerrainType.Grassland,        // Grasslands are common
                < 0.45f => MainTerrainType.Meadow,          // Meadows are slightly less common
                < 0.47f => MainTerrainType.Marsh,           // Marshes are less common
                < 0.5f => MainTerrainType.Wetland,          // Wetlands are slightly more common than marshes
                < 0.53f => MainTerrainType.Heath,           // Heathlands are fairly common
                < 0.65f => MainTerrainType.Forest,          // Forests are very common
                < 0.7f => MainTerrainType.Tundra,           // Tundra is less common
                < 0.8f => MainTerrainType.LowMountain,      // Low mountains are less common
                < 0.9f => MainTerrainType.MediumMountain,   // Medium mountains are less common
                < 0.95f => MainTerrainType.HighMountain,    // High mountains are rare
                _ => MainTerrainType.Grassland              // Default to Grassland
            };
        }

        public static string GetTownDescriptionBasedOnTerrain(MainTerrainType terrain)
        {
          
            return terrain switch
            {
                MainTerrainType.HighMountain => TownHighMountain.DescriptionGenerator(),
                MainTerrainType.MediumMountain => TownMediumMountain.DescriptionGenerator(),
                MainTerrainType.LowMountain => TownLowMountain.DescriptionGenerator(),
                MainTerrainType.Forest => TownForest.DescriptionGenerator(),
                MainTerrainType.Fjord => TownFjord.DescriptionGenerator(),
                MainTerrainType.Grassland => TownGrassland.DescriptionGenerator(),
                MainTerrainType.Wetland => TownWetland.DescriptionGenerator(),
                MainTerrainType.Highland => TownHighLand.DescriptionGenerator(),
                MainTerrainType.Heath => TownHeath.DescriptionGenerator(),
                MainTerrainType.Coastal => TownCoastal.DescriptionGenerator(),
                MainTerrainType.Lake => TownLake.DescriptionGenerator(),
                MainTerrainType.Marsh => TownMarsh.DescriptionGenerator(),
                MainTerrainType.Tundra => TownTundra.DescriptionGenerator(),
                MainTerrainType.Meadow => TownMeadow.DescriptionGenerator(),
                
                _ => "A town in a unique terrain."
            };
        }





        public MainTerrainType GetTerrainOfAdjacentTile(Map map, Direction direction, int townX, int townY)
        {
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map), "Map is null.");
            }

            // Adjust coordinates based on direction
            int adjX = townX, adjY = townY;
            switch (direction)
            {
                case Direction.North:
                    adjY -= 1;
                    break;
                case Direction.South:
                    adjY += 1;
                    break;
                case Direction.East:
                    adjX += 1;
                    break;
                case Direction.West:
                    adjX -= 1;
                    break;
                default:
                    throw new ArgumentException($"Unsupported direction: {direction}", nameof(direction));
            }

            // Check if the adjusted coordinates are within bounds
            if (adjX < 0 || adjX >= map.Width || adjY < 0 || adjY >= map.Height)
            {
                throw new ArgumentOutOfRangeException($"Adjusted coordinates ({adjX}, {adjY}) are outside map boundaries.");
            }

            // Retrieve terrain type from the map tile
            var tile = map.GetTile(adjX, adjY);
            if (tile == null)
            {
                throw new Exception($"Tile at ({adjX}, {adjY}) not found in the map.");
            }

            return tile.Terrain;
        }


        private void AddTownToMap(int x, int y, MapTile[,] mapTiles)
        {
            var terrain = mapTiles[x, y].Terrain;
            var description = GetTownDescriptionBasedOnTerrain(terrain);

            mapTiles[x, y].HasTown = true;
            mapTiles[x, y].Description = description;
        }


        public MainTerrainType GetTerrainAt(int x, int y, int height, int width, MapTile[,] mapTiles)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            return mapTiles[x, y].Terrain;
        }

    }
}

