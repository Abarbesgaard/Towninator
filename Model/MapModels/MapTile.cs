namespace TowninatorCLI.Model.MapModels
{

    public class MapTile(
        int x,
        int y,
        MainTerrainType terrain,
        SecondaryTerrainType secondaryTerrain,
        MapEvent? mapEvent = null,
        bool hasTown = false)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
        public MainTerrainType Terrain { get; set; } = terrain;
        public SecondaryTerrainType SecondaryTerrain { get; } = secondaryTerrain;
        public MapEvent? Event { get; set; } = mapEvent;
        public string? Description { get; set; } = null;
        public bool HasTown { get; set; } = hasTown;

        // Directional flags
        public bool IsNorthOfTown { get; set; } = false;
        public bool IsSouthOfTown { get; set; } = false;
        public bool IsEastOfTown { get; set; } = false;
        public bool IsWestOfTown { get; set; } = false;

        // Initialize directional flags to false by default

        public override string ToString()
        {
            if (HasTown)
            {
                return "+"; // Symbol for a tile with a town
            }
            else
            {
                var random = new Random();
                return Terrain switch
                {
                    MainTerrainType.Coastal => "~",
                    MainTerrainType.Forest => random.Next(2) == 0 ? "♣" : "♠",
                    MainTerrainType.Grassland => random.Next(2) == 0 ? "." : "ⁿ",
                    MainTerrainType.Highland => random.Next(2) == 0 ? "∩" : "n",
                    MainTerrainType.Marsh => random.Next(2) == 0 ? "≡" : "%",
                    MainTerrainType.Meadow => "_",
                    MainTerrainType.LowMountain => "⌂",
                    MainTerrainType.MediumMountain => "▲",
                    MainTerrainType.HighMountain => "∆",
                    MainTerrainType.Fjord => "≈",
                    MainTerrainType.Lake => "=",
                    MainTerrainType.Wetland => "⌠",
                    MainTerrainType.Tundra => ".",
                    MainTerrainType.Heath => "«",
                    _ => "X" // Default symbol if no valid main terrain is provided
                };
                        
            }
        }
    }
}
