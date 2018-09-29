using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Petrostat.Domain.Ideologies
{
    public abstract class Ideology
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public bool IsActive { get; set; }
        public int PoliticalCapital { get; set; }
        public int CurrentVictoryPoints { get; set; }
        public bool IsWinning { get; set; }
        public bool IsGoverning { get; set; }
        public PoliticalParty PartyMembership { get; set; }
        public int ProtestingPopulaiton { get; set; }
        public int AlignedProperty { get; set; }
        public int Armies { get; set; }
        public int EligiblePolicies { get; set; }
        public List<Population> AlignedPopulation { get => GetAlignedPopulation(); }
        public List<Population> AlignedPoorPopulation { get => GetAlignedPoorPopulation(); }
        public List<Population> AlignedWorkingClassPopulation { get => GetAlignedWorkingClassPopulation(); }
        public List<Population> AlignedMiddleClassPopulation { get => GetAlignedMiddleClassPopulation(); }
        public List<Population> AlignedWealthyPopulation { get => GetAlignedWealthyPopulation(); }
        public WarSettings WarSettings { get; set; }

        public abstract string Name { get; }
        public abstract Color Color { get; }
        public abstract decimal GameBalance { get; }
        public abstract string Instruction { get; }
        public abstract string Inspiration { get; }

        private List<Population> GetAlignedPopulation()
        {
            return (from population in Game.Nation.NationalPopulation
                    where population.Alignment.Name == Name
                    select population).ToList();
        }
        private List<Population> GetAlignedPoorPopulation()
        {
            return (from population in Game.Nation.NationalPopulation
                    where population.Alignment.Name == Name && population.IsPoor == true
                    select population).ToList();
        }
        private List<Population> GetAlignedWorkingClassPopulation()
        {
            return (from population in Game.Nation.NationalPopulation
                    where population.Alignment.Name == Name && population.IsWorkingClass == true
                    select population).ToList();
        }
        private List<Population> GetAlignedMiddleClassPopulation()
        {
            return (from population in Game.Nation.NationalPopulation
                    where population.Alignment.Name == Name && population.IsMiddleClass == true
                    select population).ToList();
        }
        private List<Population> GetAlignedWealthyPopulation()
        {
            return (from population in Game.Nation.NationalPopulation
                    where population.Alignment.Name == Name && population.IsWealthy == true
                    select population).ToList();
        }
    }
}
