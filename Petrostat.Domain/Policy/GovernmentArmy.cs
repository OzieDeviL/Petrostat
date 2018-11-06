using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class GovernmentArmy : Policy
    {
        public GovernmentArmy(Game game) : base(game)
        {
            Requirements = new HashSet<PolicyRequirement>
            {
                PolicyRequirement.Governing,
                PolicyRequirement.AtLeast3WealthPlusTreasury,
                PolicyRequirement.TargetPopulationNotArmy,
                PolicyRequirement.TargetPopulationNotProtesting
            };
        }
        public override PolicyName Name => PolicyName.Rally;
        public override string Description => "Increase your political capital by 2";

        protected override PolicyRequirement DetermineQualifications(Ideology ideology)
        {
            throw new NotImplementedException();
        }

    }
}