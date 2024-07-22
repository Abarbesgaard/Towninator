namespace TowninatorCLI.Utilities.Lists
{
    public abstract class TownHeath
    {
        public static string DescriptionGenerator()
        {

            var random = new Random();
            var descriptions = new[]
{
    "A town perched on the edge of a windswept heath, where hardy grasses and resilient shrubs thrive.",
    "Amidst the rugged expanse of heathland, a town stands resilient against the open sky and rolling terrain.",
    "On a solitary heath, where low shrubs and hardy vegetation stretch out to the horizon, a town finds its place.",
    "In the midst of a vast heath, where the land is dotted with stunted trees and sparse grasses, a town takes root.",
    "A town settled on a heath's barren stretch, where the wind sweeps across open fields of gorse and heather.",
    "Nestled in the heart of a heathland, where the landscape is marked by rugged beauty and open space.",
    "Among the windswept heaths, where low shrubs and heather paint the landscape, a town emerges resilient and enduring.",
    "On the edge of a heath, where the terrain is marked by rocky outcrops and sparse vegetation, a town stands strong.",
    "A community on the heath, where the land's rugged character and sparse growth shape a unique and isolated existence.",
    "In the midst of heathland's rough terrain and hardy flora, a town thrives amidst the open and untamed landscape.",
    "A town surrounded by the raw beauty of the heath, where the land's wild nature meets the spirit of human settlement.",
    "Among the heath's rugged expanses, where the air is filled with the scent of bracken and the whisper of the wind.",
    "A town on a heath, where the landscape's harsh beauty and scattered flora create a backdrop of enduring strength.",
    "In the heart of a heathland, where the land's sparse vegetation and rocky ground frame a town's steadfast presence.",
    "A town positioned amidst the heath's open stretches, where the earth is marked by wild grasses and resilient shrubs.",
    "Amid the barren beauty of the heath, a town stands as a beacon of life against the backdrop of rugged terrain.",
    "On the heath's edge, where the land's rugged openness and sparse flora define the landscape, a town thrives.",
    "Nestled within the heath, where the stark beauty of low vegetation and rocky outcrops creates a unique setting.",
    "In the open expanse of the heath, where hardy plants and the vast sky frame a town of enduring spirit.",
    "A village amidst the heath's rugged terrain, where the wild beauty and open space form a unique and enduring environment."
};

var description = descriptions[random.Next(descriptions.Length)];


            return description;
        }
    }
}