using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public class Authoritarian : Ideology
    {
        #region Constructors
        public Authoritarian() { }
        public Authoritarian (Guid gameId)
        {
            GameId = gameId;
        }
        #endregion
        
        public override string Name { get { return "Authoritarian"; } }
        public override Color Color { get { return Color.White; } }
        public override decimal GameBalance { get { return 0m; } }
        public override string Instruction { get { return "Authoritarian Instructions"; } }
        public override string Inspiration { get { return "Authoritarian Inspiration"; } }
    }
}
