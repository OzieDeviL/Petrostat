using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petrostat.Domain.GameplaySequences
{
    public class Turn
    {
        public Turn(Game game)
        {
            Id = new Guid();
            GameId = game.Id;
            if (game.AllTurns == null)
            {
                game.AllTurns = new List<Turn>
                {
                    this
                };  
                game.CurrentTurn = this;
                Number = game.AllTurns.Count - 1;
            } else
            {
                game.AllTurns.Add(this);
                game.CurrentTurn = this;
                Number = game.AllTurns.Count - 1;
            }
            
            PolicyRoundsPerTurn = game.Settings.PolicyRoundsPerTurn;
        }

        public Guid Id { get; set; }
        public Guid GameId { get; set; }

        public int Number { get; set; }
        public int DisplayNumber { get => Number + 1; }
        public int Year { get => 1910 + (Number - 1) * 10; }
        
        public Phase CurrentPhase { get; set; }
        public int PolicyRoundsPerTurn { get; set; }
        public IEnumerable<Phase> TurnPhases { get; set; }
        public bool AllPlayersWin { get; set; }

        public void Sequence(Game game)
        {
            PolicyPhase policyPhase = new PolicyPhase(this.Id);
            policyPhase.Sequence(game);
            NationalEventsPhase nationalEventsPhase = new NationalEventsPhase();
            nationalEventsPhase.Sequence();
        }
    }
}
