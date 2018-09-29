using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class PropagandaMiddleClass : Policy
    {
        public override string Name { get => "PropagandaMiddleClass"; }
        public override int NameByEnum { get => (int)Policies.PropagandaMiddleClass; }
        public Population TargetPopulation { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyFSM.AtLeast3PC
                  + (int)PolicyFSM.AtLeast1NonAlignedMiddleClassPopulation
                  + (int)PolicyFSM.TargetPopulationNotArmy
                  + (int)PolicyFSM.TargetPopulationNotPropagandaBlocked
                };
                return requirementsEnums;
            }
        }

    }
}
