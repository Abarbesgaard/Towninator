
namespace TowninatorCLI
{
    public enum Direction
    {
        North,
        South,
        East,
        West
    }

    public class TownController
    {
        private readonly TownRepository _townRep;
        private readonly TownViewModel _townVM;
        private readonly TownsfolkView _townsfolkView;
        private readonly MapController _mapController;
        private readonly MapUtilities _mapUtilities;

        public TownController(TownRepository townRep, MapController mapController, string dbFileName)
        {
            _townRep = townRep;
            _townVM = new TownViewModel(townRep);
            _townsfolkView = new TownsfolkView();
            _mapController = mapController;
            _mapUtilities = new MapUtilities(dbFileName);

        }

        public void AddTown(int townId)
        {
            Town randomTown = GenerateTown.GenerateRandomTown();

            Map map = _mapController.GenerateMap(townId, 20, 20); // Assuming a 20x20 map for example

            // TODO: Move this logic to a separate class
            // Determine town coordinates, for example, the center of the map
            int townX = map.Width / 2;
            int townY = map.Height / 2;

            // Get terrain type at town location
            MainTerrainType? terrain = _mapUtilities.GetTerrainAt(townX, townY, map.Height, map.Width, map.GetTiles());
            // TODO: move this logic to a separate class
            string mainDescription = _mapUtilities.GetTownDescriptionBasedOnTerrain(terrain);
            string northDescription = GetDirectionalTownDescriptionFromTerrain(terrain, Direction.North, map, townX, townY);
            string southDescription = GetDirectionalTownDescriptionFromTerrain(terrain, Direction.South, map, townX, townY);
            string eastDescription = GetDirectionalTownDescriptionFromTerrain(terrain, Direction.East, map, townX, townY);
            string westDescription = GetDirectionalTownDescriptionFromTerrain(terrain, Direction.West, map, townX, townY);

            // Assign generated values to the randomTown object
            randomTown.Id = townId;
            randomTown.MainDescription = mainDescription;
            randomTown.NorthDescription = northDescription;
            randomTown.SouthDescription = southDescription;
            randomTown.EastDescription = eastDescription;
            randomTown.WestDescription = westDescription;

            // Create and save town with descriptions
            _townRep.AddTown(randomTown);
        }
        // TODO: Move this method to a separate class
        private string GetDirectionalTownDescriptionFromTerrain(MainTerrainType? terrain, Direction direction, Map map, int townX, int townY)
        {
            // Calculate adjacent coordinates based on direction
            int adjX = townX, adjY = townY;
            switch (direction)
            {
                case Direction.North: adjY -= 1; break;
                case Direction.South: adjY += 1; break;
                case Direction.East: adjX += 1; break;
                case Direction.West: adjX -= 1; break;
                default: return $"Unknown direction {direction}";
            }

            // Get terrain type of adjacent tile
            MainTerrainType? adjacentTerrain = _mapUtilities.GetTerrainOfAdjacentTile(map, direction);

            // Determine direction description based on direction enum
            string directionDescription = direction switch
            {
                Direction.North => "To the north",
                Direction.South => "To the south",
                Direction.East => "To the east",
                Direction.West => "To the west",
                _ => "in an unknown direction"
            };

            Adj_HighMountain adj_HighMountain = new Adj_HighMountain();
            Adj_MediumMountain adj_MediumMountain = new Adj_MediumMountain();
            Adj_LowMountain adj_LowMountain = new Adj_LowMountain();
            Adj_Forest adj_Forest = new Adj_Forest();
            Adj_Ocean adj_Ocean = new Adj_Ocean();
            Adj_Swamp adj_Swamp = new Adj_Swamp();
            Adj_Hill adj_Hill = new Adj_Hill();
            Adj_Grassland adj_Grassland = new Adj_Grassland();
            string terrainDescription = adjacentTerrain switch
            {
                MainTerrainType.HighMountain => $"{directionDescription} {adj_HighMountain.DescriptionGenerator()}",
                MainTerrainType.MediumMountain => $"{directionDescription} {adj_MediumMountain.DescriptionGenerator()}",
                MainTerrainType.LowMountain => $"{directionDescription} {adj_LowMountain.DescriptionGenerator()}",
                MainTerrainType.Forest => $"{directionDescription} {adj_Forest.DescriptionGenerator()}",
                MainTerrainType.Ocean => $"{directionDescription} {adj_Ocean.DescriptionGenerator()}",
                MainTerrainType.Grassland => $"{directionDescription} {adj_Grassland.DescriptionGenerator()}",
                MainTerrainType.Swamp => $"{directionDescription} {adj_Swamp.DescriptionGenerator()}",
                MainTerrainType.Hill => $"{directionDescription} {adj_Hill.DescriptionGenerator()}",
                _ => $"{directionDescription} lies an unknown terrain."
            };

            return terrainDescription;
        }

        // TODO: move this method to a separate class
        public MainTerrainType? GetTerrainAt(int x, int y, int height, int width, IEnumerable<MapTile> mapTiles)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                return MainTerrainType.Ocean; // Return Ocean if out of map bounds
            }

            // Find the tile at the specified coordinates
            foreach (var tile in mapTiles)
            {
                if (tile.X == x && tile.Y == y) // Assuming MapTile has X and Y properties
                {
                    return tile.Terrain; // Return terrain type of the tile
                }
            }

            // Handle case where tile at (x, y) was not found (this should not normally occur if mapTiles is complete)
            throw new InvalidOperationException("Tile at specified coordinates not found.");
        }


        public void ViewTown(int id)
        {
            _townVM.ViewTown(id);
        }

        public void ViewTownWithTownsfolk(int id)
        {
            // Get the town from repository
            Town? town = _townRep.GetTownById(id);

            if (town == null)
            {
                Console.WriteLine($"Town with ID {id} not found.");
                return;
            }

            // Display town details
            _townVM.ViewTown(id);

            // Display townsfolk details using TownsfolkView
            _townsfolkView.ViewAllTownsfolk(town);
        }
    }
}

