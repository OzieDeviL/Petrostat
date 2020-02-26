using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petrostat.Domain
{
    internal class Coup : PolicyChoice
    {
        public override PolicyName Name { get => PolicyName.Coup; }
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Transfers the government marker to your party. The new governing player may immediately flip the government marker to allow or disallow elections. Players in a new governing party may remove their protest tokens immediately. Coup requires an army of your alignment or 3 protesting markers of your party. You must be in a non­governing party to play this action. Coup may be challenged by any army—see manual for conflict rules.";

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                    //use army
                    PolicyChoiceRequirement.BeInNonGoverningParty
                  | PolicyChoiceRequirement.AtLeast1AlignedArmy
                  | PolicyChoiceRequirement.AtLeast2PC
                    //use protest
                  , PolicyChoiceRequirement.AtLeast2PC
                  | PolicyChoiceRequirement.BeInNonGoverningParty
                  | PolicyChoiceRequirement.AtLeast1AlignedProtester
                  | PolicyChoiceRequirement.AtLeast3PartyAlignedProtesters
                };
                return requirementsEnums;
            }
        }

        protected override PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology)
        {
            var qualifications = PolicyChoiceRequirement.None;
            qualifications |= !ideology.CurrentParty.IsGoverning ? PolicyChoiceRequirement.BeInNonGoverningParty : PolicyChoiceRequirement.None;
            qualifications |= ideology.PoliticalCapital >= 2 ? PolicyChoiceRequirement.AtLeast2PC : PolicyChoiceRequirement.None;
            //using an army
            qualifications |= ideology.AlignedPopulation.Any(kv => kv.Value.IsArmy) ? PolicyChoiceRequirement.AtLeast1AlignedArmy : PolicyChoiceRequirement.None;
            //usingprotesters
            qualifications |= ideology.AlignedPopulation.Any(kv => kv.Value.IsProtesting) ? PolicyChoiceRequirement.AtLeast1AlignedProtester : PolicyChoiceRequirement.None;
            qualifications |= ideology.CurrentParty.Members
                .SelectMany(i => i.AlignedPopulation
                .Where(kv => kv.Value.IsProtesting))
                .Count() >= 3 ? PolicyChoiceRequirement.AtLeast3PartyAlignedProtesters : PolicyChoiceRequirement.None; 
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
