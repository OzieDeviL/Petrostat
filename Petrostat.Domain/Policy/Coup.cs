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
                    (int)PolicyRequirement.BeInNonGoverningParty
                  + (int)PolicyRequirement.HaveArmy
                  + (int)PolicyRequirement.AtLeast3PC
                    //use protest
                  , (int)PolicyRequirement.AtLeast3PC
                  + (int)PolicyRequirement.BeInNonGoverningParty
                  + (int)PolicyRequirement.AtLeast1AlignedProtester
                  + (int)PolicyRequirement.AtLeast3PartyAlignedProtesters
                };
                return requirementsEnums;
            }
        }

    }
}
