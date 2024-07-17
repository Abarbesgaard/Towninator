using TowninatorCLI.Model;

namespace TowninatorCLI.Utilities.BuildingUtilities;

public static class BuildingNameGenerator
{
    public static string GenerateName(SpecificBuilding building, MainTerrainType terrain)
    {
        return building switch
        {
            SpecificBuilding.Library => LibraryName(terrain),
            SpecificBuilding.School => "School",
            SpecificBuilding.Theater => "Theater",
            SpecificBuilding.Harbor => "Harbor",
            SpecificBuilding.Blacksmith => "Blacksmith",
            SpecificBuilding.Tavern => "Tavern",
            _ => "The establisment has no name"
        };
    }

    private static string LibraryName(MainTerrainType type)
    {
        var random = new Random();
        var prefix = new[] { "Quiet", "Tranquil", "Gentle", "Soft", "Serene", "Whispering", "Mellow", "Calm", "Subtle" };
        var randomIndex = random.Next(0, prefix.Length);
        var randomPrefix = prefix[randomIndex];
        var postfix = type switch
        {
            MainTerrainType.Desert => "Sand",
            MainTerrainType.Forest => "Lushness",
            MainTerrainType.Grassland => "Grasses",
            MainTerrainType.Hill => "Very Small Mountains",
            MainTerrainType.Jungle => "Wet Greenery",
            MainTerrainType.Ocean => "Endless Seas",
            MainTerrainType.Savannah => "Hot Sands",
            MainTerrainType.Swamp => "Foulness",
            MainTerrainType.Tundra => "Bleakness",
            MainTerrainType.HighMountain => "White Peaks",
            MainTerrainType.LowMountain => "Rocky OutCrops",
            MainTerrainType.MediumMountain => "Greys",
            _ => "Nothingness"
        };
        return $"The {randomPrefix} Library of {postfix}";
    }
}
               