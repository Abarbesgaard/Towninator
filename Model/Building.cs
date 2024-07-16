namespace TowninatorCLI.Model
{


    public enum SpecificBuilding
    {
        Library,
        School,
        Museum,
        Theater,
        Clinic,
        Harbor,
        // Add more specific buildings as needed
    }
    public enum BuildingType
    {
        Culture,
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
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public BuildingType BuildingType { get; set; }
        public SpecificBuilding? SpecificBuilding { get; set; }

        public int SpawnProbability { get; set; }
        public int? TownId { get; set; }
        public List<Townsfolk>? Townsfolk { get; set; }
        public Building() { }
        public Building(int id, string name, string? description, BuildingType type, SpecificBuilding specificBuilding, 
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
