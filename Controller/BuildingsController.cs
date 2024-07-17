using TowninatorCLI.Model;
using TowninatorCLI.Repositories;
using TowninatorCLI.Utilities.BuildingUtilities;
using TowninatorCLI.View;
using TowninatorCLI.Utilities.misc;

namespace TowninatorCLI.Controller
{
    public class BuildingsController(string dbFileName, bool debug = false)
    {
        private readonly BuildingRepository _buildingRep = new(dbFileName, debug);
        private readonly BuildingGenerator _buildingGenerator = new(dbFileName, debug);
        private readonly BuildingViewModel _buildingViewModel = new(dbFileName, debug);

        public void GenerateBuildings()
        {
            if (debug) Debugging.WriteNColor("[] BuildingsController.GenerateBuilding() ", ConsoleColor.Green);
            _buildingGenerator.GenerateBuilding();
        }

        public void ViewAllBuildings()
        {
            _buildingViewModel.ViewBuilding();

        }

    }
}
