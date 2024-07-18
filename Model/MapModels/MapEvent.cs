namespace TowninatorCLI.Model.MapModels
{
    public class MapEvent(string description)
    {
        public string Description { get; set; } = description;

        public override string ToString()
        {
            return Description;
        }
    }
}
