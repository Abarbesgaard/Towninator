using TowninatorCLI.Model;
using TowninatorCLI.Model.MapModels;
using TowninatorCLI.Utilities.misc;
using TowninatorCLI.View;
using TowninatorCLI.Utilities.MapUtilities;
using TowninatorCLI.Utilities.TownUtilities;
using TowninatorCLI.Repositories;
using Debugland;


namespace TowninatorCLI.Controller
{
    public enum Direction
    {
        North,
        South,
        East,
        West
    }

    public class TownController(
        TownRepository townRep,
        MapController mapController,
        string dbFileName,
        bool debug = false)
    {
        private readonly TownRepository _townRep = new(dbFileName, debug);
        private readonly TownViewModel _townVm = new(townRep, debug);
        private readonly MapUtilities _mapUtilities = new(dbFileName);
        private readonly TownsfolkRepository _townsfolkRepository = new(dbFileName);
        private readonly GenerateTown _generateTown = new(debug);
        private readonly TownDescriptionUpdater _townDescriptionUpdater = new(dbFileName);
        private readonly MapController _mapController = mapController;
        private Random _random = new Random();

        public Town GenerateTown()
        {
            #region Debuggin
            Debugger.MethodInitiated($"{nameof(GenerateTown)}");
            #endregion 
            var randomTown = _generateTown.GenerateRandomTown();
            #region Debuggin
            Debugger.Variable("randomTown", $"{randomTown}");
            Debugger.MethodTerminated($"{nameof(GenerateTown)}");
            #endregion
            return randomTown;
        }

        public void SaveTown(Town town, Map map)
        {
            #region Debuggin
            Debugger.MethodInitiated($"{nameof(SaveTown)}");
            Debugger.MethodParameter($"Town {town.Name}, Map {map}");
            #endregion
            _townRep.AddTown(town);
            #region Debuggin
            Debugger.MethodTerminated($"{nameof(SaveTown)}");
            #endregion
        }

        public void UpdateTown(Town town)
        {
            #region Debuggin
            Debugger.MethodInitiated($"{nameof(UpdateTown)}");
            Debugger.MethodParameter($"Town {town.Name}");
            #endregion
            _townRep.GetLatestTown();
            _townDescriptionUpdater.UpdateTownDescriptions(town);
            try
            {
                _townRep.UpdateTownDescriptions(town);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to update town directional descriptions: {e.Message}");
            }
            #region Debuggin
            Debugger.MethodTerminated($"{nameof(UpdateTown)}");
            #endregion
        }

        public void ViewLatestTown()
        {
            #region Debuggin
            Debugger.MethodInitiated($"{nameof(ViewLatestTown)}");
            #endregion
            _townVm.ViewLatestTown();

            #region Debuggin
            Debugger.MethodTerminated($"{nameof(ViewLatestTown)}");
            #endregion
        }

        public void ViewTownWithTownsfolk(int id)
        {

            if (debug) Debugging.WriteNColor($"TownController.ViewTownWithTownsfolk(id {id})", ConsoleColor.Blue); 
            var town = _townRep.GetTownById(id);

            if (town == null)
            {
                Console.WriteLine($"Town with ID {id} not found.");
                return;
            }
            _townVm.ViewLatestTown();
        }
    }
}

