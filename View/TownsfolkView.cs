using TowninatorCLI.Repositories;
using TowninatorCLI.Model;
using Spectre.Console;

namespace TowninatorCLI.View
{
    public class TownsfolkView(string dbFilename)
    {
        private readonly TownsfolkRepository _townsfolkRepository = new(dbFilename);
        public void Display()
        {
            var townsfolk = _townsfolkRepository.GetAll();

            foreach (var panel in from person in townsfolk let panelContent = TownsfolkPanel(person) select new Panel(panelContent)
                         .Header(TownsfolkHeader(person))
                         .Padding(10,1))
            {
                AnsiConsole.Write(panel);
            }
        }

        private static string TownsfolkPanel(Townsfolk person)
        {
            var age = $"{person.Age}";
            var gender = $"{person.Gender}";
            var profession = $"{person.Profession}";
            //TODO : Her skal være flere variabler når de er done

            return $"Age: {age}\nGender: {gender}\nProfession: {profession}";
        }

        private static string TownsfolkHeader(Townsfolk person)
        {
            return $"{person.FirstName} {person.LastName}";
        }
    }
}
