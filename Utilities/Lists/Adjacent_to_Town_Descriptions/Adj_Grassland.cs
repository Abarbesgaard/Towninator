namespace TowninatorCLI
{
    public class Adj_Grassland
    {
        public string DescriptionGenerator()
        {
            var random = new Random();
            string[] descriptions = new string[]
    {
        "where gentle breezes sway the tall grasses in waves of green.",
        "stretching as far as the eye can see, under a vast open sky.",
        "with wildflowers dotting the landscape, adding splashes of color.",
        "where herds of grazing animals roam freely in the open plains.",
        "offering a peaceful retreat amidst the tranquil scenery of green blades of grass.",
        "where the sun sets over rolling fields in a blaze of colors.",
        "with its expansive openness inviting exploration and discovery.",
        "where the rustling of grasses harmonizes with the song of birds.",
        "underneath which lies a thriving ecosystem of plants and wildlife.",
        "where the grasslands meet the horizon in an unbroken line.",
        "with its gentle terrain providing a sense of calm and serenity.",
        "where the wind whispers secrets through the fields of green.",
        "offering a quiet haven away from the hustle and bustle of towns.",
        "where the vast expanse of greenery meets the distant sky.",
        "with its fertile soil nurturing life under the open canopy.",
        "where the grasslands sway in rhythm with the changing seasons.",
        "offering vistas of undulating plains under an endless blue sky.",
        "where the beauty of simplicity merges with nature's abundance.",
        "with its peaceful ambiance soothing the weary traveler.",
        "where the grasslands paint the landscape in shades of green."    };
            string description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
