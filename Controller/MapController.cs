using Debugland;
using TowninatorCLI.Model.MapModels;
using TowninatorCLI.Utilities.misc;
using TowninatorCLI.Utilities.MapUtilities;
using TowninatorCLI.Repositories;
using TowninatorCLI.View;
namespace TowninatorCLI.Controller
{
    public class MapController(string dbFileName)
    {
        private readonly MapRepository _mapRepository = new(dbFileName);
        private readonly MapUtilities _mapUtilities = new(dbFileName);
        private readonly TownRepository _townRepository = new(dbFileName);
        private readonly string _dbFileName = dbFileName;
        public Map GenerateMap(int width, int height)
        {
            #region Debuggin
             Debugger.MethodInitiated($"{nameof(GenerateMap)}");
             Debugger.MethodParameter($"width: {width}, height {height}");
            #endregion
            var townX = width / 2;
            var townY = height / 2;
            #region Debuggin
            Debugger.Variable("townX", $"{townX}");
            Debugger.Variable("townY", $"{townY}");
            #endregion 
            var map = _mapUtilities.GenerateMap(townX, townY, width, height);
            #region Debuggin
 Debugger.Variable($"map", $"{map}");
            Debugger.MethodTerminated($"{nameof(GenerateMap)}");
            #endregion
            return map;
        }

        public void SaveMap(Map map, int townId)
        {
            var town = _townRepository.GetLatestTown();
            town.Id = townId;
            _mapRepository.SaveMap(map, townId);
        }

        public void DisplayMap(long mapId)
        {
            var map = _mapRepository.LoadMap(mapId);
            var mapView = new MapView(_mapRepository);
            mapView.DisplayMap(mapId);
        }

        public void DisplayLatestMap()
        {
            var mapView = new MapView(_mapRepository);
            mapView.DisplayLatestMap();
        }

        public Map? GetMapForTown(int townId)
        {
            var map = _mapRepository.GetMapByTownId(townId); 
            return map;
        }

        public void DisplayMapLegend()
        {
            var mapView = new MapView(_mapRepository);
            mapView.DisplayMapLegend();
        }

    }
}

