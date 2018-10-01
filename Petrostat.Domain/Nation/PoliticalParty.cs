using Petrostat.Domain.Ideologies;
using System.Collections;
using System.Collections.Generic;

namespace Petrostat.Domain
{
    public class PoliticalParty
    {
        public string Name { get; set; }
        public IEnumerable<Ideology> AllMembers { get; set; }
        public IEnumerable<Ideology> NonGoverningMembers { get; set; }
        public Ideology Leader { get; set; }
        public bool IsGoverning { get; set; }
        public bool ChallengesAreBlocked { get; set; }

    }
}