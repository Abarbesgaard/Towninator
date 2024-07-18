using TowninatorCLI.Repositories;
using TowninatorCLI.Utilities.misc;
using Spectre.Console;

namespace TowninatorCLI.View
{
    public class MapView(MapRepository mapRepository, bool debug = false)
    {
        private const string DesertColor = "yellow";
        private const string ForestColor = "green4";
        private const string GrassLandColor = "palegreen3";
        private const string HillColor = "chartreuse2";
        private const string JungleColor = "darkgreen";
        private const string LowMountainColor = "grey42";
        private const string MediumMountainColor = "grey62";
        private const string HighMountainColor = "grey93";
        private const string OceanColor = "deepskyblue4_1";
        private const string SavannahColor = "darkorange3";
        private const string SwampColor = "springgreen4";
        private const string TundraColor = "grey37";

        public void DisplayMapLegend()
        {
            if (debug) Debugging.WriteNColor("DisplayMapLegend()", ConsoleColor.Blue);
            var table = new Table();
            table.AddColumn(new TableColumn("Symbol").Centered());
            table.AddColumn(new TableColumn("Terrain").Centered());

            // Add the legend rows
            table.AddRow($"[{DesertColor}]~[/]", "Desert");
            table.AddRow($"[{ForestColor}]♣ ♠[/]", "Forest");
            table.AddRow($"[{GrassLandColor}]. ⁿ[/]", "Grassland");
            table.AddRow($"[{HillColor}]∩ n[/]", "Hill");
            table.AddRow($"[{JungleColor}]♣ Γ[/]", "Jungle");
            table.AddRow($"[{LowMountainColor}]⌂[/]", "Low Mountain");
            table.AddRow($"[{MediumMountainColor}]▲[/]", "Medium Mountain");
            table.AddRow($"[{HighMountainColor}]∆[/]", "High Mountain");
            table.AddRow($"[{OceanColor}]≈[/]", "Ocean");
            table.AddRow($"[{SavannahColor}]S[/]", "Savannah");
            table.AddRow($"[{SwampColor}]⌠[/]", "Swamp");
            table.AddRow($"[{TundraColor}]U[/]", "Tundra");

            // Create a panel and add the table to it
            var panel = new Panel(table)
            {
                Header = new PanelHeader("Map Legend"),
                Border = BoxBorder.Rounded
            };

            // Render the panel
            AnsiConsole.Write(panel);
        }

        public void DisplayLatestMap()
        {
            if (debug) Debugging.WriteNColor("DisplayLatestMap()", ConsoleColor.Blue);
            try
            {
                var map = mapRepository.GetLatestMap();

                var mapTiles = map.GetTiles();

                var width = map.Width;
                var height = map.Height;

                // Display the map
                for (var y = 0; y < height; y++)
                {
                    var line = "";
                    for (var x = 0; x < width; x++)
                    {
                        var tile = mapTiles[x, y];

                        // Determine the symbol to display
                        var symbol = tile.ToString();

                        // Set the color for the terrain and print the symbol
                        line += $"[{GetTerrainColor(tile.Terrain)}]{symbol}[/] ";
                    }
                    AnsiConsole.MarkupLine(line); // Move to next line after each row
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]An error occurred: {ex.Message}[/]");
            }
        }

        public void DisplayMap(long mapId)
        {
            try
            {
                var map = mapRepository.LoadMap(mapId);

                var mapTiles = map.GetTiles();

                var width = map.Width;
                var height = map.Height;

                // Display the map
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        var tile = mapTiles[x, y];

                        // Check if this tile has the same terrain type as the one to the left
                        var sameAsLeft = (x > 0 && mapTiles[x - 1, y].Terrain == tile.Terrain);
                        // Check if this tile has the same terrain type as the one above
                        var sameAsAbove = (y > 0 && mapTiles[x, y - 1].Terrain == tile.Terrain);

                        // Determine the symbol to display
                        var symbol = tile.ToString();

                        // If same as left or above, adjust the symbol
                        if (sameAsLeft || sameAsAbove)
                        {
                            symbol = tile.ToString();
                        }

                        AnsiConsole.Markup($"[{GetTerrainColor(tile.Terrain)}]{symbol}[/] ");
                        AnsiConsole.Write(symbol + " ");
                    }

                    AnsiConsole.WriteLine(); // Move to next line after each row
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static string GetTerrainColor(MainTerrainType terrain)
        {
            return terrain switch
            {
                MainTerrainType.Desert => $"{DesertColor}",
                MainTerrainType.Hill => $"{HillColor}",
                MainTerrainType.Forest => $"{ForestColor}",
                MainTerrainType.Grassland => $"{GrassLandColor}",
                MainTerrainType.Jungle => $"{JungleColor}",
                MainTerrainType.LowMountain => $"{LowMountainColor}",
                MainTerrainType.MediumMountain => $"{MediumMountainColor}",
                MainTerrainType.HighMountain => $"{HighMountainColor}",
                MainTerrainType.Ocean => $"{OceanColor}",
                MainTerrainType.Savannah => $"{SavannahColor}",
                MainTerrainType.Swamp => $"{SwampColor}",
                MainTerrainType.Tundra => $"{TundraColor}",
                _ => "white"
            };
        }
    }
}

