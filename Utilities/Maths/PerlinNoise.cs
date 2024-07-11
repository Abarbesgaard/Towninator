namespace TowninatorCLI
{
    public class PerlinNoise
    {
        private int[] permutation;
        private const int GradientSizeTable = 256;

        public PerlinNoise()
        {
            permutation = new int[GradientSizeTable * 2];
            InitPermutation();
        }

        public PerlinNoise(int[] customPermutation)
        {
            if (customPermutation.Length != GradientSizeTable)
            {
                throw new ArgumentException($"Permutation array must have a length of {GradientSizeTable}");
            }

            permutation = new int[GradientSizeTable * 2];
            for (int i = 0; i < GradientSizeTable; i++)
            {
                permutation[i] = permutation[i + GradientSizeTable] = customPermutation[i];
            }
        }

        private void InitPermutation()
        {
            int[] p = new int[GradientSizeTable];

            for (int i = 0; i < GradientSizeTable; i++)
            {
                p[i] = i;
            }

            Random rng = new Random();
            for (int i = 0; i < GradientSizeTable; i++)
            {
                int swapIndex = rng.Next(GradientSizeTable);
                int tmp = p[i];
                p[i] = p[swapIndex];
                p[swapIndex] = tmp;
            }

            for (int i = 0; i < GradientSizeTable; i++)
            {
                permutation[i] = permutation[i + GradientSizeTable] = p[i];
            }
        }

        private float Fade(float t)
        {
            return t * t * t * (t * (t * 6 - 15) + 10);
        }

        private float Gradient(int hash, float x, float y)
        {
            int h = hash & 15;
            float u = h < 8 ? x : y;
            float v = h < 4 ? y : h == 12 || h == 14 ? x : 0;
            return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
        }

        public float Noise(float x, float y)
        {
            int X = (int)Math.Floor(x) & 255;
            int Y = (int)Math.Floor(y) & 255;
            x -= (float)Math.Floor(x);
            y -= (float)Math.Floor(y);
            float u = Fade(x);
            float v = Fade(y);
            int A = permutation[X] + Y, AA = permutation[A], AB = permutation[A + 1], B = permutation[X + 1] + Y, BA = permutation[B], BB = permutation[B + 1];

            return Lerp(v, Lerp(u, Gradient(permutation[AA], x, y), Gradient(permutation[BA], x - 1, y)), Lerp(u, Gradient(permutation[AB], x, y - 1), Gradient(permutation[BB], x - 1, y - 1)));
        }

        public float Lerp(float t, float a, float b)
        {
            return a + t * (b - a);
        }
    }
}

