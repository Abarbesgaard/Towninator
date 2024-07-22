namespace TowninatorCLI.Utilities.Lists
{
    public abstract class TownCoastal
    {
        public static string DescriptionGenerator()
        {

            var random = new Random();
            var descriptions = new[]
{
    "A town perched on the edge of rugged cliffs, where the crashing waves of the sea meet the rocky shore.",
    "Along the sunlit coastline, where the rhythmic ebb and flow of the tides shape the land, a town thrives.",
    "Nestled by the shore, where the salty breeze and the sound of seagulls mark the boundary between land and sea.",
    "In a coastal haven, where sandy beaches stretch out to meet the vast expanse of the ocean, a town finds its place.",
    "On the edge of a windswept beach, where the ocean’s roar and the scent of saltwater define the town’s atmosphere.",
    "A town nestled along a tranquil bay, where calm waters and gentle waves create a serene coastal setting.",
    "Among the rolling dunes and rocky coves, a town stands resilient against the ever-changing tides of the sea.",
    "In a coastal enclave, where the land gives way to a broad expanse of open water and sandy shores.",
    "A community by the sea, where the landscape is shaped by the ceaseless rhythm of the waves and the briny air.",
    "By the bustling harbor, where ships come and go and the scent of fresh sea air mingles with the town’s lively streets.",
    "A town nestled by a picturesque coastline, where the land’s contours meet the sea’s endless horizon.",
    "On a craggy coastline, where the land's sharp edges and the ocean's endless expanse create a dramatic and beautiful setting.",
    "Amidst the coastal wetlands, where the mingling of salt and freshwater creates a unique and vibrant environment for a town.",
    "In the shadow of towering sea cliffs, where the land's rugged beauty and the sea's vastness frame the town’s existence.",
    "A village by the coast, where the interplay between rolling surf and rocky shores forms a distinctive and enduring backdrop.",
    "On the edge of a tranquil lagoon, where the water's gentle lapping and the town’s quiet charm create a peaceful retreat.",
    "At the meeting point of land and sea, where the town's lively docks and sandy shores reflect a life intertwined with the ocean.",
    "In a coastal region where the land is carved by the forces of the sea, a town stands resilient against the briny winds.",
    "By the serene seaside, where the gentle waves and the rhythmic calls of seabirds offer a picturesque setting for a town.",
    "A community set against a backdrop of rolling surf and sandy dunes, where the coastal beauty defines its character."
};

var description = descriptions[random.Next(descriptions.Length)];


            return description;
        }
    }
}
