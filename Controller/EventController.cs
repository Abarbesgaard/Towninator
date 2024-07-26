using TowninatorCLI.Model;
using TowninatorCLI.Model.EventModel;
using TowninatorCLI.Model.MapModels;
using TowninatorCLI.View;
using TowninatorCLI.Repositories;
using TowninatorCLI.Utilities.Events;

namespace TowninatorCLI.Controller;

public class EventController(string dbFileName)
{
    private readonly EventRepository _eventRepository = new(dbFileName);
    private readonly EventViewModel _eventViewModel = new(dbFileName);
    private readonly EventGenerator _eventGenerator = new(dbFileName);
    private readonly TownsfolkRepository _townsfolkRepository = new(dbFileName);

    public void AddEvent(EventModel? eventModel)
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
    
   
    public void GetEventById(int id)
    {
        _eventRepository.GetEventById(id);
    }
    
    public EventModel GenerateEventForTownsfolk(Townsfolk townsfolk)
    {
        var terrain = _townsfolkRepository.GetTerrainForTownsfolk(townsfolk.Id);
    
        if (terrain == null)
        {
            throw new InvalidOperationException($"No terrain found for townsfolk with ID {townsfolk.Id}");
        }
    
        return _eventGenerator.GenerateEvents(terrain.Value); // Use .Value to get the non-nullable type
    }
    }



