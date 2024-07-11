namespace TowninatorCLI
{
    public static class GenerateTown
    {
        public static Town GenerateRandomTown()
        {
            return new Town
            {
                // Don't set the Id here; it will be set by the TownRepository
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
                Townsfolk = new List<Townsfolk>() // Generate townsfolk if needed
            };
        }
    }
}
