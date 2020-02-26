using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

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

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                        PolicyChoiceRequirement.AtLeast2PC
                    |   PolicyChoiceRequirement.BePartyLeader
                };
                return requirementsEnums;
            }
        }
        
        protected override PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology)
        {
            var qualifications = PolicyChoiceRequirement.None;
            
            qualifications |= ideology.PoliticalCapital >= 2 ? PolicyChoiceRequirement.AtLeast2PC : PolicyChoiceRequirement.None;
            qualifications |= (ideology.CurrentParty != null && ideology.CurrentParty.Leader == ideology) ? PolicyChoiceRequirement.BePartyLeader : PolicyChoiceRequirement.None;           
            
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
