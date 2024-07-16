using TowninatorCLI.Controller;
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
                < 0.2f => MainTerrainType.Ocean,
                < 0.25f => MainTerrainType.Swamp,
                < 0.35f => MainTerrainType.Grassland,
                < 0.45f => MainTerrainType.Hill,
                < 0.55f => MainTerrainType.Forest,
                < 0.65f => MainTerrainType.Grassland,
                < 0.9f => MainTerrainType.LowMountain,
                < 0.95f => MainTerrainType.MediumMountain,
                < 0.97f => MainTerrainType.HighMountain,
                _ => MainTerrainType.Grassland
            };
        }

        public static string GetTownDescriptionBasedOnTerrain(MainTerrainType terrain)
        {
            var townHighMountain = new TownHighMountain();
            var townMediumMountain = new TownMediumMountain();
            var townLowMountain = new TownLowMountain();
            var townOcean = new TownOcean();
            var townSwamp = new TownSwamp();
            var townHill = new TownHill();
            return terrain switch
            {
                MainTerrainType.HighMountain => TownHighMountain.DescriptionGenerator(),
                MainTerrainType.MediumMountain => TownMediumMountain.DescriptionGenerator(),
                MainTerrainType.LowMountain => TownLowMountain.DescriptionGenerator(),
                MainTerrainType.Forest => TownForest.DescriptionGenerator(),
                MainTerrainType.Ocean => TownOcean.DescriptionGenerator(),
                MainTerrainType.Grassland => TownGrassland.DescriptionGenerator(),
                MainTerrainType.Swamp => TownSwamp.DescriptionGenerator(),
                MainTerrainType.Hill => TownHill.DescriptionGenerator(),
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

