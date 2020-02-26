using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Petrostat.Domain
{
    internal class Nation
    {
        private readonly Game _game;    

        public Nation(Game game)
        {
            _game = game;
        }

        public HashSet<Ideology> Ideologies             { get; set; }
        public Dictionary<int, Population> Population   { get; private set; }
        public Empire Empire                            { get; private set; }
        public Economy Economy                          { get; private set; }
        public Government Government                    { get; private set; }
        public Military Military                        { get; private set; }
        public int Year => 1920 + _game.Turns.Count * 5;

        public void SetUp(Dictionary<IdeologyName, Player> playerChoices)
        {
            Ideologies = new HashSet<Ideology>
            {
                new Authoritarian(_game),
                new Liberal(_game),
                new MajoritySectarian(_game),
                new MinoritySectarian(_game),
                new Socialist(_game)
            };
            foreach (var ideology in Ideologies)
            {
                ideology.SetUp();
                ideology.Player = playerChoices.Single(kv => kv.Key == ideology.Name).Value;
            }
            Population = new Dictionary<int, Population>();
            Economy = new Economy(this)
            {
                OilPrice = OilPrice.Medium,
                Market = Market.Growth
            };
            Government = new Government(_game)
            {
                Taxes = 1,
                Treaury = 14
            };
            Government.SetUp();
            Military = new Military(_game);
            if (_game.IncludesNationalist || _game.IncludesFundamentalist)
            {
                ExpansionSetUp();
            }
        }

        private void ExpansionSetUp()
        {
            if (_game.IncludesNationalist)
            {
                Empire = new Empire(this);
            }
            var eligibleIdeologies = this.Ideologies
                .Where(p => p.Name != IdeologyName.Nationalist && p.Name != IdeologyName.Fundamentalist)
                .Select(i => i.Name)
                .ToHashSet();
            if (_game.IncludesNationalist)
            {
                var nationalist = new Nationalist(_game);
                Ideologies.Add(nationalist);
                eligibleIdeologies = nationalist.ExpansionSetUp(eligibleIdeologies);
            }
            eligibleIdeologies.Add(IdeologyName.Nationalist);
            if (_game.IncludesFundamentalist)
            {
                var fundamentalist = new Fundamentalist(_game);
                Ideologies.Add(fundamentalist);
                fundamentalist.ExpansionSetUp(eligibleIdeologies);
            }
        }
    }
}

