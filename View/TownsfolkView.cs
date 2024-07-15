
using System.Text;

namespace TowninatorCLI
{
    public class TownsfolkView
    {
        private readonly TownsfolkRepository _townsfolkRepository;
        public TownsfolkView(string dbFilename)
        {
            _townsfolkRepository = new TownsfolkRepository(dbFilename);
        }

        public void Display()
        {
            List<Townsfolk> _townsfolk = _townsfolkRepository.GetAll();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Townsfolk Information");
            sb.AppendLine(new string('=', 50));
            foreach (var person in _townsfolk)
            {
                sb.AppendLine(GetTownsfolkAscii(person));
                sb.AppendLine(new string('-', 50));
            }

            Console.WriteLine(sb.ToString());
        }

        private string GetTownsfolkAscii(Townsfolk person)
        {
            StringBuilder sb = new StringBuilder();
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

