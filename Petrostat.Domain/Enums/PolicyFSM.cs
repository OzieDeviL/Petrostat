﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Enums
{
    [Flags]
    public enum PolicyFSM
    {
        None = 0
            , HaveArmy = 1 //Coup, Repression, ResistCoup, ResistRepression, ResistGenocide
            , Governing = 1 << 1
            , AtLeast1PC = 1 << 2 //Poor Propaganda
            , AtLeast2PC = 1 << 3 //Working-class propaganda 
            , AtLeast3PC = 1 << 4 //Middle-class Propaganda
            , AtLeast4PC = 1 << 5 //Wealthy Propaganda
            , AtLeastWealthPlusTreasury = 1 << 6 //Army
            , AtLeast3PartyAlignedProtesters = 1 << 7 //Coup
            , AtLeast1NonProtestingPopulation = 1 << 8 //Protest
            , AtLeast1Treasury = 1 << 9 //Social Spending
            , AtLeast3Treasury = 1 << 10 //Imperialism
            , LessThan15ImperialismSpending = 1 << 11 //Imperialism
            , AtLeast1ProtestingPopulation = 1 << 12 //Repression
            , AtLeast1PopulationWithoutReligiousLaw = 1 << 13 //Religious Law
            , AtLeast1NonAlignedPoorPopulation = 1 << 14 //Propogand Poor
            , AtLeast1NonAlignedWorkingClassPopulation = 1 << 15
            , AtLeast1NonAlignedMiddleClassPopulation = 1 << 16
            , AtLeast1NonAlignedWealthyPopulation = 1 << 17
            , AtLeast1AlignedNonArmyCube = 1 << 18
            , AtLeast3AlignedProperty = 1 << 19
            , NotGoverning = 1 << 20
            , BeInParty = 1 << 21
            , BeInNonGoverningParty = 1 << 22
            , AtLeast1AlignedProtester = 1 << 23
            , AtLeast1NonAlignedPopulation = 1 << 24
            , SocialistActive = 1 << 25
            , LiberalActive = 1 << 26
            , MinoritySectarianActive = 1 << 27
            , MajoritySectarianActive = 1 << 28
            , AuthoritarianActive = 1 << 29
            , NationalistActive = 1 << 30
            , FundamentalistActive = 1 << 31
            , AtLeastIndependent = 1 << 32
            , BePartyLeader = 1 << 33
            , BeNonLeadingPartyMember = 1 << 34
            , PartyChallengesNotBlocked = 1 << 35
            , LessThanSuperPower = 1 << 36
            , TargetPopulationNotPropagandaBlocked = 1 << 37
            , TargetPopulationNotArmy = 1 << 38
            , AtLeast1AlignedNonProtestingNonArmyPopulation = 1 << 39
            , AtLeast1PopulationUnderReligiousLaw = 1 << 40
            , TargetPopulationUnderReligiousLaw = 1 << 41
            , TargetPopulationNotUnderReligiousLaw = 1 << 42
            , TargetPopulationsProtesting = 1 << 43
            , TargetPopulationNotProtesting = 1 << 44
            , NewTaxBurdenOnTargetPopulationsLessThanProperty = 1 << 45
            , TaxTargetsNotArmy = 1 << 46

    }
}
