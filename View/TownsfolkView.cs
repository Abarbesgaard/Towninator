namespace TowninatorCLI
{

    public class TownsfolkView
    {
        public void ViewAllTownsfolk(Town town)
        {
            foreach (var townsfolk in town.Townsfolk ?? new List<Townsfolk>())
            {
                Console.WriteLine($"- Name: {townsfolk.FirstName}");
                Console.WriteLine($"  Gender: {townsfolk.Gender}");
                Console.WriteLine($"  Profession: {townsfolk.Profession}");
                Console.WriteLine($"  Age: {townsfolk.Age}");
            }
        }
    }
}


