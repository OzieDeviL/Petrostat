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
                    (int)PolicyFSM.AtLeast2PC
                  + (int)PolicyFSM.FundamentalistActive
                  + (int)PolicyFSM.Governing
                  + (int)PolicyFSM.AtLeast1PopulationUnderReligiousLaw
                  + (int)PolicyFSM.TargetPopulationUnderReligiousLaw
                };
                return requirementsEnums;
            }
        }

    }
}
