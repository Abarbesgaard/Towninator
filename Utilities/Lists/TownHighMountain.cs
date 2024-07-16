namespace TowninatorCLI.Utilities.Lists
{
    public class TownHighMountain
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new string[]
              {
                "Nestled in a valley between towering peaks, where the air is thin and the wind is cold.",
                "A remote town surrounded by breathtaking, ancient peaks.",
                "A secluded town with unparalleled scenic beauty, hidden in the mountains.",
                "On a high plateau, offering panoramic views of distant peaks.",
                "This high-altitude town boasts crisp air and stunning vistas.",
                "Perched between lofty peaks, enjoying thin, crisp air.",
                "A hidden town high in the mountains, enveloped by majestic summits.",
                "This mountain town offers breathtaking views and deep solitude.",
                "A serene town on a high ridge, surrounded by towering peaks.",
                "Nestled in the high mountains, a true scenic gem.",
                "A remote village amidst high peaks, with clear, crisp air.",
                "High on a plateau, providing stunning mountain views.",
                "A secluded village in the mountains, surrounded by natural beauty.",
                "On a high mountain pass, enjoying sweeping vistas.",
                "Known for pristine air and peak views, high above.",
                "Hidden in the mountains, boasting dramatic scenery.",
                "A high mountain town, offering clear air and breathtaking sights.",
                "Sitting high between peaks, with spectacular views.",
                "An elevated town surrounded by stunning mountain peaks.",
                "Perched on a mountain ridge, with panoramic views."
            };

            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
