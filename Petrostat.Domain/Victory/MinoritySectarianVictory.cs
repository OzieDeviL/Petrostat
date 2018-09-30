using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class MinoritySectarianVictory : Victory
    {
        public MinoritySectarianVictory(Game game) : base(game) { }

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
        public int Enrichment     =>    (+3 * VictoryEvents.MinorityEnrichedToWealthyCount)            
                                    +   (+2 * VictoryEvents.MinorityEnrichedToMiddleClassCount)       
                                    +   (+1 * VictoryEvents.MinorityEnrichedToWorkingClassCount);
        public int Impoverishment =>    (-5 * VictoryEvents.MinorityImpoverishedToMiddleClassCount)    
                                    +   (-3 * VictoryEvents.MinorityImpoverishedToWorkingClassCount)  
                                    +   (-1 * VictoryEvents.MinorityImpoverishedToPoorCount);
        public int GenocidePoints =>    (-11 *VictoryEvents.MinorityGenocidesCount);
    }
}
