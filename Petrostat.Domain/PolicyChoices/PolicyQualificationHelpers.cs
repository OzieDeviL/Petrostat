using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Petrostat.Domain.Interfaces;

namespace Petrostat.Domain.Ideologies
{
    internal static class PolicyQualificationExtensions
    {
        internal static bool HasSufficientPC(this PolicyChoice policyChoice, Ideology ideology, int PCRequired) => ideology.PoliticalCapital >= PCRequired;
        internal static bool IsGoverningIdeology(this PolicyChoice policyChoice, Ideology ideology) => ideology.CurrentParty.IsGoverning && ideology.CurrentParty.Leader == ideology;
        internal static bool HasAlignedArmy(this PolicyChoice policyChoice,Ideology ideology) => ideology.AlignedPopulation.Any(p => p.Value.IsArmy);
        internal static int IdeologyWealth(this PolicyChoice policyChoice,Ideology ideology) => ideology.AlignedPopulation.Sum(p => p.Value.Wealth);
        
        internal static Dictionary<int, Population> GetValidPopulationTargets(
            this TargetedPolicyChoice<Population> policyChoice, 
            Ideology ideology, 
            Nation nation,
            Func<Ideology, Population, bool> validateTarget
            ) 
        {
            return nation.Population
                .Select(kv => kv.Value)
                .SelectValidTargets(ideology, validateTarget);
        }

        internal static Dictionary<int, PoliticalParty> GetValidPartyTargets(
            this TargetedPolicyChoice<PoliticalParty> policyChoice, 
            Ideology ideology, 
            Nation nation,
            Func<Ideology, PoliticalParty, bool> validateTarget) 
        {
            return nation.Government.Parties
                .SelectValidTargets(ideology, validateTarget);
        }

        internal static Dictionary<int, PolicyChoice> GetValidPolicyChoiceTargets(
            this TargetedPolicyChoice<PolicyChoice> policyChoice, 
            Ideology ideology, 
            Round round,
            Func<Ideology, PolicyChoice, bool> validateTarget) 
        {
            return round.PolicyChoices
                .Select(kv => kv.Value)
                .SelectValidTargets(ideology, validateTarget);
        }

        private static Dictionary<int, TTargetable> SelectValidTargets<TTargetable>(
            this IEnumerable<TTargetable> candidateTargets,
            Ideology ideology, 
            Func<Ideology, TTargetable, bool> validateTarget) where TTargetable : IId
        {
            var validTargets = candidateTargets
                .ToDictionary(pc => pc.Id, pc => pc)
                    .Where(kv => validateTarget(ideology, kv.Value))
                    .ToDictionary(kv => kv.Key, kv => kv.Value);
            return validTargets;
        }
    }
}
