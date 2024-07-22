namespace TowninatorCLI.Model
{
    public enum SpecificBuilding
    {
        Longhouse,
        MeadHall,
        Smithy,
        SeersHut,
        TradingPost,
        FishermansHut,
        Tannery,
        HuntersLodge,
        GreatHall,
        Brewery,
        SkaldsHall,
        AxethrowingArena,
        Shipwright,
        FishersMarket,
        WoodworkersWorkshop,
        JarlsManor,
        StaveChurch,
        Wharf,
        ShieldmakersForge,
        WarriorsBarracks,
        Meadery,
        VikingBurialGround,
        RunecarversStudio,
        HermitsHut,
        Watchtower,
        SeafarersChapel,
        StoneMason,
        LongshipDock,
        Alehouse,
        BattlefieldMemorial,
        Farmstead,
        Temple,
        SagaHall,
        Lookout,
        Shrine,
        Tavern,
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

        public int? TownId { get; init; }
        public List<Townsfolk>? Townsfolk { get; init; }
        public float CoastalModifier { get; init; }
        public float FjordModifier { get; init; }
        public float ForestModifier { get; init; }
        public float GrasslandModifier { get; init; }
        public float HeathModifier { get; init; }
        public float HighlandModifier { get; init; }
        public float LakeModifier { get; init; }
        public float MarshModifier { get; init; }
        public float MeadowModifier { get; init; }
        public float LowMountainModifier { get; init; }
        public float MediumMountainModifier { get; init; }
        public float HighMountainModifier { get; init; }
        public float WetlandModifier { get; init; }
        public float TundraModifier { get; init; }
        public Building() { }
        public Building(int id, string? name, string? description, BuildingType type, SpecificBuilding specificBuilding, 
            int? townId, List<Townsfolk>? townsfolk, float coastalModifier, float fjordModifier, float forestModifier, 
            float grasslandModifier, float heathModifier, float highlandModifier, float lakeModifier, 
            float marshModifier, float meadowModifier, float lowMountainModifier, float mediumMountainModifier, 
            float highMountainModifier, float wetlandModifier, float tundraModifier) : this()
       
        {
            Id = id;
            Name = name;
            Description = description;
            BuildingType = type;
            SpecificBuilding = specificBuilding;
            TownId = townId;
            Townsfolk = townsfolk;
            CoastalModifier = coastalModifier;
            FjordModifier = fjordModifier;
            ForestModifier = forestModifier;
            GrasslandModifier = grasslandModifier;
            HeathModifier = heathModifier;
            HighlandModifier = highlandModifier;
            LakeModifier = lakeModifier;
            MarshModifier = marshModifier;
            MeadowModifier = meadowModifier;
            LowMountainModifier = lowMountainModifier;
            MediumMountainModifier = mediumMountainModifier;
            HighMountainModifier = highMountainModifier;
            WetlandModifier = wetlandModifier;
            TundraModifier = tundraModifier;
        }
        
    }
}
