using System;
using System.Collections.Generic;
using Petrostat.Domain.Ideologies;
using Petrostat.Domain.Utilities;
using System.Linq;
using Petrostat.Domain.Enums;

namespace Petrostat.Domain
{
    public class Game
    {
        public Game()
        {
            UIService = new ConsoleUIService(this);
        }

        public int Id { get; set; }
        public Guid EntityId { get; set; }
        public Nation Nation { get; set; }
        public Turn CurrentTurn { get; set; }
        public IList<Turn> Turns { get; private set; }
        public bool IncludesFundamentalist { get; private set; }
        public bool IncludesNationalist { get; private set; }
        public VictoryEvents VictoryEvents { get; set; }
        public Player Player { get; set; }
        public HashSet<Player> Players { get; set; }
        public IUIService UIService {get;}


        public void StartNewGame(HashSet<Player> players)
        {
            var gasDays = new SortedDictionary<int, Player>();
            foreach (var player in players)
            {
                var gasDay = UIService.GetIntegerChoice($"{player.Name}, how many days has it been since you bought gasoline?", min: 0);
                if (gasDays.ContainsKey(gasDay))
                {
                    gasDay++;
                }
                gasDays.Add(gasDay, player);
            }
            gasDays.OrderByDescending(daysSinceGas => daysSinceGas.Key);
            var availableIdeologies = new HashSet<IdeologyName>
            {
                IdeologyName.Liberal,
                IdeologyName.Authoritarian,
                IdeologyName.MajoritySectarian,
                IdeologyName.MinoritySectarian,
                IdeologyName.Socialist
            };
            if (Players.Count > 5)
            {
                IncludesNationalist = true;
                availableIdeologies.Add(IdeologyName.Nationalist);
            }
            if (Players.Count > 6)
            {
                IncludesFundamentalist = true;
                availableIdeologies.Add(IdeologyName.Fundamentalist);
            }
            var playerChoices = new Dictionary<IdeologyName, Player>();
            foreach (var gasPlayer in gasDays)
            {
                UIService.DisplayOptions(availableIdeologies.ToList());
                var choice = (IdeologyName)UIService.GetIntegerChoice($"Choose your ideology");
                playerChoices.Add(choice, gasPlayer.Value);
                availableIdeologies.Remove(choice);
            }
            gasDays.OrderBy(daysSinceGas => daysSinceGas.Key);
            this.SetUp(playerChoices, gasDays.Single(kv => kv.Key == gasDays.Count/2).Value);
            Turns = new List<Turn>();
        }

        private void SetUp(Dictionary<IdeologyName, Player> playerChoices, Player initialGoverningPlayer)
        {
            Nation = new Nation(this);
            Nation.SetUp(playerChoices, initialGoverningPlayer);
            VictoryEvents = new VictoryEvents(this);
        }
    }
}