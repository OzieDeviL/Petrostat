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
                    + ColonizationPenaltyPoints;
                return points;
            }
        }
        public override string Instructions => throw new NotImplementedException();
        public override int StartingPoints => 0;
        public override int ImperialismPoints => (int)Game.Nation.Empire.Level;
        public int ColonizationPenaltyPoints  =>   (+5 * Game.VictoryEvents.TurnEndingBonusCount) 
                                                 + (-1 * Game.VictoryEvents.ForeignPCPenaltyCount);
    }
}
