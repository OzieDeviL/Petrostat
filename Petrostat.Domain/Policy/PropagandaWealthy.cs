using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class PropagandaWealthy : Policy
    {
        public override string Name { get => "PropagandaWealthy"; }
        public override int NameByEnum { get => (int)Policies.PropagandaWealthy; }
        public Population TargetPopulation { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyFSM.AtLeast4PC
                  + (int)PolicyFSM.AtLeast1NonAlignedWealthyPopulation
                  + (int)PolicyFSM.TargetPopulationNotArmy
                  + (int)PolicyFSM.TargetPopulationNotPropagandaBlocked
                };
                return requirementsEnums;
            }
        }
    }
}
