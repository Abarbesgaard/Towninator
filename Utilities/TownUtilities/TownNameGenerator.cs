namespace TowninatorCLI.Utilities.TownUtilities
{
    public static class TownNameGenerator
    {
        public static string GenerateName()
        {
            var random = new Random();
            string[] prefix = ["Be", "De", "El", "Fa", "Ga", "Has", "He", "Jo", "Ki", "La", "Ma", "Na", "Pa", "Ra", "Sa", "Ta", "Va", "A", "Wi", "Za"
            ];
            string[] suffix = ["bur", "brish", "dalin", "fordush", "hammer", "öing", "por", "tomu", "wickkin", "woodah"
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
