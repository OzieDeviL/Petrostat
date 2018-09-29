using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Enums
{
    [Flags]
    public enum GameStates
    {
        None = 0
        , Conflict = 1
        , ChoosingPolicy = 1 << 1
    }
}
