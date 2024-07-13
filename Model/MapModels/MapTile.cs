namespace TowninatorCLI
{

    public class MapTile
    {
        public int X { get; }
        public int Y { get; }
        public MainTerrainType Terrain { get; set; }
        public SecondaryTerrainType SecondaryTerrain { get; }
        public MapEvent? Event { get; set; }
        public string? Description { get; set; }
        public bool HasTown { get; set; }

        // Directional flags
        public bool IsNorthOfTown { get; set; }
        public bool IsSouthOfTown { get; set; }
        public bool IsEastOfTown { get; set; }
        public bool IsWestOfTown { get; set; }

        public MapTile(int x, int y, MainTerrainType terrain, SecondaryTerrainType secondaryTerrain, MapEvent? mapEvent = null, bool hasTown = false)
        {
            X = x;
            Y = y;
            Terrain = terrain;
            SecondaryTerrain = secondaryTerrain;
            Event = mapEvent;
            Description = null;
            HasTown = hasTown;

            // Initialize directional flags to false by default
            IsNorthOfTown = false;
            IsSouthOfTown = false;
            IsEastOfTown = false;
            IsWestOfTown = false;
        }

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
                    MainTerrainType.Desert => "~",
                    MainTerrainType.Forest => random.Next(2) == 0 ? "♣" : "♠",
                    MainTerrainType.Grassland => random.Next(2) == 0 ? "." : "ⁿ",
                    MainTerrainType.Hill => random.Next(2) == 0 ? "∩" : "n",
                    MainTerrainType.Jungle => random.Next(2) == 0 ? "♣" : "Γ",
                    MainTerrainType.LowMountain => "⌂",
                    MainTerrainType.MediumMountain => "▲",
                    MainTerrainType.HighMountain => "∆",
                    MainTerrainType.Ocean => "≈",
                    MainTerrainType.Savannah => "S",
                    MainTerrainType.Swamp => "⌠",
                    MainTerrainType.Tundra => "U",
                    _ => "X" // Default symbol if no valid main terrain is provided
                };
            }
        }
    }
}
