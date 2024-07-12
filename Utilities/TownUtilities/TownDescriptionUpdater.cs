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
            Console.WriteLine($"[Method]: TownDescriptionUpdater.UpdateTownDescriptions. Params: townid: {town.Id}, town Name: {town.Name}");

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
                Console.WriteLine($"Town position found. X: {townMapTile.X}, Y: {townMapTile.Y}, Terrain: {townTerrain}");

                // Update town descriptions based on terrain
                town.MainDescription = _mapUtilities.GetTownDescriptionBasedOnTerrain(townTerrain);

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
                    return $"North of town: {terrain?.ToString()}";
                case Direction.South:
                    // Implement logic to get description south of town
                    return $"South of town: {terrain?.ToString()}";
                case Direction.East:
                    // Implement logic to get description east of town
                    return $"East of town: {terrain?.ToString()}";
                case Direction.West:
                    // Implement logic to get description west of town
                    return $"West of town: {terrain?.ToString()}";
                default:
                    throw new ArgumentException($"Unsupported direction: {direction}");
            }
        }
    }
}
