using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Enums
{
    [Flags]
    public enum PolicyChoiceTargetRequirement
    {
        None = 0
            , Aligned = 1
            , Army = 1 << 1
            , NotArmy = 1 << 2
            , PopulationUnderReligiousLaw = 1 << 3
            , NotUnderReligiousLaw = 1 << 4
            , PopulationsProtesting = 1 << 5
            , NotProtesting = 1 << 6
            , NotInTargetParty = 1 << 7
            , NotAligned = 1 << 8
            , Protesting = 1 << 9
            , UnderReligiousLaw = 1 << 10
            , NotIdeologyPolicyChoice = 1 << 11
            , AtLeast1Wealth = 1 << 12
    }
}
