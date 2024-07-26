namespace TowninatorCLI.Model.EventModel;

public class EventModel(int? id, string name, string description, EventSeverity eventSeverity, EventType eventType, 
   int mapTileId, int? townsfolkId,  bool isFinished, bool inProgress, string impact, int priority, 
   string resourcesNeeded, string consequences, string reward, List<SubEvent> subEvent)
{

   public int? Id { get; set; } = id;
   public string Name { get; set; } = name;
   public string Description { get; set; } = description;
   public EventSeverity EventSeverity { get; set; } = eventSeverity;
   public EventType EventType { get; set; } = eventType;
   public int MapTileId { get; set; } = mapTileId;
   public int? TownsfolkId { get; set; } = townsfolkId;
   public bool IsFinished { get; set; } = isFinished;
   public bool InProgress { get; set; } = inProgress;
   public string Impact { get; set; } = impact;
   public int Priority { get; set; } = priority;
   public string ResourcesNeeded { get; set; } = resourcesNeeded;
   public string Consequences { get; set; } = consequences;

   public string Reward { get; set; } = reward;
   public List<SubEvent> SubEvent { get; set; } = subEvent;

}

public class SubEvent(string name, string description)
{
   public int? Id { get; set; }
   public string Name { get; set; } = name;
   public string Description { get; set; } = description;
   public int EventId { get; set; }
}
