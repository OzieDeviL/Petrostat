using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Petrostat.Domain.Ideologies
{
    internal class StateSecurityMarker : TargetedPolicyChoice<PolicyChoice>
    {
        private Round _round;

        public StateSecurityMarker(Round round) : base() 
        {
            _round = round;
        }

        public override PolicyName Name { get => PolicyName.StateSecurity; }

        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Either choose a player and remove their policy token from this round or flip the government marker disc to prevent/allow elections at the end of the turn.";

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                        PolicyChoiceRequirement.AtLeast2PC
                    |   PolicyChoiceRequirement.Governing
                };
                return requirementsEnums;
            }
        }

        protected override PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology)
        {
            var qualifications = PolicyChoiceRequirement.None;
            qualifications |= this.HasSufficientPC(ideology, 2) ? PolicyChoiceRequirement.AtLeast2PC : PolicyChoiceRequirement.None;
            qualifications |= ideology.CurrentParty.IsGoverning ? PolicyChoiceRequirement.Governing : PolicyChoiceRequirement.None;
            return qualifications;
        }

        internal override Dictionary<int, PolicyChoice> GetPossibleTargets(Ideology ideology) {
            var possibleTargets = this.GetValidPolicyChoiceTargets(ideology, _round, this.ValidateTarget);
            return possibleTargets;
        }

        protected override List<PolicyChoiceTargetRequirement> MinimumTargetRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceTargetRequirement>
                {
                    PolicyChoiceTargetRequirement.NotIdeologyPolicyChoice
                };
                return requirementsEnums;
            }
        }
        
        protected override PolicyChoiceTargetRequirement GetTargetQualifications(Ideology ideology, PolicyChoice candidateTarget) 
        {
            var qualifications = PolicyChoiceTargetRequirement.None;
            qualifications |= candidateTarget.Ideology != ideology ? PolicyChoiceTargetRequirement.NotIdeologyPolicyChoice: PolicyChoiceTargetRequirement.None;
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
