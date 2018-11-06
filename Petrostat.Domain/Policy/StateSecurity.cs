using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class StateSecurity : Policy
    {
        public override string Name { get => "StateSecurity"; }
        public override int NameByEnum { get => (int)Policies.StateSecurity; }
        public Ideology TargetIdeology { get; set; }
        public bool TargetElection { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyRequirement.AtLeast2PC
                  + (int)PolicyRequirement.Governing
                };
                return requirementsEnums;
            }
        }
    }
}
