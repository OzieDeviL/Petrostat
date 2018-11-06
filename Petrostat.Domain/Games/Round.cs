using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petrostat.Domain
{
    public class Round
    {
        private readonly Game _game;

        public Round(Game game)
        {
            _game = game;
            Turn = _game.CurrentTurn;

            var previousRound = Turn.Rounds.LastOrDefault();
            if (previousRound != null)
            {
                DisplayNumber = 1;
            } else
            {
                DisplayNumber = previousRound.DisplayNumber++;
            }
            if (previousRound.DisplayNumber == 3)
                throw new Exception($"Three rounds have aleady been added to number {Turn.Number}, display number {Turn.DisplayNumber} in game {_game.Id}")
        }

        public Turn Turn { get; }
        public int DisplayNumber { get; set; }
        public bool IsFirstTurn { get; set; }
        public bool IsFinished { get; private set; }
        public Dictionary<PolicyName, Ideology>

        public void Start()
        {
            OpenRoundCheck();
            ChoosePolicies();
        }

        private Dictionary<PolicyName, Ideology> ChoosePolicies()
        {
        }

        public void OpenRoundCheck()
        {
            if (IsFinished)
            {
                throw new Exception($"Round {this.DisplayNumber} of turn {Turn.DisplayNumber} has already been finished.");
            }
        }
    }
}