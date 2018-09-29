using Petrostat.Domain.Ideologies;
using System.Collections.Generic;

namespace Petrostat.Domain
{
    public class Settings
    {
        public int Balance { get; set; }
        public int PolicyRoundsPerTurn { get => 3; }
        public List<Ideology> AvailableIdeologies {get;set;}
        public Dictionary<int, Ideology> TurnOrder { get; set; }
        public bool QuickPlay { get; set; }
    }
}