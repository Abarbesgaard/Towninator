using System.Data.SQLite;
using TowninatorCLI.Model;

namespace TowninatorCLI.Repositories
{
    public class BuildingRepository(string dbFileName)
    {
        private readonly string _connectionString = $"Data Source={dbFileName}";

        public void AddBuilding(Building building)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            const string query = """
                                 INSERT INTO Buildings 
                                 (Name, Description, BuildingType, 
                                 SpecificBuilding, coastalModifier, fjordModifier, forestModifier,
                                    grasslandModifier, heathModifier, highlandModifier, lakeModifier, marshModifier,
                                    meadowModifier, lowMountainModifier, mediumMountainModifier, highMountainModifier,
                                    wetlandModifier, tundraModifier, TownId) 
                                 VALUES 
                                 (@Name, @Description, @BuildingType, 
                                 @SpecificBuilding, @coastalModifier, @fjordModifier, @forestModifier,
                                    @grasslandModifier, @heathModifier, @highlandModifier, @lakeModifier, @marshModifier,
                                    @meadowModifier, @lowMountainModifier, @mediumMountainModifier, @highMountainModifier,
                                    @wetlandModifier, @tundraModifier, @TownId);
                                 """;


            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", building.Name);
                command.Parameters.AddWithValue("@Description", building.Description);
                command.Parameters.AddWithValue("@BuildingType", building.BuildingType);
                command.Parameters.AddWithValue("@SpecificBuilding", building.SpecificBuilding);
                command.Parameters.AddWithValue("@coastalModifier", building.CoastalModifier);
                command.Parameters.AddWithValue("@fjordModifier", building.FjordModifier);
                command.Parameters.AddWithValue("@forestModifier", building.ForestModifier);
                command.Parameters.AddWithValue("@grasslandModifier", building.GrasslandModifier);
                command.Parameters.AddWithValue("@heathModifier", building.HeathModifier);
                command.Parameters.AddWithValue("@highlandModifier", building.HighlandModifier);
                command.Parameters.AddWithValue("@lakeModifier", building.LakeModifier);
                command.Parameters.AddWithValue("@marshModifier", building.MarshModifier);
                command.Parameters.AddWithValue("@meadowModifier", building.MeadowModifier);
                command.Parameters.AddWithValue("@lowMountainModifier", building.LowMountainModifier);
                command.Parameters.AddWithValue("@mediumMountainModifier", building.MediumMountainModifier);
                command.Parameters.AddWithValue("@highMountainModifier", building.HighMountainModifier);
                command.Parameters.AddWithValue("@wetlandModifier", building.WetlandModifier);
                command.Parameters.AddWithValue("@tundraModifier", building.TundraModifier);
                command.Parameters.AddWithValue("@TownId", building.TownId);

                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        public List<Building> GetAllBuildings()
        {
            var buildings = new List<Building>();

            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            const string query = """
                                     SELECT Id, Name, Description, BuildingType, SpecificBuilding,
                                            coastalModifier, fjordModifier, forestModifier, grasslandModifier, heathModifier, highlandModifier,
                                            lakeModifier, marshModifier, meadowModifier, lowMountainModifier, mediumMountainModifier, highMountainModifier,
                                            wetlandModifier, tundraModifier, TownId
                                     FROM Buildings;
                                 """;

            using (var command = new SQLiteCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = Convert.ToInt32(reader["Id"]);
                        var name = Convert.ToString(reader["Name"]);
                        var description = Convert.ToString(reader["Description"]);
                        var buildingTypeString = Convert.ToString(reader["BuildingType"]);
                        var specificBuildingString = Convert.ToString(reader["SpecificBuilding"]);
                        var coastalModifier = Convert.ToSingle(reader["coastalModifier"]);
                        var fjordModifier = Convert.ToSingle(reader["fjordModifier"]);
                        var forestModifier = Convert.ToSingle(reader["forestModifier"]);
                        var grasslandModifier = Convert.ToSingle(reader["grasslandModifier"]);
                        var heathModifier = Convert.ToSingle(reader["heathModifier"]);
                        var highlandModifier = Convert.ToSingle(reader["highlandModifier"]);
                        var lakeModifier = Convert.ToSingle(reader["lakeModifier"]);
                        var marshModifier = Convert.ToSingle(reader["marshModifier"]);
                        var meadowModifier = Convert.ToSingle(reader["meadowModifier"]);
                        var lowMountainModifier = Convert.ToSingle(reader["lowMountainModifier"]);
                        var mediumMountainModifier = Convert.ToSingle(reader["mediumMountainModifier"]);
                        var highMountainModifier = Convert.ToSingle(reader["highMountainModifier"]);
                        var wetlandModifier = Convert.ToSingle(reader["wetlandModifier"]);
                        var tundraModifier = Convert.ToSingle(reader["tundraModifier"]);
                        var townId = reader["TownId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TownId"]);
                        var buildingType = Enum.Parse<BuildingType>(buildingTypeString ?? string.Empty);
                        var specificBuilding = Enum.Parse<SpecificBuilding>(specificBuildingString ?? string.Empty);
                        
                        var building = new Building(id, name, description, buildingType, specificBuilding, townId, null,
                            coastalModifier, fjordModifier, forestModifier, grasslandModifier, heathModifier,
                            highlandModifier,
                            lakeModifier, marshModifier, meadowModifier, lowMountainModifier, mediumMountainModifier,
                            highMountainModifier,
                            wetlandModifier, tundraModifier
                        );

                        buildings.Add(building);
                       
                    }
                }
            }

            connection.Close();

            return buildings;
        }


    }
}
