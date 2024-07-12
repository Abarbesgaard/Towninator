namespace TowninatorCLI
{
    public class MapController
    {
        private readonly MapRepository mapRepository;
        private readonly string dbFileName;
        private MapUtilities mapUtilities;


        public MapController(string dbFileName)
        {
            this.dbFileName = dbFileName;
            this.mapRepository = new MapRepository(this.dbFileName);
            mapUtilities = new MapUtilities(this.dbFileName);
        }

        public Map GenerateMap(int townId, int width, int height)
        {
            Console.WriteLine($"[Method]: GenerateMap. Params: townId: {townId}, width: {width}, height {height}.");

            Map map = new Map(width, height); // Assuming Map constructor accepts width and height
            int townX = width / 2;
            int townY = height / 2;
            mapUtilities.GenerateMap(map, townX, townY); // Pass town coordinates
                                                         // Save map with associated townId

            return map;
        }

        public void SaveMap(Map map, int townId)
        {
            Console.WriteLine($"[Method]: SaveMap. Params: map {map}, town id {townId}.");
            mapRepository.SaveMap(map, townId);
        }

        public void DisplayMap(long mapId)
        {

            Map map = mapRepository.LoadMap(mapId);

            if (map == null)
            {
                return;
            }

            MapView mapView = new MapView(mapRepository);
            mapView.DisplayMap(mapId);
        }

        public void DisplayMapLegend()
        {
            MapView mapView = new MapView(mapRepository);
            mapView.DisplayMapLegend();
        }

    }
}

