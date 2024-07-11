namespace TowninatorCLI
{
    public class Map
    {
        public MapTile[,] _mapTiles;
        public int Width { get; }
        public int Height { get; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            _mapTiles = new MapTile[width, height];
        }
        public void SetTile(int x, int y, MapTile tile)
        {
            _mapTiles[x, y] = tile;
        }

        public MapTile[,] GetTiles()
        {
            return _mapTiles; // Assuming _mapTiles is your 2D array of MapTile
        }

        public IEnumerable<MapTile> GetAllTiles()
        {
            foreach (var tile in _mapTiles)
            {
                yield return tile;
            }
        }

    }
}

