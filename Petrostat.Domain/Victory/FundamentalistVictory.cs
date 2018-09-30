using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class FundamentalistVictory : Victory
    {
        public FundamentalistVictory(Game game) : base(game) { }

        public override int CurrentPoints
        {
            get
            {
                var points = StartingPoints
                    + ImperialismPoints
                    + ReligiousLawPoints;
                return points;
            }
        }
        public override string Instructions => throw new NotImplementedException();
        public override int StartingPoints => 0;
        public int ReligiousLawPoints => 5 * VictoryEvents.ReligiousLawCount;
    }
}
