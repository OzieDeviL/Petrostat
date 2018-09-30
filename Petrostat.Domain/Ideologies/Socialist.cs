using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public class Socialist : Ideology
    {
        #region Constructors
        public Socialist() { }
        public Socialist(Guid gameId)
        {
            GameId = gameId;
        }

        public Socialist(Game game) : base(game)
        {
        }
        #endregion

        public override IdeologyName Name { get { return IdeologyName.Socialist; } }
        public override Color Color { get { return Color.White; } }
        public override decimal GameBalance { get { return 0m; } }
        public override string Instruction { get { return "Socialist Instructions"; } }
        public override string Inspiration { get { return "Socialist Inspiration"; } }
    }
}
