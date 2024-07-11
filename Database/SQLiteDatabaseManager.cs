using Microsoft.Data.Sqlite;

namespace TowninatorCLI
{
    public class SQLiteDatabaseManager
    {
        private string connectionString;
        public SQLiteDatabaseManager(string dbFileName)
        {
            connectionString = $"Data Source={dbFileName}";
        }

        public void CreateDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Drop table command (if exists)
                string commandForeignKey = @"PRAGMA foreign_keys = ON;";
                ExecuteNonQ(connection, commandForeignKey);

                string dropTableQuery = @"
                DROP TABLE IF EXISTS Towns;
                DROP TABLE IF EXISTS MapTile;
                DROP TABLE IF EXISTS Map;
                ";

                ExecuteNonQ(connection, dropTableQuery);
                string createTownsFolkTable = @"
                              CREATE TABLE Townsfolk (
                                  Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                  Age INTEGER NOT NULL,
                                  FirstName TEXT,
                                  LastName TEXT,
                                  Gender INTEGER NOT NULL,
                                  Profession INTEGER NOT NULL,
                                  SkillLevel INTEGER NOT NULL,
                                  IsAlive INTEGER NOT NULL,
                                  Description TEXT,
                                  IsMarried INTEGER NOT NULL,
                                  TownId INTEGER NOT NULL,
                                  FOREIGN KEY (TownId) REFERENCES Town (Id)
                              );";

                ExecuteNonQ(connection, createTownsFolkTable);

                string createTableQuery = @"
                        CREATE TABLE Towns (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT,
                            Culture INTEGER,
                            Education INTEGER,
                            Health INTEGER,
                            Military INTEGER,
                            ""Order"" INTEGER,
                            Production INTEGER,
                            Recreation INTEGER,
                            Trade INTEGER,
                            Wealth INTEGER,
                            Worship INTEGER,
                            MainDescription TEXT,
                            NorthDescription TEXT,
                            SouthDescription TEXT,
                            EastDescription TEXT,
                            WestDescription TEXT
                        );
                    ";
                ExecuteNonQ(connection, createTableQuery);
                string createMapTable = @"CREATE TABLE Map (
                                            Id INTEGER PRIMARY KEY,
                                            Width INTEGER,
                                            Height INTEGER,
                                            TownId INTEGER
                                        );";
                ExecuteNonQ(connection, createMapTable);

                string createMapTileTable = @"
                    CREATE TABLE MapTile (
                        Id INTEGER PRIMARY KEY,
                        MapId INTEGER,
                        X INTEGER,
                        Y INTEGER,
                        MainTerrain TEXT,
                        SecondaryTerrain TEXT,
                        Event TEXT,
                        HasTown INTEGER,
                        IsNorthOfTown INTEGER,
                        IsSouthOfTown INTEGER,
                        IsEastOfTown INTEGER,
                        IsWestOfTown INTEGER,
                        Description TEXT,
                        FOREIGN KEY(MapId) REFERENCES Map(Id)
                    );
                ";


                ExecuteNonQ(connection, createMapTileTable);
                connection.Close();
            }
        }

        private void ExecuteNonQ(SqliteConnection connection, string query)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
        }
    }
}

