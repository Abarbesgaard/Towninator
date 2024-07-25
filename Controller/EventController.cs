using TowninatorCLI.Model.EventModel;
using TowninatorCLI.View;
using TowninatorCLI.Repositories;
using TowninatorCLI.Utilities.Events;

namespace TowninatorCLI.Controller;

public class EventController(string dbFileName)
{
    private readonly EventRepository _eventRepository = new(dbFileName);
    private readonly EventViewModel _eventViewModel = new(dbFileName);
    private readonly EventGenerator _eventGenerator = new();
    public void AddEvent(EventModel eventModel)
    {
        _eventRepository.AddEvent(eventModel);
    }
    public void ViewAllEvents()
    {
        _eventViewModel.ViewAllEvents();
    }
    public void ViewEvent(int id)
    {
        _eventViewModel.ViewEvent(id);
    }
    public void DeleteEvent(int id)
    {
        _eventRepository.DeleteEvent(id);
    }
    public void UpdateEvent(EventModel eventModel)
    {
        _eventRepository.UpdateEvent(eventModel);
    }
    
    public void GenerateEvents()
    {
        _eventGenerator.GenerateEvents();
    }
    public void GetEventById(int id)
    {
        _eventRepository.GetEventById(id);
    }
}