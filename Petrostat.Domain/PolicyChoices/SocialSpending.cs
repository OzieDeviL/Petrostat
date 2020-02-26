using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Petrostat.Domain.Ideologies
{
    internal class SocialSpending : TargetedPolicyChoice<Population>
    {
        public override PolicyName Name { get => PolicyName.SocialSpending; }

        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Transfer any amount wealth from the treasury to any combination of population or army markers of any alignment. Place the spending, red­side up, under the marker. For population markers, increase the marker's position on the wealth track by an equal amount.";

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                        PolicyChoiceRequirement.AtLeast2PC
                    |   PolicyChoiceRequirement.AtLeast1Treasury
                    |   PolicyChoiceRequirement.Governing
                    |   PolicyChoiceRequirement.AtLeast1ValidTarget
                };
                return requirementsEnums;
            }
        }

        protected override PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology)
        {
            var qualifications = PolicyChoiceRequirement.None;
            qualifications |= this.HasSufficientPC(ideology, 2) ? PolicyChoiceRequirement.AtLeast2PC : PolicyChoiceRequirement.None;
            qualifications |= _nation.Government.Treaury >= 1 ? PolicyChoiceRequirement.AtLeast1Treasury : PolicyChoiceRequirement.None;
            qualifications |= ideology.CurrentParty.IsGoverning ? PolicyChoiceRequirement.Governing : PolicyChoiceRequirement.None;
            qualifications |= GetPossibleTargets(ideology).Any() ? PolicyChoiceRequirement.AtLeast1ValidTarget : PolicyChoiceRequirement.None;
            return qualifications;
        }

        internal override Dictionary<int, Population> GetPossibleTargets(Ideology ideology) {
            var possibleTargets = this.GetValidPopulationTargets(ideology, _nation, this.ValidateTarget);
            return possibleTargets;
        }

        protected override List<PolicyChoiceTargetRequirement> MinimumTargetRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceTargetRequirement>
                {
                        PolicyChoiceTargetRequirement.None
                };
                return requirementsEnums;
            }
        }
        
        protected override PolicyChoiceTargetRequirement GetTargetQualifications(Ideology ideology, Population candidateTarget) 
        {
            var qualifications = PolicyChoiceTargetRequirement.None;
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
