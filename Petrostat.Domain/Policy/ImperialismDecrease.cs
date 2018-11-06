using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class ImperialismDecrease : Policy
    {
        public ImperialismDecrease(Guid roundId) : base(roundId)
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
                    (int)PolicyRequirement.AtLeast2PC
                  + (int)PolicyRequirement.Governing
                  + (int)PolicyRequirement.NationalistActive
                  + (int)PolicyRequirement.AtLeastIndependent
                };
                return requirementsEnums;
            }
        }

    }
}
