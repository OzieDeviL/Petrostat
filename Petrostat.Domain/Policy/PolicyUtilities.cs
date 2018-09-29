using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petrostat.Domain
{
    public static class PolicyUtilities
    {
        public static int PolicyEligibilities(Nation nation, Ideology ideology)
        {
            int eligiblePolicies = 0;
            //evaluate the eligibility state of the nation/ideology
            int state = State(nation, ideology);
            //these policies are availableforFree
            eligiblePolicies += (int)Policies.Rally
                             + (int)Policies.PropagandaBlocking;
            //to determine if a player can do a policy,
            //do a bitwise comparison of the state of the ideology/nation against the requirements for that policy
            //in this case, Propaganda targeting a Poor population
            if ( (state & (int)PolicyFSM.AtLeast1PC) == (int)PolicyFSM.AtLeast1PC
                //&& there is at least one unaligned poor cube
                )
            {
                //add the eligible policy
                eligiblePolicies += (int)Policies.PropagandaPoor;
            }

            return eligiblePolicies;
        }

        private static int State (Nation nation, Ideology ideology)
        {
            int state = (int)Policies.None;
            if (ideology.Armies > 0) { state += (int)PolicyFSM.HaveArmy; }
            if (ideology.IsGoverning) { state += (int)PolicyFSM.Governing; }
            if (ideology.PoliticalCapital >= 1) { state += (int)PolicyFSM.AtLeast1PC; }
            if (ideology.PoliticalCapital >= 2) { state += (int)PolicyFSM.AtLeast2PC; }
            if (ideology.PoliticalCapital >= 3) { state += (int)PolicyFSM.AtLeast3PC; }
            if (ideology.PoliticalCapital >= 4) { state += (int)PolicyFSM.AtLeast4PC; }
            if ((ideology.IsGoverning && (ideology.AlignedProperty + nation.Treasury >= 3))
                || ideology.AlignedProperty >= 3)
            {
                state += (int)PolicyFSM.AtLeastWealthPlusTreasury;
            }
            if (ideology.ProtestingPopulaiton >= 3) { state += (int)PolicyFSM.AtLeast3PartyAlignedProtesters; }
            if (nation.NationalPopulation.Count != nation.ProtestCount) { state += (int)PolicyFSM.AtLeast1NonProtestingPopulation; }
            if (nation.Treasury > 0) { state += (int)PolicyFSM.AtLeast1TreasuryProperty; }
            if (nation.Treasury >= 3) { state += (int)PolicyFSM.AtLeast3Treasury; }
            if (nation.Power < (int)ImperialismEnums.SuperPower) { state += (int)PolicyFSM.LessThan15ImperialismSpending; }
            if (nation.ProtestCount > 0) { state += (int)PolicyFSM.AtLeast1ProtestingPopulation; }
            IEnumerable<Population> religiousPopulation = from population in nation.NationalPopulation
                                                          where population.UnderReligiousLaw == true
                                                          select population;
            if (nation.NationalPopulation.Count != religiousPopulation.Count())
            {
                state += (int)PolicyFSM.AtLeast1PopulationWithoutReligiousLaw;
            }
            //need to add states for at least 1 unaligned population of each economic class, need to learn LINQ to do that because I need where statements
            IEnumerable<Population> poorPopulation = from population in nation.NationalPopulation
                                                     where population.IsPoor == true
                                                     select population;
            IEnumerable<Population> alignedPoorPopulation = from population in nation.NationalPopulation
                                                     where population.IsPoor == true
                                                     select population;

            IEnumerable<Population> workingClassPopulation = from population in nation.NationalPopulation
                                                     where population.IsPoor == true
                                                     select population;
            IEnumerable<Population> middleClassPopulation = from population in nation.NationalPopulation
                                                     where population.IsPoor == true
                                                     select population;
            IEnumerable<Population> wealthyPopulation = from population in nation.NationalPopulation
                                                     where population.IsPoor == true
                                                     select population;

            return state;
        }


    }
}
