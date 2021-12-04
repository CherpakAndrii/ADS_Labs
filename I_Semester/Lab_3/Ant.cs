using System;
using System.Collections.Generic;

namespace Lab3
{
    public class Ant
    {
        private  static Random rand = new();
        private static int a = 2, b = 3;
        public List<int> path;
        private int[] visited;
        public int Lk;

        public Ant(int[][] D, double[][] T, int startPoint)
        {
            Lk = 0;
            int current = startPoint;
            path = new();
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
        }
        private static int chooseNext(int[] D, double[] T, int[] visited)
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
            double choise = rand.NextDouble();
            foreach (var vertice in possible)
            {
                if (choise < vertice.Value) return vertice.Key;
                choise -= vertice.Value;
            }
            return -1;
        }
    }
}