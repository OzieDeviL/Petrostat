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
        public Ideology(Game game, Victory victory)
        {
            Game = game;
            Victory = victory;
        }

        public Game Game { get; }
        public Nation Nation => Game.Nation;
        public int PoliticalCapital { get; set; }
        public bool IsGoverning { get; set; }
        public PoliticalParty PartyMembership { get; set; }
        public int ProtestingPopulation => AlignedPopulation.Where(p => p.IsProtesting).Count();
        public int AlignedPropertyTotal => AlignedPopulation.Sum(p => p.Property);
        public HashSet<Population> AlignedPopulation { get => Game.Nation.Population.Where(p => p.Alignment == Name).ToHashSet(); }
        public Victory Victory { get; }

        public abstract IdeologyName Name { get; }
        public abstract Color Color { get; }
        public abstract string Instruction { get; }
        public abstract string Inspiration { get; }

        public abstract void SetUp();
        //public int EligiblePolicies { get; set; }
        //public WarSettings WarSettings { get; set; }
    }
}
