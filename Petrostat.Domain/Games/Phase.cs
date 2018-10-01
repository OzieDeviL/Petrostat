using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain
{
    public abstract class Phase
    {
        public string Name { get; set; }
        public int PhaseOrder { get; set; }
        public bool FirstTurn { get; set; }
        public bool LastTurn { get; set; }
        public bool NationalEvent { get; set; }

        public abstract void Sequence(Game game);
    }
}