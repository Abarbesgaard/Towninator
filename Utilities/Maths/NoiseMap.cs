namespace TowninatorCLI
{
    public class NoiseMap
    {
        PerlinNoise _perlinNoise = new PerlinNoise();
        public float[,] GenerateNoiseMap(int width, int height, float scale, int octaves)
        {
            float[,] noiseMap = new float[width, height];
            float maxNoiseHeight = float.MinValue;
            float minNoiseHeight = float.MaxValue;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float amplitude = 1;
                    float frequency = 1;
                    float noiseHeight = 0;

                    for (int o = 0; o < octaves; o++)
                    {
                        float sampleX = x / scale * frequency;
                        float sampleY = y / scale * frequency;

                        // Assuming Math.PerlinNoise, adjust as per your noise generation method
                        float perlinValue = _perlinNoise.Noise(sampleX, sampleY);
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
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    noiseMap[x, y] = (noiseMap[x, y] - minNoiseHeight) / (maxNoiseHeight - minNoiseHeight);
                }
            }

            return noiseMap;
        }

    }
}
