namespace TowninatorCLI
{
    public class MapEvent
    {
        public string Description { get; set; }
        public MapEvent(string description)
        {
            Description = description;
        }
        public override string ToString()
        {
            return Description;
        }
    }
}
