using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Petrostat.Domain
{
    internal abstract class PolicyChoice
    {
        protected readonly Nation _nation;

        public PolicyChoice(Nation nation) {
            _nation = nation;
        }
        public PolicyChoice() {}

        public abstract PolicyName Name { get; }
        public abstract string Description { get; }
        public bool CanBePlayed(Ideology ideology, Population targetPopulation = null)
        {   
            var currentQualifications = DetermineCurrentQualifications(ideology, targetPopulation);
            var canBePlayed = MinimumRequirementCombinations.Any(minimumRequirementCombination => 
                minimumRequirementCombination == (minimumRequirementCombination & currentQualifications));
            return canBePlayed;
        }
        public abstract void Play();        
        protected abstract List<PolicyRequirement> MinimumRequirementCombinations { get; }
        protected abstract PolicyRequirement DetermineCurrentQualifications(Ideology ideology, Population targetPopulation = null);
        protected abstract bool IsSuccess();
        protected abstract void OnSuccess();
        protected abstract void OnFailure();
    }
}
