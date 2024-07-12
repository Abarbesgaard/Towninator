namespace TowninatorCLI
{
    public class MapController
    {
        private readonly MapRepository mapRepository;
        private readonly string dbFileName;
        private MapUtilities mapUtilities;
        private TownRepository townRepository;



        public MapController(string dbFileName)
        {
            this.dbFileName = dbFileName;
            this.mapRepository = new MapRepository(this.dbFileName);
            mapUtilities = new MapUtilities(this.dbFileName);
            townRepository = new TownRepository(this.dbFileName);

        }

        public Map GenerateMap(int width, int height)
        {
            Console.WriteLine($"[Method]: GenerateMap. Params: width: {width}, height {height}.");

            int townX = width / 2;
            int townY = height / 2;
            Map map = mapUtilities.GenerateMap(townX, townY, width, height); // Pass town coordinates

            return map;
        }

        public void SaveMap(Map map, int townId)
        {
            Console.WriteLine($"[Method]: SaveMap. Params: map {map}, town id {townId}.");
            Town town = townRepository.GetLatestTown();
            town.Id = townId;
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


        public Map? GetMapForTown(int townId)
        {
            Console.WriteLine($"[Method]: MapController.GetMapForTown. Params: townId: {townId}.");

            // Implement the logic to fetch map by town ID from your database or repository
            Map map = mapRepository.GetMapByTownId(townId); // Example method to fetch map

            if (map == null)
            {
                Console.WriteLine($"Map not found for town ID {townId}. Returning null.");
            }


            return map;
        }
        public void DisplayMapLegend()
        {
            MapView mapView = new MapView(mapRepository);
            mapView.DisplayMapLegend();
        }

    }
}

