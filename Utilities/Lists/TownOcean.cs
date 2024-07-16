namespace TowninatorCLI.Utilities.Lists
{
    public class TownOcean
    {
        public static string DescriptionGenerator()
        {

            var random = new Random();
            var descriptions = new string[]
            {
              "A town floating in the open ocean, connected by sturdy bridges and platforms.",
              "An oceanic settlement on floating rafts, where buildings sway with the gentle waves.",
              "A maritime town built on floating platforms, surrounded by the endless sea.",
              "A town in the heart of the ocean, where homes and businesses float on the water's surface.",
              "A waterborne village on stilts above tranquil waters, linked by rope bridges.",
              "A coastal town where houses rest on rafts, navigating the open sea.",
              "A marine community on floating structures, anchored in the expansive ocean.",
              "A floating town amidst the deep blue sea, where life revolves around the ocean's rhythms.",
              "An oceanic village on interconnected platforms, bobbing gently in the ocean currents.",
              "A town on the open sea, its buildings designed to withstand the elements of the ocean.",
              "A seafaring settlement where life unfolds above the azure waves of the ocean.",
              "A water-bound town where residents navigate between floating homes and businesses.",
              "A town anchored in the ocean, connected by bridges that sway with the sea breeze.",
              "A maritime village where structures float atop the calm waters, tethered to the seabed below.",
              "A coastal community on floating rafts, blending with the vast expanse of the ocean.",
              "A waterborne town where the sea serves as both barrier and lifeline for its inhabitants.",
              "An oceanic town on floating platforms, its architecture adapted to the rhythms of the sea.",
              "A marine settlement where daily life unfolds amidst the endless horizon of the open ocean.",
              "A floating village where homes and businesses float on the tranquil waters, linked by marine craft.",
              "A coastal town built on sturdy rafts and floating structures, navigating the sea's vastness."
    }; 
            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
