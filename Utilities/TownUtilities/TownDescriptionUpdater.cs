using TowninatorCLI.Controller;
using TowninatorCLI.Repositories;
using TowninatorCLI.Utilities.Lists.Adjacent_To_Town_Descriptions;
using TowninatorCLI.Model;
using TowninatorCLI.Model.MapModels;
namespace TowninatorCLI.Utilities.TownUtilities
{
    public class TownDescriptionUpdater(string dbFileName)
    {
        private readonly MapRepository _mapRepository = new(dbFileName);
        private readonly TownRepository _townRepository = new(dbFileName);


        public void UpdateTownDescriptions(Town town)
        {
            try
            {

                // Fetch map using townId
                var map = _mapRepository.GetMapByTownId(town.Id);

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
                var townTerrain = _mapRepository.GetTerrainAtCoordinate(map.Id, townMapTile.X, townMapTile.Y);

                // Update town descriptions based on terrain
                town.MainDescription = MapUtilities.MapUtilities.GetTownDescriptionBasedOnTerrain(townTerrain);

                // Get adjacent terrains
                var northTerrain = _mapRepository.GetTerrainOfAdjacentTile(map, Direction.North, townMapTile.X, townMapTile.Y);
                var southTerrain = _mapRepository.GetTerrainOfAdjacentTile(map, Direction.South, townMapTile.X, townMapTile.Y);
                var eastTerrain = _mapRepository.GetTerrainOfAdjacentTile(map, Direction.East, townMapTile.X, townMapTile.Y);
                var westTerrain = _mapRepository.GetTerrainOfAdjacentTile(map, Direction.West, townMapTile.X, townMapTile.Y);

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

            return direction switch
            {
                Direction.North =>
                    // Implement logic to get description north of town
                    $"North of town: {AddTerrainDescription(terrain)}",
                Direction.South =>
                    // Implement logic to get description south of town
                    $"South of town: {AddTerrainDescription(terrain)}",
                Direction.East =>
                    // Implement logic to get description east of town
                    $"East of town: {AddTerrainDescription(terrain)}",
                Direction.West =>
                    // Implement logic to get description west of town
                    $"West of town: {AddTerrainDescription(terrain)}",
                _ => throw new ArgumentException($"Unsupported direction: {direction}")
            };
        }
        private static string AddTerrainDescription(MainTerrainType? terrain)
        {
            return terrain switch
            {
                MainTerrainType.HighMountain => AdjHighMountain.DescriptionGenerator(),
                MainTerrainType.MediumMountain => AdjMediumMountain.DescriptionGenerator(),
                MainTerrainType.LowMountain => AdjLowMountain.DescriptionGenerator(),
                MainTerrainType.Forest => AdjForest.DescriptionGenerator(),
                MainTerrainType.Fjord => AdjFjord.DescriptionGenerator(),
                MainTerrainType.Grassland => AdjGrassland.DescriptionGenerator(),
                MainTerrainType.Wetland => AdjWetLand.DescriptionGenerator(),
                MainTerrainType.Highland => AdjHighLand.DescriptionGenerator(), 
                MainTerrainType.Coastal => AdjCoastal.DescriptionGenerator(),
                MainTerrainType.Lake => AdjLake.DescriptionGenerator(),
                MainTerrainType.Marsh => AdjMarsh.DescriptionGenerator(),
                MainTerrainType.Tundra => AdjTundra.DescriptionGenerator(),
                MainTerrainType.Meadow => AdjMeadow.DescriptionGenerator(),
                MainTerrainType.Heath => AdjHeath.DescriptionGenerator(),
                _ => "Unknown terrain"
            };
        }
    }
}
