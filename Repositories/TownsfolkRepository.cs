
using Microsoft.Data.Sqlite;
using TowninatorCLI.Model;
using TowninatorCLI.Model.MapModels;
using TowninatorCLI.Utilities.misc;

namespace TowninatorCLI.Repositories
{

    public class TownsfolkRepository(string dbFileName, bool debug = false)
    {
        private readonly string _connectionString = $"Data Source={dbFileName}";

        public MainTerrainType? GetTerrainForTownsfolk(int townsfolkId)
        {
            // Example implementation: replace with actual logic
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            const string query = "SELECT Terrain FROM Townsfolk WHERE Id = @Id";
            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Id", townsfolkId);

            var result = command.ExecuteScalar();
            if (result == DBNull.Value || result == null)
            {
                return null; // No terrain data available
            }

            // Assuming Terrain is stored as an integer representing the enum value
            Console.WriteLine($"{result}");
            return (MainTerrainType)Enum.Parse(typeof(MainTerrainType), result.ToString());
        }



        public void Add(Townsfolk townsfolk)
        {
            if (debug) Debugging.WriteNColor($"[] TownsfolkRepository.Add( {townsfolk})", ConsoleColor.Green);
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();



            const string query = """
                                  INSERT INTO Townsfolk (Age, FirstName, LastName, Gender, Profession, SkillLevel, 
                                 IsAlive, Description, IsMarried, TownId, Origin, Region, Country, IsParent, 
                                 IsChild, Terrain)
                                 VALUES (@Age, @FirstName, @LastName, @Gender, @Profession, @SkillLevel, @IsAlive, 
                                 @Description, @IsMarried, @TownId, @Origin, @Region, @Country, @IsParent, 
                                 @IsChild, @Terrain) 
                                 """;

            using var command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@Age", townsfolk.Age);
            command.Parameters.AddWithValue("@FirstName", townsfolk.FirstName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@LastName", townsfolk.LastName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Gender", townsfolk.Gender);
            command.Parameters.AddWithValue("@Profession", townsfolk.Profession);
            command.Parameters.AddWithValue("@SkillLevel", townsfolk.SkillLevel);
            command.Parameters.AddWithValue("@IsAlive", townsfolk.IsAlive);
            command.Parameters.AddWithValue("@Description", townsfolk.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@IsMarried", townsfolk.IsMarried);
            command.Parameters.AddWithValue("@TownId", townsfolk.TownId);
            command.Parameters.AddWithValue("@Origin", townsfolk.Origin ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Region", townsfolk.Region ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Country", townsfolk.Country ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@IsParent", townsfolk.IsParent ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@IsChild", townsfolk.IsChild ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Terrain", townsfolk.Terrain);

            command.ExecuteNonQuery();
        }
        public List<Townsfolk> GetAll()
        {
            var townsfolkList = new List<Townsfolk>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            // Create a command to select all townsfolk
            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, FirstName, LastName, Gender, Age, Profession, SkillLevel, IsAlive, Description, IsMarried, TownId FROM Townsfolk";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var townsfolk = new Townsfolk
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Gender = (Gender)reader.GetInt32(3),
                    Age = reader.GetInt32(4),
                    Profession = (Profession)reader.GetInt32(5), // Adjust based on your actual schema
                    SkillLevel = (ProfessionSkillLevel)reader.GetInt32(6), // Adjust based on your actual schema
                    IsAlive = reader.GetBoolean(7),
                    Description = reader.IsDBNull(8) ? null : reader.GetString(8),
                    IsMarried = reader.GetBoolean(9),
                    TownId = reader.GetInt32(10)
                };

                townsfolkList.Add(townsfolk);
            }

            return townsfolkList;
        }

    }

}
