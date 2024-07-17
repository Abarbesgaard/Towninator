using TowninatorCLI.Model.MapModels;
namespace TowninatorCLI.Model
{
    public class Town
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MainDescription { get; set; }
        public string? NorthDescription { get; set; }
        public string? SouthDescription { get; set; }
        public string? EastDescription { get; set; }
        public string? WestDescription { get; set; }
        public int Culture { get; set; }
        public int Crime { get; set; }
        public int Education { get; set; }
        public int Health { get; set; }
        public int Military { get; set; }
        public int Order { get; set; }
        public int Production { get; set; }
        public int Recreation { get; set; }
        public int Trade { get; set; }
        public int Wealth { get; set; }
        public int Worship { get; set; }
        public List<Townsfolk>? Townsfolk { get; set; }
        public Map? Map { get; set; }
        public Town() { }
        public Town(int id, string name, string mainDescription, string northDescription, string southDescription,
                    string eastDescription, string westDescription, int culture,int crime, int education, int health,
                    int military, int order, int production, int recreation, int trade, int wealth, int worship,
                    List<Townsfolk>? townsfolk)
        {
            Id = id;
            Name = name;
            MainDescription = mainDescription;
            NorthDescription = northDescription;
            SouthDescription = southDescription;
            EastDescription = eastDescription;
            WestDescription = westDescription;
            Culture = culture;
            Crime = crime;
            Education = education;
            Health = health;
            Military = military;
            Order = order;
            Production = production;
            Recreation = recreation;
            Trade = trade;
            Wealth = wealth;
            Worship = worship;
            Townsfolk = townsfolk;
        }
    }
}

