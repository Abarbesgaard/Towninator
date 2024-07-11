namespace TowninatorCLI
{
    public class Town_Forest
    {
        public string DescriptionGenerator()
        {

            var random = new Random();
            string[] descriptions = new string[]
            {
              "Hidden in an ancient forest, where trees whisper tales of old.",
              "Nestled deep in a secluded forest, shrouded in mystique.",
              "Amidst dense woodlands, sunlight filters through green canopies.",
              "In a tranquil grove surrounded by ancient oaks.",
              "Enveloped by towering pines and the scent of pine needles.",
              "Among a lush forest alive with birdsong and rustling leaves.",
              "Deep within the heart of the forest, where nature reigns supreme.",
              "Surrounded by majestic redwoods reaching for the sky.",
              "In a thicket of trees, offering sanctuary and seclusion.",
              "In a serene glade where townsfolk and forest creatures mingle.",
              "Embraced by the greenery of an ancient, untouched forest.",
              "At the edge of a mysterious forest, sheltered by ancient trees.",
              "Hidden among a labyrinth of trees, paths winding through the depths.",
              "Deep in the woodland, where moss and earth scent the air.",
              "Under mighty oaks, where village life thrives amidst nature's bounty.",
              "Amidst whispering birch leaves, tranquility meets community.",
              "Nestled within a vast forest, paths leading deeper into nature's embrace.",
              "Where the forest meets the village, trees guarding ancient secrets.",
              "In a magical forest heart, where nature's energy hums.",

            };
            string description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
