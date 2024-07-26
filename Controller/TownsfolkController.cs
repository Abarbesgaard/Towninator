using TowninatorCLI.Repositories;
using TowninatorCLI.View;
using TowninatorCLI.Utilities.TownsfolkUtilities;
using TowninatorCLI.Model;
using System.Linq;
using TowninatorCLI.Model.MapModels;
using TowninatorCLI.Utilities.misc;
using TowninatorCLI.Utilities.Profession;
namespace TowninatorCLI.Controller
{
    public class TownsfolkController(string dbFileName)
    {

        private readonly TownRepository _townRepository = new(dbFileName);
        private readonly TownsfolkRepository _townsfolkRepository = new(dbFileName);
        private readonly MapRepository _mapRepository = new(dbFileName);
        private readonly TownsfolkView _townsfolkView = new(dbFileName);
        private readonly Random _random = new();


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
                    parent.IsAlive = true;
                    parent.SkillLevel = (ProfessionSkillLevel)_random.Next(1, 6);
                    parent.Charisma = _random.Next(4, 10);
                    parent.Strength = _random.Next(4, 10);
                    parent.Intelligence = _random.Next(4, 10);
                    parent.Wisdom = _random.Next(4, 10);
                    parent.Dexterity = _random.Next(4, 10);
                    parent.Constitution = _random.Next(4, 10);
                    parent.Luck = _random.Next(4, 10);
                    parent.Sanity = _random.Next(7, 10);
                    parent.Perception = _random.Next(4, 10);
                    parent.Willpower = _random.Next(4, 10);
                    parent.Faith = _random.Next(4, 10);
                    parent.Terrain = GetMapTerrain();
                    
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
                    child.IsAlive = true;
                    child.SkillLevel = ProfessionSkillLevel.None;
                    child.Charisma = _random.Next(1, 5);
                    child.Strength = _random.Next(1, 5);
                    child.Intelligence = _random.Next(1, 5);
                    child.Wisdom = _random.Next(1, 5);
                    child.Dexterity = _random.Next(1, 5);
                    child.Constitution = _random.Next(1, 5);
                    child.Luck = _random.Next(1, 5);
                    child.Sanity = _random.Next(1, 5);
                    child.Perception = _random.Next(1, 5);
                    child.Willpower = _random.Next(1, 5);
                    child.Faith = _random.Next(1, 5);
                    child.Terrain =  GetMapTerrain();
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

        private MainTerrainType GetMapTerrain()
        {
            // Retrieve the latest map from the repository
            var map = _mapRepository.GetTownPosition();
            // Check if the map has a town and return its ID
            if (map != null && map.HasTown)
            {
                return map.Terrain;
            }

            // Handle the case where no map tile with HasTown = true was found
            throw new InvalidOperationException("No map tile with HasTown = true found.");
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
