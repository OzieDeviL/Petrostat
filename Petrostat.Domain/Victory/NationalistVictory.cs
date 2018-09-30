using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class NationalistVictory : Victory
    {
        public NationalistVictory(Game game) : base(game) { }

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
        public override int StartingPoints => 25;
        public int Enrichment => (VictoryEvents.EnrichedToMiddleClass * 2) + VictoryEvents.EnrichedToWorkingClass;
        public int Impoverishment => (-2 * VictoryEvents.ImpoverishedToWorkingClass) + (-3 * VictoryEvents.ImpoverishedToPoor);
        public int Inequality => VictoryEvents.TurnEndingWithGoodMiddleToWorkingRatioCount - VictoryEvents.TurnEndingWithBadMiddleWorkingRatioCount - VictoryEvents.TurnEndingWithRichAndPoorCount;

    }
}
