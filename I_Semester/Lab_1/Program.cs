using System;
using System.Collections.Generic;

namespace Lab1
{
    internal class Program
    {
        public static void oMain()
        {
            for (int i = 0; i < 1/*20*/; i++)
            {
                List<List<int>> matr = ProvinceListFactory.GetAdjacencyMatrix(@"Matr.csv");
                List<Province> provinces = ProvinceListFactory.GetProvinces(matr);
                Statistic.StartTime = DateTime.Now;
                if (!ANNEAL.ChooseColors(ref provinces))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\rAn error ocured!");
                    Console.ResetColor();
                }
                Statistic.FinishTime = DateTime.Now;
                //else Outputer.OutputProvinceColors(provinces);
                Outputer.OutputStatistics(i);
                Statistic.ResetCounters();
            }
        }
        
        public static void Main()
        {
            var rand = new Random();
            for (int i = 0; i < 2/*20*/; i++)
            {
                List<List<int>> matr = ProvinceListFactory.GetAdjacencyMatrix(@"Matr.csv");
                List<Province> provinces = ProvinceListFactory.GetProvinces(matr);
                provinces[i].setColor(ref provinces, rand.Next(4) + 1);
                Statistic.StartTime = DateTime.Now;
                if (!DGR.ChooseColors(ref provinces))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\rAn error ocured!");
                    Console.ResetColor();
                }
                Statistic.FinishTime = DateTime.Now;
                //else Outputer.OutputProvinceColors(provinces);
                Outputer.OutputStatistics(i);
                Statistic.ResetCounters();
            }
        }
    }
}