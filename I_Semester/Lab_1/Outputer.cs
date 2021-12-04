using System;
using System.Collections.Generic;

namespace Lab1
{
    public class Outputer
    {
        public static void OutputProvinceColors(List<Province> provinces)
        {
            Console.WriteLine("\r\t\t\t\t");
            foreach (Province p in provinces)
            {
                switch (p.Color)
                {
                    case 1: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                    case 2: Console.ForegroundColor = ConsoleColor.Green; break;
                    case 3: Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                    case 4: Console.ForegroundColor = ConsoleColor.Magenta; break;
                    default: Console.ForegroundColor = ConsoleColor.Blue; break;
                }
                Console.WriteLine(p.Name);
            }
            Console.ResetColor();
        }

        public static void OutputStatistics(int i)
        {
            Console.WriteLine($"\rInitial state {i+1}:     ");
            Console.WriteLine($"\tIterations: {Statistic.IterationCounter}");
            Console.WriteLine($"\tDead ends: {Statistic.DeadEndCounter}");
            Console.WriteLine($"\tStates generated: {Statistic.StateCounter}");
            TimeSpan executionTime = Statistic.FinishTime - Statistic.StartTime;
            Console.WriteLine($"\tExecution time: {Math.Ceiling(executionTime.TotalMilliseconds)}ms");
            //Console.WriteLine($"\r{i+1}: {Statistic.IterationCounter} . {Statistic.DeadEndCounter}\t\t\t");
        }
    }
}