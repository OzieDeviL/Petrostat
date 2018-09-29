using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public class Liberal : Ideology
    {
        #region Constructors
        public Liberal() { }
        public Liberal(Guid gameId)
        {
            GameId = gameId;
        }
        #endregion

        public override string Name { get { return "Liberal"; } }
        public override Color Color { get { return Color.White; } }
        public override decimal GameBalance { get { return 0m; } }
        public override string Instruction { get { return "Liberal Instructions"; } }
        public override string Inspiration { get { return "Liberal Inspiration"; } }
    }
    
}
