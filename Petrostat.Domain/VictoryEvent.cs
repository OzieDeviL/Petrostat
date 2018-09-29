using Petrostat.Domain.Ideologies;
using System.Collections.Generic;

namespace Petrostat.Domain
{
    public class VictoryEvent
    {
        #region Constructors
        public VictoryEvent(){}

        public VictoryEvent(string name
                            , string description
                            , Dictionary<int, Ideology> values)
        {
            Name = name;
            Description = description;
            Values = values;
        }
        #endregion  

        public string Name { get; set; }
        public string Rule { get; set; }
        public string Description { get; set; }
        public Dictionary<int, Ideology> Values { get; set; }
    }
}