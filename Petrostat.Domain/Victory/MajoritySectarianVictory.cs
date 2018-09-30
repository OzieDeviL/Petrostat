using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class MajoritySectarianVictory : Victory
    {
        public MajoritySectarianVictory(Game game) : base(game) { }

        public override int CurrentPoints
        {
            get
            {
                var points = StartingPoints
                    + ImperialismPoints
                    + Enrichment
                    + Impoverishment
                    + GenocidePoints;
                return points;
            }
        }
        public override string Instructions => throw new NotImplementedException();
        public override int StartingPoints => 0;
        public int Enrichment =>        (+3 * VictoryEvents.MajorityEnrichedToWealthyCount) 
                                    +   (+2 * VictoryEvents.MajorityEnrichedToMiddleClassCount) 
                                    +   (+1 * VictoryEvents.MajorityEnrichedToWorkingClassCount);
        public int Impoverishment =>    (-1 * VictoryEvents.MajorityImpoverishedToMiddleClassCount) 
                                    +   (-2 * VictoryEvents.MajorityImpoverishedToWorkingClassCount) 
                                    +   (-3 * VictoryEvents.MajorityImpoverishedToPoorCount);
        public int GenocidePoints =>    (-5 * VictoryEvents.MajorityGenocidesCount);

    }
}
