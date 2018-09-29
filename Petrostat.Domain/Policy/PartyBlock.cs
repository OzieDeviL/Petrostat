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
                    (int)PolicyFSM.AtLeast2PC
                  + (int)PolicyFSM.BeInParty
                  + (int)PolicyFSM.BePartyLeader
                };
                return requirementsEnums;
            }
        }

    }
}
