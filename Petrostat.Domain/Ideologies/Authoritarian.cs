using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using static Petrostat.Domain.Nation;
using static Petrostat.Domain.Utilities.StaticUtilities;


namespace Petrostat.Domain.Ideologies
{
    public class Authoritarian : Ideology
    {
        public Authoritarian(Game game) : base(game, new AuthoritarianVictory(game)) { }

        public override IdeologyName Name => IdeologyName.Authoritarian;
        public override Color Color => Color.Black;
        public override string Instruction => "Author Instructions";
        public override string Inspiration => "The imperial government has collapsed! Heedless radicals of every stripe are plotting for power. Stop this madness before Petrostat spirals into chaos and war.";

        public override void SetUp()
        {
            PoliticalCapital = 3;
            Nation.Population.Add(new Population(EconomicClass.WorkingClass,    Name));
            Nation.Population.Add(new Population(EconomicClass.Poor,            Name));
            Nation.Population.Add(new Population(EconomicClass.Poor,            Name));
            Nation.Population.Add(new Population(EconomicClass.Poor,            Name));
        }
    }
}
