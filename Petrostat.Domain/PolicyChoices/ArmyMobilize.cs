using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Petrostat.Domain.Ideologies
{
    internal class ArmyMobilize : TargetedPolicyChoice<Population>
    {

        public override PolicyName Name { get => PolicyName.ArmyMobilize; }

        public override void Play()
        {
            throw new NotImplementedException();
        }

        public override string Description => "Move one marker aligned with your ideology to or from the army box. If moving to the army box, subtract 3 wealth from your aligned cubes—the governing player may spend from the treasury—then stack three spending under the army along with a stack of wealth (red­side down coins) equal to the marker's position on the wealth track.";

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                        PolicyChoiceRequirement.AtLeast2PC
                    |   PolicyChoiceRequirement.AtLeast3AlignedWealth
                    |   PolicyChoiceRequirement.AtLeast1ValidTarget
                };
                return requirementsEnums;
            }
        }
        
        protected override PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology)
        {
            var qualifications = PolicyChoiceRequirement.None;
            qualifications |= ideology.PoliticalCapital >= 2 ? PolicyChoiceRequirement.AtLeast2PC : PolicyChoiceRequirement.None;
            qualifications |= this.IdeologyWealth(ideology) >= 3 ? PolicyChoiceRequirement.AtLeast3AlignedWealth : PolicyChoiceRequirement.None;
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
                        PolicyChoiceTargetRequirement.Aligned
                    |   PolicyChoiceTargetRequirement.Army
                };
                return requirementsEnums;
            }
        }
        protected override PolicyChoiceTargetRequirement GetTargetQualifications(Ideology ideology, Population candidateTarget) 
        {
            var qualifications = PolicyChoiceTargetRequirement.None;
            qualifications |= candidateTarget.IsArmy ? PolicyChoiceTargetRequirement.Army : 0;
            qualifications |= candidateTarget.Alignment == ideology ? PolicyChoiceTargetRequirement.Army : 0;
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
