using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Petrostat.Domain
{
    public static class PolicyQualificationHelpers
    {
        public static bool IsGoverningIdeology(Ideology ideology) => ideology.CurrentParty.IsGoverning && ideology.CurrentParty.Leader == ideology;
        public static bool HasAlignedArmy(Ideology ideology) => ideology.AlignedPopulation.Any(p => p.Value.IsArmy);
        public static int IdeologyWealth(Ideology ideology) => ideology.AlignedPopulation.Sum(p => p.Value.Wealth);
    }
}
