namespace TowninatorCLI
{
    public static class GenerateTown
    {
        public static Town GenerateRandomTown()
        {
            Random random = new Random();

            // Generate a random number of townsfolk between 30 and 55
            int numberOfTownsfolk = random.Next(30, 56);

            // Initialize a list to hold townsfolk
            List<Townsfolk> townsfolkList = new List<Townsfolk>();

            // Generate townsfolk
            for (int i = 0; i < numberOfTownsfolk; i++)
            {
                townsfolkList.Add(TownsfolkGenerator.GenerateRandomTownsfolk());
            }

            return new Town
            {
                // Don't set the Id here; it will be set by the TownRepository
                Name = TownNameGenerator.GenerateName(),
                Culture = random.Next(1, 5),
                Education = random.Next(1, 5),
                Health = random.Next(1, 5),
                Military = random.Next(1, 5),
                Order = random.Next(1, 5),
                Production = random.Next(1, 5),
                Recreation = random.Next(1, 5),
                Trade = random.Next(1, 5),
                Wealth = random.Next(1, 5),
                Worship = random.Next(1, 5),
                Townsfolk = townsfolkList // Assign the generated townsfolk list
            };
        }
    }
}
