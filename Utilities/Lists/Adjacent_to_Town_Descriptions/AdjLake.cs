namespace TowninatorCLI.Utilities.Lists.Adjacent_To_Town_Descriptions
{
    public static class AdjLake
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new string[]
            {
                "by the serene shores of a clear lake, where the still waters reflect the surrounding trees and sky.",
                "on a gentle rise overlooking a tranquil lake, with the distant sound of water lapping against the shore.",
                "beside a sparkling lake with a sandy beach, where children play and boats are moored along the edge.",
                "at the mouth of a river flowing into the lake, where the waters are calm and rich with the life of freshwater fish.",
                "in a secluded cove of the lake, surrounded by lush foliage and the gentle rustling of leaves.",
                "next to a charming lakeside dock, where fishing boats are anchored and the scent of fresh water fills the air.",
                "on the edge of a misty lake at dawn, where the fog rolls across the water and creates a serene, ethereal atmosphere.",
                "by a lakeshore adorned with vibrant wildflowers and tall grasses, where the gentle breeze carries the scent of nature.",
                "in a tranquil bay of the lake, where the water is still and the surface reflects the peaceful sky above.",
                "on a grassy hill overlooking the lake, where the view stretches across the water to distant, forested hills.",
                "beside a quiet lakeside campfire, where the crackling flames contrast with the calm, reflective waters of the lake.",
                "at the edge of a lake bordered by towering pines, where the scent of resin and the sound of rustling needles add to the peaceful setting.",
                "near a small waterfall cascading into the lake, where the sound of falling water adds a soothing rhythm to the serene environment.",
                "in a lakeside meadow where the grass meets the water’s edge, dotted with colorful wildflowers and the occasional deer.",
                "on a lakeside path winding through the forest, offering glimpses of the water through the trees and the sounds of nature all around.",
                "by a lakeshore where the land gently slopes into the water, creating a perfect spot for swimming or picnicking.",
                "next to a tranquil lake with a small island in the center, accessible by a quaint wooden bridge and surrounded by water lilies.",
                "in a picturesque lakeside village, where the houses are built along the shore and boats are a common sight on the water.",
                "by a still lake framed by rolling hills, where the reflection of the landscape creates a mirror image on the surface of the water."
            };

            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
