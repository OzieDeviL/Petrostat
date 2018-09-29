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
                    (int)PolicyFSM.AtLeast2PC
                  + (int)PolicyFSM.HaveArmy
                  + (int)PolicyFSM.Governing
                  + (int)PolicyFSM.AtLeast1ProtestingPopulation
                  + (int)PolicyFSM.TargetPopulationsProtesting
                };
                return requirementsEnums;
            }
        }

    }
}
