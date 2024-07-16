using TowninatorCLI.Model;
using TowninatorCLI.Repositories;

namespace TowninatorCLI.View;

public class BuildingViewModel(string dbFileName, bool debug = false)
{
    private readonly bool _debug = debug;
    private readonly BuildingRepository _buildingRepository = new(dbFileName, debug);

    public class ViewAllBuildings()
    {
        
        
    }
}