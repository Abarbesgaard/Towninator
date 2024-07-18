using Microsoft.Data.Sqlite;
using TowninatorCLI.Utilities.misc;
namespace TowninatorCLI.Database
{
    public class SqLiteDatabaseManager(string dbFileName, bool debug = false)
    {
        private readonly string _connectionString = $"Data Source={dbFileName}; foreign keys=true;";


        public void CreateDatabase()
        {
            if (debug) Debugging.WriteNColor("Creating database...", ConsoleColor.Green);
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            if (debug) Debugging.WriteNColor("Initiating connection.", ConsoleColor.Green);
            // Enable foreign key constraints
            const string commandForeignKey = "PRAGMA foreign_keys = ON;";
            ExecuteNonQ(connection, commandForeignKey);

            // Drop existing tables (if any)
            const string dropTableQuery = """
                                              DROP TABLE IF EXISTS MapTile;
                                              DROP TABLE IF EXISTS Map;
                                              DROP TABLE IF EXISTS Townsfolk;
                                              DROP TABLE IF EXISTS Towns;
                                              DROP TABLE IF EXISTS Buildings;
                                              DROP TABLE IF EXISTS Events;

                                          """;
            ExecuteNonQ(connection, dropTableQuery);
            if (debug) Debugging.WriteNColor("Dropping Tables", ConsoleColor.Green); 
                       // Create Towns table
            const string createTownQuery = """
                                           CREATE TABLE Towns(
                                           Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                           Name TEXT, Culture INTEGER, Crime INTEGER, 
                                           Education INTEGER, 
                                           Health INTEGER, 
                                           Military INTEGER, 
                                           "Order" INTEGER, 
                                           Production INTEGER, 
                                           Recreation INTEGER,
                                           Trade INTEGER, 
                                           Wealth INTEGER, 
                                           Worship INTEGER, 
                                           MainDescription TEXT, 
                                           NorthDescription TEXT, 
                                           SouthDescription TEXT, 
                                           EastDescription TEXT,
                                           WestDescription TEXT); 
                                           """;
            ExecuteNonQ(connection, createTownQuery);
            
            if (debug) Debugging.WriteNColor("Creating Towns table.", ConsoleColor.Green);

            const string eventTableQuery = """
                                           CREATE TABLE Event (
                                           Id INTEGER PRIMARY KEY,
                                           Name TEXT NOT NULL,
                                           Description TEXT,
                                           EventSeverity INTEGER NOT NULL,
                                           EventType INTEGER NOT NULL,
                                           MapTileId INTEGER NOT NULL,
                                           TownsfolkId INTEGER,
                                           IsFinished BOOLEAN NOT NULL,
                                           InProgress BOOLEAN NOT NULL,
                                           Impact TEXT,
                                           Priority INTEGER NOT NULL,
                                           ResourcesNeeded TEXT,
                                           Consequences TEXT);
                                           """;
            ExecuteNonQ(connection, eventTableQuery);
            if(debug) Debugging.WriteNColor("Creating Event Table", ConsoleColor.Green);
            
            const string buildTableQuery ="""
                                          CREATE TABLE Buildings( 
                                          Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                          Name TEXT, 
                                          Description TEXT, 
                                          BuildingType INTEGER , 
                                          SpecificBuilding INTEGER, 
                                          SpawnProbability INTEGER,
                                          TownId INTEGER, 
                                          FOREIGN KEY(TownId) REFERENCES Towns(Id)); 
                                          """;
            ExecuteNonQ(connection, buildTableQuery);
            if (debug) Debugging.WriteNColor("Creating Buildings table.", ConsoleColor.Green);
            
            // Create Townsfolk table
            const string createTownsfolkTable = """
                                                CREATE TABLE Townsfolk(
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
                                                Region TEXT, 
                                                Country TEXT, 
                                                Origin TEXT, 
                                                IsParent INTEGER, 
                                                IsChild INTEGER,
                                                TownId INTEGER, 
                                                FOREIGN KEY(TownId) REFERENCES Towns(Id) );  
                                                """;
            ExecuteNonQ(connection, createTownsfolkTable);



                        if (debug) Debugging.WriteNColor("Creating Townsfolk table.", ConsoleColor.Green);
            // Create Map table
            const string createMapTable = """
                                          CREATE TABLE Map( 
                                          Id INTEGER PRIMARY KEY,
                                          Width INTEGER, 
                                          Height INTEGER, 
                                          TownId INTEGER, 
                                          FOREIGN KEY (TownId) REFERENCES Towns(Id)); 
                                          """;
            ExecuteNonQ(connection, createMapTable);

            if (debug) Debugging.WriteNColor("Creating Map table.", ConsoleColor.Green);

            // Create MapTile table
                      const string createMapTileTable = """
                                                        CREATE TABLE MapTile( 
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
                                                        FOREIGN KEY(MapId) REFERENCES Map(Id)); 
                                                        """;
                      ExecuteNonQ(connection, createMapTileTable);
          
                      if (debug) Debugging.WriteNColor("Creating MapMapTile table.", ConsoleColor.Green);
            connection.Close();
        }

        public static void ExecuteNonQ(SqliteConnection connection, string query)
        {
            using var command = connection.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
        }
        public static void DeleteDatabase(string dbFileName)
        {
            if (File.Exists(dbFileName))
            {
                File.Delete(dbFileName);
            }
            else
            {
                Console.WriteLine("Database file does not exist.");
            }
        }
    }
}

