namespace TowninatorCLI.Utilities.TownUtilities
{
    public static class TownNameGenerator
    {
        public static string GenerateName()
        {
            var random = new Random();
            string[] prefix = ["Apal", "Breiðr", "Búð", "Hol", "Haug", "Hús", "Mikill", "Sand", "Steinn", "Kvi", "Langa"
            ];
            string[] suffix = ["þorn", "þorp", "toft", "keld", "by", "kirk", "nes", "dalr", "vatn", "beck", "þvait"
            ];
            var name = prefix[RandomNumber(0, prefix.Length)] + suffix[RandomNumber(0, suffix.Length)];
            return name;

            int RandomNumber(int min, int max)
            {
                return random.Next(min, max);
            }
        } 

    }
}
