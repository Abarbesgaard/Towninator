                 namespace TowninatorCLI.Utilities.Lists.Adjacent_To_Town_Descriptions
{
    public static class AdjMarsh
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new string[]
            {
                "by the edge of a misty marsh, where the water is still and the air is filled with the scent of damp earth and wet vegetation.",
                "on a raised boardwalk winding through the marsh, offering views of the winding channels and the lush growth of reeds and cattails.",
                "next to a tranquil marsh pond, where dragonflies dart above the water and the soft croaking of frogs adds to the ambiance.",
                "in a dense marshland where the land is often wet and muddy, and tall grasses and sedges sway gently in the breeze.",
                "by a small, meandering stream that cuts through the marsh, reflecting the surrounding greenery and providing a habitat for local wildlife.",
                "at the edge of a wide, open marsh where the land stretches out in a patchwork of wetland and open water, with the distant sound of birds calling.",
                "near a cluster of willow trees standing in the marsh, their branches trailing in the water and providing shelter for various creatures.",
                "in a marshy clearing where the ground is soft and the air is rich with the aroma of wet earth and aquatic plants.",
                "by a network of narrow waterways winding through the marsh, with the water shimmering under the light and the sound of rustling reeds.",
                "on a raised platform overlooking the marsh, where the view stretches across the wetland and the calls of wading birds echo in the distance.",
                "in a secluded corner of the marsh where a small, still pond reflects the surrounding reeds and the occasional glimpse of a heron in flight.",
                "next to a boggy area with thick, spongy ground covered in moss and small pools of water, creating a unique and slightly otherworldly landscape.",
                "by a marshy meadow where the land transitions from soft, wet ground to areas of taller grasses and scattered wildflowers.",
                "on a path through the marsh where the ground is uneven and often wet, with the surrounding vegetation creating a dense and lush environment.",
                "in a mist-covered marsh at dawn, where the early morning fog shrouds the landscape and creates a sense of quiet mystery.",
                "near a natural spring feeding into the marsh, where the water is clear and the surrounding area is lush with vibrant green plant life.",
                "by a large, open area of the marsh where the water stretches out and the land is dotted with tufts of grass and the occasional bird.",
                "at the boundary between the marsh and a more solid area, where the transition from wetland to dry land is marked by a rich variety of plant life.",
                "in the heart of the marsh where the landscape is a mix of shallow pools, tall grasses, and the occasional splash of a swimming animal."
            };

            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}

