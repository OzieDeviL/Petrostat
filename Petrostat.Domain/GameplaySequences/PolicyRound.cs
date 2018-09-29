using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petrostat.Domain.GameplaySequences
{
    public class PolicyRound
    {
        public PolicyRound(PolicyPhase phase)
        {
            Id = new Guid();
            PhaseId = phase.Id;
            if (phase.AllPolicyRounds == null)
            {
                phase.AllPolicyRounds = new List<PolicyRound>
                {
                    this
                };
                phase.CurrentPolicyRound = this;
                Number = phase.AllPolicyRounds.Count - 1;
            }
            else
            {
                phase.AllPolicyRounds.Add(this);
                Number = phase.AllPolicyRounds.Count - 1;
            }
        }

        public Guid Id { get; set; }
        public Guid PhaseId { get; set; }
        public int Number { get; set; }
        public int DisplayNumber { get => Number + 1; }
        //public Dictionary<int, Ideology> PlayerOrder { get; set; }
        public Dictionary<Ideology, Policy> ChosenPolicies { get; set; }
        public int WaitingOn { get; set; }
        //public Dictionary<Ideology, PolicyPlay> ChosenQuickPolicies { get; set; }
        //public Ideology CurrentPlayer { get; set; }

        public void Sequence(Game game, Turn turn)
        {
            //choose policies or policy depending on QuickPlay Option
            if (!game.Settings.QuickPlay)
            {
                //set all to waiting
            //code
            }
                //get inputs
                //flip flags to not waiting
                //on last input, proceed to next round/phase
            }
            //} else
            //{
            //    //code
            //}
            ////UIInput
            ////execute policies in turn order

        }

        private void UIInputPolicyChoice(Ideology ideology, Policy policy)
        {
            //server-side check that it's a valid policy to choose
            //if (policy.RequiresArmy)
            //{
                
            //}
            //ChosenPolicies.Add(ideology, policy);
        }
    }
}
