using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain
{
    internal class Empire
    {
        Nation nation;

        public Empire(Nation nation)
        {
            this.nation = nation;
        }

        public int Spending
        {
            get
            {
                return Spending;
            }
            set
            {
                if (value %5 == 0 && value <=0 && value <= 20)
                    Spending = value;
                else
                    throw new ArgumentOutOfRangeException("Spending on Imperialism must be increments of 5 exactly (min: 0, max: 20).");
            }
        }
        public ImperialPower Level => (ImperialPower)Spending;
        public int ForeignPCAvailable
        {
            get
            {
                switch (nation.Economy.OilReserves)
                {
                    case int oil when (oil <= 5):
                        return 0;
                    case int oil when (6 <= oil && oil <= 11):
                        return 1;
                    case int oil when (12 <= oil && oil <= 14):
                        return 2;
                    case int oil when (15 <= oil):
                        return 3;
                    default:
                        throw new ArgumentOutOfRangeException("How did this error get hit!");
                }
            }
        }
    }
}
