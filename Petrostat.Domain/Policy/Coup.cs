using Petrostat.Domain.Enums;
using static Petrostat.Domain.PolicyQualificationHelpers;
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

        protected override List<PolicyRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyRequirement>
                {
                    //use army
                    PolicyRequirement.BeInNonGoverningParty
                  | PolicyRequirement.AlignedArmy
                  | PolicyRequirement.AtLeast2PC
                    //use protest
                  , PolicyRequirement.AtLeast2PC
                  | PolicyRequirement.BeInNonGoverningParty
                  | PolicyRequirement.AtLeast1AlignedProtester
                  | PolicyRequirement.AtLeast3PartyAlignedProtesters
                };
                return requirementsEnums;
            }
        }

        protected override PolicyRequirement DetermineCurrentQualifications(Ideology ideology, Population targetPopulation = null)
        {
            var qualifications = PolicyRequirement.None;
            
            qualifications |= !ideology.CurrentParty.IsGoverning ? PolicyRequirement.BeInNonGoverningParty : PolicyRequirement.None;
            qualifications |= ideology.PoliticalCapital >= 2 ? PolicyRequirement.AtLeast2PC : PolicyRequirement.None;
            
            if (targetPopulation.IsArmy) 
            {
                qualifications |= ideology.AlignedPopulation.Any(kv => kv.Value.IsArmy) ? PolicyRequirement.AlignedArmy : PolicyRequirement.None;
            } else {
                qualifications |= ideology.AlignedPopulation.Any(kv => kv.Value.IsProtesting) ? PolicyRequirement.AtLeast1AlignedProtester : PolicyRequirement.None;
                qualifications |= ideology.CurrentParty.Members
                    .SelectMany(i => i.AlignedPopulation
                    .Where(kv => kv.Value.IsProtesting))
                    .Count() >= 3 ? PolicyRequirement.AtLeast3PartyAlignedProtesters : PolicyRequirement.None; 
            }
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
