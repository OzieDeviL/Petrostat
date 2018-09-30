using Petrostat.Domain.Enums;
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

        public MajoritySectarian(Game game) : base(game)
        {
        }
        #endregion

        public override IdeologyName Name { get { return IdeologyName.MajoritySectarian; } }
        public override Color Color { get { return Color.White; } }
        public override decimal GameBalance { get { return 0m; } }
        public override string Instruction { get { return "MajoritySectarian Instructions"; } }
        public override string Inspiration { get { return "MajoritySectarian Inspiration"; } }
    }
}
