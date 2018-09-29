using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain
{
    class Coup : Policy
    {
        public Coup(Guid roundId) : base(roundId)
        {
        }

        public override string Name { get => "Coup"; }
        public override int NameByEnum { get => (int)Policies.Coup; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    //use army
                    (int)PolicyFSM.BeInNonGoverningParty
                  + (int)PolicyFSM.HaveArmy
                  + (int)PolicyFSM.AtLeast3PC
                    //use protest
                  , (int)PolicyFSM.AtLeast3PC
                  + (int)PolicyFSM.BeInNonGoverningParty
                  + (int)PolicyFSM.AtLeast1AlignedProtester
                  + (int)PolicyFSM.AtLeast3PartyAlignedProtesters
                };
                return requirementsEnums;
            }
        }

    }
}
