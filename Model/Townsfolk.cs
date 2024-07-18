namespace TowninatorCLI.Model
{
    public enum Profession
    {
        None,
        Farmer,
        Blacksmith,
        Trader,
        Skald,
        Seafarer,
        Shipwright,
        Warrior,
        Jarl,
        Runecarver,
        Fisherman,
        Hunter,
        Shaman,
        Weaver,
        Berserker,
        Explorer,
        Fisher,
        Hermit,
    }

    public enum ProfessionSkillLevel
    {
        None,
        Novice,
        Apprentice,
        Journeyman,
        Expert,
        Master
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class Townsfolk
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; }
        public Profession Profession { get; set; }
        public ProfessionSkillLevel SkillLevel { get; set; }
        public bool IsAlive { get; set; }
        public string? Description { get; set; }
        public bool IsMarried { get; set; }
        public int TownId { get; set; }
        public string? Origin { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public bool? IsParent { get; set; }
        public bool? IsChild { get; set; }
        // TODO : Add position on map via Maptile id in db, 
        public Townsfolk()
        {
        }

        public Townsfolk(int id, string firstName, string lastName, int age, Gender gender, Profession profession, ProfessionSkillLevel skillLevel
            , bool isAlive, string description, bool isMarried, int townId, string origin, string region, string country, bool isParent, bool isChild)
    : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Profession = profession;
            SkillLevel = skillLevel;
            IsAlive = isAlive;
            Description = description;
            IsMarried = isMarried;
            TownId = townId;
            Origin = origin;
            Region = region;
            Country = country;
            IsParent = isParent;
            IsChild = isChild;
        }
    }
}

