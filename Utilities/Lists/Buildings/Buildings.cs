
using TowninatorCLI.Model;

namespace TowninatorCLI.Utilities.Lists.Buildings
{
    public static class Buildings
    {
        public static List<Building> GetBuildings()
        {
            return
            [
                new Building(1, null, null, BuildingType.Education, SpecificBuilding.Alehouse, 3, null, null),
                new Building(2, null, null, BuildingType.Education, SpecificBuilding.Wharf, 5, null, null),
                new Building(3, null, null, BuildingType.Culture, SpecificBuilding.Watchtower, 4, null, null),
                new Building(4, null, null, BuildingType.Culture, SpecificBuilding.FishermansHut, 2, null, null),
                new Building(5, null, null, BuildingType.Health, SpecificBuilding.HermitsHut, 3, null, null),
                new Building(6, null, null, BuildingType.Trade, SpecificBuilding.MeadHall, 5, null, null),
                new Building(7,null, null, BuildingType.Production, SpecificBuilding.Longhouse, 10,null,null),
                new Building(8, null, null, BuildingType.Recreation, SpecificBuilding.Shipwright, 6, null, null)
                // Add more buildings as needed
            ];
        }
    }
}
        /*
         Tavern,
        Inn,
        Alchemist,
        WizardTower,
        Guildhall,
        Cathedral,
        MageCollege,
        Apothecary,
        Observatory,
        Herbalist,
        Armory,
        Market,
        Stables,
        GuardTower,
        Watchtower,
        HerbalistShop,
        Tailor,
        Bakery,
        Brewery,
        Chandlery,
        Clocktower,
        Colosseum,
        Foundry,
        Lighthouse,
        Masonry,
        Mill,
        OperaHouse,
        Orphanage,
        PrintingPress,
        Scriptorium,
        SculptorStudio,
        SiegeWorkshop,
        SpiceTrader,
        Tannery,
        TeaHouse,
        Treasury,
        University,
        WeavingShop,
        Zoo,
        Oracle,
        ArcaneForge,
        NecromancerTower,
        EnchanterStudio,
        BeastmasterDen,
        DragonKeep,
        MinstrelHall,
        ThievesGuild,
        Watermill,
        Chapel,
        Monastery,
        HerbalGarden,
        ArmorSmith,
        MageGuild,
        GrandLibrary,
        WarlockSanctum,
        Crypt,
        AbandonedTower,
        HunterLodge,
        Courthouse,
        GuildHouse,
        ScribeShop,
        Theatre,
        TaxOffice,
        Cemetery,
        GrimoireLibrary,
        RatCatcher,
        SoapMaker,
        Butcher,
        Weaver,
        Crier,
        Basketweaver,
        TavernAndInn,
        Craftsman,
        Carpenter,
        FishMarket,
        PublicBath,
        Sculpture,
        Bathhouse,
        Clocks,
        BreadShop,
        CityGate,
        River,
        GoldSmith,
        Rancher,
        Cartographer,
        Mason,
        MouldyTower,
        PirateCove,
        Cook,
        Forge,
        Archive,
        Slaughterhouse,
        Bridge,
        Dancehall,
        BlackSmithShop,
        Tunneler,
        MillingShops,
        MedicalDoctor,
        DentistOffice,
        FortuneTeller,
        BowlingAlley,
        ClothesDyer,
        DiplomaticBackchannel,
        FancyDressParty,
        MaskedBall,
        Prison,
        AnimalTraining,
        TotemCarver,
        PalmReader,
        GiftShop,
        AnimalShelter,
        Museum*/