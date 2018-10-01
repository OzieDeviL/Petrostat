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
            Empire = new Empire(this);
            Economy = new Economy(this);
        }

        public Game Game { get; set; }
        public HashSet<Ideology> Ideologies { get; set; }
        public HashSet<Population> Population   { get; }
        public Empire Empire { get; }
        public Economy Economy { get; }
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

        public void SetUp()
        {
            Ideologies = new HashSet<Ideology>
            {
                new Authoritarian(Game),
                new Liberal(Game),
                new MajoritySectarian(Game),
                new MinoritySectarian(Game),
                new Socialist(Game)
            };
            if (Game.IncludeNationalist)
            {
                Ideologies.Add(new Nationalist(Game));
            }
            if (Game.IncludeFundamentalist)
            {
                Ideologies.Add(new Fundamentalist(Game));
            }
            foreach (var ideology in Ideologies)
            {
                ideology.SetUp();
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
}
