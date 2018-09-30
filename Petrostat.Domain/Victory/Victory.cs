using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public abstract class Victory
    {   
        public Victory(Game game)
        {
            Game = game;
        }

        public abstract int     CurrentPoints   { get; }
        public abstract int     StartingPoints  { get; }
        public abstract string  Instructions    { get; }
        public virtual  bool    IsWinning   => CurrentPoints >= MinimumVictoryPoints;
        public          int     MinimumVictoryPoints => 40;
        public virtual  int     ImperialismPoints { get; set; }

        #region Convenience References
        public Game Game { get; }
        public Nation Nation => Game.Nation;
        public VictoryEvents VictoryEvents => Nation.NationalVictoryEvents;
        #endregion
    }
}
