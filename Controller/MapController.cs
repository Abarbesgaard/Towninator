using TowninatorCLI.Model.MapModels;
using TowninatorCLI.Utilities.misc;
using TowninatorCLI.Utilities.MapUtilities;
using TowninatorCLI.Repositories;
using TowninatorCLI.View;
namespace TowninatorCLI.Controller
{
    public class MapController(string dbFileName, bool debug = false)
    {
        private readonly MapRepository _mapRepository = new(dbFileName);
        private readonly MapUtilities _mapUtilities = new(dbFileName, debug);
        private readonly TownRepository _townRepository = new(dbFileName);
        private readonly string _dbFileName = dbFileName;
        public Map GenerateMap(int width, int height)
        {
            if (debug) Debugging.WriteNColor($"[] MapController.GenerateMap(width {width}, height {height})", ConsoleColor.Green);
            var townX = width / 2;
            var townY = height / 2;
            var map = _mapUtilities.GenerateMap(townX, townY, width, height); // Pass town coordinates

            return map;
        }

        public void SaveMap(Map map, int townId)
        {
            if (debug) Debugging.WriteNColor($"MapController.SaveMap(map: {map}, townId: {townId}", ConsoleColor.Green);
            var town = _townRepository.GetLatestTown();
            town.Id = townId;
            _mapRepository.SaveMap(map, townId);
        }

        public void DisplayMap(long mapId)
        {
            if (debug) Debugging.WriteNColor($"MapController.DisplayMap(mapId: {mapId})", ConsoleColor.Blue);
            var map = _mapRepository.LoadMap(mapId);
            var mapView = new MapView(_mapRepository);
            mapView.DisplayMap(mapId);
        }

        public void DisplayLatestMap()
        {
            if (debug) Debugging.WriteNColor("MapController.DisplayLatestMap()", ConsoleColor.Blue);
            var mapView = new MapView(_mapRepository);
            mapView.DisplayLatestMap();
        }

        public Map? GetMapForTown(int townId)
        {
            if (debug) Debugging.WriteNColor($"MapController.GetMapForTown(townId {townId}", ConsoleColor.Green);
            var map = _mapRepository.GetMapByTownId(townId); 
            return map;
        }

        public void DisplayMapLegend()
        {
            if (debug) Debugging.WriteNColor("MapController.DisplayMapLegend()", ConsoleColor.Blue);
            var mapView = new MapView(_mapRepository);
            mapView.DisplayMapLegend();
        }

    }
}

