using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class ImperialismIncrease : Policy
    {
        public ImperialismIncrease(Guid roundId) : base(roundId)
        {
        }

        public override string Name { get => "Imperialism"; }
        public override int NameByEnum { get => (int)Policies.Imperialism; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyFSM.AtLeast2PC
                  + (int)PolicyFSM.Governing
                  + (int)PolicyFSM.NationalistActive
                  + (int)PolicyFSM.LessThanSuperPower
                };
                return requirementsEnums;
            }
        }

    }
}
