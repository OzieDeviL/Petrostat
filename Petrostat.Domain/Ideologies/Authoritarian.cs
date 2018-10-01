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
            nation.Population.Add(new Population(EconomicClass.WorkingClass,    Name));
            nation.Population.Add(new Population(EconomicClass.Poor,            Name));
            nation.Population.Add(new Population(EconomicClass.Poor,            Name));
            nation.Population.Add(new Population(EconomicClass.Poor,            Name));
        }
    }
}
