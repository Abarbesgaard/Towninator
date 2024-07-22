using TowninatorCLI.Repositories;
using TowninatorCLI.Utilities.misc;
using Spectre.Console;
namespace TowninatorCLI.View;

public class BuildingViewModel(string dbFileName)
{
    private readonly BuildingRepository _buildingRepository = new(dbFileName);

    
        public void ViewBuilding()
        {
            var buildings = _buildingRepository.GetAllBuildings();
            AnsiConsole.MarkupLine($"\nBuildings: [Green]{buildings.Count}[/]");
            foreach (var building in buildings)
            {
                AnsiConsole.Markup($"The {building.SpecificBuilding} called: [Green]{building.Name}[/]. It affects the {building.BuildingType} aspect of the town\n");
            }
            Console.WriteLine("\n");
        } 
        
}