namespace TowninatorCLI.Utilities.Lists
{
    public static class TownMediumMountain
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new string[] {
                "Nestled in brooding mountain ranges.",
                "Surrounded by ominous, towering peaks.",
                "At the base of imposing, jagged mountains.",
                "In the shadow of a menacing mountain.",
                "Perched among somber, rugged highlands.",
                "Encircled by lush, secretive hills.",
                "With views of dark, craggy peaks.",
                "Where stark cliffs meet gloomy skies.",
                "Among towering, mist-shrouded heights.",
                "At the crossroads of hills and steep peaks.",
                "Embraced by scarred, majestic ranges.",
                "Offering views of sharp, foreboding ridges.",
                "Mountains as a dramatic, looming backdrop.",
                "In the valleys of mid-sized ranges.",
                "Surrounded by daunting, impressive heights.",
                "With trails through echoing, rocky hills.",
                "Nestled in picturesque, perilous foothills.",
                "Framed by somber, craggy peaks.",
                "Mountains creating a piercing skyline.",
                "In a region of haunted highlands."
        };
            var description = descriptions[random.Next(descriptions.Length)];
            return description;
        }
    }
}
