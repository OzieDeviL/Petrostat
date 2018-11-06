using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class Repression : Policy
    {
        public override string Name { get => "Repression"; }
        public override int NameByEnum { get => (int)Policies.Repression; }
        public Population TargetPopulation { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyRequirement.AtLeast2PC
                  + (int)PolicyRequirement.HaveArmy
                  + (int)PolicyRequirement.Governing
                  + (int)PolicyRequirement.AtLeast1ProtestingPopulation
                  + (int)PolicyRequirement.TargetPopulationsProtesting
                };
                return requirementsEnums;
            }
        }

    }
}
