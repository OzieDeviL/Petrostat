using System;
using System.Collections.Generic;
using Petrostat.Domain.Ideologies;
using Petrostat.Domain.Utilities;
using System.Linq;
using Petrostat.Domain.Enums;
using Petrostat.Domain.Services;
using Petrostat.Domain.Interfaces;

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
        public HashSet<Player> Players { get; set; }
        public LinkedList<Ideology> TurnOrder { get; set; }
        public IUIService UIService { get; }
        public PlayerService PlayerService { get;}

        public void StartNewGame(HashSet<Player> players)
        {
            var Players = PlayerService.GetPlayersForNewGame();
            if (Players.Count() < 7) { IncludesFundamentalist = false; }
            if (Players.Count() < 6) { IncludesNationalist = false; }
            var playerPriority = DeterminePlayerPriority(players);
            var playerChoices = ChooseIdeologies(playerPriority);
            UpdateTurnOrder(playerPriority);
            Nation = new Nation(this);
            Nation.SetUp(playerChoices);

            VictoryEvents = new VictoryEvents(this);
            Turns = new List<Turn>();

            var turn1 = new Turn(this);
            Turns.Add(turn1);
            turn1.Start();
        }

        private SortedDictionary<int, Player> DeterminePlayerPriority(HashSet<Player> players)
        {
            var gasDays = new SortedDictionary<int, Player>();
            foreach (var player in players)
            {
                var gasDay = UIService.GetIntegerChoice(player, $"{player.Name}, how many days has it been since you bought gasoline?", min: 0);
                if (gasDays.ContainsKey(gasDay))
                {
                    gasDay++;
                }
                gasDays.Add(gasDay, player);
            }
            gasDays.OrderByDescending(daysSinceGas => daysSinceGas.Key);
            return gasDays;
        }

        private Dictionary<IdeologyName, Player> ChooseIdeologies (SortedDictionary<int, Player> playerPriorities)
        {
            var orderedPlayerPriorities = playerPriorities.OrderByDescending(daysSinceGas => daysSinceGas.Key);

            var choices = new Dictionary<IdeologyName, Player>();
            foreach (IdeologyName ideology in Enum.GetValues(typeof(IdeologyName)))
            {
                choices.Add(ideology, null);
            }
            if (!IncludesFundamentalist)
            {
                choices.Remove(IdeologyName.Fundamentalist);
            }
            if (!IncludesNationalist)
            {
                choices.Remove(IdeologyName.Nationalist);
            }

            foreach (var player in orderedPlayerPriorities.Select(kv => kv.Value))
            {
                UIService.DisplayOptions(choices.ToList());
                var choice = (IdeologyName)UIService.GetIntegerChoice(player, $"Choose your ideology");
                choices[choice] = player;
                this.Nation.Ideologies.Single(i => i.Name == choice).Player = player;
                choices.Remove(choice);
            }
            return choices;
        }

        public void UpdateTurnOrder(SortedDictionary<int, Player> playerPriorities)
        {
            var orderedPlayerPriorities = playerPriorities.OrderBy(daysSinceGas => daysSinceGas.Key);
            var node = new LinkedListNode<Ideology>(Nation.Ideologies.Single(i => i.Player.Id == orderedPlayerPriorities.First().Value.Id));
            foreach (var player in orderedPlayerPriorities)
            {
                if (TurnOrder == null)
                {
                    TurnOrder = new LinkedList<Ideology>();
                    TurnOrder.AddFirst(node);
                }
                else if (player.Value.Id != orderedPlayerPriorities.Last().Value.Id)
                {
                    node = TurnOrder.AddAfter(node, Nation.Ideologies.Single(i => i.Player.Id == player.Value.Id));
                } else
                {
                    TurnOrder.AddLast(Nation.Ideologies.Single(i => i.Player.Id == player.Value.Id));
                }
            }
            throw new NotImplementedException();
        }
    }
}