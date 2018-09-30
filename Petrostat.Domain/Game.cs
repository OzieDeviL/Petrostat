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
        public HashSet<Ideology> Ideologies { get; set; }
        public Turn CurrentTurn { get; set; }
        public List<Turn> AllTurns { get; set; }
        public List<VictoryEvent> ActiveVictoryEvents { get; set; }
        public bool IncludeFundamentalist { get; private set; }
        public bool IncludeNationalist { get; private set; }

        public void Start()
        {
            Console.WriteLine("Enter the number of players(5-7)");
            var players = Int32.Parse(Console.ReadLine());
            SetUp(players);
        }

        private void SetUp(int players)
        {
            Nation = new Nation(this);
            Ideologies = new HashSet<Ideology>
            {
                new Authoritarian(this),
                new Liberal(this),
                new MajoritySectarian(this),
                new MinoritySectarian(this),
                new Socialist(this)
            }; 
            if (players > 5)
            {
                Ideologies.Add(new Nationalist(this));
                IncludeNationalist = true;
            }
            if (players > 6)
            {
                Ideologies.Add(new Fundamentalist(this));
                IncludeFundamentalist = true;
            }
            foreach (var ideology in Ideologies)
            {
                ideology.SetUp();
            }

        }
    }
}