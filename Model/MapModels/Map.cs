namespace TowninatorCLI.Model.MapModels
{
    public class Map
    {
        public int Id { get; set; }
        private readonly MapTile[,] _mapTiles;
        public int Width { get; init; }
        public int Height { get; init; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            _mapTiles = new MapTile[width, height];
        }

        public Map()
        {
            throw new NotImplementedException();
        }

        public void SetTile(int x, int y, MapTile tile)
        {
            _mapTiles[x, y] = tile;
        }

        public MapTile[,] GetTiles()
        {
            return _mapTiles; // Assuming _mapTiles is your 2D array of MapTile
        }

        public IEnumerable<MapTile?> GetAllTiles()
        {
            return _mapTiles.Cast<MapTile?>();
        }

        public MapTile? GetTile(int x, int y)
        {
            // Check if (x, y) are within bounds
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return null; // Return null or throw exception based on your design
            }

            return _mapTiles[x, y];
        }

    }
}

