using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class PropagandaPoor : Policy
    {
        public override string Name { get => "PropagandaPoor"; }
        public override int NameByEnum { get => (int)Policies.PropagandaPoor; }
        public Population TargetPopulation { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyFSM.AtLeast1PC
                  + (int)PolicyFSM.AtLeast1NonAlignedPoorPopulation
                  + (int)PolicyFSM.TargetPopulationNotArmy
                  + (int)PolicyFSM.TargetPopulationNotPropagandaBlocked
                };
                return requirementsEnums;
            }
        }

    }
}
