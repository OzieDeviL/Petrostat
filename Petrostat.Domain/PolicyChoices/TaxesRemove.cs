using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Petrostat.Domain.Ideologies
{
    internal class TaxRemove : TargetedPolicyChoice<Population>
    {

        public override PolicyName Name { get => PolicyName.TaxesRemove; }
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Add or remove 1 tax token from the market area of the gameboard. If adding a tax token, immediately subtract upt to 5 wealth from any population markers. Place 5 wealth in the treasury.";

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                        PolicyChoiceRequirement.AtLeast2PC
                    |   PolicyChoiceRequirement.Governing
                    |   PolicyChoiceRequirement.AtLeast1ValidTarget
                };
                return requirementsEnums;
            }
        }       

        protected override PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology)
        {
            var qualifications = PolicyChoiceRequirement.None;            
            qualifications |= this.HasSufficientPC(ideology, 2) ? PolicyChoiceRequirement.AtLeast2PC : PolicyChoiceRequirement.None;;            
            qualifications |= this.IsGoverningIdeology(ideology) ? PolicyChoiceRequirement.Governing : PolicyChoiceRequirement.None;
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
                        PolicyChoiceTargetRequirement.AtLeast1Wealth                    
                    |   PolicyChoiceTargetRequirement.NotArmy
                };
                return requirementsEnums;
            }
        }

        protected override PolicyChoiceTargetRequirement GetTargetQualifications(Ideology ideology, Population candidateTarget) 
        {
            var qualifications = PolicyChoiceTargetRequirement.None;
            qualifications |= candidateTarget.Wealth > 0 ? PolicyChoiceTargetRequirement.AtLeast1Wealth : 0;
            qualifications |= !candidateTarget.IsArmy ? PolicyChoiceTargetRequirement.NotArmy : 0;
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

