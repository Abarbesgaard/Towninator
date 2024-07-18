namespace TowninatorCLI.Model
{
    public enum SpecificBuilding
    {
        Longhouse,
        MeadHall,
        Shipyard,
        Smithy,
        Runestone,
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
        TradingShip,
        WarriorsBarracks,
        RaidingCamp,
        Meadery,
        VikingBurialGround,
        RunecarversStudio,
        FishingVillage,
        HermitsHut,
        Watchtower,
        SeafarersChapel,
        StoneMason,
        LongshipDock,
        Alehouse,
        BattlefieldMemorial,
        ShieldWall,
        VikingFarmstead,
        NorseTemple,
        RuneLibrary,
        SagaHall,
        WolfDen,
        SeasideLookout,
        Icehouse,
        LongshipWorkshop,
        PlunderVault,
        ElderCouncilHall,
        ArcticOutpost,
        NjordsShrine,
        SeaworthyTavern,
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
