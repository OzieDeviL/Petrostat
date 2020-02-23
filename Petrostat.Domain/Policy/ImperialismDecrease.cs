using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static Petrostat.Domain.PolicyQualificationHelpers;

namespace Petrostat.Domain.Ideologies
{
    internal class ImperialismDecrease : PolicyChoice
    {
        private readonly ImperialPower _imperialPower;
        private readonly int _treasury;

        public ImperialismDecrease(ImperialPower imperialPower) {
            _imperialPower = imperialPower;
        }

        public override PolicyName Name { get => PolicyName.ImperialismDecrease; }
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Spend 3 from the the treasury to move to the next highest position on the imperialism track. Move the imperialism marker to the corresponding position.";

        protected override List<PolicyRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyRequirement>
                {
                        PolicyRequirement.AtLeast2PC
                    |   PolicyRequirement.AtLeast3Treasury
                    |   PolicyRequirement.Governing
                    |   PolicyRequirement.NotClientState
                };
                return requirementsEnums;
            }
        }
        
        protected override PolicyRequirement DetermineCurrentQualifications(Ideology ideology, Population targetPopulation = null)
        {
            var qualifications = PolicyRequirement.None;
            
            qualifications |= ideology.PoliticalCapital >= 2 ? PolicyRequirement.AtLeast2PC : PolicyRequirement.None;
            qualifications |= _treasury >= 3 ? PolicyRequirement.AtLeast3Treasury : PolicyRequirement.None;
            qualifications |= IsGoverningIdeology(ideology) ? PolicyRequirement.Governing : PolicyRequirement.None;
            qualifications |= _imperialPower != ImperialPower.ClientState ? PolicyRequirement.NotSuperPower : PolicyRequirement.None;
            
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
