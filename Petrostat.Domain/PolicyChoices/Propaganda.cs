using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Petrostat.Domain.Ideologies
{
    internal class Propaganda : TargetedPolicyChoice<Population>
    {

        public override PolicyName Name { get => PolicyName.Propaganda; }
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Roll 1d4 for a chance to realign one non­protesting population marker to your ideology. Announce the marker you want before you roll. If the marker you choose is is aligned with a player who also chose propaganda this round, then your roll recieves a ­1 modifier. A modified roll of 1, 2, 3, or 4 successfully realigns a poor, working class, middle class, or rich marker, respectively.";

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                        PolicyChoiceRequirement.AtLeast1PC
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
                    |   PolicyChoiceTargetRequirement.NotArmy
                    |   PolicyChoiceTargetRequirement.NotProtesting
                };
                return requirementsEnums;
            }
        }

        protected override PolicyChoiceTargetRequirement GetTargetQualifications(Ideology ideology, Population candidateTarget) 
        {
            var qualifications = PolicyChoiceTargetRequirement.None;
            qualifications |= candidateTarget.Alignment != ideology ? PolicyChoiceTargetRequirement.NotAligned : 0;
            qualifications |= candidateTarget.IsArmy ? PolicyChoiceTargetRequirement.NotArmy : 0;
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

