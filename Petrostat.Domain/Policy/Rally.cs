using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain
{

    public class Rally : Policy
    {
        public Rally (Game game) : base (game)
        {
            //no requirements to add
        }
        public override PolicyName Name => PolicyName.Rally;
        public override string Description => "Increase your political capital by 2";

        protected override PolicyRequirement DetermineQualifications(Ideology ideology, Population targetPopulation)
        {
            return PolicyRequirement.None;
        }
    }
}
