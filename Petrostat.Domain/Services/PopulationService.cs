using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Services
{
    public class PopulationService
    {
        Dictionary<int, Population> population;

        public PopulationService(Dictionary<int, Population> population)
        {
            this.population = population;
        }

        public void Realign(int populationId, IdeologyName ideologyName)
        {
            population.TryGetValue(populationId, out Population targetPopulation);
            targetPopulation.Alignment = ideologyName;
        }
    }
}
