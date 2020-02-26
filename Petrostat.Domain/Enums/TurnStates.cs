using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain
{
    [Flags]
    public enum TurnState
    {
        None = 0
        , PolicyPhase = 1
        , NationalEventsPhase = 1 << 1
        , PolicyRound1 = 1 << 2
        , PolicyRound2 = 1 << 3
        , PolicyRound3 = 1 << 4
        , SurplusDiscontent = 1 << 5
        , Elections = 1 << 6
        , MarketGrowth = 1 << 7
        , Oil = 1 << 8
        , CollectTaxes = 1 << 9
        , PublicSpending = 1 << 10
        , PoliticalCapital = 1 << 11
        , VictoryPoints = 1 << 12
    } 
}
