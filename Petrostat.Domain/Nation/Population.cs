using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Petrostat.Domain.Utilities.StaticUtilities;

namespace Petrostat.Domain
{
    public class Population
    {
        public Population(EconomicClass startingClass
            , IdeologyName alignment
            , Nation nation
            , bool isMajority = true)
        {
            Id = PetroLuck.Next();
            if (nation.Population.Any())
            {
                Number = nation.Population.Max(p => p.Value.Number) + 1;
            } else
            {
                Number = 1;
            }
            Alignment = alignment;
            IsMajority = isMajority;
            switch (startingClass)
            {
                case EconomicClass.Poor:
                    Property = PetroLuck.Next(0, 45);
                    break;
                case EconomicClass.WorkingClass:
                    Property = PetroLuck.Next(6, 14);
                    break;
                case EconomicClass.MiddleClass:
                    Property = PetroLuck.Next(15, 29);
                    break;
                case EconomicClass.Wealthy:
                    Property = PetroLuck.Next(30, 44);
                    break;
                default:
                    break;
            }
        }

        public int Id { get; set; }
        public int Number { get; }
        public IdeologyName Alignment { get; set; }
        public bool IsMajority { get; set; }
        public EconomicClass EconomicClass
        {
            get
            {
                if (IsArmy) return EconomicClass.None;
                switch (Wealth)
                {
                    case int n when (n < 5):
                        return EconomicClass.Poor;
                    case int n when (n >= 5 && n < 15):
                        return EconomicClass.WorkingClass;
                    case int n when (n >= 15 && n < 30):
                        return EconomicClass.MiddleClass;
                    case int n when (n >= 30):
                        return EconomicClass.Wealthy;
                    default:
                        return EconomicClass.None;
                }
            }
        }
        public bool IsArmy { get; set; }
        public int Property { get; set; }
        public int PublicSpending { get; set; }
        public int Wealth { get => Property + PublicSpending; }
        public bool IsProtesting { get; set; }
        public bool IsUnderReligiousLaw { get; set; }
        public bool PropagandaBlocked { get; set; }
    }
}
