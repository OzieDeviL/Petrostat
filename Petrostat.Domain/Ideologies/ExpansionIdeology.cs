using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public abstract class ExpansionIdeology : Ideology
    {
        public ExpansionIdeology(Game game, Victory victory) : base(game, victory) { }

        public abstract HashSet<IdeologyName> ExpansionSetUp(HashSet<IdeologyName> eligibleIdeologies);
    }
}