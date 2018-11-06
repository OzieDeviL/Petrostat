using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class ReligiousLawRemove : Policy
    {
        public override string Name { get => "ReligiousLawRemove"; }
        public override int NameByEnum { get => (int)Policies.ReligiousLawRemove; }
        public Population TargetPopulation { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyRequirement.AtLeast2PC
                  + (int)PolicyRequirement.FundamentalistActive
                  + (int)PolicyRequirement.Governing
                  + (int)PolicyRequirement.AtLeast1PopulationUnderReligiousLaw
                  + (int)PolicyRequirement.TargetPopulationUnderReligiousLaw
                };
                return requirementsEnums;
            }
        }

    }
}
