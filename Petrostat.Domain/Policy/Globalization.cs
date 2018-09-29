using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class Globalization : Policy
    {
        public Globalization(Guid roundId) : base(roundId)
        {
        }

        public override string Name { get => "Globalization"; }
        public override int NameByEnum { get => (int)Policies.Globalization; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyFSM.AtLeast2PC
                  + (int)PolicyFSM.Governing
                  + (int)PolicyFSM.FundamentalistActive
                };
                return requirementsEnums;
            }
        }

    }
}
