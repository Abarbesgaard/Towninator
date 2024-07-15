namespace TowninatorCLI
{
    public class TownsfolkController
    {

        private readonly TownRepository _townRepository;
        private readonly TownsfolkRepository _townsfolkRepository;
        private readonly MapController _mapController;
        private readonly MapRepository _mapRepository;
        private readonly TownsfolkView _townsfolkView;

        public TownsfolkController(string dbFileName)
        {
            _townRepository = new TownRepository(dbFileName);
            _townsfolkRepository = new TownsfolkRepository(dbFileName);
            _mapController = new MapController(dbFileName);
            _mapRepository = new MapRepository(dbFileName);
            _townsfolkView = new TownsfolkView(dbFileName);



        }



        public void GenerateFamilies(int numberOfFamilies, int townId)
        {
            if (_townRepository.GetTownById(townId) == null)
            {
                throw new Exception($"Town with Id {townId} does not exist.");
            }

            Random random = new Random();
            GenerateWeightedFamilySize familySizeGenerator = new GenerateWeightedFamilySize();
            ProfessionAssignmentService professionAssignmentService = new ProfessionAssignmentService();
            MapTile? townTile = _mapRepository.GetTownPosition();
            if (townTile == null)
            {
                throw new Exception("No town position found in the database.");
            }
            MainTerrainType mainTerrainType = townTile.Terrain;
            for (int i = 0; i < numberOfFamilies; i++)
            {
                // Generate family size
                int familySize = familySizeGenerator.Generate(random);

                // Ensure at least 2 parents (1 male, 1 female) over age 25
                int numAdults = 0;
                List<Townsfolk> familyMembers = new List<Townsfolk>();

                // Generate parents
                while (numAdults < 2)
                {
                    Townsfolk parent = TownsfolkGenerator.GenerateRandomTownsfolk();
                    parent.Profession = professionAssignmentService.AssignProfession(mainTerrainType, random);
                    if (parent.Age > 25 && (parent.Gender == Gender.Male || parent.Gender == Gender.Female))
                    {
                        parent.IsParent = true;
                        familyMembers.Add(parent);
                        numAdults++;
                    }
                }

                // Generate children
                int numChildren = familySize - numAdults;
                for (int j = 0; j < numChildren; j++)
                {
                    Townsfolk child = TownsfolkGenerator.GenerateRandomTownsfolk();
                    child.Profession = Profession.None;
                    child.IsChild = true;
                    familyMembers.Add(child);
                }

                // Assign last name, town ID, and other properties
                string lastName = TownsfolkNameGenerator.GenerateLastName();
                foreach (var member in familyMembers)
                {
                    member.TownId = townId;
                    member.LastName = lastName;
                    member.Origin = "Origin"; // Replace with actual logic to determine origin
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

        public void addSingleTownsfolk(Townsfolk townsfolk) { }
        public void saveSingleTownsfolk(Townsfolk townsfolk) { }
        public void deleteSingleTownsfolk(Townsfolk townsfolk) { }
        public void updateSingleTownsfolk(Townsfolk townsfolk) { }
    }
}
