using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class ProtestRemove : Policy
    {
        public override string Name { get => "ProtestRemove"; }
        public override int NameByEnum { get => (int)Policies.ProtestRemove; }
        public List<Population> TargetPopulations { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyRequirement.AtLeast1AlignedProtester
                  + (int)PolicyRequirement.TargetPopulationsProtesting
                };
                return requirementsEnums;
            }
        }

    }
}
