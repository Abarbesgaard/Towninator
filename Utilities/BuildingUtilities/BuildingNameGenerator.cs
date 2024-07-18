using TowninatorCLI.Model;

namespace TowninatorCLI.Utilities.BuildingUtilities;

public static class BuildingNameGenerator
{
    public static string GenerateName(SpecificBuilding building, MainTerrainType terrain)
    {
        return building switch
        {
            SpecificBuilding.Alehouse => AlehouseName(terrain),
            SpecificBuilding.Longhouse=> "Longhouse",
            SpecificBuilding.MeadHall => "Mead Hall",
            SpecificBuilding.FishermansHut => "Fisherman's Hut",
            SpecificBuilding.Shipwright => "Shipwright",
            SpecificBuilding.Wharf => "Wharf",
            _ => "The establisment has no name"
        };
    }

    private static string AlehouseName(MainTerrainType type)
    {
        var random = new Random();
        var prefix = new[] { "Bjór-ker", "Bjórr", "Öl", "Ǫl", "Ǫl-ker"};
        var randomIndex = random.Next(0, prefix.Length);
        var randomPrefix = prefix[randomIndex];
        var postfix = type switch
        {
            MainTerrainType.Desert => "sandr",
            MainTerrainType.Forest => "viðr",
            MainTerrainType.Grassland => "græs",
            MainTerrainType.Hill => "hæð",
            MainTerrainType.Jungle => "viðr",
            MainTerrainType.Ocean => "sund",
            MainTerrainType.Savannah => "gœðalauss",
            MainTerrainType.Swamp => "myrr",
            MainTerrainType.Tundra => "gœðalauss",
            MainTerrainType.HighMountain => "bjarg",
            MainTerrainType.LowMountain => "kaldbak",
            MainTerrainType.MediumMountain => "bjarg",
            _ => ""
        };
        return $"{randomPrefix}{postfix}";
    }
}
               