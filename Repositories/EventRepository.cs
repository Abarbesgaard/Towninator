using Microsoft.Data.Sqlite;
using Spectre.Console;
using TowninatorCLI.Model.EventModel;
using TowninatorCLI.Utilities.misc;

namespace TowninatorCLI.Repositories
{
    public class EventRepository(string dbFileName, bool debug = false)
    {
        private readonly string _connectionString = $"Data Source={dbFileName}";

        public void AddEvent(EventModel eventModel)
        {
            if (debug) Debugging.WriteNColor("[] EventRepository.AddEvent()", ConsoleColor.Green);

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            const string query = """
                                 INSERT INTO Event ( name, description, eventSeverity, eventType, mapTileId, townsfolkId, isFinished, inProgress, impact, priority, resourcesNeeded, consequences)
                                 VALUES ( @name, @description, @eventSeverity, @eventType, @mapTileId, @townsfolkId, @isFinished, @inProgress, @impact, @priority, @resourcesNeeded, @consequences)
                                 """;

            try
            {
                using var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@name", eventModel.Name ?? "");
                command.Parameters.AddWithValue("@description", eventModel.Description ?? "");
                command.Parameters.AddWithValue("@eventSeverity", eventModel.EventSeverity.ToString());
                command.Parameters.AddWithValue("@eventType", eventModel.EventType.ToString());
                command.Parameters.AddWithValue("@mapTileId", eventModel.MapTileId);
                command.Parameters.AddWithValue("@townsfolkId", (object?)eventModel.TownsfolkId ?? DBNull.Value);
                command.Parameters.AddWithValue("@isFinished", eventModel.IsFinished);
                command.Parameters.AddWithValue("@inProgress", eventModel.InProgress);
                command.Parameters.AddWithValue("@impact", eventModel.Impact ?? "");
                command.Parameters.AddWithValue("@priority", eventModel.Priority);
                command.Parameters.AddWithValue("@resourcesNeeded", eventModel.ResourcesNeeded ?? "");
                command.Parameters.AddWithValue("@consequences", eventModel.Consequences ?? "");


                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    } 
}