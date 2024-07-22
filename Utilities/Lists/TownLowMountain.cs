namespace TowninatorCLI.Utilities.Lists
{
    public static class TownLowMountain
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new string[]{
           "A town nestled in the foothills of rugged ranges.",
        "Surrounded by rolling hills and majestic peaks.",
        "At the base of a towering mountain, with a clear summit view.",
        "In the shadow of a prominent peak.",
        "Amidst undulating highlands.",
        "Where rolling hills meet the horizon.",
        "A picturesque town embraced by lofty hills.",
        "With gentle slopes and tranquil valleys.",
        "Surrounded by serene highlands.",
        "At the foothills, offering scenic vistas.",
        "Where the hills are alive with beauty.",
        "Cradled by soft mountain ranges.",
        "With sweeping views of distant peaks.",
        "At the edge of rolling hills, peaceful and serene.",
        "Nestled among undulating ridges.",
        "At the gateway to scenic trails.",
        "A charming town with lush, rolling hills.",
        "Where the highlands gently rise.",
        "In a valley of distant mountains.",
        "Surrounded by tranquil landscapes."
        };
            var description = descriptions[random.Next(descriptions.Length)];
            return description;
        }
    }
}
