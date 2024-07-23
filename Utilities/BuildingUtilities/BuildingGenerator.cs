using Debugland;
using TowninatorCLI.Model;
using TowninatorCLI.Utilities.Lists.Buildings;
using TowninatorCLI.Utilities.misc;
using TowninatorCLI.Repositories;
using TowninatorCLI.Model.MapModels;

namespace TowninatorCLI.Utilities.BuildingUtilities
{
    public class BuildingGenerator(string dbFileName, bool debug = false)
    {
        private readonly TownRepository? _townRep = new(dbFileName);
        private readonly MapRepository? _mapRepository = new(dbFileName);
        private readonly BuildingRepository? _buildingRepository = new(dbFileName);
        private readonly Random _random = new();

        public void GenerateBuilding()
        {
            #region Debugging

            Debugger.MethodInitiated($"{nameof(GenerateBuilding)}");

            #endregion

            var town = _townRep?.GetLatestTown();

            #region Debugging

            Debugger.Variable("town", $"{town}");

            #endregion

            if (town == null)
            {
                throw new Exception("No town data available.");
            }

            var mapPosition = _mapRepository?.GetTownPosition();

            #region Debugging

            Debugger.Variable("mapPosition", $"{mapPosition}");

            #endregion

            if (mapPosition == null)
            {
                throw new Exception("No map position data available.");
            }

            var terrain = mapPosition.Terrain;
            Console.WriteLine($" Terrain: {terrain}");
            var culture = town.Culture;
            var education = town.Education;
            var crime = town.Crime;
            var worship = town.Worship;
            var health = town.Health;
            var military = town.Military;
            var order = town.Order;
            var production = town.Production;
            var trade = town.Trade;
            var recreation = town.Recreation;
            var wealth = town.Wealth;
            var potentialCultureBuildings = Buildings.CultureBuildings();
            var potentialEducationBuildings = Buildings.EducationBuildings();
            var potentialRecreationBuildings = Buildings.RecreationBuildings();
            var potentialHealthBuildings = Buildings.HealthBuildings();
            var potentialMilitaryBuildings = Buildings.MilitaryBuildings();
            var potentialOrderBuildings = Buildings.OrderBuildings();
            var potentialProductionBuildings = Buildings.ProductionBuildings();
            var potentialTradeBuildings = Buildings.TradeBuildings();
            var potentialWealthBuildings = Buildings.WealthBuildings();
            

            
            var availableBuildingSlotsForCulture = (int)Math.Floor(culture / 2f);
            var availableBuildingSlotsForRecreation = (int)Math.Floor(recreation / 2f);
            var availableBuildingSlotsForEducation = (int)Math.Floor(education / 2f);
            var availableBuildingSlotsForHealth = (int)Math.Floor(health / 2f);
            var availableBuildingSlotsForMilitary = (int)Math.Floor(military / 2f);
            var availableBuildingSlotsForOrder = (int)Math.Floor(order / 2f);
            var availableBuildingSlotsForProduction = (int)Math.Floor(production / 2f);
            var availableBuildingSlotsForTrade = (int)Math.Floor(trade / 2f);
            var availableBuildingSlotsForWealth = (int)Math.Floor(wealth / 2f);
            
          
            potentialCultureBuildings = FilterBuildingsByTerrain(potentialCultureBuildings, terrain);
            potentialEducationBuildings = FilterBuildingsByTerrain(potentialEducationBuildings, terrain);
            potentialRecreationBuildings = FilterBuildingsByTerrain(potentialRecreationBuildings, terrain);
            potentialHealthBuildings = FilterBuildingsByTerrain(potentialHealthBuildings, terrain);
            potentialMilitaryBuildings = FilterBuildingsByTerrain(potentialMilitaryBuildings, terrain);
            potentialOrderBuildings = FilterBuildingsByTerrain(potentialOrderBuildings, terrain);
            potentialProductionBuildings = FilterBuildingsByTerrain(potentialProductionBuildings, terrain);
            potentialTradeBuildings = FilterBuildingsByTerrain(potentialTradeBuildings, terrain);
            potentialWealthBuildings = FilterBuildingsByTerrain(potentialWealthBuildings, terrain);
           
             
            for (var i = 0; i < availableBuildingSlotsForCulture; i++)
            {
                var building = SelectBuildingUsingLogScale(potentialCultureBuildings, terrain);
                building.Name = BuildingNameGenerator.GenerateName(building.SpecificBuilding, terrain);
                _buildingRepository?.AddBuilding(building);
            }
            for (var i = 0 ; i < availableBuildingSlotsForEducation; i++)
            {
                var building = SelectBuildingUsingLogScale(potentialEducationBuildings, terrain);
                building.Name = BuildingNameGenerator.GenerateName(building.SpecificBuilding, terrain);
                _buildingRepository?.AddBuilding(building);
            }
            for (var i = 0; i < availableBuildingSlotsForRecreation; i++)
            {
                var building = SelectBuildingUsingLogScale(potentialRecreationBuildings, terrain);
                building.Name = BuildingNameGenerator.GenerateName(building.SpecificBuilding, terrain);
                _buildingRepository?.AddBuilding(building);
            }
            for (var i = 0; i < availableBuildingSlotsForHealth; i++)
            {
                var building = SelectBuildingUsingLogScale(potentialHealthBuildings, terrain);
                building.Name = BuildingNameGenerator.GenerateName(building.SpecificBuilding, terrain);
                _buildingRepository?.AddBuilding(building);
            }
            for (var i = 0; i < availableBuildingSlotsForMilitary; i++)
            {
                var building = SelectBuildingUsingLogScale(potentialMilitaryBuildings, terrain);
                building.Name = BuildingNameGenerator.GenerateName(building.SpecificBuilding, terrain);
                _buildingRepository?.AddBuilding(building);
            }
            for (var i = 0; i < availableBuildingSlotsForOrder; i++)
            {
                var building = SelectBuildingUsingLogScale(potentialOrderBuildings, terrain);
                building.Name = BuildingNameGenerator.GenerateName(building.SpecificBuilding, terrain);
                _buildingRepository?.AddBuilding(building);
            }
            for (var i = 0; i < availableBuildingSlotsForProduction; i++)
            {
                var building = SelectBuildingUsingLogScale(potentialProductionBuildings, terrain);
                building.Name = BuildingNameGenerator.GenerateName(building.SpecificBuilding, terrain);
                _buildingRepository?.AddBuilding(building);
            }
            for (var i = 0; i < availableBuildingSlotsForTrade; i++)
            {
                var building = SelectBuildingUsingLogScale(potentialTradeBuildings, terrain);
                building.Name = BuildingNameGenerator.GenerateName(building.SpecificBuilding, terrain);
                _buildingRepository?.AddBuilding(building);
            }
            for (var i = 0; i < availableBuildingSlotsForWealth; i++)
            {
                var building = SelectBuildingUsingLogScale(potentialWealthBuildings, terrain);
                building.Name = BuildingNameGenerator.GenerateName(building.SpecificBuilding, terrain);
                _buildingRepository?.AddBuilding(building);
            }
            
            
        }

        private static List<Building> FilterBuildingsByTerrain(List<Building> buildings, MainTerrainType terrain)
        {
            return terrain switch
            {
                MainTerrainType.Coastal => buildings.Where(x => x.CoastalModifier != 0.0f).ToList(),
                MainTerrainType.LowMountain => buildings.Where(x => x.LowMountainModifier != 0.0f).ToList(),
                MainTerrainType.Forest => buildings.Where(x => x.ForestModifier != 0.0f).ToList(),
                MainTerrainType.Meadow => buildings.Where(x => x.MeadowModifier != 0.0f).ToList(),
                MainTerrainType.Fjord => buildings.Where(x => x.FjordModifier != 0.0f).ToList(),
                MainTerrainType.Grassland => buildings.Where(x => x.GrasslandModifier != 0.0f).ToList(),
                MainTerrainType.Heath => buildings.Where(x => x.HeathModifier != 0.0f).ToList(),
                MainTerrainType.Highland => buildings.Where(x => x.HighlandModifier != 0.0f).ToList(),
                MainTerrainType.Lake => buildings.Where(x => x.LakeModifier != 0.0f).ToList(),
                MainTerrainType.Marsh => buildings.Where(x => x.MarshModifier != 0.0f).ToList(),
                MainTerrainType.MediumMountain => buildings.Where(x => x.MediumMountainModifier != 0.0f).ToList(),
                MainTerrainType.HighMountain => buildings.Where(x => x.HighMountainModifier != 0.0f).ToList(),
                MainTerrainType.Tundra => buildings.Where(x => x.TundraModifier != 0.0f).ToList(),
                MainTerrainType.Wetland => buildings.Where(x => x.WetlandModifier != 0.0f).ToList(),
                MainTerrainType.None => throw new Exception("No terrain type available."),
                _ => throw new ArgumentOutOfRangeException(nameof(terrain), terrain, null)
            };
        } 
       private Building SelectBuildingUsingLogScale(List<Building> buildings, MainTerrainType terrain)
        {
            var logScaledBuildings = buildings.ToDictionary(
                b => b, 
                b => Math.Log(GetTerrainModifier(b, terrain) + 1)
            );

            var sum = logScaledBuildings.Values.Sum();
            var probabilities = logScaledBuildings.ToDictionary(
                kvp => kvp.Key, 
                kvp => kvp.Value / sum
            );

            var rand = _random.NextDouble();
            var cumulative = 0.0;

            foreach (var kvp in probabilities)
            {
                cumulative += kvp.Value;
                if (rand < cumulative)
                {
                    return kvp.Key;
                }
            }

            throw new Exception("Failed to select a building using log scale.");
        }

        private static float GetTerrainModifier(Building building, MainTerrainType terrain)
        {
            return terrain switch
            {
                MainTerrainType.Coastal => building.CoastalModifier,
                MainTerrainType.LowMountain => building.LowMountainModifier,
                MainTerrainType.Forest => building.ForestModifier,
                MainTerrainType.Meadow => building.MeadowModifier,
                MainTerrainType.Fjord => building.FjordModifier,
                MainTerrainType.Grassland => building.GrasslandModifier,
                MainTerrainType.Heath => building.HeathModifier,
                MainTerrainType.Highland => building.HighlandModifier,
                MainTerrainType.Lake => building.LakeModifier,
                MainTerrainType.Marsh => building.MarshModifier,
                MainTerrainType.MediumMountain => building.MediumMountainModifier,
                MainTerrainType.HighMountain => building.HighMountainModifier,
                MainTerrainType.Tundra => building.TundraModifier,
                MainTerrainType.Wetland => building.WetlandModifier,
                MainTerrainType.None => throw new Exception("No terrain type available."),
                _ => throw new ArgumentOutOfRangeException(nameof(terrain), terrain, null)
            };
        }
    } 
}