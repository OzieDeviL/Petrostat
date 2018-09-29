using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Enums
{
    [Flags]
    public enum WaitingFor
    {
        None = 0
            , Socialist = 1
            , Liberal = 1 << 2
            , MinoritySectarian = 1 << 3
            , MajoritySectarian = 1 << 4
            , Authoritarian = 1 << 5
            , Nationalist = 1 << 6
            , Fundamentalist = 1 << 7
    }
}
