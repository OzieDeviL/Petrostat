using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class PropagandaBlocking : Policy
    {
        public override string Name { get => "PropagandaBlocking"; }
        public override int NameByEnum { get => (int)Policies.PropagandaBlocking; }
        public List<Population> TargetPopulations { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyRequirement.AtLeast1PC
                  + (int)PolicyRequirement.AtLeast1AlignedNonArmyCube
                };
                return requirementsEnums;
            }
        }

    }
}
