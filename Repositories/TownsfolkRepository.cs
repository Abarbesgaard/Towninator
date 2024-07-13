
using Microsoft.Data.Sqlite;

namespace TowninatorCLI
{

    public class TownsfolkRepository
    {
        private readonly string _connectionString;

        public TownsfolkRepository(string dbFileName)
        {
            _connectionString = $"Data Source={dbFileName}";
        }



        public void Add(Townsfolk townsfolk)
        {

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                // Check if TownId exists in Towns table
                using (var checkCommand = connection.CreateCommand())
                {
                    checkCommand.CommandText = "SELECT COUNT(*) FROM Towns WHERE Id = @TownId";
                    checkCommand.Parameters.AddWithValue("@TownId", townsfolk.TownId);

                    long? count = (long?)checkCommand.ExecuteScalar();
                    if (count == 0)
                    {
                        throw new Exception($"Foreign key constraint failed: TownId {townsfolk.TownId} does not exist in Towns table.");
                    }
                }

                // Create a command to insert townsfolk
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Townsfolk (FirstName, LastName, Gender, Age, TownId, Description, IsAlive, IsMarried, SkillLevel, Profession) 
                                VALUES (@FirstName, @LastName, @Gender, @Age, @TownId, @Description, @IsAlive, @IsMarried, @SkillLevel, @Profession)";
                command.Parameters.AddWithValue("@FirstName", townsfolk.FirstName ?? "");
                command.Parameters.AddWithValue("@LastName", townsfolk.LastName ?? "");
                command.Parameters.AddWithValue("@Gender", (int)townsfolk.Gender);
                command.Parameters.AddWithValue("@Age", townsfolk.Age);
                command.Parameters.AddWithValue("@TownId", townsfolk.TownId);
                command.Parameters.AddWithValue("@Description", townsfolk.Description ?? "");
                command.Parameters.AddWithValue("@IsAlive", townsfolk.IsAlive);
                command.Parameters.AddWithValue("@IsMarried", townsfolk.IsMarried);
                command.Parameters.AddWithValue("@SkillLevel", (int)townsfolk.SkillLevel);
                command.Parameters.AddWithValue("@Profession", (int)townsfolk.Profession);

                // Execute the command
                command.ExecuteNonQuery();
            }
        }
        public List<Townsfolk> GetAll()
        {
            List<Townsfolk> townsfolkList = new List<Townsfolk>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                // Create a command to select all townsfolk
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, FirstName, LastName, Gender, Age, Profession, SkillLevel, IsAlive, Description, IsMarried, TownId FROM Townsfolk";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Townsfolk townsfolk = new Townsfolk
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
                }
            }

            return townsfolkList;
        }
    }
}
