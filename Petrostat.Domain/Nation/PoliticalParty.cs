using Petrostat.Domain.Ideologies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Petrostat.Domain
{
    public class PoliticalParty
    {
        public string Name { get; set; }
        public ICollection<Ideology> Members { get; set; }
        public IEnumerable<Ideology> NonRulingMembers => Members.Where(i => i != this.Leader);
        public Ideology Leader { get; set; }
        public bool IsGoverning { get; set; }
        public bool ChallengesAreBlocked { get; set; }

        public void AddIdeology(Ideology ideology)
        {
            if (Members.Contains(ideology))
                throw new Exception($"Cannot add {ideology.Name} the {this.Name}. That ideology is already in that party.");

            Members.Add(ideology);

            if (Members.Count == 1)
                Leader = ideology;
        }

        public void RemoveIdeology(Ideology ideology)
        {
            if (!Members.Contains(ideology))
                throw new Exception($"Cannot add {ideology.Name} to {this.Name}. That ideology is not in that party.");
            Members.Remove(ideology);
        }
    }
}