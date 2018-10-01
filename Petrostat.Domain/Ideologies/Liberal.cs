using Petrostat.Domain.Enums;


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
            nation.Population.Add(new Population(EconomicClass.MiddleClass, Name, false));
            nation.Population.Add(new Population(EconomicClass.WorkingClass, Name));
            nation.Population.Add(new Population(EconomicClass.WorkingClass, Name));
            nation.Population.Add(new Population(EconomicClass.Poor, Name));
        }
    }
}
