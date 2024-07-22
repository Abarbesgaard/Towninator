namespace TowninatorCLI.Utilities.Lists;

public static class TownMeadow
{
    public static string DescriptionGenerator()
    {
        var random = new Random();
        var descriptions = new[]
        {
            "A town nestled within the sprawling marshlands, where the landscape is marked by reeds, wetlands, and the murmur of wildlife.",
            "In the heart of a vast marsh, where the land is a tapestry of wet grasses and slow-moving streams, a town thrives amidst the reeds.",
            "By the edge of a sprawling marsh, where the land's lush greenery and the meandering waterways create a unique and tranquil setting.",
            "A community set amidst the marsh's rich tapestry of waterlogged grasses and tangled underbrush, where the air is alive with the sounds of nature.",
            "In a marshy haven, where the land is dotted with bogs and the slow-moving waters reflect the vibrant greenery surrounding the town.",
            "On the fringes of a great marsh, where the land's mix of wetland flora and shallow pools offers a distinctive and peaceful retreat.",
            "A town amid the marsh's lush vegetation and winding channels, where the landscape is shaped by water and the growth of hardy plants.",
            "Among the reeds and water channels of the marsh, where the town's presence adds a touch of human life to the verdant, wet landscape.",
            "By the edge of a dense marshland, where the intertwining waterways and dense foliage create a haven for both wildlife and town life.",
            "In the midst of a sprawling marsh, where the wet ground and tall grasses form a rich and verdant backdrop for a thriving community.",
            "A village nestled in the marsh, where the network of streams and the dense vegetation create a serene and enigmatic atmosphere.",
            "Surrounded by the lush, swampy expanse of the marsh, where the still waters and dense plant life form a unique and thriving habitat.",
            "On the edge of a murky marsh, where the landscape is marked by brackish waters and thick growths of reeds and moss.",
            "A town set within the marsh's tangled waterways and verdant growths, where the land's wet nature defines its character.",
            "In a marshy enclave, where the land's mix of pools, grasses, and wildlife creates a serene yet untamed environment.",
            "Among the slow-moving waters and dense reeds of the marsh, where the town stands as a beacon of life in the wetland expanse.",
            "In the heart of a lush marsh, where the intertwining channels and vibrant greenery offer a unique and peaceful setting for a town.",
            "By the edge of the marshland, where the landscape is defined by its wet, boggy terrain and the constant hum of life within the reeds.",
            "A community amidst the marsh's rich wetlands, where the still waters and dense vegetation create an environment of quiet beauty.",
            "On the outskirts of a vast marsh, where the interplay of water and plant life forms a serene and captivating backdrop for a town."
        };
        var description = descriptions[random.Next(descriptions.Length)];
        return description;
    }
}