using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class SocialSpending : Policy
    {
        public override string Name { get => "SocialSpending"; }
        public override int NameByEnum { get => (int)Policies.SocialSpending; }
        public Dictionary<Population, int> TargetPopulations { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyRequirement.AtLeast1PC
                  + (int)PolicyRequirement.Governing
                  + (int)PolicyRequirement.AtLeast1Treasury
                };
                return requirementsEnums;
            }
        }

    }
}
