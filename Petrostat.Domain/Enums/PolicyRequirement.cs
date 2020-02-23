using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Enums
{
    internal static class EnumHelper 
    {
        internal const long LongOne = 1;
    }

    [Flags]
    public enum PolicyRequirement : Int64
    {
        None = 0
            , AlignedArmy = EnumHelper.LongOne //Coup, Repression, ResistCoup, ResistRepression, ResistGenocide
            , Governing = EnumHelper.LongOne << 1
            , AtLeast1PC = EnumHelper.LongOne << 2 //Poor Propaganda
            , AtLeast2PC = EnumHelper.LongOne << 3 //Working-class propaganda 
            , AtLeast3PC = EnumHelper.LongOne << 4 //Middle-class Propaganda
            , AtLeast4PC = EnumHelper.LongOne << 5 //Wealthy Propaganda
            , AtLeast3WealthPlusTreasury = EnumHelper.LongOne << 6 //Army
            , AtLeast3PartyAlignedProtesters = EnumHelper.LongOne << 7 //Coup
            , AtLeast1NonProtestingPopulation = EnumHelper.LongOne << 8 //Protest
            , AtLeast1Treasury = EnumHelper.LongOne << 9 //Social Spending
            , AtLeast3Treasury = EnumHelper.LongOne << 10 //Imperialism
            , NotClientState = EnumHelper.LongOne << 11 //Imperialism
            , AtLeast1ProtestingPopulation = EnumHelper.LongOne << 12 //Repression
            , AtLeast1PopulationWithoutReligiousLaw = EnumHelper.LongOne << 13 //Religious Law
            , AtLeast1NonAlignedPoorPopulation = EnumHelper.LongOne << 14 //Propogand Poor
            , AtLeast1NonAlignedWorkingClassPopulation = EnumHelper.LongOne << 15
            , AtLeast1NonAlignedMiddleClassPopulation = EnumHelper.LongOne << 16
            , AtLeast1NonAlignedWealthyPopulation = EnumHelper.LongOne << 17
            , AtLeast1AlignedNonArmyCube = EnumHelper.LongOne << 18
            , AtLeast3AlignedProperty = EnumHelper.LongOne << 19
            , NotGoverning = EnumHelper.LongOne << 20
            , BeInParty = EnumHelper.LongOne << 21
            , BeInNonGoverningParty = EnumHelper.LongOne << 22
            , AtLeast1AlignedProtester = EnumHelper.LongOne << 23
            , AtLeast1NonAlignedPopulation = EnumHelper.LongOne << 24
            , SocialistActive = EnumHelper.LongOne << 25
            , LiberalActive = EnumHelper.LongOne << 26
            , MinoritySectarianActive = EnumHelper.LongOne << 27
            , MajoritySectarianActive = EnumHelper.LongOne << 28
            , AuthoritarianActive = EnumHelper.LongOne << 29
            , NationalistActive = EnumHelper.LongOne << 30
            , FundamentalistActive = EnumHelper.LongOne << 31
            , AtLeastIndependent = EnumHelper.LongOne << 32
            , BePartyLeader = EnumHelper.LongOne << 33
            , BeNonLeadingPartyMember = EnumHelper.LongOne << 34
            , PartyChallengesNotBlocked = EnumHelper.LongOne << 35
            , NotSuperPower = EnumHelper.LongOne << 36
            , TargetPopulationNotPropagandaBlocked = EnumHelper.LongOne << 37
            , TargetPopulationNotArmy = EnumHelper.LongOne << 38
            , AtLeast1AlignedNonProtestingNonArmyPopulation = EnumHelper.LongOne << 39
            , AtLeast1PopulationUnderReligiousLaw = EnumHelper.LongOne << 40
            , TargetPopulationUnderReligiousLaw = EnumHelper.LongOne << 41
            , TargetPopulationNotUnderReligiousLaw = EnumHelper.LongOne << 42
            , TargetPopulationsProtesting = EnumHelper.LongOne << 43
            , TargetPopulationNotProtesting = EnumHelper.LongOne << 44
            , NewTaxBurdenOnTargetPopulationsLessThanProperty = EnumHelper.LongOne << 45
            , TaxTargetsNotArmy = EnumHelper.LongOne << 46
            , AtLeast3AlignedWealth = EnumHelper.LongOne << 47
            , AtLeast1Globalization = EnumHelper.LongOne << 48
    }
}
