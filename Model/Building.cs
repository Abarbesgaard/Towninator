namespace TowninatorCLI.Model
{
    public enum SpecificBuilding
    {
        Library,
        School,
        Theater,
        Clinic,
        Harbor,
        Blacksmith,
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
        Museum
    }

    public enum BuildingType
    {
        Culture,
        Crime,
        Education,
        Health,
        Military,
        Order,
        Production,
        Recreation,
        Trade,
        Wealth,
        Worship
    }
    public class Building
    {
        public int Id { get; init; }
        public string? Name { get; set; }
        public string? Description { get; init; }
        public BuildingType BuildingType { get; init; }
        public SpecificBuilding SpecificBuilding { get; init; }

        public int SpawnProbability { get; init; }
        public int? TownId { get; init; }
        public List<Townsfolk>? Townsfolk { get; init; }
        public Building() { }
        public Building(int id, string? name, string? description, BuildingType type, SpecificBuilding specificBuilding, 
            int spawnProbability, int? townId, List<Townsfolk>? townsfolk) : this()
        {
            Id = id;
            Name = name;
            Description = description;
            BuildingType = type;
            SpecificBuilding = specificBuilding;
            SpawnProbability = spawnProbability;
            TownId = townId;
            Townsfolk = townsfolk;

        }
    }
}
