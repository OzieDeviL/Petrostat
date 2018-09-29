using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class ProtestAdd : Policy
    {
        public override string Name { get => "ProtestAdd"; }
        public override int NameByEnum { get => (int)Policies.ProtestAdd; }
        public Population TargetPopulation { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyFSM.AtLeast2PC
                  + (int)PolicyFSM.AtLeast1AlignedNonProtestingNonArmyPopulation
                  + (int)PolicyFSM.TargetPopulationNotArmy
                  + (int)PolicyFSM.TargetPopulationNotPropagandaBlocked
                  + (int)PolicyFSM.TargetPopulationNotProtesting
                };
                return requirementsEnums;
            }
        }

    }
}
