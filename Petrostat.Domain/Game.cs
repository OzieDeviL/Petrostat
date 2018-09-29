using System;
using System.Collections.Generic;
using Petrostat.Domain.Ideologies;
using Petrostat.Domain.GameplaySequences;

namespace Petrostat.Domain
{
    public class Game
    {
        public Game() { }

        public Game(Player parentPlayer, string name)
        {
            Id = new Guid();
            Name = name;

            ParentPlayer = parentPlayer;
            AllPlayers.Add(parentPlayer);
            ActivePlayers.Add(parentPlayer);
            PlayerGameSessions.Add(new PlayerGameSession(parentPlayer.Id, this.Id));
            ActivePlayerGameSessions.AddRange(PlayerGameSessions);
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Player ParentPlayer { get; set; }
        public List<Player> AllPlayers { get; set; }
        public List<Player> ActivePlayers { get; set; }
        public bool AvailableToJoin { get; set; }
        public bool GameplayComplete { get; set; }
        public Settings Settings { get; set; }

        public List<PlayerGameSession> PlayerGameSessions { get; set; }
        public List<PlayerGameSession> ActivePlayerGameSessions { get; set; } //use LINQ for this Setter Where PlayerGameSession IsActive Property = true

        public List<Ideology> ActiveIdeologies { get; set; }
        public Dictionary<PlayerGameSession, Ideology> AllGameSessionIdeologies { get; set; }
        public Dictionary<PlayerGameSession, Ideology> CurrentGameSessionIdeologies { get; set; } //use LINQ for this Setter

        public Turn CurrentTurn { get; set; }
        public List<Turn> AllTurns { get; set; }

        public List<VictoryEvent> ActiveVictoryEvents { get; set; }

        public Nation Nation { get; set; }
    }
}