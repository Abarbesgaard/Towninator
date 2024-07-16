
using TowninatorCLI.Model;

namespace TowninatorCLI.Utilities.Lists.Buildings
{
    public static class Buildings
    {
        public static List<Building> GetBuildings()
        {
            return
            [
                new Building(1, "Library", null, BuildingType.Education, SpecificBuilding.Library, 3, 1, null),
                new Building(2, "School", null, BuildingType.Education, SpecificBuilding.School, 5, 1, null),
                new Building(3, "Museum", null, BuildingType.Culture, SpecificBuilding.Museum, 4, 1, null),
                new Building(4, "Theater", null, BuildingType.Culture, SpecificBuilding.Theater, 2, 1, null),
                new Building(5, "Clinic", null, BuildingType.Health, SpecificBuilding.Clinic, 3, 1, null),
                new Building(6, "Harbor", null, BuildingType.Trade, SpecificBuilding.Harbor, 5, 1, null)
                // Add more buildings as needed
            ];
        }
    }
}

