using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public class MinoritySectarian : Ideology
    {
        #region Constructors
        public MinoritySectarian() { }
        public MinoritySectarian(Guid gameId)
        {
            GameId = gameId;
        }
        #endregion

        public override string Name { get { return "MinoritySectarian"; } }
        public override Color Color { get { return Color.White; } }
        public override decimal GameBalance { get { return 0m; } }
        public override string Instruction { get { return "MinoritySectarian Instructions"; } }
        public override string Inspiration { get { return "MinoritySectarian Inspiration"; } }
    }
}
