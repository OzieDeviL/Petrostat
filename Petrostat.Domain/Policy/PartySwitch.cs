using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public class PartySwitch : Policy
    {
        public override string Name { get => "PartySwitch"; }
        public override int NameByEnum { get => (int)Policies.PartySwitch; }
        public PoliticalParty BeginningParty { get; set; }
        public PoliticalParty TargetParty { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyRequirement.AtLeast2PC
                  + (int)PolicyRequirement.BeInParty
                };
                return requirementsEnums;
            }
        }

    }
}
