using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public class PartyJoin : Policy
    {
        public override string Name { get => "PartyJoin"; }
        public override int NameByEnum { get => (int)Policies.PartyJoin; }
        public PoliticalParty TargetParty { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyFSM.AtLeast2PC
                };
                return requirementsEnums;
            }
        }
    }
}
