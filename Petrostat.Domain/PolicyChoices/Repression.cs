using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Petrostat.Domain.Ideologies
{
    internal class Repression : TargetedPolicyChoice<Population>
    {

        public override PolicyName Name { get => PolicyName.Repression; }
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Roll 1d6 for a chance to remove one protest token from any population marker. A roll of 1-­2 is a failure, discard 1PC; 3­-6 is success. If failure, discard 1PC. Repression requires an army marker aligned with your ideology. Repression may be challenged by any army—see manual for conflict rules.";

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                        PolicyChoiceRequirement.AtLeast1PC
                    |   PolicyChoiceRequirement.AtLeast1AlignedArmy
                    |   PolicyChoiceRequirement.AtLeast1ValidTarget
                };
                return requirementsEnums;
            }
        }       

        protected override PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology)
        {
            var qualifications = PolicyChoiceRequirement.None;            
            qualifications |= this.HasSufficientPC(ideology, 1) ? PolicyChoiceRequirement.AtLeast1PC : PolicyChoiceRequirement.None;
            qualifications |= this.HasAlignedArmy(ideology) ? PolicyChoiceRequirement.AtLeast1AlignedArmy : PolicyChoiceRequirement.None;
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
                        PolicyChoiceTargetRequirement.NotAligned                    
                    |   PolicyChoiceTargetRequirement.Protesting
                };
                return requirementsEnums;
            }
        }

        protected override PolicyChoiceTargetRequirement GetTargetQualifications(Ideology ideology, Population candidateTarget) 
        {
            var qualifications = PolicyChoiceTargetRequirement.None;
            qualifications |= candidateTarget.Alignment != ideology ? PolicyChoiceTargetRequirement.NotAligned : 0;
            qualifications |= candidateTarget.IsProtesting ? PolicyChoiceTargetRequirement.Protesting : 0;
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

