using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    internal class Genocide : PolicyChoice
    {
        public override PolicyName Name { get => PolicyName.Genocide; }

        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override string Description => "Target a population or army marker. Remove the targeted marker from the from the population and distribute half its wealth and spending among markers of your choice. Genocide may be challenged by any army after the target marker is announced—see manual for conflict rules.";

        protected override List<PolicyRequirement> MinimumRequirementCombinations
        {
            get
            {
                var requirementsEnums = new List<PolicyRequirement>
                {
                    PolicyRequirement.AtLeast3PC
                };
                return requirementsEnums;
            }
        }
        
        protected override PolicyRequirement DetermineCurrentQualifications(Ideology ideology, Population targetPopulation = null)
        {
            return ideology.PoliticalCapital >= 3 ? PolicyRequirement.AtLeast3PC : PolicyRequirement.None;
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
