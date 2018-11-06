using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class Genocide : Policy
    {
        public Genocide(Guid roundId) : base(roundId)
        {
        }

        public override string Name { get => "Genocide"; }
        public override int NameByEnum { get => (int)Policies.Genocide; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyRequirement.AtLeast3PC
                  + (int)PolicyRequirement.HaveArmy
                  + (int)PolicyRequirement.AtLeast1NonAlignedPopulation
                };
                return requirementsEnums;
            }
        }

    }
}
