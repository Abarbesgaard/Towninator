namespace TowninatorCLI.Utilities.Lists.Adjacent_To_Town_Descriptions
{
    public static class AdjMeadow
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new string[]
            {
                "by the edge of a sunlit meadow, where wildflowers dance in the breeze and the soft hum of bees fills the air.",
                "on a grassy knoll overlooking a vibrant meadow, where the landscape is dotted with colorful blooms and the horizon stretches wide.",
                "next to a gentle stream meandering through the meadow, where the water glistens under the open sky and tall grasses sway.",
                "in the midst of a wide, open meadow, where the fields are covered with a patchwork of wildflowers and the air is fresh and fragrant.",
                "by a serene pond nestled in the meadow, reflecting the sky and surrounded by the gentle hum of nature.",
                "at the edge of a lush meadow with rolling hills, where the golden grasses ripple in the wind and birds sing from the treetops.",
                "on a sunlit path winding through the meadow, where the fragrance of blooming flowers and the rustling of grass create a peaceful ambiance.",
                "beside a quaint farmhouse with a backdrop of flowering meadows, where the fields stretch out in all directions and the air is filled with the scent of earth.",
                "in a meadow adorned with vibrant wildflowers, where the landscape is painted with splashes of color and the gentle breeze carries their sweet fragrance.",
                "near a field of tall, waving grasses, where the soft rustle of the wind and the occasional flutter of butterflies add life to the scene.",
                "by a gentle hill in the meadow, where the open space and rolling fields provide a perfect setting for picnics and leisurely strolls.",
                "on the edge of a meadow dotted with grazing animals, where the sight of gentle creatures and the sound of their grazing create a pastoral charm.",
                "in a tranquil clearing within the meadow, where the wildflowers bloom in abundance and the peaceful environment invites relaxation.",
                "at a corner of the meadow where the grass meets a small, babbling brook, adding a touch of serenity to the open landscape.",
                "next to a cluster of ancient oaks standing proudly in the meadow, offering shade and a sense of timelessness amid the vibrant landscape.",
                "in a meadow where the wild grasses and colorful flowers create a natural mosaic, stretching out under the wide, open sky.",
                "by a rustic stone wall that runs through the meadow, where the landscape transitions from lush grasses to wild, untamed fields.",
                "on a grassy rise overlooking a sprawling meadow, where the gentle curves of the land and the play of light create a picturesque setting.",
                "in a secluded spot in the meadow, where the sounds of nature and the sight of swaying flowers provide a serene and inviting atmosphere.",
                "by a meadow where the changing seasons paint the landscape with a tapestry of colors, from vibrant spring blooms to golden autumn hues."
            };

            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
