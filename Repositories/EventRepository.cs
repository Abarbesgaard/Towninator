using Microsoft.Data.Sqlite;
using Spectre.Console;
using TowninatorCLI.Model.EventModel;

namespace TowninatorCLI.Repositories
{
    public class EventRepository(string dbFileName)
    {
        private readonly string _connectionString = $"Data Source={dbFileName}";

        public void DeleteEvent(int id)
        { 
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            const string query = "DELETE FROM Event WHERE id = @id";

            try
            {
                using var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                var rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    AnsiConsole.WriteLine($"No event found with Id: {id} to delete.");
                }
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
        public List<EventModel> GetAllEvents()
        {
          List<EventModel> events = [];
          if (events == null) throw new ArgumentNullException(nameof(events));

          using var connection = new SqliteConnection(_connectionString);
          connection.Open();
          const string query = "SELECT * FROM Event";
          try
          {
              using var command = new SqliteCommand(query, connection);
              using var reader = command.ExecuteReader();
              if (reader.Read())
              {
                    var eventModel = new EventModel(
                        id: reader.GetInt32(reader.GetOrdinal("id")),
                        name: reader.GetString(reader.GetOrdinal("name")),
                        description: reader.GetString(reader.GetOrdinal("description")),
                        eventSeverity: Enum.Parse<EventSeverity>(reader.GetString(reader.GetOrdinal("eventSeverity"))),
                        eventType: Enum.Parse<EventType>(reader.GetString(reader.GetOrdinal("eventType"))),
                        mapTileId: reader.GetInt32(reader.GetOrdinal("mapTileId")),
                        townsfolkId: reader.IsDBNull(reader.GetOrdinal("townsfolkId")) ? null : reader.GetInt32(reader.GetOrdinal("townsfolkId")),
                        isFinished: reader.GetBoolean(reader.GetOrdinal("isFinished")),
                        inProgress: reader.GetBoolean(reader.GetOrdinal("inProgress")),
                        impact: reader.GetString(reader.GetOrdinal("impact")),
                        priority: reader.GetInt32(reader.GetOrdinal("priority")),
                        resourcesNeeded: reader.GetString(reader.GetOrdinal("resourcesNeeded")),
                        consequences: reader.GetString(reader.GetOrdinal("consequences"))
                    );
                    events.Add(eventModel);
              }
              else
              {
                  AnsiConsole.WriteLine("No events found.");
              }
          }
          catch( Exception ex)
          {
                AnsiConsole.WriteLine(ex.Message);
          }
          finally
          {
              connection.Close();
          }

          return events;
        }
        public EventModel? GetEventById(int id)
        {
            EventModel? eventModel = null;

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            const string query = """
                                 SELECT id, name, description, eventSeverity, eventType, mapTileId, townsfolkId, 
                                        isFinished, inProgress, impact, priority, resourcesNeeded, consequences
                                 FROM Event
                                 WHERE id = @id
                                 """;
            try
            {
                using var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    eventModel = new EventModel(
                        reader.GetInt32(reader.GetOrdinal("id")),
                        name: reader.GetString(reader.GetOrdinal("name")),
                        description: reader.GetString(reader.GetOrdinal("description")),
                        eventSeverity: Enum.Parse<EventSeverity>(reader.GetString(reader.GetOrdinal("eventSeverity"))),
                        eventType: Enum.Parse<EventType>(reader.GetString(reader.GetOrdinal("eventType"))),
                        mapTileId: reader.GetInt32(reader.GetOrdinal("mapTileId")),
                        townsfolkId: reader.IsDBNull(reader.GetOrdinal("townsfolkId")) ? null : reader.GetInt32(reader.GetOrdinal("townsfolkId")),
                        isFinished: reader.GetBoolean(reader.GetOrdinal("isFinished")),
                        inProgress: reader.GetBoolean(reader.GetOrdinal("inProgress")),
                        impact: reader.GetString(reader.GetOrdinal("impact")),
                        priority: reader.GetInt32(reader.GetOrdinal("priority")),
                        resourcesNeeded: reader.GetString(reader.GetOrdinal("resourcesNeeded")),
                        consequences: reader.GetString(reader.GetOrdinal("consequences"))
                    );
                }
                else
                {
                    AnsiConsole.WriteLine($"No event found with Id: {id}");
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return eventModel;
        }


        public void AddEvent(EventModel eventModel)
        {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        const string query = """
                             INSERT INTO Event (name, description, eventSeverity, eventType, mapTileId, townsfolkId, isFinished, inProgress, impact, priority, resourcesNeeded, consequences)
                             VALUES (@name, @description, @eventSeverity, @eventType, @mapTileId, @townsfolkId, @isFinished, @inProgress, @impact, @priority, @resourcesNeeded, @consequences);
                             SELECT last_insert_rowid();
                             """;

        try
        {
            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@name", eventModel.Name);
            command.Parameters.AddWithValue("@description", eventModel.Description);
            command.Parameters.AddWithValue("@eventSeverity", eventModel.EventSeverity.ToString());
            command.Parameters.AddWithValue("@eventType", eventModel.EventType.ToString());
            command.Parameters.AddWithValue("@mapTileId", eventModel.MapTileId);
            command.Parameters.AddWithValue("@townsfolkId", (object?)eventModel.TownsfolkId ?? DBNull.Value);
            command.Parameters.AddWithValue("@isFinished", eventModel.IsFinished);
            command.Parameters.AddWithValue("@inProgress", eventModel.InProgress);
            command.Parameters.AddWithValue("@impact", eventModel.Impact);
            command.Parameters.AddWithValue("@priority", eventModel.Priority);
            command.Parameters.AddWithValue("@resourcesNeeded", eventModel.ResourcesNeeded);
            command.Parameters.AddWithValue("@consequences", eventModel.Consequences);

            // Retrieve the ID of the newly inserted event
            _ = (long)(command.ExecuteScalar() ?? throw new InvalidOperationException());
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteLine(ex.Message);
            throw;
        }
        finally
        {
            connection.Close();
        }
        }

        public void UpdateEvent(EventModel eventModel)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            const string query = """
                                 UPDATE Event
                                 SET name = @name,
                                     description = @description,
                                     eventSeverity = @eventSeverity,
                                     eventType = @eventType,
                                     mapTileId = @mapTileId,
                                     townsfolkId = @townsfolkId,
                                     isFinished = @isFinished,
                                     inProgress = @inProgress,
                                     impact = @impact,
                                     priority = @priority,
                                     resourcesNeeded = @resourcesNeeded,
                                     consequences = @consequences
                                 WHERE id = @id
                                 """;

            try
            {
                using var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@id", eventModel.Id);
                command.Parameters.AddWithValue("@name", eventModel.Name);
                command.Parameters.AddWithValue("@description", eventModel.Description);
                command.Parameters.AddWithValue("@eventSeverity", eventModel.EventSeverity.ToString());
                command.Parameters.AddWithValue("@eventType", eventModel.EventType.ToString());
                command.Parameters.AddWithValue("@mapTileId", eventModel.MapTileId);
                command.Parameters.AddWithValue("@townsfolkId", (object?)eventModel.TownsfolkId ?? DBNull.Value);
                command.Parameters.AddWithValue("@isFinished", eventModel.IsFinished);
                command.Parameters.AddWithValue("@inProgress", eventModel.InProgress);
                command.Parameters.AddWithValue("@impact", eventModel.Impact);
                command.Parameters.AddWithValue("@priority", eventModel.Priority);
                command.Parameters.AddWithValue("@resourcesNeeded", eventModel.ResourcesNeeded);
                command.Parameters.AddWithValue("@consequences", eventModel.Consequences);

                var rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    // Handle the case where no rows were updated
                    AnsiConsole.WriteLine($"No event found with Id: {eventModel.Id} to update.");
                }
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