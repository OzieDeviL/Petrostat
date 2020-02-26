using System;
using System.Collections.Generic;
using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System.Linq;
using Petrostat.Domain.Interfaces;

namespace Petrostat.Domain
{
    internal abstract class TargetedPolicyChoice<T> : PolicyChoice where T : IId
    {

        internal T ChosenTarget
        { get { return ChosenTarget; }
            set 
            {
                if (ChosenTarget == null) {
                    ChosenTarget = value;
                } else if (TargetLocked) {
                    throw new ArgumentException("Chosen target cannot be changed after it is locked");
                } else {
                    ChosenTarget = value;
                }
            } 
        }
        internal bool TargetLocked {get; set;}
        internal abstract Dictionary<int, T> GetPossibleTargets(Ideology ideology);
        protected bool ValidateTarget(Ideology ideology, T candidateTarget) 
        {
            var qualifications = GetTargetQualifications(ideology, candidateTarget);
            var qualificationsMeetRequirements = MinimumTargetRequirementCombinations.Any(r => 
                (r & qualifications) == r);
            return qualificationsMeetRequirements;
        }
        protected abstract PolicyChoiceTargetRequirement GetTargetQualifications(Ideology ideology, T candidateTarget);
        protected abstract List<PolicyChoiceTargetRequirement> MinimumTargetRequirementCombinations { get; }
    }
}