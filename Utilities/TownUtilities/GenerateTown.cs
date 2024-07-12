namespace TowninatorCLI
{
    public class GenerateTown
    {
        public Town GenerateRandomTown()
        {
            Console.WriteLine($"[Method]: GenerateTown.GenerateRandomTown");
            return new Town
            {
                Name = TownNameGenerator.GenerateName(),
                Culture = new Random().Next(1, 5),
                Education = new Random().Next(1, 5),
                Health = new Random().Next(1, 5),
                Military = new Random().Next(1, 5),
                Order = new Random().Next(1, 5),
                Production = new Random().Next(1, 5),
                Recreation = new Random().Next(1, 5),
                Trade = new Random().Next(1, 5),
                Wealth = new Random().Next(1, 5),
                Worship = new Random().Next(1, 5),
            };

        }
    }
}
