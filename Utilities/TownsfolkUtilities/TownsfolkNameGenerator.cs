namespace TowninatorCLI
{

    public static class TownsfolkNameGenerator
    {
        public static string GenerateMaleName()
        {
            Random random = new Random();
            int RandomNumber(int min, int max)
            {
                return random.Next(min, max);
            }
            // Generate a random name
            String[] prefix = { "Thrad", "Broung", "Muk", "Yat", "Dar", "Glorik", "Git", "Bwol", "Dwol" };
            String[] suffix = { "nuid", "reath", "ruri", "ag", "mir", "numir", "matub", "matin", "git", "duki" };
            string name = prefix[RandomNumber(0, prefix.Length)] + suffix[RandomNumber(0, suffix.Length)];
            return name;
        }

        public static string GenerateFemaleName()
        {
            Random random = new Random();
            int RandomNumber(int min, int max)
            {
                return random.Next(min, max);
            }
            // Generate a random name
            String[] prefix = { "Læuth", "Bru", "Luk", "Skoz", "Dho", "Dhog", "Del", "Bel", "Haz" };
            String[] suffix = { "wynn", "buna", "bela", "ilda", "ir", "umir", "ub", "tin", "itish", "mora" };
            string name = prefix[RandomNumber(0, prefix.Length)] + suffix[RandomNumber(0, suffix.Length)];
            return name;
        }

        public static string GenerateLastName()
        {
            Random random = new Random();
            int RandomNumber(int min, int max)
            {
                return random.Next(min, max);
            }
            // Generate a random last name
            String[] prefix = { "Black", "Storm", "Raven", "Night", "Iron", "Frost", "Thorn", "Blood", "Grim" };
            String[] suffix = { "rider", "shadow", "bane", "born", "blade", "soul", "fang", "claw", "spire", "wolf" };
            string name = prefix[RandomNumber(0, prefix.Length)] + suffix[RandomNumber(0, suffix.Length)];
            return name;

        }

    }

}
