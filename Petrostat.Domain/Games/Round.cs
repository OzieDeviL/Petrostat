using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain
{
    public class Round
    {
        private readonly Game _game;

        public Round (Game game)
        {
            _game = game;
        }

        public int Id { get; set; }
        public string DisplayNumber { get; set; }
        public int PhaseOrder { get; set; }
        public bool IsFirstTurn { get; set; }
        public bool IsFinished { get; private set; }

        public void Start()
        {
            OpenRoundCheck();
            PlayersChoosePolicies();
        }

        private void PlayersChoosePolicies()
        {
            foreach (_game.Nation.Ideologies)
        }

        public void OpenRoundCheck()
        {
            if (IsFinished)
            {
                throw new Exception($"Phase {Id} (displayed as turn {DisplayNumber}) has already been finished.");
            }
        }
    }
}