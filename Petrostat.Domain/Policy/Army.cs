using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class Army : Policy
    {
        public Army(Guid roundId) : base(roundId)
        {
        }

        public override string Name { get => "Army"; } //reflection on the  Policies enum?
        public override int NameByEnum { get => (int)Policies.Army; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    //use gov't spending
                    (int)PolicyFSM.Governing
                  + (int)PolicyFSM.AtLeastWealthPlusTreasury
                  + (int)PolicyFSM.AtLeast1AlignedNonArmyCube
                  + (int)PolicyFSM.AtLeast2PC             
                    //without gov't
                  , (int)PolicyFSM.AtLeast3AlignedProperty 
                  + (int)PolicyFSM.AtLeast1AlignedNonArmyCube
                  + (int)PolicyFSM.AtLeast2PC
                };
                return requirementsEnums;
            }
        }

    }
}