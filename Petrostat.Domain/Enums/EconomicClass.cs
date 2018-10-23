using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Enums
{
    [Flags]
    public enum EconomicClass
    {
        InvalidEconomicClass = 0
        , Poor = 1
        , WorkingClass = 2
        , MiddleClass = 3
        , Wealthy = 4
        , None = 5
    }
}
