using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain
{
    public abstract class Policy
    {
        private readonly Game _game;

        public Policy(Game game)
        {
            _game = game;
        }

        public abstract PolicyName Name { get; }
        public abstract string Description { get; }
        //TODO public abstract string FlavorText { get; }
        public HashSet<PolicyRequirement> Requirements { get; protected set; }
        public PolicyRequirement MinimumRequirement
        {
            get
            {
                var minimumRequiredState = PolicyRequirement.None;
                foreach (var requirement in Requirements)
                {
                    minimumRequiredState = minimumRequiredState | requirement;
                }
                return minimumRequiredState;
            }
        }

        public virtual bool Validate(Ideology ideology, Population targetPopulation)
        {
            var qualifications = DetermineQualifications(ideology, targetPopulation);
            return (qualifications & MinimumRequirement) == MinimumRequirement;
        }

        protected abstract PolicyRequirement DetermineQualifications(Ideology ideology, Population targetPopulation);
    }
}
