namespace TowninatorCLI.Utilities.TownsfolkUtilities
{

    public static class TownsfolkNameGenerator
    {
        public static string GenerateMaleName()
        {
            var random = new Random();
            var nameList = new[,]
            {
                {"Arne", "Eagle"},
                {"Birger", "keeper"},
                {"Bjorn", "Bear"},
                {"Bo", "resident"},
                {"Erik","absolute ruler"},
                {"Frode","wise and clever"},
                {"Gorm","worshiper of god"},
                {"Harald","lord and ruler"},
                {"Knud","knot"},
                {"Kåre","one with curly hair"},
                {"Leif","descendant"},
                {"Njal","Giant"},
                {"Roar","fame and spear"},
                {"Rune","secret"},
                {"Sten","stone"},
                {"Skarde","one with cleft chin"},
                {"Sune","son"},
                {"Svend","freeman"},
                {"Troels","arrow of Thor"},
                {"Toke","helmet of Thor"},
                {"Thorsten","stone of Thor"},
                {"Trygve","trustworthy"},
                {"Ulf","Wolf"},
                {"Ødger","wealthy"},
                {"Åge","Ancestor"},
                // Add more names and meanings as needed
            };
        
            // Generate a random index for the nameList array
            var index = random.Next(0, nameList.GetLength(0));
        
            // Retrieve the name and meaning at the random index
            var name = nameList[index, 0];
            var meaning = nameList[index, 1];
        
            // Format the name and meaning into a single string
            return $"{name}, the {meaning},";

            
        }

        public static string GenerateFemaleName()
        {
            var random = new Random();
            var nameList = new[,]
            {
                { "Astrid", "beautiful" },
                { "Bodil", "fighter" },
                { "Frida", "peaceful" },
                { "Gertrud", "spear" },
                { "Gro", "grower" },
                { "Estrid", "grace of god" },
                { "Hilda", "fighter" },
                { "Gudrun", "rune" },
                { "Gunhild", "fighter" },
                { "Helga", "sacred" },
                { "Inga", "woman of god" },
                { "Liv", "woman of life" },
                { "Randi", "shield" },
                { "Signe", "victorious" },
                { "Revna", "raven" },
                { "Sif", "bride" },
                { "Tora", "woman of Thor" },
                { "Tove", "dove" },
                { "Thyra", "helpful" },
                { "Yrsa", "she-bear" },
                { "Ulfhild", "wolf" },
                { "Åse", "goddess" },
            };
            var index = random.Next(0, nameList.GetLength(0));
            var name = nameList[index, 0];
            var meaning = nameList[index, 1];
            return $"{name}, the {meaning},";
            
        }

        public static string GenerateLastName()
        {
            var random = new Random();
            // Generate a random last name
            string[] prefix = ["Å", "Agnar", "Ahl", "Åker", "Åke", "Bård", "Bak", "Beck", "Björk"];
            string[] suffix = ["berg", "son", "ström", "man", "stedt", "rud", "gren", "quist", "gaard", "lund"];
            var name = prefix[RandomNumber(0, prefix.Length)] + suffix[RandomNumber(0, suffix.Length)];
            return name;

            int RandomNumber(int min, int max)
            {
                return random.Next(min, max);
            }
        }

    }

}
