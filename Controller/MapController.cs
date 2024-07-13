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
            int townX = width / 2;
            int townY = height / 2;
            Map map = mapUtilities.GenerateMap(townX, townY, width, height); // Pass town coordinates

            return map;
        }

        public void SaveMap(Map map, int townId)
        {
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

        public void DisplayLatestMap()
        {
            MapView mapView = new MapView(mapRepository);
            mapView.DisplayLatestMap();
        }

        public Map? GetMapForTown(int townId)
        {
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

