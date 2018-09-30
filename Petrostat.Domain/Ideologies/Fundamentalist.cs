using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public class Fundamentalist : Ideology
    {
        public Fundamentalist(Game game) : base(game, new FundamentalistVictory(game)) { }

        public override IdeologyName Name { get { return IdeologyName.Fundamentalist; } }
        public override string Inspiration { get { return "Your people have lost themselves in the poisonous imports of empire. The time has come to purify the soul of your nation! Ressurect the forgetten traditions of the Petrosi."; } }

        public override void SetUp()
        {
            throw new NotImplementedException();
        }
    }
}
