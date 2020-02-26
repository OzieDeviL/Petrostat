using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Petrostat.Domain.Ideologies
{
    internal class ReligiousLawAdd : TargetedPolicyChoice<Population>
    {

        public override PolicyName Name { get => PolicyName.ReligiousLawAdd; }
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Add a religious law token to or from 1 of your aligned population or army markers. Government player may add or remove 1 religious law tokens to or from any population or army marker.";

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
            qualifications |= this.HasSufficientPC(ideology, 2) ? PolicyChoiceRequirement.AtLeast2PC : PolicyChoiceRequirement.None;;            
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
                        PolicyChoiceTargetRequirement.NotUnderReligiousLaw                    
                    |   PolicyChoiceTargetRequirement.Aligned
                };
                return requirementsEnums;
            }
        }

        protected override PolicyChoiceTargetRequirement GetTargetQualifications(Ideology ideology, Population candidateTarget) 
        {
            var qualifications = PolicyChoiceTargetRequirement.None;
            qualifications |= !candidateTarget.IsUnderReligiousLaw ? PolicyChoiceTargetRequirement.NotUnderReligiousLaw : 0;
            qualifications |= candidateTarget.Alignment == ideology ? PolicyChoiceTargetRequirement.Aligned : 0;
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

