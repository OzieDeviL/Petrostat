using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class PropagandaPoor : PolicyChoice
    {
        public override string Name { get => "PropagandaPoor"; }
        public override int NameByEnum { get => (int)Policies.PropagandaPoor; }
        public Population TargetPopulation { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyRequirement.AtLeast1PC
                  + (int)PolicyRequirement.AtLeast1NonAlignedPoorPopulation
                  + (int)PolicyRequirement.TargetPopulationNotArmy
                  + (int)PolicyRequirement.TargetPopulationNotPropagandaBlocked
                };
                return requirementsEnums;
            }
        }

    }
}
