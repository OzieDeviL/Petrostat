using Petrostat.Domain.Ideologies;
using System;

namespace Petrostat.Domain
{
    public class PolicyPlay
    {
        public PolicyPlay(Guid policyRoundId
                        , Ideology ideology
                        , PolicyChoice policy)
        {
            Id = new Guid();
            PolicyRoundId = policyRoundId;
            Ideology = ideology;
            Policy = policy;
        }

        public Guid Id { get; set; }
        public Guid PolicyRoundId { get; set; }
        public int ChosenRound { get; set; }
        public Ideology Ideology {get;set;}
        public PolicyChoice Policy { get; set; }
    }
}