
using Microsoft.Data.Sqlite;
using TowninatorCLI.Controller;

namespace TowninatorCLI.Repositories
{
    public class MapRepository(string dbFileName)
    {
        private readonly string _connectionString = $"Data Source={dbFileName}";
        private readonly TownRepository _townRepository = new(dbFileName);

        public MainTerrainType? GetTerrainOfAdjacentTile(Map map, Direction direction, int x, int y)
        {

            if (map == null)
            {
                throw new ArgumentNullException(nameof(map), "Map is null.");
            }
            var adjacentX = x;
            var adjacentY = y;

            switch (direction)
            {
                case Direction.North:
                    adjacentY -= 1;
                    break;
                case Direction.South:
                    adjacentY += 1;
                    break;
                case Direction.East:
                    adjacentX += 1;
                    break;
                case Direction.West:
                    adjacentX -= 1;
                    break;
                default:
                    throw new ArgumentException($"Unsupported direction: {direction}");
            }
            if (adjacentX < 0 || adjacentX >= map.Width || adjacentY < 0 || adjacentY >= map.Height)
            {
                throw new ArgumentOutOfRangeException($"Adjusted coordinates ({adjacentX}, {adjacentY}) are outside map boundaries.");
            }

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = new SqliteCommand("SELECT MainTerrain FROM MapTile WHERE MapId = @MapId AND X = @X AND Y = @Y", connection);
            command.Parameters.AddWithValue("@MapId", map.Id);
            command.Parameters.AddWithValue("@X", adjacentX);
            command.Parameters.AddWithValue("@Y", adjacentY);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return Enum.Parse<MainTerrainType>(reader.GetString(0));
            }
            else
            {
                return null; // Or handle the case where the adjacent tile is not found
            }
        }

        public void SaveMap(Map map, int townId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                // Verify that the TownId exists in the Towns table
                var verifyTownCmd = connection.CreateCommand();
                verifyTownCmd.CommandText = "SELECT COUNT(*) FROM Towns WHERE Id = @TownId";
                verifyTownCmd.Parameters.AddWithValue("@TownId", townId);

                var townCount = (long?)verifyTownCmd.ExecuteScalar();

                if (townCount == 0)
                {
                    throw new Exception($"TownId {townId} does not exist in the Towns table.");
                }

                // Insert or replace map record
                var insertMapCmd = connection.CreateCommand();
                insertMapCmd.CommandText = "INSERT OR REPLACE INTO Map (Width, Height, TownId)VALUES (@Width, @Height, @TownId);SELECT last_insert_rowid(); ";

                insertMapCmd.Parameters.AddWithValue("@Width", map.Width);
                insertMapCmd.Parameters.AddWithValue("@Height", map.Height);
                insertMapCmd.Parameters.AddWithValue("@TownId", townId);

                try
                {
                    var mapId = (long?)insertMapCmd.ExecuteScalar();
                    if (mapId != null)
                    {
                        map.Id = (int)mapId;
                    }
                    else
                    {
                        throw new Exception("Failed to retrieve mapId from database.");
                    }
                    // Delete existing map tiles for the map
                    var deleteMapTilesCmd = connection.CreateCommand();
                    deleteMapTilesCmd.CommandText = "DELETE FROM MapTile WHERE MapId = @MapId";
                    deleteMapTilesCmd.Parameters.AddWithValue("@MapId", mapId);
                    deleteMapTilesCmd.ExecuteNonQuery();

                    // Insert new map tiles
                    var insertTileCmd = connection.CreateCommand();
                    insertTileCmd.CommandText = "INSERT INTO MapTile (MapId, X, Y, MainTerrain, SecondaryTerrain, Event, HasTown, IsNorthOfTown, IsSouthOfTown, IsEastOfTown, IsWestOfTown) VALUES (@MapId, @X, @Y, @MainTerrain, @SecondaryTerrain, @Event, @HasTown, @IsNorthOfTown, @IsSouthOfTown, @IsEastOfTown, @IsWestOfTown)";

                    foreach (var tile in map.GetAllTiles())
                    {
                        insertTileCmd.Parameters.Clear();
                        insertTileCmd.Parameters.AddWithValue("@MapId", mapId); // Use the retrieved mapId here
                        insertTileCmd.Parameters.AddWithValue("@X", tile.X);
                        insertTileCmd.Parameters.AddWithValue("@Y", tile.Y);
                        insertTileCmd.Parameters.AddWithValue("@MainTerrain", tile.Terrain.ToString());
                        insertTileCmd.Parameters.AddWithValue("@SecondaryTerrain", tile.SecondaryTerrain.ToString());
                        insertTileCmd.Parameters.AddWithValue("@Event", tile.Event?.Description ?? string.Empty);
                        insertTileCmd.Parameters.AddWithValue("@HasTown", tile.HasTown ? 1 : 0);
                        insertTileCmd.Parameters.AddWithValue("@IsNorthOfTown", tile.IsNorthOfTown ? 1 : 0);
                        insertTileCmd.Parameters.AddWithValue("@IsSouthOfTown", tile.IsSouthOfTown ? 1 : 0);
                        insertTileCmd.Parameters.AddWithValue("@IsEastOfTown", tile.IsEastOfTown ? 1 : 0);
                        insertTileCmd.Parameters.AddWithValue("@IsWestOfTown", tile.IsWestOfTown ? 1 : 0);

                        insertTileCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                    throw;
                }
            }

            connection.Close();
        }


        public MainTerrainType GetTerrainAtCoordinate(long mapId, int x, int y)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = new SqliteCommand("SELECT MainTerrain FROM MapTile WHERE MapId = @MapId AND X = @X AND Y = @Y", connection);
            command.Parameters.AddWithValue("@MapId", mapId);
            command.Parameters.AddWithValue("@X", x);
            command.Parameters.AddWithValue("@Y", y);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return Enum.Parse<MainTerrainType>(reader.GetString(0));
            }
            else
            {
                throw new Exception($"Tile at coordinates ({x}, {y}) not found in map with ID {mapId}.");
            }
        }



        public MapTile? GetTownPosition()
        {
            const string sql = " SELECT X, Y, MainTerrain, SecondaryTerrain, Event, Description, IsNorthOfTown, IsSouthOfTown, IsEastOfTown, IsWestOfTown FROM MapTile  WHERE HasTown = 1 LIMIT 1;  ";

            try
            {
                using var connection = new SqliteConnection(_connectionString);
                connection.Open();

                using var command = new SqliteCommand(sql, connection);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var x = Convert.ToInt32(reader["X"]);
                    var y = Convert.ToInt32(reader["Y"]);

                    var mainTerrain = MainTerrainType.None;

                    if (reader["MainTerrain"] != DBNull.Value)
                    {
                        Enum.TryParse(reader["MainTerrain"].ToString(), out MainTerrainType parsedMainTerrain);
                        mainTerrain = parsedMainTerrain;
                    }


                    var secondaryTerrain = Enum.TryParse(reader["SecondaryTerrain"].ToString(), out SecondaryTerrainType parsedSecondaryTerrain)
                        ? parsedSecondaryTerrain
                        : SecondaryTerrainType.None; // Replace DefaultValue with actual default value
                    MapEvent? mapEvent = null;
                    if (reader["Event"] != DBNull.Value)
                    {
                        var eventDescription = reader["Event"].ToString();
                        if (!string.IsNullOrEmpty(eventDescription))
                        {
                            mapEvent = new MapEvent(eventDescription); // Assuming MapEvent constructor takes a non-null string parameter
                        }
                    }
                    var description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString();
                    var isNorthOfTown = Convert.ToBoolean(reader["IsNorthOfTown"]);
                    var isSouthOfTown = Convert.ToBoolean(reader["IsSouthOfTown"]);
                    var isEastOfTown = Convert.ToBoolean(reader["IsEastOfTown"]);
                    var isWestOfTown = Convert.ToBoolean(reader["IsWestOfTown"]);

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

        public Map GetLatestMap()
        {
            var map = new Map(0, 0);


            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                const string query = "SELECT Id, Width, Height FROM Map ORDER BY Id DESC LIMIT 1;";

                using (var command = new SqliteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var mapId = reader.GetInt64(reader.GetOrdinal("Id"));
                            var width = reader.GetInt32(reader.GetOrdinal("Width"));
                            var height = reader.GetInt32(reader.GetOrdinal("Height"));
                            map = new Map(width, height) { Id = map.Id };

                            var tileCommand = new SqliteCommand("SELECT X, Y, MainTerrain, SecondaryTerrain, Event, HasTown, IsNorthOfTown, IsSouthOfTown, IsEastOfTown, IsWestOfTown FROM MapTile WHERE MapId = @MapId", connection);
                            tileCommand.Parameters.AddWithValue("@MapId", mapId);

                            using var tileReader = tileCommand.ExecuteReader();
                            while (tileReader.Read())
                            {
                                var x = tileReader.GetInt32(tileReader.GetOrdinal("X"));
                                var y = tileReader.GetInt32(tileReader.GetOrdinal("Y"));
                                var terrain = Enum.Parse<MainTerrainType>(tileReader.GetString(tileReader.GetOrdinal("MainTerrain")));
                                var secondaryTerrain = Enum.Parse<SecondaryTerrainType>(tileReader.GetString(tileReader.GetOrdinal("SecondaryTerrain")));
                                var eventDescription = tileReader.IsDBNull(tileReader.GetOrdinal("Event")) ? null : tileReader.GetString(tileReader.GetOrdinal("Event"));
                                var hasTown = tileReader.GetBoolean(tileReader.GetOrdinal("HasTown"));
                                var isNorthOfTown = tileReader.GetBoolean(tileReader.GetOrdinal("IsNorthOfTown"));
                                var isSouthOfTown = tileReader.GetBoolean(tileReader.GetOrdinal("IsSouthOfTown"));
                                var isEastOfTown = tileReader.GetBoolean(tileReader.GetOrdinal("IsEastOfTown"));
                                var isWestOfTown = tileReader.GetBoolean(tileReader.GetOrdinal("IsWestOfTown"));

                                // Create MapEvent object if eventDescription is not null
                                var mapEvent = !string.IsNullOrEmpty(eventDescription) ? new MapEvent(eventDescription) : null;

                                // Create the MapTile including HasTown and directional flags
                                var tile = new MapTile(x, y, terrain, secondaryTerrain, mapEvent, hasTown)
                                {
                                    IsNorthOfTown = isNorthOfTown,
                                    IsSouthOfTown = isSouthOfTown,
                                    IsEastOfTown = isEastOfTown,
                                    IsWestOfTown = isWestOfTown
                                };

                                map.SetTile(x, y, tile);
                            }
                        }
                    }
                }

                connection.Close();
            }

            if (map == null)
            {
                throw new Exception("No maps found in the database.");
            }

            return map;
        }


        public Map LoadMap(long mapId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = new SqliteCommand("SELECT Width, Height FROM Map WHERE Id = @MapId", connection);
            command.Parameters.AddWithValue("@MapId", mapId);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var width = reader.GetInt32(0);
                var height = reader.GetInt32(1);
                var map = new Map(width, height);

                var tileCommand = new SqliteCommand("SELECT X, Y, MainTerrain, SecondaryTerrain, Event, HasTown, IsNorthOfTown, IsSouthOfTown, IsEastOfTown, IsWestOfTown FROM MapTile WHERE MapId = @MapId", connection);
                tileCommand.Parameters.AddWithValue("@MapId", mapId);

                using var tileReader = tileCommand.ExecuteReader();
                while (tileReader.Read())
                {
                    var x = tileReader.GetInt32(tileReader.GetOrdinal("X"));
                    var y = tileReader.GetInt32(tileReader.GetOrdinal("Y"));
                    var terrain = Enum.Parse<MainTerrainType>(tileReader.GetString(tileReader.GetOrdinal("MainTerrain")));
                    var secondaryTerrain = Enum.Parse<SecondaryTerrainType>(tileReader.GetString(tileReader.GetOrdinal("SecondaryTerrain")));
                    var eventDescription = tileReader.IsDBNull(tileReader.GetOrdinal("Event")) ? null : tileReader.GetString(tileReader.GetOrdinal("Event"));
                    var hasTown = tileReader.GetBoolean(tileReader.GetOrdinal("HasTown"));
                    var isNorthOfTown = tileReader.GetBoolean(tileReader.GetOrdinal("IsNorthOfTown"));
                    var isSouthOfTown = tileReader.GetBoolean(tileReader.GetOrdinal("IsSouthOfTown"));
                    var isEastOfTown = tileReader.GetBoolean(tileReader.GetOrdinal("IsEastOfTown"));
                    var isWestOfTown = tileReader.GetBoolean(tileReader.GetOrdinal("IsWestOfTown"));

                    // Create MapEvent object if eventDescription is not null
                    var mapEvent = !string.IsNullOrEmpty(eventDescription) ? new MapEvent(eventDescription) : null;

                    // Create the MapTile including HasTown and directional flags
                    var tile = new MapTile(x, y, terrain, secondaryTerrain, mapEvent, hasTown)
                    {
                        IsNorthOfTown = isNorthOfTown,
                        IsSouthOfTown = isSouthOfTown,
                        IsEastOfTown = isEastOfTown,
                        IsWestOfTown = isWestOfTown
                    };

                    // Set the tile in the map
                    map.SetTile(x, y, tile);
                }

                return map;
            }
            else
            {
                throw new Exception($"Map with ID {mapId} not found.");
            }
        }


        public Map GetMapByTownId(int townId)
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                connection.Open();

                var command = new SqliteCommand("SELECT Id, Width, Height FROM Map WHERE TownId = @TownId", connection);
                command.Parameters.AddWithValue("@TownId", townId);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var mapId = reader.GetInt64(reader.GetOrdinal("Id"));
                    var width = reader.GetInt32(reader.GetOrdinal("Width"));
                    var height = reader.GetInt32(reader.GetOrdinal("Height"));

                    var map = new Map(width, height)
                    {
                        Id = (int)mapId // Set the mapId
                    };

                    return map;
                }
                else
                {
                    throw new Exception($"Map for TownId {townId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching map for TownId {townId}: {ex.Message}");
                throw;
            }
        }
    }
}

