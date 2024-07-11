namespace TowninatorCLI
{
    public class Adj_LowMountain
    {
        public string DescriptionGenerator()
        {
            var random = new Random();
            string[] descriptions = new string[]
    {
         "nestled in the foothills, with gentle slopes and scattered boulders.",
        "surrounded by rolling hills and occasional outcroppings of rock.",
        "in a valley between low peaks, where wildflowers bloom in abundance.",
        "amidst a landscape of low ridges and shallow valleys.",
        "by a winding mountain trail, leading up to higher elevations.",
        "in a sheltered hollow, protected from the harsh winds.",
        "alongside a serene mountain stream, meandering through the low hills.",
        "at the edge of a pine forest that climbs the lower slopes.",
        "overlooking a peaceful alpine meadow, with grazing animals.",
        "in a quiet dell where the sun filters through the sparse tree cover.",
        "surrounded by heather-covered slopes, dotted with ancient standing stones.",
        "by a tranquil lake nestled in the midst of the low mountain range.",
        "on a plateau with sweeping views of the surrounding low peaks.",
        "among scattered groves of aspen trees, their leaves shimmering in the breeze.",
        "by a natural hot spring, bubbling up from deep within the mountains.",
        "near a series of small waterfalls cascading down the rocky terrain.",
        "in the shadow of towering cliffs, worn smooth by centuries of weathering.",
        "beside a hidden cave entrance, leading into the heart of the mountain.",
        "at the base of a winding path that leads to higher elevations.",
        "within a labyrinth of narrow gorges and hidden valleys."
    };

            string description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
