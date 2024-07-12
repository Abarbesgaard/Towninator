namespace TowninatorCLI
{
    public class MapUtilities
    {
        private Random _random = new Random();
        private SmoothMap _smoothMap = new SmoothMap();
        NoiseMap _noiseMap = new NoiseMap();
        private MapRepository? mapRepository;
        public MapUtilities(string dbFileName)
        {
            mapRepository = new MapRepository(dbFileName);
        }
        public void GenerateMap(Map map, int townX, int townY)
        {
            Console.WriteLine($"[Method]: MapUtilities.GenerateMap. Params: townX: {townX}, townY: {townY}.");
            int width = map.Width;
            int height = map.Height;
            MapTile[,] _mapTiles = map.GetTiles();

            float[,] noiseMap = _noiseMap.GenerateNoiseMap(width, height, 0.3f, 5);

            // Initialize the map with initial noise-based terrain types
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    MainTerrainType? terrain = GetTerrainFromNoiseValue(noiseMap[x, y]);
                    _mapTiles[x, y] = new MapTile(x, y, terrain, SecondaryTerrainType.None, null);
                }
            }

            // Smooth the map to ensure more natural transitions between terrain types
            _smoothMap.initiate(height, width, _mapTiles);
            AddTownToMap(townX, townY, _mapTiles);
            // Add random events
            for (int i = 0; i < 3; i++)
            {
                int x = _random.Next(width);
                int y = _random.Next(height);
                _mapTiles[x, y].Event = new MapEvent("A mysterious encounter");
            }
        }

        private MainTerrainType? GetTerrainFromNoiseValue(float noiseValue)
        {
            if (noiseValue < 0.2f)
                return MainTerrainType.Ocean;
            else if (noiseValue < 0.25f)
                return MainTerrainType.Swamp;
            else if (noiseValue < 0.35f)
                return MainTerrainType.Grassland;
            else if (noiseValue < 0.45f)
                return MainTerrainType.Hill;
            else if (noiseValue < 0.55f)
                return MainTerrainType.Forest;
            else if (noiseValue < 0.65f)
                return MainTerrainType.Grassland;
            else if (noiseValue < 0.9f)
                return MainTerrainType.LowMountain;
            else if (noiseValue < 0.95f)
                return MainTerrainType.MediumMountain;
            else if (noiseValue < 0.97f)
                return MainTerrainType.HighMountain;
            else
                return MainTerrainType.Grassland;
        }
        public string GetTownDescriptionBasedOnTerrain(MainTerrainType? terrain)
        {
            Town_Highmountain town_Highmountain = new Town_Highmountain();
            Town_MediumMountain town_MediumMountain = new Town_MediumMountain();
            Town_LowMountain town_Lowmountain = new Town_LowMountain();
            Town_Forest town_Forest = new Town_Forest();
            Town_Ocean town_Ocean = new Town_Ocean();
            Town_Grassland town_Grasland = new Town_Grassland();
            Town_Swamp town_Swamp = new Town_Swamp();
            Town_Hill town_Hill = new Town_Hill();
            switch (terrain)
            {
                case MainTerrainType.HighMountain:
                    return town_Highmountain.DescriptionGenerator();
                case MainTerrainType.MediumMountain:
                    return town_MediumMountain.DescriptionGenerator();
                case MainTerrainType.LowMountain:
                    return town_Lowmountain.DescriptionGenerator();
                case MainTerrainType.Forest:
                    return town_Forest.DescriptionGenerator();
                case MainTerrainType.Ocean:
                    return town_Ocean.DescriptionGenerator();
                case MainTerrainType.Grassland:
                    return town_Grasland.DescriptionGenerator();
                case MainTerrainType.Swamp:
                    return town_Swamp.DescriptionGenerator();
                case MainTerrainType.Hill:
                    return town_Hill.DescriptionGenerator();

                default:
                    return "A town in a unique terrain.";
            }
        }


        public MainTerrainType? GetTerrainOfAdjacentTile(Map map, Direction direction)
        {
            if (map == null)
            {
                throw new ArgumentNullException("Map is null.");
            }

            if (mapRepository == null)
            {
                throw new ArgumentNullException("Map repository is null.");
            }

            // Retrieve town coordinates from the repository
            var townPosition = mapRepository.GetTownPosition();
            if (townPosition == null)
            {
                throw new Exception("Town position not found in repository.");
            }


            if (townPosition == null)
            {
                throw new Exception("Town position not found in repository.");
            }

            int townX = townPosition.X;
            int townY = townPosition.Y;

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
            }

            // Check if the adjusted coordinates are within bounds
            if (adjX < 0 || adjX >= map.Width || adjY < 0 || adjY >= map.Height)
            {
                throw new ArgumentOutOfRangeException("Direction leads to a tile outside the map boundaries.");
            }

            // Retrieve terrain type from the map
            MainTerrainType? terrain = map._mapTiles[adjX, adjY]?.Terrain;

            return terrain;
        }


        public void AddTownToMap(int x, int y, MapTile[,] _mapTiles)
        {
            Console.WriteLine($"[Method]: MapUtilities.AddTownToMap. Params: x: {x}, y: {y}.");
            MainTerrainType? terrain = _mapTiles[x, y].Terrain;
            string description = GetTownDescriptionBasedOnTerrain(terrain);

            _mapTiles[x, y].HasTown = true;
            _mapTiles[x, y].Description = description;
        }


        public MainTerrainType? GetTerrainAt(int x, int y, int height, int width, MapTile[,] _mapTiles)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                throw new ArgumentOutOfRangeException("Coordinates are out of map bounds.");
            }

            return _mapTiles[x, y].Terrain;
        }

    }
}

