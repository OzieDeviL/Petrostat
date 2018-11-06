using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    class TaxReform : Policy
    { 
        public override string Name { get => "TaxReform"; }
        public override int NameByEnum { get => (int)Policies.TaxReform; }
        public Dictionary<Population, int> TargetPopulation { get; set; }
        public override List<int> RequirementsEnums
        {
            get
            {
                List<int> requirementsEnums = new List<int>
                {
                    (int)PolicyRequirement.AtLeast2PC
                  + (int)PolicyRequirement.Governing
                  + (int)PolicyRequirement.TaxTargetsNotArmy
                  + (int)PolicyRequirement.NewTaxBurdenOnTargetPopulationsLessThanProperty
                };
                return requirementsEnums;
            }
        }

    }
}
