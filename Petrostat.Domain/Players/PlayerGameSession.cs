using Petrostat.Domain.Ideologies;
using System;

namespace Petrostat.Domain
{
    public class PlayerGameSession
    {
        public PlayerGameSession () { }
        public PlayerGameSession (Guid playerId
                                , Guid gameId)
        {
            PlayerId = playerId;
            GameId = gameId;
            Id = new Guid();
            IsActive = true;
        }

        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public Ideology Ideology { get; set; }
    }
}