using System;
using System.Collections.Generic;
using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;

namespace Petrostat.Domain.Interfaces
{
    public interface IUIService
    {
        Population PickPopulation(HashSet<Population> options, string extraInstructions = null, string title = "POPULATIONS");

        int GetIntegerChoice(Player player, string message, int min = Int32.MinValue, int max = Int32.MaxValue);
        IDictionary<int, Player> GetIntegerChoice(HashSet<Player> players, string message, int min = Int32.MinValue, int max = Int32.MaxValue);
        IDictionary<int, Player> GetIntegerChoice(string message, int min = Int32.MinValue, int max = Int32.MaxValue);

        void DisplayOptions<T>(IList<T> options);
        void DisplayOptions<T>(IList<T> options, Player player);
        void DisplayOptions<T>(IList<T> options, HashSet<Player> players);
    }
}