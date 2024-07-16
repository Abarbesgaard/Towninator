namespace TowninatorCLI.Utilities.TownsfolkUtilities
{

    public static class TownsfolkNameGenerator
    {
        public static string GenerateMaleName()
        {
            var random = new Random();
            // Generate a random name
            string[] prefix = ["Thrad", "Broung", "Muk", "Yat", "Dar", "Glorik", "Git", "Bwol", "Dwol"];
            string[] suffix = ["nuid", "reath", "ruri", "ag", "mir", "numir", "matub", "matin", "git", "duki"];
            var name = prefix[RandomNumber(0, prefix.Length)] + suffix[RandomNumber(0, suffix.Length)];
            return name;

            int RandomNumber(int min, int max)
            {
                return random.Next(min, max);
            }
        }

        public static string GenerateFemaleName()
        {
            var random = new Random();
            // Generate a random name
            string[] prefix = ["Læuth", "Bru", "Luk", "Skoz", "Dho", "Dhog", "Del", "Bel", "Haz"];
            string[] suffix = ["wynn", "buna", "bela", "ilda", "ir", "umir", "ub", "tin", "itish", "mora"];
            var name = prefix[RandomNumber(0, prefix.Length)] + suffix[RandomNumber(0, suffix.Length)];
            return name;

            int RandomNumber(int min, int max)
            {
                return random.Next(min, max);
            }
        }

        public static string GenerateLastName()
        {
            var random = new Random();
            // Generate a random last name
            string[] prefix = ["Black", "Storm", "Raven", "Night", "Iron", "Frost", "Thorn", "Blood", "Grim"];
            string[] suffix = ["rider", "shadow", "bane", "born", "blade", "soul", "fang", "claw", "spire", "wolf"];
            var name = prefix[RandomNumber(0, prefix.Length)] + suffix[RandomNumber(0, suffix.Length)];
            return name;

            int RandomNumber(int min, int max)
            {
                return random.Next(min, max);
            }
        }

    }

}
