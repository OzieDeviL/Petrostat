using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public class Nationalist : Ideology
    {
        #region Constructors
        public Nationalist() { }
        public Nationalist(Guid gameId)
        {
            GameId = gameId;
        }
        #endregion

        public override string Name { get { return "Nationalist"; } }
        public override Color Color { get { return Color.White; } }
        public override decimal GameBalance { get { return 0m; } }
        public override string Instruction { get { return "Nationalist Instructions"; } }
        public override string Inspiration { get { return "Nationalist Inspiration"; } }
    }
}
