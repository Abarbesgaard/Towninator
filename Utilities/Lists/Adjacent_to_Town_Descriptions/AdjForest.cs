namespace TowninatorCLI.Utilities.Lists.Adjacent_To_Town_Descriptions
{
    public static class AdjForest
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new string[]
    {
        "where ancient trees whisper tales of old.",
        "shrouded in mystique amidst towering trunks.",
        "where sunlight filters through green canopies.",
        "in a tranquil grove surrounded by ancient oaks.",
        "enveloped by towering pines and the scent of pine needles.",
        "alive with birdsong and the rustling of leaves.",
        "deep within the heart of the forest, where nature reigns supreme.",
        "surrounded by majestic redwoods reaching for the sky.",
        "offering sanctuary and seclusion within a thicket of trees.",
        "where townsfolk and forest creatures mingle in a serene glade.",
        "embraced by the greenery of an ancient, untouched forest.",
        "sheltered by ancient trees at the edge of a mysterious forest.",
        "hidden among a labyrinth of trees, paths winding through the depths.",
        "where moss and earth scent the air deep in the woodland.",
        "thriving amidst mighty oaks, where village life flourishes.",
        "where tranquility meets community amidst whispering birch leaves.",
        "nestled within a vast forest, paths leading deeper into nature's embrace.",
        "guarded by ancient trees where the forest meets the village.",
        "in the magical heart of a forest, where nature's energy hums."    };
            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
