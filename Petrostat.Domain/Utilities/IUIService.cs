using System;
using System.Collections.Generic;
using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;

namespace Petrostat.Domain.Utilities
{
    public interface IUIService
    {
        Population PickPopulation(HashSet<Population> options, string extraInstructions = null, string title = "POPULATIONS");
        int GetIntegerChoice(string message, int min = Int32.MinValue, int max = Int32.MaxValue);
        void DisplayOptions<T>(IList<T> options);
    }
}