using TowninatorCLI.Repositories;
using Spectre.Console;

namespace TowninatorCLI.View;


public class EventViewModel(string dbFileName)
{
    private readonly EventRepository _eventRepository = new(dbFileName);
    public void ViewAllEvents()
    {
        AnsiConsole.WriteLine("All events:");
        foreach (var eventModel in _eventRepository.GetAllEvents())
        {
            AnsiConsole.WriteLine(eventModel.ToString() ?? throw new InvalidOperationException());
        }
    }
    public void ViewEvent(int id)
    {
        AnsiConsole.WriteLine($"{_eventRepository.GetEventById(id)}");
    }
}