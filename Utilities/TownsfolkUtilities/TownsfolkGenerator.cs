using TowninatorCLI.Model;
namespace TowninatorCLI.Utilities.TownsfolkUtilities
{

    public static class TownsfolkGenerator
    {

        public static Townsfolk GenerateRandomTownsfolk()
        {
            var random = new Random();
            var genderValue = random.Next(0, 2);
            var gender = (Gender)genderValue;

            var name = gender == Gender.Male ? TownsfolkNameGenerator.GenerateMaleName() : TownsfolkNameGenerator.GenerateFemaleName();

            return new Townsfolk
            {
                Gender = gender,
                FirstName = name,
                Profession = (Model.Profession)random.Next(1, 9),
                Age = random.Next(1, 100)
            };
        }
    }
}
