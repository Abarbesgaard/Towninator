using TowninatorCLI.Model.MapModels;

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
        
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Charisma { get; set; }
        public int Wisdom { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Luck { get; set; }
        public int Sanity { get; set; }
        public int Perception { get; set; }
        public int Willpower { get; set; }
        public int Faith { get; set; }
        public MainTerrainType Terrain { get; set; }
        public Townsfolk()
        {
        }

        public Townsfolk(int id, string firstName, string lastName, int age, Gender gender, Profession profession, ProfessionSkillLevel skillLevel
            , bool isAlive, string description, bool isMarried, int townId, string origin, string region, string country, bool isParent, bool isChild,
             int intelligence, int strength, int charisma, int wisdom, int dexterity, int constitution, int luck, int sanity, 
            int perception, int willpower, int faith, MainTerrainType terrain)
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
            Intelligence = intelligence;
            Strength = strength;
            Charisma = charisma;
            Wisdom = wisdom;
            Dexterity = dexterity;
            Constitution = constitution;
            Luck = luck;
            Sanity = sanity;
            Perception = perception;
            Willpower = willpower;
            Faith = faith;
            Terrain = terrain; 
        }
    }
}

