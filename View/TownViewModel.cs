namespace TowninatorCLI
{
    public class TownViewModel
    {
        private readonly TownRepository _townRepository;

        public TownViewModel(TownRepository townRep)
        {
            _townRepository = townRep;
        }

        public void ViewLatestTown()
        {
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
