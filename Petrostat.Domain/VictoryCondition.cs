namespace Petrostat.Domain
{
    public class VictoryCondition
    {
        public string Name { get; set; }
        public int VictoryPoints { get; set; }
        public string Description { get; set; }
        public VictoryEvent VictoryEvent { get; set; }

    }
}