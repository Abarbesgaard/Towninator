namespace TowninatorCLI.Utilities.Lists
{
    public class TownHill
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new string[]
            {
        "A town nestled in rolling hills, where the sun sets over gentle slopes.",
        "Amidst picturesque hills and valleys, a town flourishes in the embrace of nature.",
        "In the heart of undulating hills, where wildflowers bloom and birds soar.",
        "Surrounded by sculpted landscapes and panoramic vistas, a town thrives.",
        "A serene village amidst green hills and winding paths, where life moves at a gentle pace.",
        "Nestled in the quiet embrace of rolling hills, where the air is crisp and clear.",
        "Among lush green hills and tranquil valleys, a town offers a peaceful sanctuary.",
        "In the shadow of towering peaks and winding trails, a town finds harmony with nature.",
        "A town perched on rolling hills, where the horizon stretches into the distance.",
        "Surrounded by sweeping slopes and golden fields, a town embodies rural tranquility.",
        "A village nestled among verdant hills and scattered orchards, where time moves leisurely.",
        "Embraced by the curves of gentle hills, a town enjoys the beauty of its natural surroundings.",
        "At the edge of expansive meadows and winding country lanes, a town welcomes visitors.",
        "In the heart of green hills and sunlit valleys, where the breeze carries the scent of wildflowers.",
        "Amidst quiet hills and shaded groves, a town offers respite from bustling city life.",
        "A community nestled in the gentle folds of rolling hills, where peace reigns supreme.",
        "Where hills meet sky and the land stretches wide, a town finds its place in the world.",
        "In the tranquil embrace of hills and valleys, a town's spirit echoes through the landscape.",
        "Nestled in the curves of rolling hills, where each rise and fall tells a story of its own.",
        "Among undulating landscapes and winding paths, a town thrives amidst natural beauty."
    }; 
            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
