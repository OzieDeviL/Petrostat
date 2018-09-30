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
    public class Liberal : Ideology
    {
        public Liberal(Game game) : base(game, new LiberalVictory(game)) { }

        public override IdeologyName Name => IdeologyName.Liberal;
        public override Color Color => Color.Blue;
        public override string Instruction => "Liberal Instructions";
        public override string Inspiration => "The empire is crumbling! Now is the time for the people of Petrostat to take that which is every person's sacred right, a life free from tyranny, terror, and taxation.";

        public override void SetUp()
        {
            PoliticalCapital = 3;
            Nation.Population.Add(new Population(EconomicClass.MiddleClass, Name, false));
            Nation.Population.Add(new Population(EconomicClass.WorkingClass, Name));
            Nation.Population.Add(new Population(EconomicClass.WorkingClass, Name));
            Nation.Population.Add(new Population(EconomicClass.Poor, Name));
        }
    }
}
