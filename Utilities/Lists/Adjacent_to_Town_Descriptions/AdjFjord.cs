namespace TowninatorCLI.Utilities.Lists.Adjacent_To_Town_Descriptions
{
    public class AdjFjord
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new string[]
    {
        "where the waves endlessly crash against the shore.",
        "stretching as far as the eye can see, its depths full of mysteries.",
        "with its vast expanse reflecting the colors of the sky.",
        "where the horizon meets the water in a seamless blend of blues.",
        "where seabirds glide over the endless expanse of shimmering waters.",
        "underneath which lies a world teeming with marine life.",
        "where the salty breeze carries tales of distant lands.",
        "offering both tranquility and a sense of boundless freedom.",
        "where ships brave the open waters under the wide-open sky.",
        "where the sun sets over the distant waves in a blaze of colors.",
        "with its calming rhythm soothing the weary soul.",
        "whose depths hide stories of ancient voyages and lost treasures.",
        "where the ocean's melody blends with the whispers of the wind.",
        "where the sound of waves breaking against the shore lulls the mind.",
        "with its endless blue expanse stretching into infinity.",
        "where the ocean meets the sky in a seamless horizon.",
        "with its waves crashing against cliffs in a symphony of nature.",
        "where the tides ebb and flow, marking the passage of time.",
        "with its gentle waves carrying dreams from distant shores.",
        "where the ocean's vastness invites contemplation and wonder."
    };
            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
