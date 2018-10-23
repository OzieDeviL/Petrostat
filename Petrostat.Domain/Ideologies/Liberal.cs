﻿using Petrostat.Domain.Enums;


namespace Petrostat.Domain.Ideologies
{
    public class Liberal : Ideology
    {
        public Liberal(Game game) : base(game, new LiberalVictory(game)) { }

        public override IdeologyName Name => IdeologyName.Liberal;
        public override string Inspiration => "The empire is crumbling! Now is the time for the people of Petrostat to take that which is every person's sacred right: a life free from tyranny, terror, and taxation.";

        public override void SetUp()
        {
            PoliticalCapital = 3;
            var newPopulation1 = new Population(EconomicClass.MiddleClass, Name, game.Nation, false);
            Nation.Population.Add(newPopulation1.Id, newPopulation1);
            var newPopulation2 = new Population(EconomicClass.WorkingClass, Name, game.Nation);
            Nation.Population.Add(newPopulation2.Id, newPopulation2);
            var newPopulation3 = new Population(EconomicClass.WorkingClass, Name, game.Nation);
            Nation.Population.Add(newPopulation3.Id, newPopulation3);
            var newPopulation4 = new Population(EconomicClass.Poor, Name, game.Nation);
            Nation.Population.Add(newPopulation4.Id, newPopulation4);
        }
    }
}
