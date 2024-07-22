namespace TowninatorCLI.Utilities.Lists;

public class TownLake
{
    public static string DescriptionGenerator()
    {
        var random = new Random();
        var descriptions = new[]
      {
    "A town nestled on the serene shores of a crystal-clear lake, where the calm waters mirror the surrounding landscape.",
    "By the edge of a tranquil lake, where the gentle ripples and the reflections of distant hills create a peaceful setting.",
    "On the shores of a vast lake, where the still waters and the surrounding woodlands provide a quiet retreat.",
    "A community beside a shimmering lake, where the gentle lapping of the water and the scent of pine define the atmosphere.",
    "In a lakeside haven, where the land meets the water's edge and the peaceful reflection of trees and sky forms a picturesque scene.",
    "A town by a serene lake, where the clear waters and the soft rustle of reeds create an environment of calm and beauty.",
    "Nestled by the lake's edge, where the water's reflective surface and the surrounding green meadows blend into a harmonious landscape.",
    "Amidst the stillness of a large lake, where the quiet waters and the distant mountains frame the town’s peaceful existence.",
    "On the shores of a tranquil lake, where the gentle breezes and the sound of water create a soothing backdrop for daily life.",
    "A village overlooking a placid lake, where the serene waters and the surrounding natural beauty create a tranquil setting.",
    "By the peaceful lake, where the landscape's calm waters and surrounding forests offer a serene and inviting environment.",
    "In the embrace of a large lake, where the land's gentle slopes and the water's still surface create a serene and picturesque view.",
    "A town positioned by a clear, still lake, where the water’s mirror-like surface reflects the surrounding hills and sky.",
    "On the edge of a placid lake, where the land’s gentle contours and the water’s calm surface offer a retreat from the world.",
    "A community beside a tranquil lake, where the reflections on the water and the lush greenery create a peaceful retreat.",
    "Nestled by a quiet lake, where the gentle ripples and the surrounding natural beauty form a serene and inviting atmosphere.",
    "In a lakeside setting where the clear waters and the surrounding forested hills create a peaceful and picturesque backdrop.",
    "On the shore of a serene lake, where the still waters and the surrounding fields blend into a calm and beautiful landscape.",
    "A village by a clear lake, where the tranquil waters and the surrounding nature offer a serene escape from the hustle of life.",
    "By the edge of a quiet lake, where the gentle lapping of the water and the surrounding trees create a peaceful and reflective environment."
};

        var description = descriptions[random.Next(descriptions.Length)];

        return description;
    } 
}