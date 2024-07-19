namespace TowninatorCLI.Utilities.Lists
{
    public class TownWetland
    {
        public static string DescriptionGenerator()
        {

            var random = new Random();
            var descriptions = new string[]
            {
              "A town nestled amidst misty swamplands, where ancient trees rise from murky waters.",
        "In the heart of a mystical swamp, a town thrives amidst twisting vines and eerie mists.",
        "Amidst tangled roots and whispering reeds, a town finds solace in the haunting beauty of the swamp.",
        "A secluded village amidst dense marshes and twisting waterways, where silence hangs heavy.",
        "In a murky wetland where cypress trees cast eerie shadows, a town stands resilient.",
        "Nestled in a labyrinth of marshy channels and moss-covered trees, a town finds its home.",
        "Surrounded by stagnant waters and tangled vegetation, a town survives in the depths of the swamp.",
        "A town in the heart of a forbidding marshland, where mist veils ancient secrets and eerie sounds echo.",
        "In a land of quagmires and stagnant pools, a town endures amidst the damp embrace of the swamp.",
        "Amidst murky waters and moss-draped trees, a town exists in the haunting stillness of the swamp.",
        "A village among murky bogs and twisting roots, where the air is thick with mystery and decay.",
        "Deep in a shadowy marshland, where the call of unseen creatures echoes through the mist.",
        "Nestled among twisted mangroves and murky ponds, a town is cloaked in the quiet of the swamp.",
        "In the midst of damp peat and murky pools, a town thrives amidst the eerie solitude of the swamp.",
        "A settlement amidst dark waters and gnarled roots, where life perseveres in the harshness of the swamp.",
        "Among gnarled cypress and mist-shrouded waters, a town finds its place in the enigmatic swamp.",
        "In a realm of tangled vines and stagnant pools, a town's resilience echoes through the damp silence.",
        "A town amidst the shifting mists and tangled growth of a mysterious wetland.",
        "Nestled in the murky depths of a foreboding marsh, where the land and water intertwine.",
        "In a labyrinth of twisting channels and mossy shores, a town's spirit is forged in the heart of the swamp."
    };
            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
