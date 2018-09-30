using Petrostat.Domain.Enums;
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
        }

        public Game Game { get; set; }

        public HashSet<Population> Population   { get; }
        public HashSet<PoliticalParty> Parties  { get; set; }

        public int Treasury                         { get; set; }
        public int Spending                         { get; set; }
        public string MarketState                   { get; set; }
        public int TaxBurden                        { get; set; }
        public int OilProduction                    { get; set; }
        public int OilPrice                         { get; set; }
        public bool PeakOil                         { get; set; }
        public int ConflictCount                    { get; set; }
        public int ProtestCount                     { get; set; }
        public int ForeignPCAvailablePerRally       { get; set; }
        public int Power                            { get; set; }
        public VictoryEvents NationalVictoryEvents  { get; set; }

        public void SetUp()
        {
            OilProduction = 0;
            Treasury = 14;
            Spending = 0;
            PeakOil = false;
            MarketState = "Growth";
            ConflictCount = 0;
            ProtestCount = 0;
            ForeignPCAvailablePerRally = 0;
            Power = (int)ImperialismEnums.ClientState;

            PoliticalParty PeoplesPartyOfPertrostat = new PoliticalParty();
            PoliticalParty PetrostatiPeoplesParty = new PoliticalParty();
            PoliticalParty PartyOfPetrostatiPeople = new PoliticalParty();
            Parties.Add(PeoplesPartyOfPertrostat);
            Parties.Add(PetrostatiPeoplesParty);
            Parties.Add(PartyOfPetrostatiPeople);

            //create new Population Cubes
            //align Population Cubes
        }


    }
}
