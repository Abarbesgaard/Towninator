using TowninatorCLI.Model;
using TowninatorCLI.Model.EventModel;
using TowninatorCLI.Model.MapModels;
using TowninatorCLI.Repositories;
namespace TowninatorCLI.Utilities.Events;

   public class EventGenerator(string dbFileName)
   {
       private readonly Random _random = new();
       private readonly MapRepository _mapRepository = new(dbFileName);
       private readonly TownsfolkRepository _townsfolkRepository = new(dbFileName);
       private readonly EventRepository _eventRepository = new(dbFileName);
     
public EventModel GenerateEvents(MainTerrainType terrain)
{
    var events = new List<EventModel>();
    if (events == null) throw new ArgumentNullException(nameof(events));
    var townsfolk = _townsfolkRepository.GetAll();

    foreach (var tf in townsfolk)
    {
        var eventModel = GenerateEventForTownsfolk(tf, terrain); 

        // Save the event to the database and get its ID
        var eventId = _eventRepository.AddEvent(eventModel);
        eventModel.Id = eventId;

        // Save each sub-event with the event ID
        foreach (var subEvent in eventModel.SubEvent)
        {
            subEvent.EventId = eventId;
            _eventRepository.AddSubEvent(subEvent, eventId);
        }

        events.Add(eventModel);
        return eventModel;
    }

    return null!;
}
private EventModel GenerateEventForTownsfolk(Townsfolk townsfolk, MainTerrainType terrain)
{
    return new EventModel(
        null, EventName(terrain), EventDescription(), 0, EventType(), 
        1, townsfolk.Id, false, false, Impact(), 3, ResourcesNeeded(), Consequences(), Reward(), SubEvents());
}


    private List<SubEvent> SubEvents()
    {
        var subEvents = new List<SubEvent>
        {
            new("SubEvent1", "Description of SubEvent1"),
            new("SubEvent2", "Description of SubEvent2"),
            new("SubEvent3", "Description of SubEvent3")
        };
        
        return subEvents;
    }
    private string Reward()
    {
        const string reward = "A reward";
        return reward;
    }
    private string Consequences()
    {
        const string consequences = "A description of consequences";
        return consequences;
    }
    private string ResourcesNeeded()
    {
        const string resourcesNeeded = "Oxen, food, and water";
        return resourcesNeeded;
    }
    private string Impact()
    {
        const string impact = "Impact Description";
        return impact;
    }
private int EventTownsfolk()
    {
        var townsfolk = _townsfolkRepository.GetAll();
        var townsfolkId = townsfolk[_random.Next(townsfolk.Count)].Id;
        return townsfolkId;
    }
    private EventType EventType()
    {
        const EventType eventType = Model.EventModel.EventType.PoliticalEvent;
        return eventType;
    }

    private string EventName(MainTerrainType terrain)
    {
        var eventName = $"name of event in {terrain}";
        return eventName;
    }
    private string EventDescription(){
        const string eventDescription = "description of event";
        return eventDescription;
    }

    
}

     