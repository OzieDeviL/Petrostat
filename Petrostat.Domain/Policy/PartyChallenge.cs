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
                    (int)PolicyRequirement.AtLeast2PC
                  + (int)PolicyRequirement.BeInParty
                  + (int)PolicyRequirement.BeNonLeadingPartyMember
                  + (int)PolicyRequirement.PartyChallengesNotBlocked
                };
                return requirementsEnums;
            }
        }

    }
}
