namespace TowninatorCLI.Utilities.TownsfolkUtilities
{
    public class GenerateWeightedFamilySize
    {
        public int Generate(Random random)
        {
            int[] sizes = [2, 3, 4, 5];
            double[] weights = [0.1, 0.4, 0.4, 0.1]; // Adjust weights as needed

            var cumulative = 0.0;
            var roll = random.NextDouble();

            for (var i = 0; i < sizes.Length; i++)
            {
                cumulative += weights[i];
                if (roll < cumulative)
                {
                    return sizes[i];
                }
            }

            return sizes[^1]; // Fallback in case of rounding issues
        }
    }
}
