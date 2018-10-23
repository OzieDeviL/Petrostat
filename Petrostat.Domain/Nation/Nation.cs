using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Petrostat.Domain
{
    public class Nation
    {
        public Nation(Game game)
        {
            Game = game;
            Population = new Dictionary<int, Population>();
            Economy = new Economy(this);
            Government = new Government();
            if (Game.IncludesNationalist)
            {
                Empire = new Empire(this);
            }
        }

        public Game Game                                { get; }
        public HashSet<Ideology> Ideologies             { get; set; }
        public Dictionary<int, Population> Population   { get; }
        public Empire Empire                            { get; }
        public Economy Economy                          { get; }
        public Government Government                    { get; }
        public int Year => 1920 + Game.Turns.Count * 5;
        public OilPrice OilPrice                        { get; set; }
        public Market Market                            { get; set; }
        //public HashSet<PoliticalParty> Parties  { get; set; }
        //public int ConflictCount                    { get; set; }
        //public int ProtestCount                     { get; set; }
        //public int Treasury                         { get; set; }
        //public int Spending                         { get; set; }
        //public string MarketState                   { get; set; }
        //public int OilProduction                    { get; set; }
        //public int OilPrice                         { get; set; }
        //public bool PeakOil                         { get; set; }
        //public int ForeignPCAvailablePerRally       { get; set; }
        //public int Power                            { get; set; }

        public void SetUp(Dictionary<IdeologyName, Player> playerChoices, Player initialGoverningPlayer)
        {
            Ideologies = new HashSet<Ideology>
            {
                new Authoritarian(Game),
                new Liberal(Game),
                new MajoritySectarian(Game),
                new MinoritySectarian(Game),
                new Socialist(Game)
            };
            foreach (var ideology in Ideologies)
            {
                ideology.SetUp();
                ideology.Player = playerChoices.Single(kv => kv.Key == ideology.Name).Value;
            }
            if (Game.IncludesNationalist || Game.IncludesFundamentalist)
            {
                ExpansionSetUp();
            }
            Government.Treaury = 14;
            OilPrice = OilPrice.Medium;
            Market = Market.Growth;
            Government.Taxes = 1;
        }

        private void ExpansionSetUp()
        {
            var eligibleIdeologies = this.Ideologies
                .Where(p => p.Name != IdeologyName.Nationalist && p.Name != IdeologyName.Fundamentalist)
                .Select(i => i.Name)
                .ToHashSet();
            if (Game.IncludesNationalist)
            {
                var nationalist = new Nationalist(Game);
                Ideologies.Add(nationalist);
                eligibleIdeologies = nationalist.ExpansionSetUp(eligibleIdeologies);
            }
            eligibleIdeologies.Add(IdeologyName.Nationalist);
            if (Game.IncludesFundamentalist)
            {
                var fundamentalist = new Fundamentalist(Game);
                Ideologies.Add(fundamentalist);
                fundamentalist.ExpansionSetUp(eligibleIdeologies);
            }
        }



        //OilProduction = 0;
        //Treasury = 14;
        //Spending = 0;
        //PeakOil = false;
        //MarketState = "Growth";
        //ConflictCount = 0;
        //ProtestCount = 0;
        //ForeignPCAvailablePerRally = 0;
        //Power = (int)ImperialismEnums.ClientState;

        //PoliticalParty PeoplesPartyOfPertrostat = new PoliticalParty();
        //PoliticalParty PetrostatiPeoplesParty = new PoliticalParty();
        //PoliticalParty PartyOfPetrostatiPeople = new PoliticalParty();
        //Parties.Add(PeoplesPartyOfPertrostat);
        //Parties.Add(PetrostatiPeoplesParty);
        //Parties.Add(PartyOfPetrostatiPeople);

        //create new Population Cubes
        //align Population Cubes
    }


}

