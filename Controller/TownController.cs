
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
        private readonly TownRepository _townRep;
        private readonly TownViewModel _townVM;
        private readonly MapUtilities _mapUtilities;
        private readonly TownsfolkRepository townsfolkRepository;
        private readonly GenerateTown _generateTown;
        private readonly TownDescriptionUpdater _townDescriptionUpdater;
        private readonly MapController _mapController;
        Random random = new Random();

        public TownController(TownRepository townRep, MapController mapController, string dbFileName)
        {
            _townRep = townRep;
            _townVM = new TownViewModel(townRep);
            _mapController = mapController;
            _mapUtilities = new MapUtilities(dbFileName);
            townsfolkRepository = new TownsfolkRepository(dbFileName);
            _townDescriptionUpdater = new TownDescriptionUpdater(dbFileName);
            _generateTown = new GenerateTown();
        }

        public Town GenerateTown()
        {
            Town randomTown = _generateTown.GenerateRandomTown();

            return randomTown;
        }

        public void SaveTown(Town town, Map map)
        {
            _townRep.AddTown(town);
        }

        public void UpdateTown(Town town)
        {
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
            _townVM.ViewLatestTown();
        }

        public void ViewTownWithTownsfolk(int id)
        {
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

