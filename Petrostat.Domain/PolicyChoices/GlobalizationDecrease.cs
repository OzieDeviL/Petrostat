using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    internal class GlobalizationDecrease : PolicyChoice
    {
        private readonly int _globalizationLevel;

        public GlobalizationDecrease(int globalizationLevel) {
            _globalizationLevel = globalizationLevel;
        }

        public override PolicyName Name { get => PolicyName.GlobalizationDecrease; }
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Remove 1 globalization token to or from the Market area of the gameboard.";

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                        PolicyChoiceRequirement.AtLeast2PC
                    |   PolicyChoiceRequirement.Governing
                    |   PolicyChoiceRequirement.AtLeast1Globalization
                };
                return requirementsEnums;
            }
        }
        
        protected override PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology)
        {
            var qualifications = PolicyChoiceRequirement.None;
            qualifications |= ideology.PoliticalCapital >= 2 ? PolicyChoiceRequirement.AtLeast2PC : PolicyChoiceRequirement.None;
            qualifications |= this.IsGoverningIdeology(ideology) ? PolicyChoiceRequirement.Governing : PolicyChoiceRequirement.None;
            qualifications |= _globalizationLevel > 0 ? PolicyChoiceRequirement.AtLeast1Globalization : PolicyChoiceRequirement.None;
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
