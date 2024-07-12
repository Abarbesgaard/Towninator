using CommandLine;
namespace TowninatorCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dbFileName = Path.Combine(AppContext.BaseDirectory, "town.sqlite");
            SQLiteDatabaseManager database = new SQLiteDatabaseManager(dbFileName);
            bool databaseExists = File.Exists(dbFileName);

            if (!databaseExists)
            {
                database.CreateDatabase();
                Console.WriteLine("New database created.");
            }

            var townRepository = new TownRepository(dbFileName);
            var mapRepository = new MapRepository(dbFileName);
            var mapController = new MapController(dbFileName);
            var townController = new TownController(townRepository, mapController, dbFileName);

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(options =>
                {
                    if (options.Town)
                    {
                        Console.WriteLine("Town options selected");

                        townController.AddTown(1);
                        townController.ViewLatestTown();
                    }
                    else if (options.TownWithTownsfolk)
                    {
                        townController.ViewTownWithTownsfolk(1);
                    }
                    else if (options.ViewMap)
                    {
                        mapController.DisplayMap(1);
                    }
                    else if (options.MapLengend)
                    {
                        mapController.DisplayMapLegend();
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




    }
}



