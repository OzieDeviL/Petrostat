using Petrostat.Domain.Enums;


namespace Petrostat.Domain.Ideologies
{
    public class Authoritarian : Ideology
    {
        public Authoritarian(Game game) : base(game, new AuthoritarianVictory(game)) { }

        public override IdeologyName Name => IdeologyName.Authoritarian;
        public override string Inspiration => "The imperial government has collapsed! Heedless radicals of every stripe are plotting for power. Stop this madness before Petrostat spirals into chaos and war.";

        public override void SetUp()
        {
            PoliticalCapital = 3;
            var population = new Population(EconomicClass.WorkingClass, Name, game.Nation);
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
