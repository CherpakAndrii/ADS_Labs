using System;
using System.Collections.Generic;

namespace Lab1
{
    public class DGR
    {
        //public static DateTime StartTime, FinishTime;
        
        private static int findMinDGR(List<Province> prov)
        {
            int minDegree = Int32.MaxValue;
            int i = -1;
            foreach (Province p in prov)
            {
                if (p.Color > 0) continue;
                if (p.PossibleCol.Count < 1) return -1;
                int degree = 0;
                foreach (int adjacentProvince in p.Adjacent) if (prov[adjacentProvince].Color == 0) degree++;
                if (degree < minDegree)
                {
                    minDegree = degree;
                    i = p.Num;
                }
            }
            return i;
        }
        
        public static bool ChooseColors(ref List<Province> provinces, int count = 1 )
        {
            //int i = findMaxDGR(provinces);
            int i = findMinDGR(provinces);
            //int i = getMRV(provinces);
            if (i == -1)
            {
                return false;
            }
            foreach (int col in provinces[i].PossibleCol)
            {
                Statistic.IterationCounter++;
                List<Province> n_prov = ProvinceListFactory.Copy(provinces);
                n_prov[i].setColor(ref n_prov, col);
                Statistic.StateCounter++;
                if (count+1 == ProvinceListFactory.ProvinceCount) {
                    provinces = n_prov;
                    return true;
                }
                if (ChooseColors(ref n_prov, count+1))
                {
                    provinces = n_prov;
                    return true;
                }
                Statistic.DeadEndCounter++;
            }
            return false;
        }
        
        /*private static int getMRV(List<Province> prov)
        {
            int minRV = 9;
            int i = -1;
            foreach (Province p in prov)
            {
                if (p.Color > 0) continue;
                if (p.PossibleCol.Count < 1) return -1;
                if (p.PossibleCol.Count < minRV)
                {
                    minRV = p.PossibleCol.Count;
                    i = p.Num;
                }
            }
            return i;
        }*/
        
        /*private static int findMaxDGR(List<Province> prov)
        {
            int maxDegree = 0;
            int i = -1;
            foreach (Province p in prov)
            {
                if (p.Color > 0) continue;
                if (p.PossibleCol.Count < 1) return -1;
                int degree = 0;
                foreach (int adjacentProvince in p.Adjacent) if (prov[adjacentProvince].Color == 0) degree++;
                if (degree > maxDegree)
                {
                    maxDegree = degree;
                    i = p.Num;
                }
            }
            return i;
        }*/
    }
}