using Petrostat.Domain.Enums;

namespace Petrostat.Domain.Ideologies
{
    public class Nationalist : Ideology
    {
        public Nationalist(Game game) : base(game, new NationalistVictory(game)) { }

        public override IdeologyName Name { get { return IdeologyName.Nationalist; } }
        public override string Inspiration { get { return "For centuries Petrostat has been crushed by empires. Awaken the people to their common enemy. History moves to that hour when Petrostat will take its place upon the world stage!"; } }

        public override void SetUp()
        {
            //get input to remove 1 working class
            //get input to remove 2 poor markers
            //no two markers from the same player
            PoliticalCapital = 3;
            game.Nation.Population.Add(new Population(EconomicClass.MiddleClass, IdeologyName.Nationalist));
            game.Nation.Population.Add(new Population(EconomicClass.Poor, IdeologyName.Nationalist));
            game.Nation.Population.Add(new Population(EconomicClass.Poor, IdeologyName.Nationalist));
        }
    }
}
