namespace TowninatorCLI.Utilities.Lists
{
    public abstract class TownGrassland
    {
        public static string DescriptionGenerator()
        {

            var random = new Random();
            var descriptions = new string[]
            {
        "A town nestled in expansive grasslands, where the wind whispers through tall blades.",
        "Amidst rolling hills and endless meadows, a town thrives in the embrace of nature.",
        "A tranquil town surrounded by lush greenery and gentle slopes of grassy plains.",
        "In the heart of verdant grasslands, where wildflowers bloom and wildlife roams freely.",
        "A picturesque town amidst open fields and sun-kissed meadows, dotted with grazing cattle.",
        "A serene village surrounded by golden fields of swaying grass and peaceful horizons.",
        "Nestled in vast, undulating grasslands, where the scent of earth and wildflowers fills the air.",
        "A town on the edge of expansive prairies, where the horizon stretches endlessly.",
        "In a land of rolling green hills and open skies, a town offers a peaceful retreat.",
        "Surrounded by sweeping plains and sunlit fields, a town enjoys the tranquility of the grasslands.",
        "A peaceful village in the heart of endless grassy plains, where the sky meets the earth.",
        "Amidst fields of tall grass and grazing herds, a town embodies the harmony of rural life.",
        "A community nestled among gentle slopes and verdant pastures, where nature's beauty prevails.",
        "In the midst of sweeping meadows and fertile lands, a town thrives amidst the beauty of the grasslands.",
        "A town surrounded by undulating waves of green, where the land stretches as far as the eye can see.",
        "Among open fields and rolling terrain, a town offers a tranquil haven in the heart of the grasslands.",
        "Embraced by the openness of the prairies and the serenity of nature, a town flourishes.",
        "Nestled in expansive grasslands, where the breeze carries the scent of wild herbs and freedom.",
        "In the embrace of rolling hills and vast plains, a town finds solace amidst the beauty of the grasslands.",
        "A village nestled in a sea of green, where the rhythm of life mirrors the gentle sway of the grass."
    }; 
            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
