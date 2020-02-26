using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Petrostat.Domain.Ideologies
{
    internal class StateSecurityElection : PolicyChoice
    {
        public override PolicyName Name { get => PolicyName.StateSecurity; }

        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Either choose a player and remove their policy token from this round or flip the government marker disc to prevent/allow elections at the end of the turn.";

        protected override List<PolicyChoiceRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyChoiceRequirement>
                {
                        PolicyChoiceRequirement.AtLeast2PC
                    |   PolicyChoiceRequirement.ElectionsNotRepressed
                };
                return requirementsEnums;
            }
        }

        protected override PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology)
        {
            var qualifications = PolicyChoiceRequirement.None;
            qualifications |= this.HasSufficientPC(ideology, 2) ? PolicyChoiceRequirement.AtLeast2PC : PolicyChoiceRequirement.None;
            qualifications |= !_nation.Government.ElectionsRepressed ? PolicyChoiceRequirement.ElectionsNotRepressed : PolicyChoiceRequirement.None;
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
