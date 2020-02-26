using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Petrostat.Domain.Ideologies
{
    internal class Genocide : TargetedPolicyChoice<Population>
    {
        public override PolicyName Name { get => PolicyName.Genocide; }

        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Target a population or army marker. Remove the targeted marker from the from the population and distribute half its wealth and spending among markers of your choice. Genocide may be challenged by any army after the target marker is announced—see manual for conflict rules.";

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                    PolicyChoiceRequirement.AtLeast3PC,
                    PolicyChoiceRequirement.AtLeast1ValidTarget
                };
                return requirementsEnums;
            }
        }

        protected override PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology)
        {
            var qualifications = PolicyChoiceRequirement.None;
            qualifications |= ideology.PoliticalCapital >= 3 ? PolicyChoiceRequirement.AtLeast3PC : PolicyChoiceRequirement.None;
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
