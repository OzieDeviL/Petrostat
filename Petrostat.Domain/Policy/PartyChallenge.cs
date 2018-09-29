using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public class PartyChallenge : Policy
    {
        public override string Name { get => "PartyChallenge"; }
        public override int NameByEnum { get => (int)Policies.PartyChallenge; }
        public PoliticalParty TargetParty;
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyFSM.AtLeast2PC
                  + (int)PolicyFSM.BeInParty
                  + (int)PolicyFSM.BeNonLeadingPartyMember
                  + (int)PolicyFSM.PartyChallengesNotBlocked
                };
                return requirementsEnums;
            }
        }

    }
}
