using CommandLine;
namespace TowninatorCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(options =>
                {
                    bool debug = options.Debug;
                    if (debug) Debugging.WriteNColor("Dig in!", ConsoleColor.Green);

                    string dbFileName = Path.Combine(AppContext.BaseDirectory, "town.sqlite");
                    SQLiteDatabaseManager database = new SQLiteDatabaseManager(dbFileName, debug);
                    bool databaseExists = File.Exists(dbFileName);

                    if (!databaseExists)
                    {
                        database.CreateDatabase();
                        Console.WriteLine("New database created.");
                    }

                    var _townRepository = new TownRepository(dbFileName);
                    var _townsfolkController = new TownsfolkController(dbFileName);
                    var _mapRepository = new MapRepository(dbFileName);
                    var _mapController = new MapController(dbFileName, debug);
                    var _townController = new TownController(_townRepository, _mapController, dbFileName, debug);

                    if (options.Reset)
                    {
                        database.DeleteDatabase(dbFileName);
                        database.CreateDatabase();
                    }

                    if (options.Town)
                    {
                        Map map = _mapController.GenerateMap(20, 20);
                        Town town = _townController.GenerateTown();
                        _townController.SaveTown(town, map);
                        _mapController.SaveMap(map, town.Id);
                        _townsfolkController.GenerateFamilies(7, town.Id);
                        _townController.UpdateTown(town);
                        _townController.ViewLatestTown();
                    }
                    else if (options.TownWithTownsfolk)
                    {
                        if (debug) Console.WriteLine("Viewing town information with townsfolk...");
                        _townsfolkController.ViewAllTownsfolk();
                    }
                    else if (options.ViewMap)
                    {
                        if (debug) Console.WriteLine("Viewing map...");
                        _mapController.DisplayLatestMap();
                    }
                    else if (options.MapLengend)
                    {
                        if (debug) Console.WriteLine("Viewing map legend...");
                        _mapController.DisplayMapLegend();
                    }

                    if (debug)
                    {
                        Console.WriteLine("-_Debug End_-");
                    }
                });
        }
    }
    public class Options
    {
        [Option('t', "Town", HelpText = "View town information.")]
        public bool Town { get; set; }

        [Option('w', "TownWithTownsfolk", HelpText = "View town information with townsfolk.")]
        public bool TownWithTownsfolk { get; set; }

        [Option('m', "ViewMap", HelpText = "View map information.")]
        public bool ViewMap { get; set; }

        [Option('l', "MapLegend", HelpText = "View map legend.")]
        public bool MapLengend { get; set; }

        [Option('R', "reset", Required = false, HelpText = "Reset the database.")]
        public bool Reset { get; set; }

        [Option('D', "Debug", Required = false, HelpText = "print debug information.")]
        public bool Debug { get; set; }


    }
}



