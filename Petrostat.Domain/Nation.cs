using Petrostat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petrostat.Domain
{
    public class Nation
    {
        public Nation(Game game)
        {
            GameId = game.Id;
        }

        public Guid GameId { get; set; }

        public int Treasury { get; set; }
        public int Spending { get; set; }

        public int OilProduction { get; set; }
        public int OilPrice { get; set; }
        public bool PeakOil { get; set; }
        
        public List<Population> NationalPopulation { get; }
        public List<Population> PoorPopulation { get => GetPoorPopulation(); }
        public List<Population> WorkingClassPopulation { get => GetWorkingClassPopulation(); }
        public List<Population> MiddleClassPopulation { get => GetMiddleClassPopulation(); }
        public List<Population> WealthyPopulation { get => GetWealthyPopulation(); }
        public int TotalPopulation { get => PoorPopulation.Count + WorkingClassPopulation.Count + MiddleClassPopulation.Count + WealthyPopulation.Count; }
        public string MarketState { get; set; }

        public int ConflictCount { get; set; }
        public int ProtestCount { get; set; }

        public int ForeignPCAvailablePerRally { get; set; }
        public int Power { get; set; }

        public List<PoliticalParty> Parties { get; set; }

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
        
        private List<Population> GetPoorPopulation()
        {
            return (from population in NationalPopulation
                    where population.IsPoor == true
                    select population).ToList<Population>();
        }
        private List<Population> GetWorkingClassPopulation()
        {
            return (from population in NationalPopulation
                    where population.IsWorkingClass == true
                    select population).ToList<Population>();
        }
        private List<Population> GetMiddleClassPopulation()
        {
            return (from population in NationalPopulation
                    where population.IsMiddleClass == true
                    select population).ToList<Population>();
        }
        private List<Population> GetWealthyPopulation()
        {
            return (from population in NationalPopulation
                    where population.IsWealthy == true
                    select population).ToList<Population>();
        }

    }
}
