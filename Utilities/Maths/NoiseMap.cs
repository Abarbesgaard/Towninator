using TowninatorCLI.Utilities.misc;
namespace TowninatorCLI.Utilities.Maths
{
    public class NoiseMap(bool debug = false)
    {
        private readonly PerlinNoise _perlinNoise = new PerlinNoise();

        public float[,] GenerateNoiseMap(int width, int height, float scale, int octaves)
        {
            if (debug) Debugging.WriteNColor($"[] NoiseMap.GenerateNoiseMap( width: {width}, height: {height}, scale: {scale}, octaves: {octaves} )", ConsoleColor.Green);
            var noiseMap = new float[width, height];
            var maxNoiseHeight = float.MinValue;
            var minNoiseHeight = float.MaxValue;

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    float amplitude = 1;
                    float frequency = 1;
                    float noiseHeight = 0;

                    for (var o = 0; o < octaves; o++)
                    {
                        var sampleX = x / scale * frequency;
                        var sampleY = y / scale * frequency;

                        // Assuming Math.PerlinNoise, adjust as per your noise generation method
                        var perlinValue = _perlinNoise.Noise(sampleX, sampleY);
                        noiseHeight += perlinValue * amplitude;

                        amplitude *= 0.5f;
                        frequency *= 2;
                    }

                    if (noiseHeight > maxNoiseHeight)
                        maxNoiseHeight = noiseHeight;
                    else if (noiseHeight < minNoiseHeight)
                        minNoiseHeight = noiseHeight;

                    noiseMap[x, y] = noiseHeight;
                }
            }

            // Normalize the noise map to a range between 0 and 1
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    noiseMap[x, y] = (noiseMap[x, y] - minNoiseHeight) / (maxNoiseHeight - minNoiseHeight);
                }
            }

            return noiseMap;
        }

    }
}
