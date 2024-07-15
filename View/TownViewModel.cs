namespace TowninatorCLI
{
    public class TownViewModel
    {
        private readonly TownRepository _townRepository;
        private bool debug;


        public TownViewModel(TownRepository townRep, bool debug = false)
        {
            this.debug = debug;
            _townRepository = townRep;
        }

        public void ViewLatestTown()
        {
            if (debug) Debugging.WriteNColor("[] TownViewModel.ViewLatestTown() ", ConsoleColor.Green);

            Town? town = _townRepository.GetLatestTown();
            if (town == null)
            {
                Console.WriteLine($"Town not found.");
                return;
            }
            Console.Write($"Welcome to the town of ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{town.Name} ");
            Console.ResetColor();
            Console.Write($"\n{town.MainDescription} ");
            Console.WriteLine($"{town.EastDescription} {town.WestDescription} {town.NorthDescription} {town.SouthDescription}");

        }
    }
}
