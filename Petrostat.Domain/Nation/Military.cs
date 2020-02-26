using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petrostat.Domain
{
    internal class Military
    {
        private readonly Game _game;

        public Military(Game game)
        {
            _game = game;
        }

        public int ConflictCount { get; set; }
        public IDictionary<int, Population> Armies => _game.Nation.Population.Where(p => p.Value.IsArmy).ToDictionary(kv => kv.Key, kv => kv.Value);
    }
}
