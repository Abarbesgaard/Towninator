namespace TowninatorCLI.Utilities.Lists.Adjacent_To_Town_Descriptions
{
    public class AdjHighMountain
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new string[]
    {
        "near the edge of a deep ravine, with steep cliffs and a distant waterfall.",
        "on a narrow path winding between towering peaks, offering glimpses of distant valleys.",
        "amidst sparse vegetation on a high plateau, overlooking jagged mountain ranges.",
        "along a rocky ridge with sheer drops on either side, where the wind howls relentlessly.",
        "in a secluded valley blanketed by thick mist, with echoes of wildlife in the distance.",
        "by a crystal-clear mountain lake reflecting the snow-capped peaks above.",
        "beside a cascading mountain stream, where the water rushes over smooth stones.",
        "on a grassy slope dotted with wildflowers, leading up to rugged mountain trails.",
        "at a mountain pass where the trail splits, offering routes to different scenic vistas.",
        "amidst dense pine forests and the scent of resin, with sunlight filtering through the canopy.",
        "by a tranquil meadow dotted with grazing deer, framed by towering mountain walls.",
        "near ancient ruins perched on a cliffside, remnants of a bygone civilization.",
        "on a rocky outcrop overlooking a vast expanse of untouched wilderness.",
        "by a cluster of hot springs, steaming in the crisp mountain air.",
        "in a valley of colorful alpine flowers, where bees buzz in the warm sunlight.",
        "alongside a narrow gorge cut deep into the mountain, with a narrow footbridge crossing it.",
        "in the shadow of a towering monolith, a landmark visible from miles around.",
        "at the mouth of a cavern leading deep into the heart of the mountain.",
        "beside a natural arch formed by millennia of wind and water erosion.",
        "in a clearing where ancient trees grow, their gnarled roots twisting into the earth."
    };
            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
