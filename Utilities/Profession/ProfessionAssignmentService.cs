
namespace TowninatorCLI
{
    public class ProfessionAssignmentService
    {
        private Dictionary<MainTerrainType, Dictionary<Profession, double>> professionWeights;

        public ProfessionAssignmentService()
        {
            // Initialize profession weights based on MainTerrainType
            professionWeights = new Dictionary<MainTerrainType, Dictionary<Profession, double>>();

            // Example weights based on terrain types
            professionWeights[MainTerrainType.Desert] = new Dictionary<Profession, double>
            {
                { Profession.Farmer, 0.3 },
                { Profession.Blacksmith, 0.2 },
                { Profession.Trader, 0.3 },
                // Adjust weights as needed for each terrain type
            };

            professionWeights[MainTerrainType.Forest] = new Dictionary<Profession, double>
            {
                { Profession.Farmer, 0.2 },
                { Profession.Blacksmith, 0.1 },
                { Profession.Teacher, 0.4 },
                // Adjust weights as needed for each terrain type
            };

            professionWeights[MainTerrainType.Grassland] = new Dictionary<Profession, double>
           {
                { Profession.Farmer, 0.4 },
                { Profession.Doctor, 0.2 },
                { Profession.Teacher, 0.2 },
           };

            professionWeights[MainTerrainType.Hill] = new Dictionary<Profession, double>
            {
                { Profession.Farmer, 0.3 },
                { Profession.Blacksmith, 0.2 },
                { Profession.Soldier, 0.4 },
            };
            professionWeights[MainTerrainType.Jungle] = new Dictionary<Profession, double>
            {
                { Profession.Farmer, 0.2 },
                { Profession.Blacksmith, 0.1 },
                { Profession.Teacher, 0.4 },
            };
            professionWeights[MainTerrainType.LowMountain] = new Dictionary<Profession, double>
            {
                { Profession.Farmer, 0.2 },
                { Profession.Blacksmith, 0.1 },
                { Profession.Teacher, 0.4 },
            };
            professionWeights[MainTerrainType.MediumMountain] = new Dictionary<Profession, double>
            {
                { Profession.Farmer, 0.2 },
                { Profession.Blacksmith, 0.1 },
                { Profession.Teacher, 0.4 },
            };
            professionWeights[MainTerrainType.HighMountain] = new Dictionary<Profession, double>
            {
                { Profession.Farmer, 0.2 },
                { Profession.Blacksmith, 0.1 },
                { Profession.Teacher, 0.4 },
            };
            professionWeights[MainTerrainType.Ocean] = new Dictionary<Profession, double>
            {
                { Profession.Farmer, 0.2 },
                { Profession.Blacksmith, 0.1 },
                { Profession.Teacher, 0.4 },
            };
            professionWeights[MainTerrainType.Savannah] = new Dictionary<Profession, double>
            {
                { Profession.Farmer, 0.2 },
                { Profession.Blacksmith, 0.1 },
                { Profession.Teacher, 0.4 },
            };
            professionWeights[MainTerrainType.Swamp] = new Dictionary<Profession, double>
            {
                { Profession.Farmer, 0.2 },
                { Profession.Blacksmith, 0.1 },
                { Profession.Teacher, 0.4 },
            };
            professionWeights[MainTerrainType.Tundra] = new Dictionary<Profession, double>
            {
                { Profession.Farmer, 0.2 },
                { Profession.Blacksmith, 0.1 },
                { Profession.Teacher, 0.4 },
            };

        }

        public Profession AssignProfession(MainTerrainType terrainType, Random random)
        {
            if (professionWeights.ContainsKey(terrainType))
            {
                var weights = professionWeights[terrainType];
                return WeightedRandom(weights, random);
            }
            else
            {
                // Default profession if no specific weights are defined for the terrain type
                return Profession.None;
            }
        }

        private Profession WeightedRandom(Dictionary<Profession, double> weights, Random random)
        {
            double totalWeight = 0.0;
            foreach (var kvp in weights)
            {
                totalWeight += kvp.Value;
            }

            double randomValue = random.NextDouble() * totalWeight;

            foreach (var kvp in weights)
            {
                randomValue -= kvp.Value;
                if (randomValue <= 0)
                {
                    return kvp.Key;
                }
            }

            // Fallback in case of rounding issues
            return weights.Keys.GetEnumerator().Current;
        }
    }
}
