using TowninatorCLI.Database;
using TowninatorCLI.Model;
using TowninatorCLI.Utilities.misc;
using TowninatorCLI.View;
using TowninatorCLI.Utilities.MapUtilities;
using TowninatorCLI.Utilities.TownUtilities;
using TowninatorCLI.Repositories;
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
            if (debug) Debugging.WriteNColor("[] TownController.GenerateTown() ", ConsoleColor.Green);
            var randomTown = _generateTown.GenerateRandomTown();

            return randomTown;
        }

        public void SaveTown(Town town, Map map)
        {

            if (debug) Debugging.WriteNColor($"[] TownController.SaveTown( Town {town.Name}, map {map}) ", ConsoleColor.Green);
            _townRep.AddTown(town);
        }

        public void UpdateTown(Town town)
        {
            if (debug) Debugging.WriteNColor($"[] TownController.UpdateTown( Town {town.Name}) ", ConsoleColor.Green);


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
        }

        public void ViewLatestTown()
        {
            if (debug) Debugging.WriteNColor("[] TownController.ViewLatestTown() ", ConsoleColor.Green);
            _townVm.ViewLatestTown();
        }

        public void ViewTownWithTownsfolk(int id)
        {

            if (debug) Console.WriteLine("Viewing town with townsfolk...");
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

