using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain
{
    public class Economy
    {
        Nation nation;

        public Economy(Nation nation)
        {
            this.nation = nation;
        }

        public int OilReserves      { get; set; }
        public OilPrice OilPrice    { get; set; }
        public bool PeakOil         { get; set; }
        public Market Market { get; set; }
    }
}
