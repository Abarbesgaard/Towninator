using TowninatorCLI.Model;
using TowninatorCLI.Utilities.Lists.Buildings;
using TowninatorCLI.Utilities.misc;
using TowninatorCLI.Repositories;

namespace TowninatorCLI.Utilities.BuildingUtilities
{
    public class BuildingGenerator(string dbFileName, bool debug = false)
    {
        private readonly TownRepository? _townRep = new(dbFileName);
        private readonly MapRepository? _mapRepository = new(dbFileName);
        private readonly BuildingRepository? _buildingRepository = new(dbFileName);
        private readonly Random _random = new Random();

        public void GenerateBuilding()
        {
            if (debug) Debugging.WriteNColor("[] BuildingGenerator.GenerateBuilding() ", ConsoleColor.Green);

            var town = _townRep?.GetLatestTown();
            if (town == null)
            {
                throw new Exception("No town data available.");
            }

            var mapPosition = _mapRepository?.GetTownPosition();
            if (mapPosition == null)
            {
                throw new Exception("No map position data available.");
            }

            var terrain = mapPosition.Terrain;
            var culture = town.Culture;
            var education = town.Education;
            var crime = town.Order;
            var worship = town.Worship;
            var health = town.Health;
            var military = town.Military;
            var order = town.Order;
            var production = town.Production;
            var trade = town.Trade;
            var recreation = town.Recreation;
            var wealth = town.Wealth;
            var potentialBuildings = Buildings.GetBuildings();

            if (debug)
            {
                Debugging.WriteNColor($"    Potential buildings count: {potentialBuildings.Count}", ConsoleColor.Yellow);
            }

            var filteredBuildings = FilterBuildingsByTerrain(potentialBuildings, terrain);
            if (debug)
            {
                Debugging.WriteNColor($"    Filtered buildings by terrain count: {filteredBuildings.Count}", ConsoleColor.Yellow);
            }

            filteredBuildings = FilterBuildingsByTownCharacteristics(filteredBuildings, culture, education, crime, worship, health,
                military,order,production,trade,recreation,wealth);
            if (debug)
            {
                Debugging.WriteNColor($"    Filtered buildings by characteristics count: {filteredBuildings.Count}", ConsoleColor.Yellow);
            }

            if (filteredBuildings.Count == 0)
            {
                
            }

            var randomBuilding = filteredBuildings[_random.Next(filteredBuildings.Count)];
            randomBuilding.Name = BuildingNameGenerator.GenerateName(randomBuilding.SpecificBuilding, mapPosition.Terrain);
            _buildingRepository?.AddBuilding(randomBuilding);

            if (debug)
            {
                Debugging.WriteNColor($"Added building: {randomBuilding.Name} {randomBuilding.Id}", ConsoleColor.Green);
            }
        }
       
        private List<Building> FilterBuildingsByTerrain(List<Building> buildings, MainTerrainType terrain)
        {
            if (debug) Debugging.WriteNColor($"[] BuildingGenerator.FilterBuildingsByTerrain(building {buildings.Count} mainTerrain {terrain} ) ", ConsoleColor.Green);

            var filteredBuildings = new List<Building>();

            foreach (var building in buildings)
            {
                var isValid = terrain switch
                {
                    MainTerrainType.Ocean => building.SpecificBuilding == SpecificBuilding.Harbor,
                    MainTerrainType.Grassland or MainTerrainType.LowMountain => building.SpecificBuilding !=
                        SpecificBuilding.Harbor,
                    _ => true
                };

                if (isValid)
                {
                    filteredBuildings.Add(building);
                }
                else if (debug)
                {
                    Debugging.WriteNColor($"Filtered out building {building.Name} for terrain {terrain}", ConsoleColor.Red);
                }
            }
            if (filteredBuildings.Count == 0)
            {
                // For example, return the first building in the original list as a fallback
                filteredBuildings.Add(buildings.FirstOrDefault() ?? throw new InvalidOperationException());
            }
            return filteredBuildings;
        }

        private List<Building> FilterBuildingsByTownCharacteristics(List<Building> buildings, int culture, int education, int crime, int worship, int health,
            int military, int order, int production, int trade, int recreation, int wealth)
        {
            if (debug) Debugging.WriteNColor($"[] BuildingGenerator.FilterBuildingsByTownCharacteristics(building {buildings.Count} culture {culture} education {education} crime {crime} worship {worship} ) ", ConsoleColor.Green);

            var filteredBuildings = new List<Building>();
            const int adjustedSpawnRate = 10;
            foreach (var building in buildings)
            {
                var spawnChance = building.SpawnProbability + adjustedSpawnRate; // Increase base spawn chance by 10

                // Adjust spawn chance based on town characteristics
                switch (building.BuildingType)
                {
                    case BuildingType.Culture:
                        spawnChance += culture * 2;
                        break;
                    case BuildingType.Education:
                        spawnChance += education * 2;
                        break;
                    case BuildingType.Health:
                        spawnChance -= health * 2;
                        break;
                    case BuildingType.Worship:
                        spawnChance += worship * 2;
                        break;
                    case BuildingType.Crime:
                        spawnChance += crime * 2;
                        break;
                    case BuildingType.Military:
                        spawnChance += military * 2;
                        break;
                    case BuildingType.Order:
                        spawnChance += order * 2;
                        break;
                    case BuildingType.Production:
                        spawnChance += production * 2;
                        break;
                    case BuildingType.Trade:
                        spawnChance += trade * 2;
                        break;
                    case BuildingType.Recreation:
                        spawnChance += recreation * 2;
                        break;
                    case BuildingType.Wealth:
                        spawnChance += wealth * 2;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
               

                // Ensure a minimum spawn chance to avoid filtering out all buildings
                spawnChance = Math.Max(spawnChance, 20);

                if (debug) Debugging.WriteNColor($"Building: {building.SpecificBuilding.ToString()}, Type: {building.BuildingType}, Initial SpawnChance: {building.SpawnProbability}, Adjusted SpawnChance: {spawnChance}", ConsoleColor.Yellow);

                if (_random.Next(1, 101) <= spawnChance)
                {
                    filteredBuildings.Add(building);
                }
                else if (debug)
                {
                    Debugging.WriteNColor($"Filtered out building {building.Name} with spawn chance {spawnChance}", ConsoleColor.Red);
                }
            }

            return filteredBuildings;
        }



    }
}
