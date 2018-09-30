using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class LiberalVictory : Victory
    {
        public LiberalVictory(Game game) : base(game) { }

        public override int CurrentPoints
        {
            get
            {
                var points = StartingPoints
                    + ImperialismPoints
                    + TaxBurdenPoints
                    + GenocidePoints
                    + RepressionPoints
                    + CoupPoints
                    + ElectionPoints;
                if (Nation.Game.IncludeNationalist)
                {
                    points += GlobalizationPoints;
                }
                if (Nation.Game.IncludeFundamentalist)
                {
                    points += UnwantedFundamentalismPoints;
                }
                return points;
            }
        }
        public override string Instructions => throw new NotImplementedException();

        public override int StartingPoints => 20;
        public int TaxBurdenPoints => -5 * Nation.TaxBurden;
        public int GenocidePoints => -15 * VictoryEvents.GenocideCount;
        public int RepressionPoints => VictoryEvents.RepressionFailureCount * 2 - VictoryEvents.RepressionSuccessCount;
        public int CoupPoints => VictoryEvents.CoupCount * -5;
        public int ElectionPoints => (VictoryEvents.ElectionCount * 5) - (2 * VictoryEvents.TurnEndingWithoutElectionCount);
        public int GlobalizationPoints => (2 * VictoryEvents.GlobalizationsAddedCount) - (5 * VictoryEvents.GlobalizationsRemovedCount);
        public int UnwantedFundamentalismPoints => VictoryEvents.UnwantedFundamentalistCount;
    }
}
