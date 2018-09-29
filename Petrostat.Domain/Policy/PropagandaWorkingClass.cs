using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class PropagandaWorkingClass : Policy
    {
        public override string Name { get => "PropagandaWorkingClass"; }
        public override int NameByEnum { get => (int)Policies.PropagandaWorkingClass; }
        public Population TargetPopulation { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyFSM.AtLeast2PC
                  + (int)PolicyFSM.AtLeast1NonAlignedWorkingClassPopulation
                  + (int)PolicyFSM.TargetPopulationNotArmy
                  + (int)PolicyFSM.TargetPopulationNotPropagandaBlocked
                };
                return requirementsEnums;
            }
        }

    }
}
