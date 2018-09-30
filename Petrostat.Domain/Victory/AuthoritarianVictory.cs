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
                var points = StartingPoints
                    + ImperialismPoints
                    + WarPoints
                    + NonGoverningGenocidePoints
                    + RepressionPoints
                    + ProtestPoints;
                return points;
            }
        }
        public override string Instructions => throw new NotImplementedException();
        public override int StartingPoints => 25;
        public int WarPoints => VictoryEvents.WarCount * 2 + VictoryEvents.TurnEndingsWithoutWarCount * 5;
        public int NonGoverningGenocidePoints => -15 * VictoryEvents.NonGoverningGenocideCount;
        public int RepressionPoints => (VictoryEvents.RepressionSuccessCount) - (3 * VictoryEvents.RepressionFailureCount);
        public int ProtestPoints => -VictoryEvents.TurnEndingsProtestCount;
    }
}
