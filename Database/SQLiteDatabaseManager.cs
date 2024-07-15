using Microsoft.Data.Sqlite;

namespace TowninatorCLI
{
    public class SQLiteDatabaseManager
    {
        private string connectionString;
        private bool debug;

        public SQLiteDatabaseManager(string dbFileName, bool debug = false)
        {
            connectionString = $"Data Source={dbFileName}; foreign keys=true;";
            this.debug = debug;
        }


        public void CreateDatabase()
        {
            if (debug) Debugging.WriteNColor("Creating database...", ConsoleColor.Green);
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                if (debug) Debugging.WriteNColor("Initiating connection.", ConsoleColor.Green);
                // Enable foreign key constraints
                string commandForeignKey = @"PRAGMA foreign_keys = ON;";
                ExecuteNonQ(connection, commandForeignKey);

                // Drop existing tables (if any)
                string dropTableQuery = @"
                DROP TABLE IF EXISTS MapTile;
                DROP TABLE IF EXISTS Map;
                DROP TABLE IF EXISTS Townsfolk;
                DROP TABLE IF EXISTS Towns;
                ";
                ExecuteNonQ(connection, dropTableQuery);

                // Create Towns table
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

                if (debug) Debugging.WriteNColor("Creating Towns table.", ConsoleColor.Green);
                // Create Townsfolk table
                string createTownsfolkTable = @"
                CREATE TABLE Townsfolk (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Age INTEGER,
                    FirstName TEXT,
                    LastName TEXT,
                    Gender INTEGER,
                    Profession INTEGER,
                    SkillLevel INTEGER,
                    IsAlive INTEGER,
                    Description TEXT,
                    IsMarried INTEGER,
                    TownId INTEGER,
                    Origin TEXT,
                    Region TEXT,
                    Country TEXT,
                    IsParent INTEGER,
                    IsChild INTEGER,
                    FOREIGN KEY(TownId) REFERENCES Towns(Id)
                );
            ";
                ExecuteNonQ(connection, createTownsfolkTable);

                if (debug) Debugging.WriteNColor("Creating Townsfolk table.", ConsoleColor.Green);
                // Create Map table
                string createMapTable = @"
                  CREATE TABLE Map (
                      Id INTEGER PRIMARY KEY,
                      Width INTEGER,
                      Height INTEGER,
                      TownId INTEGER,
                      FOREIGN KEY (TownId) REFERENCES Towns(Id)
                  );

                ";
                ExecuteNonQ(connection, createMapTable);

                if (debug) Debugging.WriteNColor("Creating Map table.", ConsoleColor.Green);

                // Create MapTile table
                string createMapTileTable = @"
                CREATE TABLE  MapTile (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
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

                if (debug) Debugging.WriteNColor("Creating MapMapTile table.", ConsoleColor.Green);
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
        public void DeleteDatabase(string dbFileName)
        {
            if (File.Exists(dbFileName))
            {
                File.Delete(dbFileName);
                Console.WriteLine("Database file deleted.");
            }
            else
            {
                Console.WriteLine("Database file does not exist.");
            }
        }
    }
}

