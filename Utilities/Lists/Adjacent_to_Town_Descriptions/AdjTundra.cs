namespace TowninatorCLI.Utilities.Lists.Adjacent_To_Town_Descriptions
{
    public static class AdjTundra
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new[]
            {
                "by the edge of a vast tundra, where the land is covered in a blanket of frost and the horizon stretches endlessly under a pale sky.",
                "on a windswept plateau overlooking the tundra, where the icy wind whistles across the open expanse and the ground is dotted with hardy shrubs.",
                "next to a frozen lake in the tundra, where the surface is covered in a thick layer of ice and the surrounding area is blanketed in snow.",
                "in a stark, open tundra where the ground is sparse and the low, resilient vegetation survives in the harsh, cold environment.",
                "by a rocky outcrop in the tundra, where the rugged terrain contrasts with the flat, snow-covered plains stretching out in all directions.",
                "at the boundary of a tundra where the land transitions from icy plains to rocky outcrops, with the occasional patch of moss and lichen.",
                "in a frosty valley within the tundra, where the snow-clad hills rise gently and the cold air is crisp and invigorating.",
                "next to a small, partially frozen river winding through the tundra, where the water flows sluggishly beneath a thin layer of ice.",
                "on a high ridge overlooking the tundra, where the wind howls and the view stretches over a desolate, snow-covered landscape.",
                "by a cluster of hardy, low-growing plants that manage to survive in the harsh conditions of the tundra, surrounded by a sea of white snow.",
                "in a cold, open expanse of tundra where the ground is covered with a thin layer of snow and the sky is a wide, unbroken expanse of gray.",
                "at the edge of a frozen marsh in the tundra, where the water is solid and the land is scattered with patches of resilient, frost-tolerant plants.",
                "near a small, snow-draped settlement where the structures are built to withstand the harsh tundra climate and the snow-covered landscape is expansive.",
                "by a deep ravine in the tundra, where the ice-cold wind cuts through the rugged terrain and the landscape is marked by dramatic, frozen features.",
                "in a desolate expanse of tundra where the sky is often overcast and the ground is covered in a thick layer of snow and ice.",
                "on a frosty knoll overlooking a tundra valley, where the cold air is crisp and the landscape is dotted with sparse, hardy vegetation.",
                "by a rocky plateau in the tundra, where the landscape is shaped by the relentless winds and the snow-covered terrain stretches out in all directions.",
                "in a snow-covered valley with occasional patches of frozen ground and low, hardy shrubs surviving in the harsh conditions of the tundra.",
                "at the edge of a windswept tundra plain, where the cold wind sweeps across the open land and the snow-covered ground creates a stark, beautiful landscape."
            };

            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
