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
        private readonly Random _random = new Random();

        public Building GenerateBuilding()
        {
            if (debug) Debugging.WriteNColor("[] BuildingGenerator.GenerateBuilding() ", ConsoleColor.Green);
            if (_townRep == null || _mapRepository == null)
            {
                throw new Exception("TownRepository or MapRepository is null");
            }
            var town = _townRep.GetLatestTown();
            var terrain = _mapRepository.GetTownPosition()!.Terrain;
            var culture = town.Culture;
            var education = town.Education;
            var crime = town.Order;
            var worship = town.Worship;
            var potentialBuildings = Buildings.GetBuildings();

            var filteredBuildings = FilterBuildingsByTerrain(potentialBuildings, terrain);
            filteredBuildings = FilterBuildingsByTownCharacteristics(filteredBuildings, culture, education, crime, worship);

            if (filteredBuildings.Count == 0)
            {
                return null!;
            }

            var randomBuilding = filteredBuildings[_random.Next(filteredBuildings.Count)];
            return randomBuilding;
        }
        private List<Building> FilterBuildingsByTerrain(List<Building> buildings, MainTerrainType terrain)
        {
            if (debug) Debugging.WriteNColor($"[] BuildingGenerator.FilterBuildingsByTerrain(building {buildings.Count} mainTerrain {terrain} ) ", ConsoleColor.Green);

            var filteredBuildings = new List<Building>();

            foreach (var building in buildings)
            {
                var isValid = true;

                switch (terrain)
                {
                    // Example of terrain-based filtering
                    case MainTerrainType.Ocean when building.SpecificBuilding == SpecificBuilding.Harbor:
                    case MainTerrainType.Grassland when building.SpecificBuilding != SpecificBuilding.Harbor:
                    case MainTerrainType.LowMountain when building.SpecificBuilding != SpecificBuilding.Harbor:
                        isValid = true;
                        break;
                    case MainTerrainType.None:
                    case MainTerrainType.Desert:
                    case MainTerrainType.Forest:
                    case MainTerrainType.Hill:
                    case MainTerrainType.Jungle:
                    case MainTerrainType.MediumMountain:
                    case MainTerrainType.HighMountain:
                    case MainTerrainType.Savannah:
                    case MainTerrainType.Swamp:
                    case MainTerrainType.Tundra:
                    default:
                        isValid = false;
                        break;
                }

                if (isValid)
                {
                    filteredBuildings.Add(building);
                }
            }

            return filteredBuildings;
        }

        private List<Building> FilterBuildingsByTownCharacteristics(List<Building> buildings, int culture, int education, int crime, int worship)
        {
            if (debug) Debugging.WriteNColor($"[] BuildingGenerator.FilterBuildingsByTownCharacteristics(building {buildings.Count} culture {culture} education {education} crime {crime} worship {worship} ) ", ConsoleColor.Green);
            var filteredBuildings = new List<Building>();

            foreach (var building in buildings)
            {
                var spawnChance = building.SpawnProbability;

                switch (building.BuildingType)
                {
                    case BuildingType.Culture:
                        spawnChance += culture * 2;
                        break;
                    case BuildingType.Education:
                        spawnChance += education * 2;
                        break;
                    case BuildingType.Health:
                        spawnChance -= crime * 2;
                        break;
                    case BuildingType.Worship:
                        spawnChance += worship * 2;
                        break;
                    case BuildingType.Military:
                        break;
                    case BuildingType.Order:
                        break;
                    case BuildingType.Production:
                        break;
                    case BuildingType.Recreation:
                        break;
                    case BuildingType.Trade:
                        break;
                    case BuildingType.Wealth:
                        break;

                    default:
                        return null!;
                }
                // Add more category-based logic

                if (_random.Next(1, 101) <= spawnChance)
                {
                    filteredBuildings.Add(building);
                }
            }

            return filteredBuildings;
        }
    }
}
