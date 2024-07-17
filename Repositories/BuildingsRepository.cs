using System.Data.SQLite;
using TowninatorCLI.Utilities.misc;
using TowninatorCLI.Model;

namespace TowninatorCLI.Repositories
{
    public class BuildingRepository(string dbFileName, bool debug = false)
    {
        private readonly string _connectionString = $"Data Source={dbFileName}";

        public void AddBuilding(Building building)
        {
            if (debug) Debugging.WriteNColor($"[] BuildingRepository.AddBuilding(building {building})", ConsoleColor.Green);
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            const string query = """
                                 INSERT INTO Buildings 
                                 (Name, Description, BuildingType, 
                                 SpecificBuilding, SpawnProbability, TownId) 
                                 VALUES 
                                 (@Name, @Description, @BuildingType, 
                                 @SpecificBuilding, @SpawnProbability, @TownId);
                                 """;

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", building.Name);
                command.Parameters.AddWithValue("@Description", building.Description);
                command.Parameters.AddWithValue("@BuildingType", building.BuildingType.ToString());
                command.Parameters.AddWithValue("@SpecificBuilding", building.SpecificBuilding.ToString());
                command.Parameters.AddWithValue("@SpawnProbability", building.SpawnProbability);
                command.Parameters.AddWithValue("@TownId", building.TownId);

                command.ExecuteNonQuery();
            }

            connection.Close();
        }
        public List<Building> GetAllBuildings()
        {
            if (debug) Debugging.WriteNColor("[] BuildingRepository.GetAllBuildings()", ConsoleColor.Green);

            var buildings = new List<Building>();

            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            const string query = @"
        SELECT Id, Name, Description, BuildingType, SpecificBuilding, SpawnProbability, TownId 
        FROM Buildings;
    ";

            using (var command = new SQLiteCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = Convert.ToInt32(reader["Id"]);
                        var name = Convert.ToString(reader["Name"]);
                        var description = Convert.ToString(reader["Description"]);
                        var buildingType = Enum.Parse<BuildingType>(Convert.ToString(reader["BuildingType"]) ?? string.Empty);
                        var specificBuilding = Enum.Parse<SpecificBuilding>(Convert.ToString(reader["SpecificBuilding"]) ?? string.Empty);
                        var spawnProbability = reader["SpawnProbability"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SpawnProbability"]);
                        var townId = reader["TownId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TownId"]);

                        // You can load townsfolk or other related data if needed
                        List<Townsfolk>? townsfolk = null; // Example: Load townsfolk related to this building

                        if (name == null) continue;
                        var building = new Building(id, name, description, buildingType, specificBuilding, spawnProbability, townId, townsfolk);
                        buildings.Add(building);
                    }
                }
            }

            connection.Close();

            return buildings;
        }

    }
}

