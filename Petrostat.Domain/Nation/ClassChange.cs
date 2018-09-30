﻿using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain
{
    public class ClassChange
    {
        public ClassChange(
            Game game,
            Population population,
            EconomicClass previousClass,
            EconomicClass subsequentClass)
        {
            Population = population;
            PreviousClass = previousClass;
            SubsequentClass = subsequentClass;
            game.Nation.NationalVictoryEvents.ClassChanges.Add(this);
            if (Impoverished) Realign();
        }

        public Population Population { get; }
        public EconomicClass PreviousClass { get; }
        public EconomicClass SubsequentClass { get; }
        public bool Impoverished
        {
            get
            {
                if (SubsequentClass < PreviousClass)
                    return true;
                return false;
            }
        }

        public void Realign()
        {
            throw new NotImplementedException();
        }
    }
}