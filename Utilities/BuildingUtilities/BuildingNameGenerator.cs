using TowninatorCLI.Model;
using TowninatorCLI.Model.MapModels;

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
            MainTerrainType.Coastal => "fyrir",
            MainTerrainType.Forest => "viðr",
            MainTerrainType.Grassland => "græs",
            MainTerrainType.Highland => "upplönd",
            MainTerrainType.Lake => "særvar",
            MainTerrainType.Fjord => "fjǫrðr",
            MainTerrainType.Marsh => "más",
            MainTerrainType.Wetland => "myrr",
            MainTerrainType.Tundra => "gœðalauss",
            MainTerrainType.HighMountain => "bjarg",
            MainTerrainType.LowMountain => "kaldbak",
            MainTerrainType.MediumMountain => "bjarg",
            MainTerrainType.Meadow => "eng",
            _ => ""
        };
        /* None, Coastal, Fjord,
                Forest, Grassland, Heath, Highland, Lake, Marsh,
                Meadow, LowMountain, MediumMountain, HighMountain, Tundra, Wetland
                                */
        return $"{randomPrefix}{postfix}";
    }
}
               