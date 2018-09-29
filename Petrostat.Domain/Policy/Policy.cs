using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain
{
    public abstract class Policy
    {
        public Policy (Guid roundId) {
            Id = new Guid();
            RoundId = roundId;
        }

        public Guid Id { get; set; }
        public Guid RoundId { get; set; }

        public abstract string Name { get; }    
        public abstract int NameByEnum { get; }
        public abstract List<int> RequirementsEnums { get; }
    }
}
