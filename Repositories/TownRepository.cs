using Microsoft.Data.Sqlite;
using TowninatorCLI.Model;
using TowninatorCLI.Utilities.misc;
namespace TowninatorCLI.Repositories
{
    public class TownRepository(string dbFileName, bool debug = false)
    {

        private readonly string _connectionString = $"Data Source={dbFileName}";

        public Town? GetTownById(int id)
        {
            if (debug) Debugging.WriteNColor($"[] TownRepository.GetTownById( id: {id} )", ConsoleColor.Green);

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Towns WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Town(
                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                    name: reader.GetString(reader.GetOrdinal("Name")),
                    mainDescription: reader.IsDBNull(reader.GetOrdinal("MainDescription")) ? "" : reader.GetString(reader.GetOrdinal("MainDescription")),
                    northDescription: reader.IsDBNull(reader.GetOrdinal("NorthDescription")) ? "" : reader.GetString(reader.GetOrdinal("NorthDescription")),
                    southDescription: reader.IsDBNull(reader.GetOrdinal("SouthDescription")) ? "" : reader.GetString(reader.GetOrdinal("SouthDescription")),
                    eastDescription: reader.IsDBNull(reader.GetOrdinal("EastDescription")) ? "" : reader.GetString(reader.GetOrdinal("EastDescription")),
                    westDescription: reader.IsDBNull(reader.GetOrdinal("WestDescription")) ? "" : reader.GetString(reader.GetOrdinal("WestDescription")),
                    culture: reader.GetInt32(reader.GetOrdinal("Culture")),
                    education: reader.GetInt32(reader.GetOrdinal("Education")),
                    health: reader.GetInt32(reader.GetOrdinal("Health")),
                    military: reader.GetInt32(reader.GetOrdinal("Military")),
                    order: reader.GetInt32(reader.GetOrdinal("Order")),
                    production: reader.GetInt32(reader.GetOrdinal("Production")),
                    recreation: reader.GetInt32(reader.GetOrdinal("Recreation")),
                    trade: reader.GetInt32(reader.GetOrdinal("Trade")),
                    wealth: reader.GetInt32(reader.GetOrdinal("Wealth")),
                    worship: reader.GetInt32(reader.GetOrdinal("Worship")),
                    townsfolk: null // Handle townsfolk retrieval if needed
                );
            }

            return null;
        }

        public Town GetLatestTown()
        {
            if (debug) Debugging.WriteNColor("[] TownRepository.GetLatestTown()", ConsoleColor.Green);

            var town = new Town();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            const string query = "SELECT * FROM Towns ORDER BY Id DESC LIMIT 1;";

            using (var command = new SqliteCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        town.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        town.Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name"));
                        town.Culture = reader.GetInt32(reader.GetOrdinal("Culture"));
                        town.Education = reader.GetInt32(reader.GetOrdinal("Education"));
                        town.Health = reader.GetInt32(reader.GetOrdinal("Health"));
                        town.Military = reader.GetInt32(reader.GetOrdinal("Military"));
                        town.Order = reader.GetInt32(reader.GetOrdinal("Order"));
                        town.Production = reader.GetInt32(reader.GetOrdinal("Production"));
                        town.Recreation = reader.GetInt32(reader.GetOrdinal("Recreation"));
                        town.Trade = reader.GetInt32(reader.GetOrdinal("Trade"));
                        town.Wealth = reader.GetInt32(reader.GetOrdinal("Wealth"));
                        town.Worship = reader.GetInt32(reader.GetOrdinal("Worship"));
                        town.MainDescription = reader.IsDBNull(reader.GetOrdinal("MainDescription")) ? null : reader.GetString(reader.GetOrdinal("MainDescription"));
                        town.NorthDescription = reader.IsDBNull(reader.GetOrdinal("NorthDescription")) ? null : reader.GetString(reader.GetOrdinal("NorthDescription"));
                        town.SouthDescription = reader.IsDBNull(reader.GetOrdinal("SouthDescription")) ? null : reader.GetString(reader.GetOrdinal("SouthDescription"));
                        town.EastDescription = reader.IsDBNull(reader.GetOrdinal("EastDescription")) ? null : reader.GetString(reader.GetOrdinal("EastDescription"));
                        town.WestDescription = reader.IsDBNull(reader.GetOrdinal("WestDescription")) ? null : reader.GetString(reader.GetOrdinal("WestDescription"));

                        // Add mappings for other properties as needed
                    }
                }
            }

            connection.Close();

            return town;
        }

        public void UpdateTownDescriptions(Town town)
        {
            if (debug) Debugging.WriteNColor($"[] TownRepository.UpdateTownDescriptions( Town {town.Name} )", ConsoleColor.Green);
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            const string updateQuery = "UPDATE Towns SET MainDescription = @MainDescription, NorthDescription = @NorthDescription, SouthDescription = @SouthDescription, EastDescription = @EastDescription, WestDescription = @WestDescription WHERE Id = @Id; ";

            using (var command = new SqliteCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@MainDescription", town.MainDescription);
                command.Parameters.AddWithValue("@NorthDescription", town.NorthDescription);
                command.Parameters.AddWithValue("@SouthDescription", town.SouthDescription);
                command.Parameters.AddWithValue("@EastDescription", town.EastDescription);
                command.Parameters.AddWithValue("@WestDescription", town.WestDescription);
                command.Parameters.AddWithValue("@Id", town.Id);

                var rowsAffected = command.ExecuteNonQuery();

                // Optionally, you can handle error checking or logging here
            }

            connection.Close();
        }


        public int AddTown(Town town)
        {
            if (debug) Debugging.WriteNColor($"[] TownRepository.AddTown( Town {town.Name} )", ConsoleColor.Green);

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            const string query = """ INSERT INTO Towns (Name, Culture, Education, Health, Military, "Order", Production, Recreation, Trade, Wealth, Worship, MainDescription,NorthDescription, SouthDescription, EastDescription, WestDescription) VALUES (@Name, @Culture, @Education, @Health, @Military, @Order, @Production, @Recreation, @Trade, @Wealth, @Worship, @MainDescription, @NorthDescription, @SouthDescription, @EastDescription, @WestDescription); SELECT last_insert_rowid(); """;

            try
            {
                using var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@Name", town.Name ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Culture", town.Culture);
                command.Parameters.AddWithValue("@Education", town.Education);
                command.Parameters.AddWithValue("@Health", town.Health);
                command.Parameters.AddWithValue("@Military", town.Military);
                command.Parameters.AddWithValue("@Order", town.Order);
                command.Parameters.AddWithValue("@Production", town.Production);
                command.Parameters.AddWithValue("@Recreation", town.Recreation);
                command.Parameters.AddWithValue("@Trade", town.Trade);
                command.Parameters.AddWithValue("@Wealth", town.Wealth);
                command.Parameters.AddWithValue("@Worship", town.Worship);
                command.Parameters.AddWithValue("@MainDescription", town.MainDescription ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@NorthDescription", town.NorthDescription ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@SouthDescription", town.SouthDescription ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@EastDescription", town.EastDescription ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@WestDescription", town.WestDescription ?? (object)DBNull.Value);

                var newTownId = (long?)command.ExecuteScalar();

                if (newTownId != null)
                {
                    town.Id = (int)newTownId;
                    return (int)newTownId;
                }
                else
                {
                    Console.WriteLine("Failed to retrieve new town Id from database.");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

