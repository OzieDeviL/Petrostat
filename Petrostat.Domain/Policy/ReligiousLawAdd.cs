using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class ReligiousLawAdd : Policy
    {
        public ReligiousLawAdd(Guid roundId) : base(roundId) { }
   
        public override Guid Id { get; set; }
        public override Guid RoundId { get; set; }

        public override string Name { get => "ReligiousLawAdd"; }
        public override int NameByEnum { get => (int)Policies.ReligiousLawAdd; }
        public Population TargetPopulation { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyFSM.AtLeast2PC
                  + (int)PolicyFSM.AtLeast1PopulationWithoutReligiousLaw
                  + (int)PolicyFSM.FundamentalistActive
                  + (int)PolicyFSM.Governing
                  + (int)PolicyFSM.TargetPopulationNotUnderReligiousLaw
                };
                return requirementsEnums;
            }
        }

    }
}
