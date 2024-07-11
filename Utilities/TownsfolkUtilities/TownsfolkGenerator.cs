namespace TowninatorCLI
{

    public static class TownsfolkGenerator
    {
        public static Townsfolk GenerateRandomTownsfolk()
        {
            Random random = new Random();
            int genderValue = random.Next(0, 2);
            Gender gender = (Gender)genderValue;
            string name;

            if (gender == Gender.Male)
            {
                name = TownsfolkNameGenerator.GenerateMaleName();
            }
            else
            {
                name = TownsfolkNameGenerator.GenerateFemaleName();
            }

            return new Townsfolk
            {
                Gender = gender,
                // Don't set the Id here; it will be set by the TownRepository
                FirstName = name,
                Profession = (Profession)random.Next(1, 9),
                Age = random.Next(1, 100)
            };
        }
    }
}
