using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Enums
{
    [Flags]
    public enum GameplayFSM
    {
        None = 0
            , Waiting = 1 //Coup, Repression, ResistCoup, ResistRepression, ResistGenocide
            , WaitingForSocialist = 1 << 1
            , WaitingForLiberal = 1 << 2 //Poor Propaganda
            , WaitingForMinoritySectarian = 1 << 3 //Working-class propaganda 
            , WaitingForMajoritySectarian = 1 << 4 //Middle-class Propaganda
            , WaitingForNationalist = 1 << 5 //Wealthy Propaganda
            , WaitingForFundamentalist = 1 << 6 //Army
            , OnePolicyCommited = 1 << 7 //Coup
            , TwoPoliciesCommited = 1 << 8 //Protest
            , ThreePoliciesCommited = 1 << 9 //Social Spending
            , ChoosingPolicies = 1 << 10 //Imperialism
            , WaitingForAuthoritarian = 1 << 11
            , AutomaticEventsOccuring = 1 << 12
            //, AtLeast1ProtestingPopulation = 1 << 12 //Repression
            //, AtLeast1PopulationWithoutReligiousLaw = 1 << 13 //Religious Law
            //, AtLeast1NonAlignedPoorPopulation = 1 << 14 //Propogand Poor
            //, AtLeast1NonAlignedWorkingClassPopulation = 1 << 15
            //, AtLeast1NonAlignedMiddleClassPopulation = 1 << 16
            //, AtLeast1NonAlignedWealthyPopulation = 1 << 17
            //, AtLeast1AlignedNonArmyCube = 1 << 18
            //, AtLeast3AlignedProperty = 1 << 19
            //, NotGoverning = 1 << 20
            //, BeInParty = 1 << 21
            //, BeInNonGoverningParty = 1 << 22
            //, AtLeast1AlignedProtester = 1 << 23
            //, AtLeast1NonAlignedPopulation = 1 << 24
            //, SocialistActive = 1 << 25
            //, LiberalActive = 1 << 26
            //, MinoritySectarianActive = 1 << 27
            //, MajoritySectarianActive = 1 << 28
            //, AuthoritarianActive = 1 << 29
            //, NationalistActive = 1 << 30
            //, FundamentalistActive = 1 << 31
            //, AtLeastIndependent = 1 << 32
            //, BePartyLeader = 1 << 33
            //, BeNonLeadingPartyMember = 1 << 34
            //, PartyChallengesNotBlocked = 1 << 35
            //, LessThanSuperPower = 1 << 36
            //, TargetPopulationNotPropagandaBlocked = 1 << 37
            //, TargetPopulationNotArmy = 1 << 38
            //, AtLeast1AlignedNonProtestingNonArmyPopulation = 1 << 39
            //, AtLeast1PopulationUnderReligiousLaw = 1 << 40
            //, TargetPopulationUnderReligiousLaw = 1 << 41
            //, TargetPopulationNotUnderReligiousLaw = 1 << 42
            //, TargetPopulationsProtesting = 1 << 43
            //, TargetPopulationNotProtesting = 1 << 44
            //, NewTaxBurdenOnTargetPopulationsLessThanProperty = 1 << 45
            //, TaxTargetsNotArmy = 1 << 46

    }
}
