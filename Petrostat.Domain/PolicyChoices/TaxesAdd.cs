using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    internal class TaxesDecrease : PolicyChoice
    {
        private readonly int _taxLevel;

        public TaxesDecrease(int taxLevel) {
            _taxLevel = taxLevel;
        }

        public override PolicyName Name { get => PolicyName.TaxesRemove; }
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Remove 1 tax token from the market area of the gameboard.";

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                        PolicyChoiceRequirement.AtLeast1PC
                    |   PolicyChoiceRequirement.Governing
                    |   PolicyChoiceRequirement.AtLeast1Tax
                };
                return requirementsEnums;
            }
        }
        
        protected override PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology)
        {
            var qualifications = PolicyChoiceRequirement.None;
            qualifications |= this.HasSufficientPC(ideology, 1) ? PolicyChoiceRequirement.AtLeast1PC : PolicyChoiceRequirement.None;
            qualifications |= this.IsGoverningIdeology(ideology) ? PolicyChoiceRequirement.Governing : PolicyChoiceRequirement.None;
            qualifications |= _taxLevel < 0 ? PolicyChoiceRequirement.AtLeast1Tax : PolicyChoiceRequirement.None;
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
