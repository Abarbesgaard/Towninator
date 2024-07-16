using TowninatorCLI.Repositories;
using TowninatorCLI.Utilities.misc;
namespace TowninatorCLI.View
{
    public class TownViewModel(TownRepository townRep, bool debug = false)
    {
        public void ViewLatestTown()
        {
            if (debug) Debugging.WriteNColor("[] TownViewModel.ViewLatestTown() ", ConsoleColor.Green);

            var town = townRep.GetLatestTown();
            Console.Write($"Welcome to the town of ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{town.Name} ");
            Console.ResetColor();
            Console.Write($"\n{town.MainDescription} ");
            Console.WriteLine($"{town.EastDescription} {town.WestDescription} {town.NorthDescription} {town.SouthDescription}");

        }
    }
}
