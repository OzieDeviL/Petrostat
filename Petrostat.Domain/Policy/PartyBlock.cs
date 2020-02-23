using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static Petrostat.Domain.PolicyQualificationHelpers;

namespace Petrostat.Domain.Ideologies
{
    internal class PartyBlock : PolicyChoice
    {
        public override PolicyName Name { get => PolicyName.PartyBlock; }
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Blocks other players from taking leadership of your party this round";

        protected override List<PolicyRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyRequirement>
                {
                        PolicyRequirement.AtLeast2PC
                    |   PolicyRequirement.BePartyLeader
                };
                return requirementsEnums;
            }
        }
        
        protected override PolicyRequirement DetermineCurrentQualifications(Ideology ideology, Population targetPopulation = null)
        {
            var qualifications = PolicyRequirement.None;
            
            qualifications |= ideology.PoliticalCapital >= 2 ? PolicyRequirement.AtLeast2PC : PolicyRequirement.None;
            qualifications |= (ideology.CurrentParty != null && ideology.CurrentParty.Leader == ideology) ? PolicyRequirement.BePartyLeader : PolicyRequirement.None;           
            
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
