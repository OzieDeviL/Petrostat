using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static Petrostat.Domain.PolicyQualificationHelpers;
using System.Linq;

namespace Petrostat.Domain.Ideologies
{
    internal class ArmyMobilize : PolicyChoice
    {

        public override PolicyName Name { get => PolicyName.ArmyMobilize; }

        public override void Play()
        {
            throw new NotImplementedException();
        }

        public override string Description => "Move one marker aligned with your ideology to or from the army box. If moving to the army box, subtract 3 wealth from your aligned cubes—the governing player may spend from the treasury—then stack three spending under the army along with a stack of wealth (red­side down coins) equal to the marker's position on the wealth track.";

        protected override List<PolicyRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyRequirement>
                {
                        PolicyRequirement.AtLeast2PC
                    |   PolicyRequirement.AtLeast1AlignedNonArmyCube
                    |   PolicyRequirement.AtLeast3AlignedWealth
                };
                return requirementsEnums;
            }
        }
        
        protected override PolicyRequirement DetermineCurrentQualifications(Ideology ideology, Population targetPopulation = null)
        {
            var qualifications = PolicyRequirement.None;
            qualifications |= ideology.PoliticalCapital >= 2 ? PolicyRequirement.AtLeast2PC : PolicyRequirement.None;
            qualifications |= ideology.AlignedPopulation.Any(kv => !kv.Value.IsArmy) ? PolicyRequirement.AtLeast1AlignedNonArmyCube : PolicyRequirement.None;
            qualifications |= IdeologyWealth(ideology) >= 3 ? PolicyRequirement.AtLeast3AlignedWealth : PolicyRequirement.None;
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
