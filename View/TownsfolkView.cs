
using TowninatorCLI.Repositories;
using TowninatorCLI.Model;
using System.Text;

namespace TowninatorCLI.View
{
    public class TownsfolkView(string dbFilename)
    {
        private readonly TownsfolkRepository _townsfolkRepository = new(dbFilename);

        public void Display()
        {
            var townsfolk = _townsfolkRepository.GetAll();

            var sb = new StringBuilder();
            sb.AppendLine("Townsfolk Information");
            sb.AppendLine(new string('=', 50));
            foreach (var person in townsfolk)
            {
                sb.AppendLine(GetTownsfolkAscii(person));
                sb.AppendLine(new string('-', 50));
            }

            Console.WriteLine(sb.ToString());
        }

        private static string GetTownsfolkAscii(Townsfolk person)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {person.FirstName} {person.LastName}");
            sb.AppendLine($"Age: {person.Age}");
            sb.AppendLine($"Gender: {person.Gender}");
            sb.AppendLine($"Profession: {person.Profession}");
            sb.AppendLine($"Town ID: {person.TownId}");
            sb.AppendLine($"Origin: {person.Origin}");
            sb.AppendLine($"Region: {person.Region}");
            sb.AppendLine($"Country: {person.Country}");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}

