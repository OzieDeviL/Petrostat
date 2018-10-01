using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petrostat.Domain.GameplaySequences
{
    public class Turn
    {
        Game game;

        public Turn(Game game)
        {
            this.game = game;
        }

        //public Guid Id { get; set; }
        //public Guid GameId { get; set; }

        //public int Number { get; set; }
        //public int DisplayNumber { get => Number + 1; }
        //public int Year { get => 1910 + (Number - 1) * 10; }
        
        //public Phase CurrentPhase { get; set; }
        //public int PolicyRoundsPerTurn { get; set; }
        //public IEnumerable<Phase> TurnPhases { get; set; }
        //public bool AllPlayersWin { get; set; }

        //public void Sequence(Game game)
        //{
        //    PolicyPhase policyPhase = new PolicyPhase(this.Id);
        //    policyPhase.Sequence(game);
        //    NationalEventsPhase nationalEventsPhase = new NationalEventsPhase();
        //    nationalEventsPhase.Sequence();
        //}
    }
}
