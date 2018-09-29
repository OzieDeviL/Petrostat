using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain
{
    public class Population
    {
        public int Property { get; set; }
        public int Spending { get; set; }
        public int Wealth { get => Property + Spending; }
        public bool IsPoor { get { if ((Wealth) <= 5) { return true; } else { return false; }; } }
        public bool IsWorkingClass { get { if ((Wealth) > 5 && (Wealth) <= 15) { return true; } else { return false; }; } }
        public bool IsMiddleClass { get { if ((Wealth) > 15 && (Wealth) <= 25) { return true; } else { return false; }; } }
        public bool IsWealthy { get { if ((Wealth) > 25) { return true; } else { return false; }; } }
        public bool IsMajority { get; set; }
        public bool IsProtesting { get; set; }
        public bool IsArmy { get; set; }
        public bool TaxBurden { get; set; }
        public bool UnderReligiousLaw { get; set; }
        public bool PropagandaBlocked { get; set; }
        public Ideology Alignment { get; set; }

    }
}
