using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static Petrostat.Domain.PolicyQualificationHelpers;

namespace Petrostat.Domain.Ideologies
{
    internal class GlobalizationIncrease : PolicyChoice
    {
             public override PolicyName Name { get => PolicyName.GlobalizationIncrease; }
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Add or remove 1 globalization token to or from the Market area of the gameboard.";

        protected override List<PolicyRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyRequirement>
                {
                        PolicyRequirement.AtLeast2PC
                    |   PolicyRequirement.Governing
                };
                return requirementsEnums;
            }
        }
        
        protected override PolicyRequirement DetermineCurrentQualifications(Ideology ideology, Population targetPopulation = null)
        {
            var qualifications = PolicyRequirement.None;
            qualifications |= ideology.PoliticalCapital >= 2 ? PolicyRequirement.AtLeast2PC : PolicyRequirement.None;
            qualifications |= IsGoverningIdeology(ideology) ? PolicyRequirement.Governing : PolicyRequirement.None;
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
