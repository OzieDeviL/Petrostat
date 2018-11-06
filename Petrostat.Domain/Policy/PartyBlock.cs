using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public class PartyBlock : Policy
    {
        public override string Name { get => "PartyBlock"; }
        public override int NameByEnum { get => (int)Policies.PartyBlock; }
        public PoliticalParty TargetParty { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyRequirement.AtLeast2PC
                  + (int)PolicyRequirement.BeInParty
                  + (int)PolicyRequirement.BePartyLeader
                };
                return requirementsEnums;
            }
        }

    }
}
