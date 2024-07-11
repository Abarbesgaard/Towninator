
using Microsoft.Data.Sqlite;
namespace TowninatorCLI
{
    public class MapRepository
    {
        private readonly string _connectionString;

        public MapRepository(string dbFileName)
        {
            _connectionString = $"Data Source={dbFileName}";
        }


        public void SaveMap(Map map, int townId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    // Insert or replace map record
                    var insertMapCmd = connection.CreateCommand();
                    insertMapCmd.CommandText = @"
                INSERT OR REPLACE INTO Map (Id, Width, Height, TownId)
                VALUES (@Id, @Width, @Height, @TownId)";
                    insertMapCmd.Parameters.AddWithValue("@Id", townId);
                    insertMapCmd.Parameters.AddWithValue("@Width", map.Width);
                    insertMapCmd.Parameters.AddWithValue("@Height", map.Height);
                    insertMapCmd.Parameters.AddWithValue("@TownId", townId);
                    insertMapCmd.ExecuteNonQuery();

                    // Delete existing map tiles for the given mapId
                    var deleteMapTilesCmd = connection.CreateCommand();
                    deleteMapTilesCmd.CommandText = @"
                DELETE FROM MapTile WHERE MapId = @MapId";
                    deleteMapTilesCmd.Parameters.AddWithValue("@MapId", townId);
                    deleteMapTilesCmd.ExecuteNonQuery();

                    // Insert new map tiles
                    var insertTileCmd = connection.CreateCommand();
                    insertTileCmd.CommandText = @"
                INSERT INTO MapTile (MapId, X, Y, MainTerrain, SecondaryTerrain, Event, HasTown, IsNorthOfTown, IsSouthOfTown, IsEastOfTown, IsWestOfTown)
                VALUES (@MapId, @X, @Y, @MainTerrain, @SecondaryTerrain, @Event, @HasTown, @IsNorthOfTown, @IsSouthOfTown, @IsEastOfTown, @IsWestOfTown)";
                    insertTileCmd.Parameters.AddWithValue("@MapId", townId);
                    insertTileCmd.Parameters.AddWithValue("@X", 0);
                    insertTileCmd.Parameters.AddWithValue("@Y", 0);
                    insertTileCmd.Parameters.AddWithValue("@MainTerrain", string.Empty);
                    insertTileCmd.Parameters.AddWithValue("@SecondaryTerrain", string.Empty);
                    insertTileCmd.Parameters.AddWithValue("@Event", string.Empty);
                    insertTileCmd.Parameters.AddWithValue("@HasTown", false);
                    insertTileCmd.Parameters.AddWithValue("@IsNorthOfTown", false);
                    insertTileCmd.Parameters.AddWithValue("@IsSouthOfTown", false);
                    insertTileCmd.Parameters.AddWithValue("@IsEastOfTown", false);
                    insertTileCmd.Parameters.AddWithValue("@IsWestOfTown", false);

                    foreach (var tile in map.GetAllTiles())
                    {
                        insertTileCmd.Parameters["@X"].Value = tile.X;
                        insertTileCmd.Parameters["@Y"].Value = tile.Y;
                        insertTileCmd.Parameters["@MainTerrain"].Value = tile.Terrain.ToString();
                        insertTileCmd.Parameters["@SecondaryTerrain"].Value = tile.SecondaryTerrain.ToString();
                        insertTileCmd.Parameters["@Event"].Value = tile.Event?.Description ?? string.Empty;
                        insertTileCmd.Parameters["@HasTown"].Value = tile.HasTown ? 1 : 0; // SQLite boolean mapping
                        insertTileCmd.Parameters["@IsNorthOfTown"].Value = tile.IsNorthOfTown ? 1 : 0; // SQLite boolean mapping
                        insertTileCmd.Parameters["@IsSouthOfTown"].Value = tile.IsSouthOfTown ? 1 : 0; // SQLite boolean mapping
                        insertTileCmd.Parameters["@IsEastOfTown"].Value = tile.IsEastOfTown ? 1 : 0; // SQLite boolean mapping
                        insertTileCmd.Parameters["@IsWestOfTown"].Value = tile.IsWestOfTown ? 1 : 0; // SQLite boolean mapping

                        insertTileCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }

                connection.Close();
            }
        }

        public MainTerrainType GetTerrainAtCoordinate(long mapId, int x, int y)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = new SqliteCommand("SELECT MainTerrain FROM MapTile WHERE MapId = @MapId AND X = @X AND Y = @Y", connection);
                command.Parameters.AddWithValue("@MapId", mapId);
                command.Parameters.AddWithValue("@X", x);
                command.Parameters.AddWithValue("@Y", y);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Enum.Parse<MainTerrainType>(reader.GetString(0));
                    }
                    else
                    {
                        throw new Exception($"Tile at coordinates ({x}, {y}) not found in map with ID {mapId}.");
                    }
                }
            }
        }



        public MapTile? GetTownPosition()
        {
            string sql = @"
        SELECT X, Y, MainTerrain, SecondaryTerrain, Event, Description,
               IsNorthOfTown, IsSouthOfTown, IsEastOfTown, IsWestOfTown
        FROM MapTile
        WHERE HasTown = 1
        LIMIT 1;
    ";

            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqliteCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int x = Convert.ToInt32(reader["X"]);
                                int y = Convert.ToInt32(reader["Y"]);

                                MainTerrainType? mainTerrain = null;
                                if (reader["MainTerrain"] != DBNull.Value)
                                {
                                    Enum.TryParse(reader["MainTerrain"].ToString(), out MainTerrainType parsedMainTerrain);
                                    mainTerrain = parsedMainTerrain;
                                }


                                SecondaryTerrainType secondaryTerrain = Enum.TryParse(reader["SecondaryTerrain"].ToString(), out SecondaryTerrainType parsedSecondaryTerrain)
                                                          ? parsedSecondaryTerrain
                                                          : SecondaryTerrainType.None; // Replace DefaultValue with actual default value
                                MapEvent? mapEvent = null;
                                if (reader["Event"] != DBNull.Value)
                                {
                                    string? eventDescription = reader["Event"].ToString();
                                    if (!string.IsNullOrEmpty(eventDescription))
                                    {
                                        mapEvent = new MapEvent(eventDescription); // Assuming MapEvent constructor takes a non-null string parameter
                                    }
                                }
                                string? description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString();
                                bool isNorthOfTown = Convert.ToBoolean(reader["IsNorthOfTown"]);
                                bool isSouthOfTown = Convert.ToBoolean(reader["IsSouthOfTown"]);
                                bool isEastOfTown = Convert.ToBoolean(reader["IsEastOfTown"]);
                                bool isWestOfTown = Convert.ToBoolean(reader["IsWestOfTown"]);

                                return new MapTile(x, y, mainTerrain, secondaryTerrain, mapEvent, true)
                                {
                                    IsNorthOfTown = isNorthOfTown,
                                    IsSouthOfTown = isSouthOfTown,
                                    IsEastOfTown = isEastOfTown,
                                    IsWestOfTown = isWestOfTown,
                                    Description = description
                                };
                            }
                            else
                            {
                                Console.WriteLine("No town position found in the database.");
                            }
                        }
                    }
                }

                // If no data was found or another issue occurred, return null
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error occurred while fetching town position.");
                return null; // Handle exception and return null or log the error
            }
        }


        public Map LoadMap(long mapId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = new SqliteCommand("SELECT Width, Height FROM Map WHERE Id = @MapId", connection);
                command.Parameters.AddWithValue("@MapId", mapId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int width = reader.GetInt32(0);
                        int height = reader.GetInt32(1);
                        Map map = new Map(width, height);

                        var tileCommand = new SqliteCommand("SELECT X, Y, MainTerrain, SecondaryTerrain, Event, HasTown, IsNorthOfTown, IsSouthOfTown, IsEastOfTown, IsWestOfTown FROM MapTile WHERE MapId = @MapId", connection);
                        tileCommand.Parameters.AddWithValue("@MapId", mapId);

                        using (var tileReader = tileCommand.ExecuteReader())
                        {
                            while (tileReader.Read())
                            {
                                int x = tileReader.GetInt32(tileReader.GetOrdinal("X"));
                                int y = tileReader.GetInt32(tileReader.GetOrdinal("Y"));
                                MainTerrainType terrain = Enum.Parse<MainTerrainType>(tileReader.GetString(tileReader.GetOrdinal("MainTerrain")));
                                SecondaryTerrainType secondaryTerrain = Enum.Parse<SecondaryTerrainType>(tileReader.GetString(tileReader.GetOrdinal("SecondaryTerrain")));
                                string? eventDescription = tileReader.IsDBNull(tileReader.GetOrdinal("Event")) ? null : tileReader.GetString(tileReader.GetOrdinal("Event"));
                                bool hasTown = tileReader.GetBoolean(tileReader.GetOrdinal("HasTown"));
                                bool isNorthOfTown = tileReader.GetBoolean(tileReader.GetOrdinal("IsNorthOfTown"));
                                bool isSouthOfTown = tileReader.GetBoolean(tileReader.GetOrdinal("IsSouthOfTown"));
                                bool isEastOfTown = tileReader.GetBoolean(tileReader.GetOrdinal("IsEastOfTown"));
                                bool isWestOfTown = tileReader.GetBoolean(tileReader.GetOrdinal("IsWestOfTown"));

                                // Create MapEvent object if eventDescription is not null
                                MapEvent? mapEvent = !string.IsNullOrEmpty(eventDescription) ? new MapEvent(eventDescription) : null;

                                // Create the MapTile including HasTown and directional flags
                                MapTile tile = new MapTile(x, y, terrain, secondaryTerrain, mapEvent, hasTown)
                                {
                                    IsNorthOfTown = isNorthOfTown,
                                    IsSouthOfTown = isSouthOfTown,
                                    IsEastOfTown = isEastOfTown,
                                    IsWestOfTown = isWestOfTown
                                };

                                // Set the tile in the map
                                map.SetTile(x, y, tile);
                            }
                        }

                        return map;
                    }
                    else
                    {
                        throw new Exception($"Map with ID {mapId} not found.");
                    }
                }
            }
        }


    }
}

