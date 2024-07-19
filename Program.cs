using CommandLine;
using TowninatorCLI.Controller;
using TowninatorCLI.Database;
using TowninatorCLI.Utilities.misc;
using TowninatorCLI.Repositories;

namespace TowninatorCLI
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(options =>
                {
                    var debug = options.Debug;
                    if (debug) Debugging.WriteNColor("Dig in!", ConsoleColor.Green);

                    var dbFileName = Path.Combine(AppContext.BaseDirectory, "town.sqlite");
                    var database = new SqLiteDatabaseManager(dbFileName, debug);
                    var databaseExists = File.Exists(dbFileName);

                    if (!databaseExists)
                    {
                        database.CreateDatabase();
                        Console.WriteLine("New database created.");
                    }

                    var townRepository = new TownRepository(dbFileName);
                    var townsfolkController = new TownsfolkController(dbFileName);
                    var mapController = new MapController(dbFileName, debug);
                    var townController = new TownController(townRepository, mapController, dbFileName, debug);
                    var buildingController = new BuildingsController(dbFileName, debug);

                    if (options.Reset)
                    {
                        SqLiteDatabaseManager.DeleteDatabase(dbFileName);
                        database.CreateDatabase();
                    }

                    if (options.Town)
                    {
                        var map = mapController.GenerateMap(30, 30);
                        var town = townController.GenerateTown();
                        townController.SaveTown(town, map);
                        mapController.SaveMap(map, town.Id);
                        townsfolkController.GenerateFamilies(7, town.Id);
                        townController.UpdateTown(town);
                        buildingController.GenerateBuildings();
                        townController.ViewLatestTown();
                        buildingController.ViewAllBuildings();
                        mapController.DisplayLatestMap();
                        
                    }
                    else if (options.TownWithTownsfolk)
                    {
                        if (debug) Console.WriteLine("Viewing town information with townsfolk...");
                        townsfolkController.ViewAllTownsfolk();
                    }
                    else if (options.ViewMap)
                    {
                        if (debug) Console.WriteLine("Viewing map...");
                        mapController.DisplayLatestMap();
                    }
                    else if (options.MapLegend)
                    {
                        if (debug) Console.WriteLine("Viewing map legend...");
                        mapController.DisplayMapLegend();
                    }
                    else if (options.Buildings)
                    {
                        if(debug) Debugging.WriteNColor("[] Options.Buildings", ConsoleColor.Green);
                        buildingController.ViewAllBuildings();
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
        public bool MapLegend { get; set; }

        [Option('R', "reset", Required = false, HelpText = "Reset the database.")]
        public bool Reset { get; set; }
        
        [Option('B',"Buildings", Required = false, HelpText = "Display a building" )]
        public bool Buildings { get; set; }
        
        [Option('D', "Debug", Required = false, HelpText = "print debug information.")]
        public bool Debug { get; set; }
        
    }
}



