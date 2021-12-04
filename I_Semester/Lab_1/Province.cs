using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab1
{
    public class Province
    {
        public readonly string Name;
        public readonly int Num;
        public List<int> Adjacent;
        public int Color = 0;
        public readonly List<int> PossibleCol;

        public Province(int n, string s)
        {
            Num = n;
            Name = s;
            PossibleCol = new List<int>{1, 2, 3, 4};
        }
        public Province(Province p) {
            Num = p.Num;
            Name = p.Name;
            PossibleCol = p.PossibleCol.ToList();
            Adjacent = p.Adjacent.ToList();
            Color = p.Color; }

        public void setColor(ref List<Province> n_prov, int color)
        {
            Color = color;
            foreach (int j in Adjacent) n_prov[j].PossibleCol.Remove(color);
        }

        public int Conflicts(List<Province> state)
        {
            int ctr = 0;
            foreach (int adj in Adjacent)
            {
                if (Color == state[adj].Color) ctr++;
            }

            return ctr;
        }
    }
}