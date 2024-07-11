using Microsoft.Data.Sqlite;

namespace TowninatorCLI
{
    public class TownRepository
    {

        private readonly string _connectionString;

        public TownRepository(string dbFileName)
        {
            _connectionString = $"Data Source={dbFileName}";
        }



        public Town? GetTownById(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Towns WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
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
                    }
                }
            }

            return null;
        }


        public Town? GetLatestTown()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    // Query to get the town with the highest ID
                    command.CommandText = "SELECT * FROM Towns ORDER BY Id DESC LIMIT 1";

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Town
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Culture = reader.GetInt32(reader.GetOrdinal("Culture")),
                                Education = reader.GetInt32(reader.GetOrdinal("Education")),
                                Health = reader.GetInt32(reader.GetOrdinal("Health")),
                                Military = reader.GetInt32(reader.GetOrdinal("Military")),
                                Order = reader.GetInt32(reader.GetOrdinal("Order")),
                                Production = reader.GetInt32(reader.GetOrdinal("Production")),
                                Recreation = reader.GetInt32(reader.GetOrdinal("Recreation")),
                                Trade = reader.GetInt32(reader.GetOrdinal("Trade")),
                                Wealth = reader.GetInt32(reader.GetOrdinal("Wealth")),
                                Worship = reader.GetInt32(reader.GetOrdinal("Worship")),
                                // Add mappings for other properties as needed
                                MainDescription = reader.GetString(reader.GetOrdinal("MainDescription")),
                                NorthDescription = reader.GetString(reader.GetOrdinal("NorthDescription")),
                                SouthDescription = reader.GetString(reader.GetOrdinal("SouthDescription")),
                                EastDescription = reader.GetString(reader.GetOrdinal("EastDescription")),
                                WestDescription = reader.GetString(reader.GetOrdinal("WestDescription")),
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void AddTown(Town town)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string query = @"
            INSERT INTO Towns (Name, Culture, Education, Health, Military, ""Order"", Production, Recreation, Trade, Wealth, Worship, MainDescription,
                               NorthDescription, SouthDescription, EastDescription, WestDescription)
            VALUES (@Name, @Culture, @Education, @Health, @Military, @Order, @Production, @Recreation, @Trade, @Wealth, @Worship, @MainDescription,
                    @NorthDescription, @SouthDescription, @EastDescription, @WestDescription);
        ";
                try
                {
                    using (var command = new SqliteCommand(query, connection))
                    {
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

                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                connection.Close();
            }
        }

    }
}

