
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

        private bool debug;
        private readonly TownRepository _townRep;
        private readonly TownViewModel _townVM;
        private readonly MapUtilities _mapUtilities;
        private readonly TownsfolkRepository townsfolkRepository;
        private readonly GenerateTown _generateTown;
        private readonly TownDescriptionUpdater _townDescriptionUpdater;
        private readonly MapController _mapController;
        Random random = new Random();

        public TownController(TownRepository townRep, MapController mapController, string dbFileName, bool debug = false)
        {
            _townRep = new TownRepository(dbFileName, debug);
            _townVM = new TownViewModel(townRep, debug);
            _mapController = mapController;
            _mapUtilities = new MapUtilities(dbFileName);
            townsfolkRepository = new TownsfolkRepository(dbFileName);
            _townDescriptionUpdater = new TownDescriptionUpdater(dbFileName);
            _generateTown = new GenerateTown();
            this.debug = debug;

        }

        public Town GenerateTown()
        {
            if (debug) Debugging.WriteNColor("[] TownController.GenerateTown() ", ConsoleColor.Green);
            Town randomTown = _generateTown.GenerateRandomTown();

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


            Town newTown = _townRep.GetLatestTown();
            newTown = town;
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
            _townVM.ViewLatestTown();
        }

        public void ViewTownWithTownsfolk(int id)
        {

            if (debug) Console.WriteLine("Viewing town with townsfolk...");
            Town? town = _townRep.GetTownById(id);

            if (town == null)
            {
                Console.WriteLine($"Town with ID {id} not found.");
                return;
            }
            _townVM.ViewLatestTown();
        }
    }
}

