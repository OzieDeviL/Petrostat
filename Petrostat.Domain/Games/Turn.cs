using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petrostat.Domain
{
    internal class Turn
    {
        private readonly Game _game;

        public Turn(Game game)
        {   
            _game = game;
        }

        public void Start()
        {
            OpenTurnCheck();
            Number = _game.Turns?.Count ?? 0;
            _game.Turns.Add(this);
            _game.CurrentTurn = this;
            Rounds = new List<Round> { new Round(_game) };
            CurrentRound.Start();
        }
        
        public int Number   { get; private set; }
        public int DisplayNumber => Number + 1;
        public Round CurrentRound => Rounds.Last();
        public IList<Round> Rounds { get; set; }
        public bool IsFinished { get; set; }

        public void OpenTurnCheck ()
        {
            if (IsFinished)
            {
                throw new Exception($"Turn {Number} (displayed as turn {DisplayNumber}) has already been finished.");
            }
        }
    }
}
