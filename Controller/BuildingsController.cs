using Debugland;
using TowninatorCLI.Utilities.BuildingUtilities;
using TowninatorCLI.View;

namespace TowninatorCLI.Controller
{
    public class BuildingsController(string dbFileName)
    {
        private readonly BuildingGenerator _buildingGenerator = new(dbFileName);
        private readonly BuildingViewModel _buildingViewModel = new(dbFileName);
        public void GenerateBuildings()
        {
            #region Debuggin
            Debugger.MethodInitiated($"{nameof(GenerateBuildings)}");
            #endregion
            _buildingGenerator.GenerateBuilding();
            #region Debuggin
Debugger.MethodTerminated($"{nameof(GenerateBuildings)}");
            #endregion
        }

        public void ViewAllBuildings()
        {
            #region Debuggin
            Debugger.MethodInitiated($"{nameof(ViewAllBuildings)}");
            #endregion
            _buildingViewModel.ViewBuilding();
            #region Debuggin
            Debugger.MethodTerminated($"{nameof(ViewAllBuildings)}");

            #endregion

        }

    }
}
