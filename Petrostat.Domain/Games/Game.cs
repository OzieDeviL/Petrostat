using System;
using System.Collections.Generic;
using Petrostat.Domain.Ideologies;
using Petrostat.Domain.GameplaySequences;

namespace Petrostat.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public Guid EntityId { get; set; }
        public Nation Nation { get; set; }
        public Turn CurrentTurn { get; set; }
        public List<Turn> Turns { get; set; }
        public bool IncludeFundamentalist { get; private set; }
        public bool IncludeNationalist { get; private set; }
        public VictoryEvents VictoryEvents { get; set; }
        public int Players { get; set; }


        public void Start()
        {
            Console.WriteLine("Enter the number of players(5-7)");
            Players = Int32.Parse(Console.ReadLine());
            SetUp();
        }

        private void SetUp()
        {
            if (Players > 5)
            {
                IncludeNationalist = true;
            }
            if (Players > 6)
            {
                IncludeFundamentalist = true;
            }
            Nation =        new Nation(this);
            VictoryEvents = new VictoryEvents(this);
        }
    }
}