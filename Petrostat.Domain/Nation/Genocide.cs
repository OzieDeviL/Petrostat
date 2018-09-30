using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain
{
    public class Genocide
    {
        public Genocide(Game game, Population population, Ideology instigator)
        {
            Population = population;
            if (instigator.IsGoverning)
                ByGovernment = true;
            game.Nation.NationalVictoryEvents.Genocides.Add(this);
        }
        public Population Population { get; set; }
        public bool ByGovernment { get; set; }
    }
}
