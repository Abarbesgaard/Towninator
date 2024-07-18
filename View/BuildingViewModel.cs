using TowninatorCLI.Repositories;
using TowninatorCLI.Utilities.misc;
using Spectre.Console;
namespace TowninatorCLI.View;

public class BuildingViewModel(string dbFileName, bool debug = false)
{
    private readonly BuildingRepository _buildingRepository = new(dbFileName, debug);

    
        public void ViewBuilding()
        {
            if (debug) Debugging.WriteNColor("ViewBuilding()", ConsoleColor.Blue);
            var buildings = _buildingRepository.GetAllBuildings();
            Console.WriteLine($"Currently theres {buildings.Count} in this town:\n");
            foreach (var building in buildings)
            {
                AnsiConsole.WriteLine($"{building.Name}");
            }
            Console.WriteLine("\n");
        } 
        
}