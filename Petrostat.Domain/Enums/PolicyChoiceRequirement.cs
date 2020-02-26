using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Enums
{
    [Flags]
    public enum PolicyChoiceRequirement : Int64
    {
        None = 0
            , AtLeast1AlignedArmy = EnumHelper.LongOne //Coup, Repression, ResistCoup, ResistRepression, ResistGenocide
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
            , AtLeast1PropagandaTargetAvailable = EnumHelper.LongOne << 14 //Propogand Poor
            , NonArmyTargetPopulation = EnumHelper.LongOne << 15
            , AtLeast1NonAlignedPopulation = EnumHelper.LongOne << 16
            , NonProtestingTargetPopulation = EnumHelper.LongOne << 17
            , AtLeast1ValidTarget = EnumHelper.LongOne << 18
            , AtLeast3AlignedProperty = EnumHelper.LongOne << 19
            , NotGoverning = EnumHelper.LongOne << 20
            , BeInParty = EnumHelper.LongOne << 21
            , BeInNonGoverningParty = EnumHelper.LongOne << 22
            , AtLeast1AlignedProtester = EnumHelper.LongOne << 23
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
            , NewTaxBurdenOnTargetPopulationsLessThanProperty = EnumHelper.LongOne << 45
            , AtLeast3AlignedWealth = EnumHelper.LongOne << 47
            , AtLeast1Globalization = EnumHelper.LongOne << 48
            , NotInParty = EnumHelper.LongOne << 49
            , ElectionsNotRepressed = EnumHelper.LongOne << 50
            , AtLeast1Tax = EnumHelper.LongOne << 51
    }
}
