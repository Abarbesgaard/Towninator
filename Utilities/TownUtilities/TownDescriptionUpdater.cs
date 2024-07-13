namespace TowninatorCLI
{
    public class TownDescriptionUpdater
    {
        private readonly MapUtilities _mapUtilities;
        private readonly MapRepository _mapRepository;
        private readonly MapController _mapController;
        private readonly TownRepository _townRepository;
        public TownDescriptionUpdater(string dbFileName)
        {
            _mapUtilities = new MapUtilities(dbFileName);
            _mapRepository = new MapRepository(dbFileName);
            _mapController = new MapController(dbFileName);
            _townRepository = new TownRepository(dbFileName);

        }





        public void UpdateTownDescriptions(Town town)
        {
            try
            {

                // Fetch map using townId
                Map map = _mapRepository.GetMapByTownId(town.Id);

                if (map == null)
                {
                    throw new Exception($"Map not found for TownId {town.Id}.");
                }

                // Fetch town's map tile position
                MapTile? townMapTile = _mapRepository.GetTownPosition();

                if (townMapTile == null)
                {
                    throw new Exception("Town position not found in the map tiles.");
                }

                // Get the terrain at the town's position
                MainTerrainType townTerrain = _mapRepository.GetTerrainAtCoordinate(map.Id, townMapTile.X, townMapTile.Y);

                // Update town descriptions based on terrain
                town.MainDescription = _mapUtilities.GetTownDescriptionBasedOnTerrain(townTerrain);
                // TODO : Denne kommer med forkerte adjacent terrains

                // Get adjacent terrains
                MainTerrainType? northTerrain = _mapRepository.GetTerrainOfAdjacentTile(map, Direction.North, townMapTile.X, townMapTile.Y);
                MainTerrainType? southTerrain = _mapRepository.GetTerrainOfAdjacentTile(map, Direction.South, townMapTile.X, townMapTile.Y);
                MainTerrainType? eastTerrain = _mapRepository.GetTerrainOfAdjacentTile(map, Direction.East, townMapTile.X, townMapTile.Y);
                MainTerrainType? westTerrain = _mapRepository.GetTerrainOfAdjacentTile(map, Direction.West, townMapTile.X, townMapTile.Y);

                // Update town descriptions based on adjacent terrains
                town.NorthDescription = GetDirectionalTownDescriptionFromTerrain(northTerrain, Direction.North);
                town.SouthDescription = GetDirectionalTownDescriptionFromTerrain(southTerrain, Direction.South);
                town.EastDescription = GetDirectionalTownDescriptionFromTerrain(eastTerrain, Direction.East);
                town.WestDescription = GetDirectionalTownDescriptionFromTerrain(westTerrain, Direction.West);

                // Update town in the database
                _townRepository.UpdateTownDescriptions(town);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating town descriptions: {ex.Message}");
                throw; // Optionally, handle or log the exception according to your needs
            }
        }
        private string GetDirectionalTownDescriptionFromTerrain(MainTerrainType? terrain, Direction direction)
        {
            // Implement your logic to get directional descriptions based on terrain and direction
            // Example logic:


            switch (direction)
            {
                case Direction.North:
                    // Implement logic to get description north of town
                    return $"North of town: {AddTerrainDescription(terrain)}";
                case Direction.South:
                    // Implement logic to get description south of town
                    return $"South of town: {AddTerrainDescription(terrain)}";
                case Direction.East:
                    // Implement logic to get description east of town
                    return $"East of town: {AddTerrainDescription(terrain)}";
                case Direction.West:
                    // Implement logic to get description west of town
                    return $"West of town: {AddTerrainDescription(terrain)}";
                default:
                    throw new ArgumentException($"Unsupported direction: {direction}");
            }
        }
        private string AddTerrainDescription(MainTerrainType? terrain)
        {
            Adj_Grassland adj_Grassland = new Adj_Grassland();
            Adj_LowMountain adj_lowMountain = new Adj_LowMountain();
            Adj_MediumMountain adj_MediumMountain = new Adj_MediumMountain();
            Adj_HighMountain adj_HighMountain = new Adj_HighMountain();
            Adj_Forest adj_Forest = new Adj_Forest();
            Adj_Ocean adj_Ocean = new Adj_Ocean();
            Adj_Swamp adj_Swamp = new Adj_Swamp();
            Adj_Hill adj_Hill = new Adj_Hill();
            switch (terrain)
            {
                case MainTerrainType.HighMountain:
                    return adj_HighMountain.DescriptionGenerator();
                case MainTerrainType.MediumMountain:
                    return adj_MediumMountain.DescriptionGenerator();
                case MainTerrainType.LowMountain:
                    return adj_lowMountain.DescriptionGenerator();
                case MainTerrainType.Forest:
                    return adj_Forest.DescriptionGenerator();
                case MainTerrainType.Ocean:
                    return adj_Ocean.DescriptionGenerator();
                case MainTerrainType.Grassland:
                    return adj_Grassland.DescriptionGenerator();
                case MainTerrainType.Swamp:
                    return adj_Swamp.DescriptionGenerator();
                case MainTerrainType.Hill:
                    return adj_Hill.DescriptionGenerator();

                default:
                    return "Unknown terrain";
            }
        }
    }
}
