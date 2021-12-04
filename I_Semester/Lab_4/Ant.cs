using System;
using System.Collections.Generic;

namespace Lab4
{
    public class Ant
    {
        private  static readonly Random rand = new();
        protected static int a = 2, b = 7;
        public List<int> path;
        public int Lk;
        public char type;
        private int[] visited;

        public Ant(char antType = 'c')
        {
            type = antType;
        }

        public KeyValuePair<int, List<int>> Go(int[][] D, double[][] T, int startPoint, ref double[][] newT)
        {
            Lk = 0;
            path = new();
            int current = startPoint;
            path.Add(current);
            visited = new int[D.Length];
            visited[current] = 1;
            while (path.Count < D.Length)
            {
                int next = chooseNext(D[current], T[current], visited);
                path.Add(next);
                Lk += D[current][next];
                visited[next] = 1;
                current = next;
            }
            Lk += D[current][startPoint];
            path.Add(startPoint);
            
            double delta = (double)ACO.Lmin / Lk;
            if (type == 'e') delta *= 2;
            for (int i = 1; i < path.Count; i++)
            {
                newT[path[i - 1]][path[i]] += delta;
                newT[path[i]][path[i-1]] += delta;
            }
            
            return new(Lk, path);
        }

        private int chooseNext(int[] D, double[] T, int[] visited)
        {
            List<KeyValuePair<int, double>> _possible = new List<KeyValuePair<int, double>>();
            double denominator = 0;
            for (int i = 0; i < D.Length; i++)
            {
                if (visited[i] == 0)
                {
                    double numerator = Math.Pow(T[i], a) * Math.Pow(1.0 / D[i], b);
                    if (numerator < Math.Pow(10, -15)) numerator = Math.Pow(10, -15);
                    _possible.Add(new KeyValuePair<int, double>(i, numerator));
                    denominator += numerator;
                }
            }
            double test = 0;
            List<KeyValuePair<int, double>> possible = new List<KeyValuePair<int, double>>();
            for (int i = 0; i < _possible.Count; i++)
            {
                test += _possible[i].Value / denominator;
                possible.Add(new KeyValuePair<int, double>(_possible[i].Key, _possible[i].Value/denominator));
            }
            if (Math.Round(test, 8)!=1) Console.WriteLine($"{test}!=1");
            if (type == 'c')
            {
                double choise = rand.NextDouble();
                foreach (var vertice in possible)
                {
                    if (choise < vertice.Value) return vertice.Key;
                    choise -= vertice.Value;
                }
            }
            else if (type == 'e')
            {
                possible.Sort((p1, p2) => p2.Value.CompareTo(p1.Value));
                return possible[0].Key;
            }
            else if (type == 'w')
            {
                int choise = rand.Next(possible.Count);
                return possible[choise].Key;
            }
            
            return -1;
        }
    }
}