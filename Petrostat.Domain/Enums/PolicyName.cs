using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Enums
{
    [Flags]
    public enum PolicyName
    {
        None = 0
            , Rally = 1
            , PropagandaBlocking = 1 << 1
            , Repression = 1 << 2
            , PartyBlock = 1 << 3
            , Army = 1 << 4
            , ProtestAdd = 1 << 5
            , Coup = 1 << 6
            , Genocide = 1 << 7
            , ReligiousLawAdd = 1 << 8
            , StateSecurity = 1 << 9
            , TaxReform = 1 << 10
            , SocialSpending = 1 << 11
            , Imperialism = 1 << 12
            , Globalization = 1 << 13
            , PropagandaPoor = 1 << 14
            , PropagandaWorkingClass = 1 << 15
            , PropagandaMiddleClass = 1 << 16
            , PropagandaWealthy = 1 << 17
            , PartySwitch = 1 << 18
            , PartyLeave = 1 << 19
            , PartyChallenge = 1 << 20
            , PartyJoin = 1 << 21
            , ProtestRemove = 1 << 22
            , ReligiousLawRemove = 1 << 23
    
    }
}
