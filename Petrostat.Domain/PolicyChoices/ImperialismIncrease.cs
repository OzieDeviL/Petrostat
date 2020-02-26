using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    internal class ImperialismIncrease : PolicyChoice
    {
        private readonly ImperialPower _imperialPower;
        private readonly int _treasury;

        public ImperialismIncrease(ImperialPower imperialPower, int treasury) {
            _imperialPower = imperialPower;
            _treasury = treasury;
        }

        public override PolicyName Name { get => PolicyName.ImperialismIncrease; }
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Spend 3 from the the treasury to move to the next highest position on the imperialism track. Move the imperialism marker to the corresponding position.";

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                        PolicyChoiceRequirement.AtLeast2PC
                    |   PolicyChoiceRequirement.AtLeast3Treasury
                    |   PolicyChoiceRequirement.Governing
                    |   PolicyChoiceRequirement.NotSuperPower
                };
                return requirementsEnums;
            }
        }
        
        protected override PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology)
        {
            var qualifications = PolicyChoiceRequirement.None;
            
            qualifications |= ideology.PoliticalCapital >= 2 ? PolicyChoiceRequirement.AtLeast2PC : PolicyChoiceRequirement.None;
            qualifications |= _treasury >= 3 ? PolicyChoiceRequirement.AtLeast3Treasury : PolicyChoiceRequirement.None;
            qualifications |= this.IsGoverningIdeology(ideology) ? PolicyChoiceRequirement.Governing : PolicyChoiceRequirement.None;
            qualifications |= _imperialPower != ImperialPower.SuperPower ? PolicyChoiceRequirement.NotSuperPower : PolicyChoiceRequirement.None;
            
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
