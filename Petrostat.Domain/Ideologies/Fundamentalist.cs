using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public class Fundamentalist : ExpansionIdeology
    {
        public Fundamentalist(Game game) : base(game, new FundamentalistVictory(game)) { }

        public override IdeologyName Name { get { return IdeologyName.Fundamentalist; } }
        public override string Inspiration { get { return "Your people have lost themselves in the poisonous imports of empire. The time has come to purify the soul of your nation! Ressurect the forgetten traditions of the Petrosi."; } }

        public override HashSet<IdeologyName> ExpansionSetUp(HashSet<IdeologyName> eligibleIdeologies)
        {
            if (Nation.Ideologies.Count < 5)
            {
                throw new Exception("Base Ideologies must be set up before expansion ideologies can be set up.");
            }
            var eligiblePopulations = game.Nation.Population
                .Where(p => !p.Value.IsArmy
                    && eligibleIdeologies.Contains(p.Value.Alignment))
                .Select(p => p.Value)
                .ToHashSet();
            var removedMarkerClasses = new List<EconomicClass>
            {
                EconomicClass.Poor,
                EconomicClass.WorkingClass
            };
            foreach (var removedMarkerClass in removedMarkerClasses)
            {
                var pickedPopulation = game.UIService.PickPopulation(eligiblePopulations.Where(p => p.EconomicClass == removedMarkerClass).ToHashSet());
                eligibleIdeologies.RemoveWhere(i => i == pickedPopulation.Alignment);
                Nation.Population.Remove(pickedPopulation.Id);
            }
            SetUp();
            return eligibleIdeologies;
        }

        public override void SetUp()
        {
            PoliticalCapital = 3;
            var population = new Population(EconomicClass.WorkingClass, IdeologyName.Nationalist, game.Nation);
            game.Nation.Population.Add(population.Id, population);
            population = new Population(EconomicClass.Poor, IdeologyName.Nationalist, game.Nation);
            game.Nation.Population.Add(population.Id, population);
        }
    }
}
