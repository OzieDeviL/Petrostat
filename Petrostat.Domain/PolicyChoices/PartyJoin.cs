using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static Petrostat.Domain.Ideologies.PolicyQualificationExtensions;

namespace Petrostat.Domain.Ideologies
{
    internal class PartyJoin : TargetedPolicyChoice<PoliticalParty>
    {
        private PoliticalParty _targetParty;

        PartyJoin (PoliticalParty targetParty) {
            _targetParty = targetParty;
        }

        public override PolicyName Name { get => PolicyName.PartyJoin; }
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Join a party.";

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                        PolicyChoiceRequirement.AtLeast2PC
                    |   PolicyChoiceRequirement.AtLeast1ValidTarget
                };
                return requirementsEnums;
            }
        }
        
        protected override PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology)
        {
            var qualifications = PolicyChoiceRequirement.None;
            qualifications |= ideology.PoliticalCapital >= 2 ? PolicyChoiceRequirement.AtLeast2PC : PolicyChoiceRequirement.None;
            qualifications |= GetPossibleTargets(ideology).Any() ? PolicyChoiceRequirement.AtLeast1ValidTarget : PolicyChoiceRequirement.None;
            return qualifications;
        }

        internal override Dictionary<int, PoliticalParty> GetPossibleTargets(Ideology ideology) {
            var possibleTargets = this.GetValidPartyTargets(ideology, _nation, this.ValidateTarget);
            return possibleTargets;
        }
        protected override List<PolicyChoiceTargetRequirement> MinimumTargetRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceTargetRequirement>
                {
                        PolicyChoiceTargetRequirement.NotInTargetParty
                };
                return requirementsEnums;
            }
        }
        protected override PolicyChoiceTargetRequirement GetTargetQualifications(Ideology ideology, PoliticalParty candidateTarget) 
        {
            var qualifications = PolicyChoiceTargetRequirement.None;
            qualifications |= !candidateTarget.Members.Contains(ideology) ? PolicyChoiceTargetRequirement.NotInTargetParty : 0;
            return qualifications;
        }

        protected override bool IsSuccess()
        {
            throw new NotImplementedException();
        }

        protected override void OnSuccess()
        {
            throw new NotImplementedException();
        }

        protected override void OnFailure()
        {
            throw new NotImplementedException();
        }

    }    
}
