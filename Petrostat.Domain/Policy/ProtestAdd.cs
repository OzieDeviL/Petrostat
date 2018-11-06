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
                    (int)PolicyRequirement.AtLeast2PC
                  + (int)PolicyRequirement.AtLeast1AlignedNonProtestingNonArmyPopulation
                  + (int)PolicyRequirement.TargetPopulationNotArmy
                  + (int)PolicyRequirement.TargetPopulationNotPropagandaBlocked
                  + (int)PolicyRequirement.TargetPopulationNotProtesting
                };
                return requirementsEnums;
            }
        }

    }
}
