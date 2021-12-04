using System;
using System.Collections.Generic;

namespace Lab1
{
    public static class ANNEAL
    {
        public static bool ChooseColors(ref List<Province> provinces)
        {
            double T = 1000, k = 2;
            Random rand = new();
            List<Province> currentState = ProvinceListFactory.Copy(provinces);
            foreach (Province prov in provinces) prov.Color = 1;
            while (T > 0)
            {
                Statistic.IterationCounter++;
                List<Province> newState = getNewState(currentState);
                int newStateConflicts = conflictCount(newState), currentStateConflict = conflictCount(currentState);
                double stateDifference = currentStateConflict - newStateConflicts;
                if (newStateConflicts == 0)
                {
                    provinces = newState;
                    return true;
                }
                if ( stateDifference > 0 || rand.NextDouble()>Math.Exp(stateDifference/T))
                {
                    if (stateDifference <= 0) Statistic.DeadEndCounter++;
                    Console.Write($"\r{Statistic.IterationCounter}, {T}, {conflictCount(currentState)}, {conflictCount(newState)}, {stateDifference}\t\t");
                    currentState = newState;
                    T -= k;
                }
            }
            return false;
        }

        public static int conflictCount(List<Province> state)
        {
            int ctr = 0;
            foreach (Province prov in state) ctr += prov.Conflicts(state);
            return ctr;
        }

        private static List<Province> getNewState(List<Province> currentState)
        {
            List<Province> newState = ProvinceListFactory.Copy(currentState);
            Random rand = new Random();
            List<Province> withConflict = new();
            foreach (var province in newState)
                if (province.Conflicts(newState) > 0)
                    withConflict.Add(province);
            Province randomProvince = withConflict[rand.Next(withConflict.Count)];
            randomProvince.Color = randomProvince.PossibleCol[rand.Next(randomProvince.PossibleCol.Count)];
            Statistic.StateCounter++;
            return newState;
        }
    }
}