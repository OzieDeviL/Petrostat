using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Enums
{
    [Flags]
    public enum ConflictFSM
    {
        None = 0
            , Coup = 1
            , Repression = 1 << 1
            , Genocide = 1 << 2 
            , SupportAction = 1 << 3
            , OpposeAction = 1 << 4
            , TargetIdeology = 1 << 5 
            , InstigatingIdeology = 1 << 6 
            , AtLeast1SupportingArmy = 1 << 7
            , AtLeast1OpposingArmy = 1 << 8
            , SocialistHasArmy = 1 << 9
            , LiberalHasArmy = 1 << 10
            , MinoritySectarianHasArmy = 1 << 11
            , MajoritySectarianHasArmy = 1 << 12
            , AuthoritarianHasArmy = 1 << 13
            , NationalistHasArmy = 1 << 14
            , FundamentalistHasArmy = 1 << 15
            , SupportingArmyWinsDieRoll = 1 << 16
            , TiedDieRoll = 1 << 17
            , OpposingArmyWinsDieRoll = 1 << 18
            , OpposesSocialist = 1 << 19
            , OpposesLiberal = 1 << 20
            , OpposesMinoritySectarian = 1 << 21
            , OpposesMajoritySectarianon = 1 << 22
            , OpposesAuthoritarian = 1 << 23
            , OpposesNationalist = 1 << 24
            , OpposesFundamentalist = 1 << 25
            , SupportsSocialist = 1 << 26
            , SupportsLiberal = 1 << 27
            , SupportsMinoritySectarian = 1 << 28
            , SupportsMajoritySectarianon = 1 << 29
            , SupportsAuthoritarian = 1 << 30
            , SupportsNationalist = 1 << 31
            , SupportsFundamentalist = 1 << 32
            , NeutralToSocialist = 1 << 19
            , NeutralToLiberal = 1 << 20
            , NeutralToMinoritySectarian = 1 << 21
            , NeutralToMajoritySectarianon = 1 << 22
            , NeutralToAuthoritarian = 1 << 23
            , NeutralToNationalist = 1 << 24
            , NeutralToFundamentalist = 1 << 25

    }
}
