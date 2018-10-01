//using System;
//using System.Collections.Generic;

//namespace Petrostat.Domain.GameplaySequences
//{
//    public class PolicyPhase : Phase
//    {
//        public PolicyPhase(Guid turnId)
//        {
//            Id = new Guid();
//            TurnId = turnId;
//        }

//        public Guid Id { get; set; }
//        public Guid TurnId {get;set;}
//        public List<PolicyRound> AllPolicyRounds;
//        public PolicyRound CurrentPolicyRound;

//        public override void Sequence(Game game)
//        {
//            while (AllPolicyRounds.Count < game.Settings.PolicyRoundsPerTurn)
//            {
//                PolicyRound policyRound = new PolicyRound(this);
//                policyRound.Sequence(game, game.CurrentTurn);
//            }
//        }
//    }
//}