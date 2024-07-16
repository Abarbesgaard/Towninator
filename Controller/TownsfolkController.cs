using TowninatorCLI.Repositories;
using TowninatorCLI.View;
using TowninatorCLI.Utilities.TownsfolkUtilities;
using TowninatorCLI.Model;
using TowninatorCLI.Utilities.Profession;
namespace TowninatorCLI.Controller
{
    public class TownsfolkController(string dbFileName)
    {

        private readonly TownRepository _townRepository = new(dbFileName);
        private readonly TownsfolkRepository _townsfolkRepository = new(dbFileName);
        private readonly MapController _mapController = new(dbFileName);
        private readonly MapRepository _mapRepository = new(dbFileName);
        private readonly TownsfolkView _townsfolkView = new(dbFileName);


        public void GenerateFamilies(int numberOfFamilies, int townId)
        {
            if (_townRepository.GetTownById(townId) == null)
            {
                throw new Exception($"Town with Id {townId} does not exist.");
            }

            var random = new Random();
            var familySizeGenerator = new GenerateWeightedFamilySize();
            var professionAssignmentService = new ProfessionAssignmentService();
            var townTile = _mapRepository.GetTownPosition();
            if (townTile == null)
            {
                throw new Exception("No town position found in the database.");
            }
            var mainTerrainType = townTile.Terrain;
            for (var i = 0; i < numberOfFamilies; i++)
            {
                // Generate family size
                var familySize = familySizeGenerator.Generate(random);

                // Ensure at least 2 parents (1 male, 1 female) over age 25
                var numAdults = 0;
                var familyMembers = new List<Townsfolk>();

                // Generate parents
                while (numAdults < 2)
                {
                    var parent = TownsfolkGenerator.GenerateRandomTownsfolk();
                    parent.Profession = professionAssignmentService.AssignProfession(mainTerrainType, random);
                    if (parent.Age <= 25 || (parent.Gender != Gender.Male && parent.Gender != Gender.Female)) continue;
                    parent.IsParent = true;
                    familyMembers.Add(parent);
                    numAdults++;
                }

                // Generate children
                var numChildren = familySize - numAdults;
                for (var j = 0; j < numChildren; j++)
                {
                    var child = TownsfolkGenerator.GenerateRandomTownsfolk();
                    child.Profession = Profession.None;
                    child.IsChild = true;
                    familyMembers.Add(child);
                }

                // Assign last name, town ID, and other properties
                var lastName = TownsfolkNameGenerator.GenerateLastName();
                foreach (var member in familyMembers)
                {
                    member.TownId = townId;
                    member.LastName = lastName;
                    member.Origin = "Origin"; // TODO : Replace with actual logic to determine origin
                    member.Region = "Region"; // Replace with actual logic to determine region
                    member.Country = "Country"; // Replace with actual logic to determine country
                    _townsfolkRepository.Add(member);
                }
            }
        }


        public void ViewAllTownsfolk()
        {
            _townsfolkView.Display();
        }

        public void AddSingleTownsfolk(Townsfolk townsfolk) { }
        public void SaveSingleTownsfolk(Townsfolk townsfolk) { }
        public void DeleteSingleTownsfolk(Townsfolk townsfolk) { }
        public void UpdateSingleTownsfolk(Townsfolk townsfolk) { }
    }
}
