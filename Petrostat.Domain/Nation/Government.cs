using Petrostat.Domain.Ideologies;
using Petrostat.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Petrostat.Domain
{
    public class Government
    {
        private readonly Game _game;

        public Government(Game game)
        {
            _game = game;
        }

        public int Treaury { get; set; }
        public int Taxes { get; set; }
        public int PublicSpending
        {
            get
            {
                var count = _game.Nation.Population.Sum(p => p.Value.PublicSpending);
                if (_game.IncludesNationalist)
                {
                    count += _game.Nation.Empire.Spending;
                }
                return count;
            }
        }
        public int ProtestCount => _game.Nation.Population.Where(p => p.Value.IsProtesting).Count();
        public HashSet<PoliticalParty> Parties  { get; set; }
        public PoliticalParty RulingParty       { get; set; }

        public void SetUp()
        {
            var peoplesPartyOfPetrostat = new PoliticalParty
            {
                Name = "Peoples Party of Petrostat"
            };
            var petrostatiPeoplesParty = new PoliticalParty
            {
                Name = "Peoples Party of Petrostat"
            };
            var partyOfPetrostatiPeople = new PoliticalParty
            {
                Name = "Party of Petrostati People"
            };
            
            var partiesList = Parties.ToList();
            _game.UIService.DisplayOptions(partiesList);
            var mostRecentGas = _game.TurnOrder.First();
            var rulersChoice = partiesList[_game.UIService.GetIntegerChoice(mostRecentGas.Player, "Governing Player. Choose your starting political party.", 1, 3)];
            rulersChoice.AddIdeology(mostRecentGas);
            RulingParty = rulersChoice;
        }

        public void SwitchIdeology(PoliticalParty targetParty, Ideology ideology)
        {
            var originalParty = ideology.CurrentParty;
            originalParty.RemoveIdeology(ideology);
            targetParty.AddIdeology(ideology);
        }
    }
}