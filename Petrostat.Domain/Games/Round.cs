using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain
{
    public class Round
    {
        public int Id { get; set; }
        public string DisplayNumber { get; set; }
        public int PhaseOrder { get; set; }
        public bool IsFirstTurn { get; set; }
        public bool IsFinished { get; private set; }

        public void Start()
        {
            OpenPhaseCheck();
            PlayersChoosePolicies();
        }

        private void PlayersChoosePolicies()
        {
            throw new NotImplementedException();
        }

        public void OpenPhaseCheck()
        {
            if (IsFinished)
            {
                throw new Exception($"Phase {Id} (displayed as turn {DisplayNumber}) has already been finished.");
            }
        }
    }
}