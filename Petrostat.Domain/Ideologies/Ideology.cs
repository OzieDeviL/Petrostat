using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public abstract class Ideology
    {
        protected readonly Game game;

        public Nation Nation => game.Nation;
        public Ideology(Game game, Victory victory)
        {
            this.game = game;
            Victory = victory;
        }

        public int PoliticalCapital { get; set; }
        public bool IsGoverning { get; set; }
        public PoliticalParty PartyMembership { get; set; }
        public int ProtestingPopulation => AlignedPopulation.Where(p => p.Value.IsProtesting).Count();
        public int AlignedPropertyTotal => AlignedPopulation.Sum(p => p.Value.Property);
        public Dictionary<int, Population> AlignedPopulation { get => game.Nation.Population.Where(p => p.Value.Alignment == Name).ToDictionary(kv => kv.Key, kv => kv.Value); }
        public Victory Victory { get; }
        public Player Player { get; set; }

        public abstract IdeologyName Name { get; }
        public abstract string Inspiration { get; }

        public abstract void SetUp();
        //public int EligiblePolicies { get; set; }
        //public WarSettings WarSettings { get; set; }
    }
}
