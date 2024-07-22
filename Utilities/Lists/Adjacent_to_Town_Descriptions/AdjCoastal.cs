namespace TowninatorCLI.Utilities.Lists.Adjacent_To_Town_Descriptions
{
    public static class AdjCoastal
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new string[]
            {
                "by a sandy beach with gentle waves lapping at the shore, where seagulls circle overhead.",
                "next to a rocky cove where the crashing surf creates a dramatic and picturesque scene.",
                "along a rugged coastline with steep cliffs overlooking the vast, open sea.",
                "beside a bustling harbor where ships of all sizes come and go, adding life to the coastal landscape.",
                "at the mouth of a serene estuary where freshwater meets the saltwater, creating a rich habitat for birds.",
                "near a lighthouse perched on a rocky promontory, guiding sailors safely through the foggy nights.",
                "on a wide, sunlit beach with rolling dunes and scattered shells, framed by the endless horizon of the ocean.",
                "by a tidal pool filled with vibrant sea life, where the ebb and flow of the tides bring new discoveries.",
                "in a coastal village where colorful fishing boats are moored along the docks, ready for the day's catch.",
                "at the base of a sea stack, a towering column of rock rising from the ocean's depths.",
                "by a serene lagoon surrounded by mangroves, where the water is still and teeming with marine life.",
                "on a cliffside overlooking a sweeping bay, where the town's buildings cling to the edge of the precipice.",
                "next to a picturesque fishing pier, where the scent of saltwater and fresh catch fills the air.",
                "in a coastal marsh where saltwater and freshwater mix, creating a unique ecosystem rich with flora and fauna.",
                "by a sandy cove hidden away from the main beaches, offering a quiet and secluded spot to enjoy the sea.",
                "on a grassy knoll overlooking the ocean, where the breeze carries the scent of salt and seaweed.",
                "beside a natural harbor where the water is calm and sheltered, ideal for small boats and watercraft.",
                "near a cluster of seaside cottages, their cheerful colors bright against the backdrop of the ocean waves.",
                "in a coastal wetland, where the interplay of land and sea creates a rich tapestry of wildlife and plant life."
            };

            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
