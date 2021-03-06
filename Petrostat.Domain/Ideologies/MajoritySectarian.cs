﻿using Petrostat.Domain.Enums;

namespace Petrostat.Domain.Ideologies
{
    public class MajoritySectarian : Ideology
    {
        public MajoritySectarian(Game game) : base(game, new MajoritySectarianVictory(game)) { }

        public override IdeologyName Name { get { return IdeologyName.MajoritySectarian; } }
        public override string Inspiration { get { return "For centuries, the empire's colonists have stolen your land and savagely subjugated your once great people. But the time is ripe for rebellion. Take back what's yours!"; } }

        public override void SetUp()
        {
            var population = new Population(EconomicClass.Poor, Name, game.Nation);
            Nation.Population.Add(population.Id, population);
            population = new Population(EconomicClass.Poor, Name, game.Nation);
            Nation.Population.Add(population.Id, population);
            population = new Population(EconomicClass.Poor, Name, game.Nation);
            Nation.Population.Add(population.Id, population);
            population = new Population(EconomicClass.Poor, Name, game.Nation);
            Nation.Population.Add(population.Id, population);
        }
    }
}
