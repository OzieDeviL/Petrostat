using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class AuthoritarianVictory : Victory
    {
        public AuthoritarianVictory(Game game) : base(game) { }

        public override int CurrentPoints
        {
            get
            {
                var score = StartingPoints
                    + WarPoints
                    + NonGoverningGenocidePoints
                    + RepressionPoints
                    + ProtestPoints;
                return score;
            }
        }
        public override int StartingPoints => 25;
        public int WarPoints => VictoryEvents.WarCount * 2 + VictoryEvents.TurnEndingsWithoutWarCount * 5;
        public int NonGoverningGenocidePoints => -15 * VictoryEvents.NonGoverningGenocideCount;
        public int RepressionPoints => (VictoryEvents.RepressionSuccessCount) - (3 * VictoryEvents.RepressionFailureCount);
        public int ProtestPoints => -VictoryEvents.TurnEndingsProtestCount;
    }
}
