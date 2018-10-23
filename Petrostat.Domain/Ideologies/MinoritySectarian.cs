using Petrostat.Domain.Enums;
using System;
using System.Drawing;
using static Petrostat.Domain.Utilities.StaticUtilities;

namespace Petrostat.Domain.Ideologies
{
    public class MinoritySectarian : Ideology
    {
        public MinoritySectarian(Game game) : base(game, new MinoritySectarianVictory(game)) { }

        public override IdeologyName Name => IdeologyName.MinoritySectarian;
        public override string Inspiration { get { return "Who built the roads? Who built the banks and the hospitals, the schools and the sewers? None of this was here before you. Protect what our people built!"; } }

        public override void SetUp()
        {
            PoliticalCapital = 3;
            var newPopulation = new Population(EconomicClass.Wealthy, IdeologyName.MinoritySectarian, game.Nation, false);
            game.Nation.Population.Add(newPopulation.Id, newPopulation);
            newPopulation = new Population(EconomicClass.Wealthy, IdeologyName.MinoritySectarian, game.Nation, false);
            game.Nation.Population.Add(newPopulation.Id, newPopulation);
            newPopulation = new Population(EconomicClass.Poor, IdeologyName.MinoritySectarian, game.Nation, false);
            game.Nation.Population.Add(newPopulation.Id, newPopulation);
            var startingArmy = new Population(EconomicClass.None, IdeologyName.MinoritySectarian, game.Nation, false);
            startingArmy.IsArmy = true;
            startingArmy.Property = PetroLuck.Next(2, 6);
            startingArmy.PublicSpending = 3;
            game.Nation.Population.Add(startingArmy.Id, startingArmy);
        }
    }
}