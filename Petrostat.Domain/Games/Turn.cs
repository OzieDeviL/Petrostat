using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petrostat.Domain
{
    public class Turn
    {
        Game game;

        public Turn(Game game)
        {   
            this.game = game;
        }

        public void Start()
        {
            OpenTurnCheck();
            Number = game.Turns?.Count() ?? 0;
            game.Turns.Add(this);
            game.CurrentTurn = this;
            Rounds = new List<Round> { new Round() };
            CurrentRound.Start();
        }
        
        public int Number   { get; private set; }
        public int DisplayNumber => Number + 1;
        public Round CurrentRound => Rounds.Last();
        public IList<Round> Rounds { get; private set; }
        public bool IsFinished { get; set; }

        public void OpenTurnCheck ()
        {
            if (IsFinished)
            {
                throw new Exception($"Turn {Number} (displayed as turn {DisplayNumber}) has already been finished.");
            }
        }
        
        //public bool AllPlayersWin { get; set; }

        //public void Sequence(Game game)
        //{
        //    PolicyRound policyRound = new PolicyRound(this.Id);
        //    policyRound.Sequence(game);
        //    NationalEventsRound nationalEventsRound = new NationalEventsRound();
        //    nationalEventsRound.Sequence();
        //}
    }
}
