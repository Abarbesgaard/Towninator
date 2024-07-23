using TowninatorCLI.Model;
using TowninatorCLI.Model.MapModels;

namespace TowninatorCLI.Utilities.BuildingUtilities;

public static class BuildingNameGenerator
{
    private static readonly Random Random = new();
   
       private static readonly Dictionary<SpecificBuilding, string[]> BuildingPrefixes = new()
       {
    { SpecificBuilding.Alehouse, ["Bjór-ker", "Bjórr", "Öl", "Ǫl", "Ǫl-ker"] },
    { SpecificBuilding.Longhouse, ["Taka", "Búa", "Að"] },
    { SpecificBuilding.MeadHall, ["Mjǫð", "Mjǫðr", "Mjǫðr-ker"] },
    { SpecificBuilding.Shipwright, ["Skip", "Stjóri", "Byggi"] },
    { SpecificBuilding.Wharf, ["Vesta", "Láta", "Sund"] },
    { SpecificBuilding.Smithy, ["Smið", "Járn", "Hamarr", "Smiðja"] },
    { SpecificBuilding.SeersHut, ["Seiðr", "Vǫlva", "Spá", "Galdr"] },
    { SpecificBuilding.TradingPost, ["Verslun", "Markaðr", "Sölva"] },
    { SpecificBuilding.FishermansHut, ["Fiskr", "Veiða", "Net"] },
    { SpecificBuilding.Tannery, ["Gagarr", "Skinn", "Blástr"] },
    { SpecificBuilding.HuntersLodge, ["Veiðr", "Dýr", "Skot"] },
    { SpecificBuilding.GreatHall, ["Hǫll", "Stór", "Mikil"] },
    { SpecificBuilding.Brewery, ["Brugga", "Ölgerð", "Korn"] },
    { SpecificBuilding.SkaldsHall, ["Skáld", "Orð", "Saga"] },
    { SpecificBuilding.AxethrowingArena, ["Øx", "Kasta", "Leikr"] },
    { SpecificBuilding.FishersMarket, ["Fiskr", "Markaðr", "Selja"] },
    { SpecificBuilding.WoodworkersWorkshop, ["Tré", "Smíð", "Tré-smíð"] },
    { SpecificBuilding.JarlsManor, ["Jarl", "Hǫll", "Stórhús"] },
    { SpecificBuilding.StaveChurch, ["Stafr", "Kirkja", "Trú"] },
    { SpecificBuilding.ShieldmakersForge, ["Skjǫldr", "Smíða", "Járn"] },
    { SpecificBuilding.WarriorsBarracks, ["Hersir", "Búð", "Víkingr"] },
    { SpecificBuilding.Meadery, ["Mjǫð", "Brugga", "Korn"] },
    { SpecificBuilding.VikingBurialGround, ["Haugr", "Leggja", "Grav"] },
    { SpecificBuilding.RunecarversStudio, ["Rún", "Rista", "Steinn"] },
    { SpecificBuilding.HermitsHut, ["Einsetumaðr", "Hús", "Einbúi"] },
    { SpecificBuilding.Watchtower, ["Vaka", "Turn", "Útsýn"] },
    { SpecificBuilding.SeafarersChapel, ["Sjófarar", "Kirkja", "Hǫf"] },
    { SpecificBuilding.StoneMason, ["Steinn", "Meistari", "Hǫgg"] },
    { SpecificBuilding.LongshipDock, ["Langskip", "Bryggja", "Hafn"] },
    { SpecificBuilding.BattlefieldMemorial, ["Vígvǫllr", "Minnisvarði", "Hólmr"] },
    { SpecificBuilding.Farmstead, ["Bú", "Bœr", "Land"] },
    { SpecificBuilding.Temple, ["Hof", "Blót", "Goð"] },
    { SpecificBuilding.SagaHall, ["Saga", "Hǫll", "Sögumaðr"] },
    { SpecificBuilding.Lookout, ["Útsýn", "Hólmr", "Vaka"] },
    { SpecificBuilding.Shrine, ["Hǫf", "Dýrkun", "Blót"] },
    { SpecificBuilding.Tavern, ["Smiðja", "Mál", "Samkoma"] },

    }; 
    public static string GenerateName(SpecificBuilding building, MainTerrainType terrain)
    {
        return building switch
        {
            SpecificBuilding.Alehouse => GenerateBuildingName(SpecificBuilding.Alehouse, terrain),
            SpecificBuilding.SagaHall => GenerateBuildingName(SpecificBuilding.SagaHall, terrain),
            SpecificBuilding.Longhouse=> GenerateBuildingName(SpecificBuilding.Longhouse, terrain),
            SpecificBuilding.MeadHall => GenerateBuildingName(SpecificBuilding.MeadHall, terrain),
            SpecificBuilding.Shipwright => GenerateBuildingName( SpecificBuilding.Shipwright, terrain), 
            SpecificBuilding.Wharf => GenerateBuildingName( SpecificBuilding.Wharf, terrain), 
            SpecificBuilding.Smithy => GenerateBuildingName( SpecificBuilding.Smithy, terrain),
            SpecificBuilding.SeersHut =>  GenerateBuildingName( SpecificBuilding.SeersHut, terrain),
            SpecificBuilding.TradingPost => GenerateBuildingName( SpecificBuilding.TradingPost, terrain),
            SpecificBuilding.FishermansHut => GenerateBuildingName( SpecificBuilding.FishermansHut, terrain),
            SpecificBuilding.Tannery => GenerateBuildingName( SpecificBuilding.Tannery, terrain),
            SpecificBuilding.HuntersLodge => GenerateBuildingName( SpecificBuilding.HuntersLodge, terrain), 
            SpecificBuilding.GreatHall  => GenerateBuildingName( SpecificBuilding.GreatHall, terrain),
            SpecificBuilding.Brewery =>  GenerateBuildingName( SpecificBuilding.Brewery, terrain),
            SpecificBuilding.SkaldsHall => GenerateBuildingName( SpecificBuilding.SkaldsHall, terrain),
            SpecificBuilding.AxethrowingArena =>  GenerateBuildingName( SpecificBuilding.AxethrowingArena, terrain),
            SpecificBuilding.FishersMarket =>  GenerateBuildingName( SpecificBuilding.FishersMarket, terrain),
            SpecificBuilding.WoodworkersWorkshop =>  GenerateBuildingName( SpecificBuilding.WoodworkersWorkshop, terrain),
            SpecificBuilding.JarlsManor =>  GenerateBuildingName( SpecificBuilding.JarlsManor, terrain),
            SpecificBuilding.StaveChurch =>  GenerateBuildingName( SpecificBuilding.StaveChurch, terrain),
            SpecificBuilding.ShieldmakersForge =>  GenerateBuildingName( SpecificBuilding.ShieldmakersForge, terrain),
            SpecificBuilding.WarriorsBarracks =>  GenerateBuildingName( SpecificBuilding.WarriorsBarracks, terrain),
            SpecificBuilding.Meadery =>  GenerateBuildingName( SpecificBuilding.Meadery, terrain),
            SpecificBuilding.VikingBurialGround =>  GenerateBuildingName( SpecificBuilding.VikingBurialGround, terrain),
            SpecificBuilding.RunecarversStudio =>  GenerateBuildingName( SpecificBuilding.RunecarversStudio, terrain),
            SpecificBuilding.HermitsHut =>  GenerateBuildingName( SpecificBuilding.HermitsHut, terrain),
            SpecificBuilding.Watchtower =>  GenerateBuildingName( SpecificBuilding.Watchtower, terrain),
            SpecificBuilding.SeafarersChapel =>  GenerateBuildingName( SpecificBuilding.SeafarersChapel, terrain),
            SpecificBuilding.StoneMason =>  GenerateBuildingName( SpecificBuilding.StoneMason, terrain),
            SpecificBuilding.LongshipDock =>  GenerateBuildingName( SpecificBuilding.LongshipDock, terrain),
            SpecificBuilding.BattlefieldMemorial =>  GenerateBuildingName( SpecificBuilding.BattlefieldMemorial, terrain),
            SpecificBuilding.Farmstead =>  GenerateBuildingName( SpecificBuilding.Farmstead, terrain),
            SpecificBuilding.Temple =>  GenerateBuildingName( SpecificBuilding.Temple, terrain),
            SpecificBuilding.Lookout =>  GenerateBuildingName( SpecificBuilding.Lookout, terrain),
            SpecificBuilding.Shrine =>  GenerateBuildingName( SpecificBuilding.Shrine, terrain),
            SpecificBuilding.Tavern =>  GenerateBuildingName( SpecificBuilding.Tavern, terrain),
            _ => "The establisment has no name"
        };
                
    }
    private static string GenerateBuildingName(SpecificBuilding building, MainTerrainType terrain)
    {
        var prefixes = BuildingPrefixes.TryGetValue(building, out var buildingPrefix) ? buildingPrefix : new[] { "DefaultPrefix" };
        var prefix = prefixes[Random.Next(prefixes.Length)];
        return $"{prefix}{Postfix(terrain)}, {GetBlessingPhrase()} {GodsPostFix()}";
    } 
   
    private static string Postfix(MainTerrainType terrain)
    {
       var returnString = terrain switch
                {
                    MainTerrainType.Coastal => Random.Next(2) == 0 ? "fyrir" : "strǫnd",
                    MainTerrainType.Forest => Random.Next(2) == 0 ? "fýri" : "skógr",
                    MainTerrainType.Grassland => Random.Next(2) == 0 ? "eng" : "völlr",
                    MainTerrainType.Highland => Random.Next(2) == 0 ? "háls" : "fjall",
                    MainTerrainType.Lake => Random.Next(2) == 0 ? "vatn" : "sjór",
                    MainTerrainType.Fjord => Random.Next(2) == 0 ? "fjǫrðr" : "vatn",
                    MainTerrainType.Marsh => Random.Next(2) == 0 ? "mýrr" : "vatn",
                    MainTerrainType.Wetland => Random.Next(2) == 0 ? "myrr" : "vatn",
                    MainTerrainType.Tundra => Random.Next(2) == 0 ? "frost" : "snjór",
                    MainTerrainType.HighMountain => Random.Next(2) == 0 ? "fjall" : "háls",
                    MainTerrainType.LowMountain => Random.Next(2) == 0 ? "fjall" : "háls",
                    MainTerrainType.MediumMountain => Random.Next(2) == 0 ? "fjall" : "háls",
                    MainTerrainType.Meadow => Random.Next(2) == 0 ? "eng" : "völlr", 
                    MainTerrainType.Heath => Random.Next(2) == 0 ? "heiðr" : "lyng",
                    _ => ""
                };
                return returnString;
    }

    private static string GodsPostFix()
    {
        var returnString = new Random().Next(0, 18) switch
        {
            0 => "Odin",
            1 => "Thor",
            2 => "Freya",
            3 => "Loki",
            4 => "Frigg",
            5 => "Balder",
            6 => "Tyr",
            7 => "Heimdall",
            8 => "Freyr",
            9 => "Njord",
            10 => "Hel",
            11 => "Sif",
            12 => "Bragi",
            13 => "Idun",
            14 => "Forseti",
            15 => "Vidar",
            16 => "Vali",
            17 => "Ullr",
            18 => "Jord",
            _ => "The gods"
            
            
        };
        return returnString;
    }

    private static string GetBlessingPhrase()
    {
        var returnString = new Random().Next(0, 20) switch
        {
            0 => "blessed by",
            1 => "favored by",
            2 => "endowed with the strength of",
            3 => "graced by the touch of",
            4 => "sanctified in the name of",
            5 => "gifted by the hand of",
            6 => "benefited from the wisdom of",
            7 => "bestowed by the grace of",
            8 => "consecrated by",
            9 => "empowered by the spirit of",
            10 => "hallowed by",
            11 => "enriched by the blessings of",
            12 => "anointed by",
            13 => "cherished by the favor of",
            14 => "venerated by the followers of",
            15 => "honored by",
            16 => "fortified by the might of",
            17 => "rewarded by",
            18 => "praised by the name of",
            19 => "approved by the will of",
            20 => "elevated by the power of",
            _ => "unknown blessing type"
        };
        return returnString;
    }

}
               