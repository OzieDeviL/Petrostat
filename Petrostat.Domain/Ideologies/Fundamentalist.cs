using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public class Fundamentalist : Ideology
    {
        #region Constructors
        public Fundamentalist() { }
        public Fundamentalist(Guid gameId)
        {
            GameId = gameId;
        }

        public Fundamentalist(Game game) : base(game)
        {
        }
        #endregion

        public override IdeologyName Name { get { return IdeologyName.Funamentalist; } }
        public override Color Color { get { return Color.White; } }
        public override decimal GameBalance { get { return 0m; } }
        public override string Instruction { get { return "Fundamentalist Instructions"; } }
        public override string Inspiration { get { return "Fundamentalist Inspiration"; } }
    }
}
