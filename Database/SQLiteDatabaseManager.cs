using Debugland;
using Microsoft.Data.Sqlite;
using TowninatorCLI.Utilities.misc;
namespace TowninatorCLI.Database
{
    public class SqLiteDatabaseManager(string dbFileName)
    {
        private readonly string _connectionString = $"Data Source={dbFileName}; foreign keys=true;";
        public void CreateDatabase()
        {
            #region Debuggin
            Debugger.MethodInitiated("CreateDatabase");
            Debugger.SQLConnectionInitiated();
            #endregion
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
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
                                              DROP TABLE IF EXISTS Event;

                                          """;
            ExecuteNonQ(connection, dropTableQuery);
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
                                           Consequences TEXT,
                                           Reward TEXT);
                                           """;
            ExecuteNonQ(connection, eventTableQuery);
            
            const string buildTableQuery ="""
                                          CREATE TABLE Buildings( 
                                          Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                          Name TEXT, 
                                          Description TEXT, 
                                          BuildingType INTEGER , 
                                          SpecificBuilding INTEGER, 
                                          TownId INTEGER, 
                                            TownsfolkId INTEGER,
                                            CoastalModifier REAL,
                                            FjordModifier REAL,
                                            ForestModifier REAL,
                                            GrasslandModifier REAL,
                                            HeathModifier REAL,
                                            HighlandModifier REAL,
                                            LakeModifier REAL,
                                            MarshModifier REAL,
                                            MeadowModifier REAL,
                                            LowMountainModifier REAL,
                                            MediumMountainModifier REAL,
                                            HighMountainModifier REAL,
                                            WetlandModifier REAL,
                                            TundraModifier REAL,
                                          FOREIGN KEY(TownId) REFERENCES Towns(Id)); 
                                          """;
       

            ExecuteNonQ(connection, buildTableQuery);
            
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
                                                Intelligence INTEGER,
                                                Strength INTEGER,
                                                Charisma INTEGER,
                                                Wisdom INTEGER,
                                                Dexterity INTEGER,
                                                Constitution INTEGER,
                                                Luck INTEGER,
                                                Sanity INTEGER,
                                                Perception INTEGER,
                                                Willpower INTEGER,
                                                Faith INTEGER,
                                                Terrain TEXT,
                                                FOREIGN KEY(TownId) REFERENCES Towns(Id) );  
                                                """;
             
            ExecuteNonQ(connection, createTownsfolkTable);
            const string createMapTable = """
                                          CREATE TABLE Map( 
                                          Id INTEGER PRIMARY KEY,
                                          Width INTEGER, 
                                          Height INTEGER, 
                                          TownId INTEGER, 
                                          FOREIGN KEY (TownId) REFERENCES Towns(Id)); 
                                          """;
            ExecuteNonQ(connection, createMapTable);
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
                      const string createSubEventTable = """
                                                        CREATE TABLE SubEvent( 
                                                        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                                        Name TEXT, 
                                                        Description TEXT, 
                                                        EventId INTEGER, 
                                                        FOREIGN KEY(EventId) REFERENCES Event(Id)); 
                                                        """;
                      ExecuteNonQ(connection, createSubEventTable);
            connection.Close();
            #region Debuggin
Debugger.SQLCommandTerminated();
            Debugger.MethodTerminated($"{nameof(SqliteConnection)}");
            #endregion
        }

        public static void ExecuteNonQ(SqliteConnection connection, string query)
        {
            #region Debuggin
            Debugger.MethodInitiated($"{nameof(ExecuteNonQ)}");
            Debugger.MethodParameter($"{connection}, {query}");
            #endregion
            using var command = connection.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            #region Debuggin
            Debugger.MethodTerminated($"{nameof(ExecuteNonQ)}");
            #endregion
        }
        public static void DeleteDatabase(string dbFileName)
        {
            #region Debuggin
    Debugger.MethodInitiated($"{nameof(DeleteDatabase)}");
                 Debugger.MethodParameter($"{dbFileName}");
            #endregion
            if (File.Exists(dbFileName))
            {
                File.Delete(dbFileName);
            }
            else
            {
                Console.WriteLine("Database file does not exist.");
            }
            #region Debuggin
            Debugger.MethodTerminated($"{nameof(ExecuteNonQ)}");
            #endregion
        }
    }
}

