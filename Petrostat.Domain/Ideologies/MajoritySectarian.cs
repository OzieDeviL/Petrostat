using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public class MajoritySectarian : Ideology
    {
        #region Constructors
        public MajoritySectarian() { }
        public MajoritySectarian(Guid gameId)
        {
            GameId = gameId;
        }
        #endregion

        public override string Name { get { return "MajoritySectarian"; } }
        public override Color Color { get { return Color.White; } }
        public override decimal GameBalance { get { return 0m; } }
        public override string Instruction { get { return "MajoritySectarian Instructions"; } }
        public override string Inspiration { get { return "MajoritySectarian Inspiration"; } }
    }
}
