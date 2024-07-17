using TowninatorCLI.Model;
using TowninatorCLI.Repositories;

namespace TowninatorCLI.View;

public class BuildingViewModel(string dbFileName, bool debug = false)
{
    private readonly bool _debug = debug;
    private readonly BuildingRepository _buildingRepository = new(dbFileName, debug);

    
        public void ViewBuilding()
        {
            var buildings = _buildingRepository.GetAllBuildings();
            Console.WriteLine($"Currently theres {buildings.Count} in this town:\n");
            foreach (var building in buildings)
            {
                Console.WriteLine($"{building.Name}");
            }
            Console.WriteLine("\n");
        } 
        
}