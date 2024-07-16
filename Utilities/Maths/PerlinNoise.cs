namespace TowninatorCLI.Utilities.Maths
{
    public class PerlinNoise
    {
        private readonly int[] _permutation;
        private const int GradientSizeTable = 256;

        public PerlinNoise()
        {
            _permutation = new int[GradientSizeTable * 2];
            InitPermutation();
        }

        public PerlinNoise(int[] customPermutation)
        {
            if (customPermutation.Length != GradientSizeTable)
            {
                throw new ArgumentException($"Permutation array must have a length of {GradientSizeTable}");
            }

            _permutation = new int[GradientSizeTable * 2];
            for (var i = 0; i < GradientSizeTable; i++)
            {
                _permutation[i] = _permutation[i + GradientSizeTable] = customPermutation[i];
            }
        }

        private void InitPermutation()
        {
            var p = new int[GradientSizeTable];

            for (var i = 0; i < GradientSizeTable; i++)
            {
                p[i] = i;
            }

            var rng = new Random();
            for (var i = 0; i < GradientSizeTable; i++)
            {
                var swapIndex = rng.Next(GradientSizeTable);
                (p[i], p[swapIndex]) = (p[swapIndex], p[i]);
            }

            for (var i = 0; i < GradientSizeTable; i++)
            {
                _permutation[i] = _permutation[i + GradientSizeTable] = p[i];
            }
        }

        private static float Fade(float t)
        {
            return t * t * t * (t * (t * 6 - 15) + 10);
        }

        private static float Gradient(int hash, float x, float y)
        {
            var h = hash & 15;
            var u = h < 8 ? x : y;
            var v = h < 4 ? y : h is 12 or 14 ? x : 0;
            return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
        }

        public float Noise(float x, float y)
        {
            var X = (int)Math.Floor(x) & 255;
            var Y = (int)Math.Floor(y) & 255;
            x -= (float)Math.Floor(x);
            y -= (float)Math.Floor(y);
            var u = Fade(x);
            var v = Fade(y);
            int a = _permutation[X] + Y, aa = _permutation[a], ab = _permutation[a + 1], b = _permutation[X + 1] + Y, ba = _permutation[b], bb = _permutation[b + 1];

            return Lerp(v, Lerp(u, Gradient(_permutation[aa], x, y), Gradient(_permutation[ba], x - 1, y)), Lerp(u, Gradient(_permutation[ab], x, y - 1), Gradient(_permutation[bb], x - 1, y - 1)));
        }

        private static float Lerp(float t, float a, float b)
        {
            return a + t * (b - a);
        }
    }
}

