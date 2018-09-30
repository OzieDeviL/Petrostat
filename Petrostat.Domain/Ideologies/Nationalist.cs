using Petrostat.Domain.Enums;
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

        public Nationalist(Game game) : base(game)
        {
        }
        #endregion

        public override IdeologyName Name { get { return IdeologyName.Nationalist; } }
        public override Color Color { get { return Color.White; } }
        public override decimal GameBalance { get { return 0m; } }
        public override string Instruction { get { return "Nationalist Instructions"; } }
        public override string Inspiration { get { return "Nationalist Inspiration"; } }
    }
}
