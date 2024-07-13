namespace TowninatorCLI
{
    public static class TownNameGenerator
    {
        // TODO : add Mainterrain to add variety to the names
        public static string GenerateName()
        {
            Random random = new Random();
            int RandomNumber(int min, int max)
            {
                return random.Next(min, max);
            }
            string[] prefix = { "Be", "De", "El", "Fa", "Ga", "Has", "He", "Jo", "Ki", "La", "Ma", "Na", "Pa", "Ra", "Sa", "Ta", "Va", "A", "Wi", "Za" };
            string[] suffix = { "bur", "brish", "dalin", "fordush", "hammer", "öing", "por", "tomu", "wickkin", "woodah" };
            string name = prefix[RandomNumber(0, prefix.Length)] + suffix[RandomNumber(0, suffix.Length)];
            return name;
        }

    }
}
