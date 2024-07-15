namespace TowninatorCLI
{
    public class GenerateWeightedFamilySize
    {
        public int Generate(Random random)
        {
            int[] sizes = { 2, 3, 4, 5 };
            double[] weights = { 0.1, 0.4, 0.4, 0.1 }; // Adjust weights as needed

            double cumulative = 0.0;
            double roll = random.NextDouble();

            for (int i = 0; i < sizes.Length; i++)
            {
                cumulative += weights[i];
                if (roll < cumulative)
                {
                    return sizes[i];
                }
            }

            return sizes[sizes.Length - 1]; // Fallback in case of rounding issues
        }
    }
}
