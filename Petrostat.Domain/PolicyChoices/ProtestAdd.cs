using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Petrostat.Domain.Ideologies
{
    internal class ProtestAdd : TargetedPolicyChoice<Population>
    {

        public override PolicyName Name { get => PolicyName.ProtestAdd; }
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Place a protest token on one of your population or army markers—limit 1 protest token per marker. Protesting cubes cannot be propagandized and earn double PC during the national events phase.";

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
                        PolicyChoiceTargetRequirement.Aligned                    
                    |   PolicyChoiceTargetRequirement.NotProtesting
                };
                return requirementsEnums;
            }
        }

        protected override PolicyChoiceTargetRequirement GetTargetQualifications(Ideology ideology, Population candidateTarget) 
        {
            var qualifications = PolicyChoiceTargetRequirement.None;
            qualifications |= candidateTarget.Alignment == ideology ? PolicyChoiceTargetRequirement.Aligned : 0;
            qualifications |= !candidateTarget.IsProtesting ? PolicyChoiceTargetRequirement.NotProtesting : 0;
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

