namespace TowninatorCLI
{
    public enum Profession
    {
        None,
        Farmer,
        Blacksmith,
        Trader,
        Doctor,
        Teacher,
        Soldier,
        TavernKeeper,
        Innkeeper,

        // Add more professions as needed
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

        public Townsfolk()
        {
            // Default constructor
        }

        public Townsfolk(int id, string firstName, string lastName, int age, Gender gender, Profession profession, ProfessionSkillLevel skillLevel)
    : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Profession = profession;
            SkillLevel = skillLevel;
        }
    }
}

