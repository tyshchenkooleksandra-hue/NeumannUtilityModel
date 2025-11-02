using System;
using NeumannUtilityModel;

public class Program
{
    public static void Main()
    {
        var scenario1 = new Scenario { Name = "Economic growth", Probability = 0.5 };
        var scenario2 = new Scenario { Name = "Crisis", Probability = 0.1 };
        var scenario3 = new Scenario { Name = "Inflation", Probability = 0.4 };

        var decisions = new Decisions
        {
            new ()
            {
                Name = "Decision 1",
                ScenarioOutcomes = new Outcomes
                {
                    new () { Scenario = scenario1, Value = 10 },
                    new () { Scenario = scenario2, Value = -5 },
                    new () { Scenario = scenario3, Value = -5 }
                }
            },
            new ()
            {
                Name = "Decision 2",
                ScenarioOutcomes = new Outcomes
                {
                    new () { Scenario = scenario1, Value = -5 },
                    new () { Scenario = scenario2, Value = -5 },
                    new () { Scenario = scenario3, Value = 10 }
                }
            },
            new ()
            {
                Name = "Decision 3",
                ScenarioOutcomes = new Outcomes
                {
                    new () { Scenario = scenario1, Value = 1.5 },
                    new () { Scenario = scenario2, Value = 1.5 },
                    new () { Scenario = scenario3, Value = 0 }
                }
            },
            new ()
            {
                Name = "Decision 4",
                ScenarioOutcomes = new Outcomes
                {
                    new () { Scenario = scenario1, Value = 0 },
                    new () { Scenario = scenario2, Value = 0 },
                    new () { Scenario = scenario3, Value = 0 }
                }
            }
        };

        Func<double, double> func = outcome => Math.Pow(outcome + 5, 2) / 15.0;

        CalculateUtility(func, decisions);
    }

    public static void CalculateUtility(Func<double, double> func, Decisions decisions)
    {
        foreach (var decision in decisions)
        {
            double expectedUtility = 0;
            decision.ScenarioOutcomes.ForEach(outcome =>
            {
                expectedUtility += outcome.Scenario.Probability * func(outcome.Value);
            });

            decision.Utility = expectedUtility;
            Console.WriteLine($"{decision.Name}: Expected utility = {expectedUtility:F4}");
        }
    }
}
