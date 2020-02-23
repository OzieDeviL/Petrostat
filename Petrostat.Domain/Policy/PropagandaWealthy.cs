using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class PropagandaWealthy : PolicyChoice
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
                    (int)PolicyRequirement.AtLeast4PC
                  + (int)PolicyRequirement.AtLeast1NonAlignedWealthyPopulation
                  + (int)PolicyRequirement.TargetPopulationNotArmy
                  + (int)PolicyRequirement.TargetPopulationNotPropagandaBlocked
                };
                return requirementsEnums;
            }
        }
    }
}
