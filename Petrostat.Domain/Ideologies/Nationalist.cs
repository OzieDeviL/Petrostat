using Petrostat.Domain.Enums;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Petrostat.Domain.Ideologies
{
    public class Nationalist : ExpansionIdeology
    {
        public Nationalist(Game game) : base(game, new NationalistVictory(game)) { }

        public override IdeologyName Name { get { return IdeologyName.Nationalist; } }
        public override string Inspiration { get { return "For centuries Petrostat has been crushed by empires. Awaken the people to their common enemy. History moves to that hour when Petrostat will take its place upon the world stage!"; } }

        public override HashSet<IdeologyName> ExpansionSetUp(HashSet<IdeologyName> eligibleIdeologies)
        {
            if (Nation.Ideologies.Count < 5)
            {
                throw new Exception("Base Ideologies must be set up before expansion ideologies can be set up.");
            }
            var pickedPopulations = new HashSet<Population>();
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
                var pickedPopulation = game.UIService.PickPopulation(eligiblePopulations.Where(p =>p.EconomicClass == removedMarkerClass).ToHashSet());
                eligibleIdeologies.RemoveWhere(i => i == pickedPopulation.Alignment);
                Nation.Population.Remove(pickedPopulation.Id);
            }       
            SetUp();
            return eligibleIdeologies;
        }

        public override void SetUp()
        {
            PoliticalCapital = 3;          
            var population = new Population(EconomicClass.MiddleClass, IdeologyName.Nationalist, game.Nation);
            game.Nation.Population.Add(population.Id, population);
            population = new Population(EconomicClass.Poor, IdeologyName.Nationalist, game.Nation);
            game.Nation.Population.Add(population.Id, population);
        }
    }
}
