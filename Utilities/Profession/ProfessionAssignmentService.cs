using TowninatorCLI.Model.MapModels;
namespace TowninatorCLI.Utilities.Profession
{
    public class ProfessionAssignmentService
    {
        private readonly Dictionary<MainTerrainType, Dictionary<Model.Profession, double>> _professionWeights = new()
        {
            // Example weights based on terrain types
            [MainTerrainType.Coastal] = new Dictionary<Model.Profession, double>
            {
                { Model.Profession.Farmer, 0.3 },
                { Model.Profession.Blacksmith, 0.2 },
                { Model.Profession.Trader, 0.3 },
                // Adjust weights as needed for each terrain type
            },
            [MainTerrainType.Forest] = new Dictionary<Model.Profession, double>
            {
                { Model.Profession.Farmer, 0.2 },
                { Model.Profession.Blacksmith, 0.1 },
                { Model.Profession.Berserker, 0.4 },
                // Adjust weights as needed for each terrain type
            },
            [MainTerrainType.Grassland] = new Dictionary<Model.Profession, double>
            {
                { Model.Profession.Farmer, 0.4 },
                { Model.Profession.Hunter, 0.2 },
                { Model.Profession.Hermit, 0.2 },
            },
            [MainTerrainType.Highland] = new Dictionary<Model.Profession, double>
            {
                { Model.Profession.Farmer, 0.3 },
                { Model.Profession.Blacksmith, 0.2 },
                { Model.Profession.Hunter, 0.4 },
            },
            [MainTerrainType.Wetland] = new Dictionary<Model.Profession, double>
            {
                { Model.Profession.Farmer, 0.2 },
                { Model.Profession.Blacksmith, 0.1 },
                { Model.Profession.Hunter, 0.4 },
            },
            [MainTerrainType.LowMountain] = new Dictionary<Model.Profession, double>
            {
                { Model.Profession.Farmer, 0.2 },
                { Model.Profession.Blacksmith, 0.1 },
                { Model.Profession.Hunter, 0.4 },
            },
            [MainTerrainType.MediumMountain] = new Dictionary<Model.Profession, double>
            {
                { Model.Profession.Farmer, 0.2 },
                { Model.Profession.Blacksmith, 0.1 },
                { Model.Profession.Hunter, 0.4 },
            },
            [MainTerrainType.HighMountain] = new Dictionary<Model.Profession, double>
            {
                { Model.Profession.Shaman, 0.2 },
                { Model.Profession.Blacksmith, 0.1 },
                { Model.Profession.Hunter, 0.4 },
            },
            [MainTerrainType.Fjord] = new Dictionary<Model.Profession, double>
            {
                { Model.Profession.Seafarer, 0.2 },
                { Model.Profession.Blacksmith, 0.1 },
                { Model.Profession.Hunter, 0.4 },
            },
            [MainTerrainType.Heath] = new Dictionary<Model.Profession, double>
            {
                { Model.Profession.Farmer, 0.2 },
                { Model.Profession.Blacksmith, 0.1 },
                { Model.Profession.Hunter, 0.4 },
            },
            [MainTerrainType.Marsh] = new Dictionary<Model.Profession, double>
            {
                { Model.Profession.Farmer, 0.2 },
                { Model.Profession.Blacksmith, 0.1 },
                { Model.Profession.Hunter, 0.4 },
            },
            [MainTerrainType.Tundra] = new Dictionary<Model.Profession, double>
            {
                { Model.Profession.Farmer, 0.2 },
                { Model.Profession.Blacksmith, 0.1 },
                { Model.Profession.Hunter, 0.4 },
            },
            [MainTerrainType.Lake] = new Dictionary<Model.Profession, double>()
            {
                {Model.Profession.Fisherman, 0.2},
                {Model.Profession.Fisher, 0.2},
                {Model.Profession.Skald, 0.2},
            },
            
            [MainTerrainType.Meadow] = new Dictionary<Model.Profession, double>()
            {
                {Model.Profession.Farmer, 0.2},
                {Model.Profession.Hermit, 0.2},
                {Model.Profession.Trader, 0.2},
            }
        };
        // Initialize profession weights based on MainTerrainType
        // Example weights based on terrain types
        // Adjust weights as needed for each terrain type
        // Adjust weights as needed for each terrain type

        public Model.Profession AssignProfession(MainTerrainType terrainType, Random random)
        {
            return _professionWeights.TryGetValue(terrainType, out var value) ? WeightedRandom(value, random) :
                // Default profession if no specific weights are defined for the terrain type
                Model.Profession.None;
        }

        private static Model.Profession WeightedRandom(Dictionary<Model.Profession, double> weights, Random random)
        {
            var totalWeight = weights.Sum(kvp => kvp.Value);

            var randomValue = random.NextDouble() * totalWeight;

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
