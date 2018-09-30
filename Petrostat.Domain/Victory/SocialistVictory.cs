using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class SocialistVictory : Victory
    {
        public SocialistVictory(Game game) : base(game) { }

        public override int CurrentPoints
        {
            get
            {
                var points = StartingPoints
                    + ImperialismPoints
                    + Enrichment
                    + Impoverishment
                    + Inequality;
                return points;
            }
        }
        public override string Instructions => throw new NotImplementedException();
        public override int StartingPoints => 0;
        public int Enrichment => (2 * VictoryEvents.AnyEnrichedToMiddleClassCount) + VictoryEvents.AnyEnrichedToWorkingClassCount;
        public int Impoverishment => (-2 * VictoryEvents.AnyImpoverishedToWorkingClassCount) + (-3 * VictoryEvents.AnyImpoverishedToPoorCount);
        public int Inequality => VictoryEvents.TurnEndingWithGoodMiddleToWorkingRatioCount - VictoryEvents.TurnEndingWithBadMiddleWorkingRatioCount - VictoryEvents.TurnEndingWithRichAndPoorCount;
    }
}
