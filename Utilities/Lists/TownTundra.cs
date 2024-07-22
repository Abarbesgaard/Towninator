namespace TowninatorCLI.Utilities.Lists;

public static class TownTundra
{
    public static string DescriptionGenerator()
    {
        var random = new Random();
        var descriptions = new string[] {
    "A town nestled in the vast expanse of the tundra, where the land is marked by icy plains and sparse, resilient flora.",
    "In the heart of the tundra, where the frozen ground meets a sky of endless blue, a town stands resilient against the harsh environment.",
    "By the edge of the tundra, where the land's stark beauty and the chill of the arctic air create a serene and rugged setting.",
    "A community set against the backdrop of the tundra's barren expanses, where the landscape is defined by its icy vastness and scattered vegetation.",
    "On the fringes of the tundra, where the land's icy surface and sparse, hardy shrubs create a stark yet beautiful environment for a town.",
    "A town amid the tundra's cold, open plains, where the land's frosty terrain and limited vegetation offer a unique and resilient setting.",
    "In the midst of the tundra's harsh beauty, where the ground is covered in frost and the sparse plants adapt to the cold and wind.",
    "By the icy shores of a frozen lake, where the tundra's barren landscape and the crisp, cold air define the town's stark beauty.",
    "A village set in the tundra's expansive cold, where the land's frost-covered surface and sparse growths create a quiet and resilient environment.",
    "Among the tundra's vast, open stretches, where the frozen ground and the clear, frigid air frame a town's rugged existence.",
    "On the edge of the frozen tundra, where the land's icy beauty and the sparse, hardy flora form a harsh but awe-inspiring backdrop.",
    "In a remote corner of the tundra, where the land's stark, frozen landscape and the chill of the air create a serene yet rugged setting.",
    "A town on the tundra's icy plains, where the harsh cold and the sparse vegetation define a landscape of raw and untouched beauty.",
    "By the edge of the tundra, where the land's frozen surface and the sparse growths of hardy shrubs create a unique and enduring environment.",
    "In the midst of the tundra's expansive cold, where the land's icy terrain and the sparse, resilient flora form a rugged and isolated community.",
    "A settlement in the tundra, where the icy expanse and the sparse vegetation create a landscape of stark beauty and enduring spirit.",
    "On the cold expanse of the tundra, where the land's frozen surface and limited plant life define a serene and rugged environment.",
    "A community amid the tundra's barren beauty, where the icy ground and sparse growths create a peaceful yet harsh setting.",
    "In the heart of the tundra's frozen landscape, where the land's stark expanses and the chill of the air offer a unique and resilient backdrop.",
    "By the edge of a tundra's icy expanse, where the frozen ground and sparse vegetation create a landscape of tranquil and harsh beauty."
};
        var description = descriptions[random.Next(descriptions.Length)];
        return description;
    } 
}