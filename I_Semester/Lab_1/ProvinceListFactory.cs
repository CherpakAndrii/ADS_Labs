using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1
{
    public static class ProvinceListFactory
    {
        public static int ProvinceCount;
        public static string[] ProvinceNames;
        
        public static List<List<int>> GetAdjacencyMatrix(string path)
        {
            List<List<int>> matr = new List<List<int>>();
            string [] lines = File.ReadAllLines(path);
            ProvinceCount = lines.Length-1;
            ProvinceNames = lines[0].Split(new []{","}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i<lines.Length; i++)
            {
                List<int> l = new List<int>();
                string[] slices = lines[i].Split(new []{","}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in slices) l.Add(Int16.Parse(s));
                matr.Add(l);
            }
            return matr;
        }

        public static List<Province> GetProvinces(List<List<int>> matr)
        {
            List<Province> provinces = new List<Province>();
            for (int i = 0; i < ProvinceCount; i++)
            {
                Province p = new Province(i, ProvinceNames[i]);
                p.Adjacent = new List<int>();
                for (int j = 0; j < ProvinceCount; j++) if (matr[i][j] == 1) p.Adjacent.Add(j);
                provinces.Add(p);
            }

            return provinces;
        }
        
        public static List<Province> Copy(List<Province> orig)
        {
            List<Province> copy = new List<Province>();
            foreach (Province p in orig)
            {
                Province provinceCopy = new Province(p);
                copy.Add(provinceCopy);
            }
            return copy;
        }
    }
}