using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static System.Console;

namespace Petrostat.Domain.Utilities
{
    public class ConsoleUIService : IUIService
    {
        private readonly Game game;

        public ConsoleUIService(Game game)
        {
            this.game = game;
        }

        public Population PickPopulation(HashSet<Population> options, string extraInstructions = null, string title = "POPULATIONS")
        {
            WriteLine(title);
            if (!String.IsNullOrWhiteSpace(extraInstructions))
            {
                WriteLine(extraInstructions);
            }
            NewLine();
            DisplayPopulations(options);
            var message = "Enter the id number of the population you would like to choose.";
            WriteLine(message);
            Int32.TryParse(ReadLine(), out int choice);
            while (!game.Nation.Population.Select(p => p.Value.Id).Contains(choice))
            {
                InvalidInput(message);
            }
            return game.Nation.Population[choice];
        }

        private void NewLine()
        {
            Write(Environment.NewLine);
        }

        private void InvalidInput(string message)
        {
            WriteLine($"Invalid Input, try again. {message}");
        }

        private void DisplayPopulations(HashSet<Population> populations)
        {
            var display = new StringBuilder();
            foreach (var population in populations)
            {
                if (display.Length > 0)
                {
                    display.Append(Environment.NewLine);
                }
                display.AppendJoin<string>(". ", new List<string>()
                {
                    ("Id: " + population.Id.ToString()),
                    Enum.GetName(typeof(IdeologyName), population.Alignment),
                    Enum.GetName(typeof(EconomicClass), population.EconomicClass),
                    population.IsMajority ? "Ethnic Majority" : "Ethnic Minority",
                    ("Wealth (Property + Public Spending): " + population.Wealth),
                    ("Property: " + population.Property),
                    ("Public Spending: " + population.PublicSpending),
                    population.IsArmy ? "Army" : "Civilian",
                    population.IsProtesting ? "Protesting" : "Not Protesting",
                    population.PropagandaBlocked ? "Protest prevented by state security" : "Can protest"
                });
                if (game.IncludesFundamentalist)
                {
                    display.Append(". ");
                    display.Append(population.IsUnderReligiousLaw ? "Under religious law." : "Free from religious law.");
                }
            }
            WriteLine(display);
        }

        public int GetIntegerChoice(string message, int min = int.MinValue, int max = int.MaxValue)
        {
            WriteLine(message);
            int escape = 0;
            var invalidInput = true;
            while (invalidInput)
            {
                if (escape > 10)
                {
                    throw new Exception("Problem choosing ineger input");
                }
                escape++;
                Int32.TryParse(ReadLine(), out int choice);
                if (choice < min)
                {
                    WriteLine(Environment.NewLine + $"That choice is less than the minimum limit ({min}).");
                    continue;
                } else if (choice > max) { 
                    WriteLine(Environment.NewLine + $"That choice is less than the minimum limit ({min}).");
                    continue;
                } else
                {
                    return choice;
                }
            }
            throw new Exception("Something is wonky in the GetIntegerInput Method");
        }

        public void DisplayOptions<T>(IList<T> options)
        {
            var display = new StringBuilder();
            foreach (var option in options)
            {
                if (display.Length > 0)
                {
                    display.Append(Environment.NewLine);
                }
                display.AppendJoin<string>(". ", new List<string>()
                {
                    (options.IndexOf(option).ToString() + ": " + option.ToString()),
                });
            }
            WriteLine(display);
        }
    }
}
