using Petrostat.Domain.Enums;

namespace Petrostat.Domain.Ideologies
{
    public class Socialist : Ideology
    {
        public Socialist(Game game) : base(game, new SocialistVictory(game)) { }

        public override IdeologyName Name { get { return IdeologyName.Socialist; } }
        public override string Inspiration { get { return "For centuries, the people hungered for justice while the rich ate the fruits of their labor! Now, history calls you to free the people of Petrostat from the tyranny of want."; } }

        public override void SetUp()
        {
            PoliticalCapital = 3;
            Game.Nation.Population.Add(new Population(EconomicClass.WorkingClass,   IdeologyName.Socialist));
            Game.Nation.Population.Add(new Population(EconomicClass.Poor,           IdeologyName.Socialist));
            Game.Nation.Population.Add(new Population(EconomicClass.Poor,           IdeologyName.Socialist));
            Game.Nation.Population.Add(new Population(EconomicClass.Poor,           IdeologyName.Socialist));
        }
    }
}
