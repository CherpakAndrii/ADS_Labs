using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
    public class ACO
    {
        private static double p = 0.55;
        private static int M = 20, graphSize;
        private static Random rand = new();
        public static int Lmin;
        /*private*/public double[][] T;
        private int[][] D;
        private List<int> bestPath;
        //private StreamWriter sw;

        public ACO(int[][] D, double[][] T)
        {
            graphSize = D.Length;
            Lmin = greedy(D);
            this.D = MatrixFactory.Copy(D);
            this.T = MatrixFactory.Copy(T);
            bestPath = new List<int>();
            /*if (!File.Exists($"statistics{parameter}.csv"))
            {
                using (File.Create($"statistics{parameter}.csv")) { }
            }
            sw = new StreamWriter($"statistics{parameter}.csv", false, System.Text.Encoding.Default);
        */}

        public void Go(int numberOfIterations)
        {
            Ant ant = new();
            int newLmin = Lmin;
            KeyValuePair<int, List<int>> pair;

            for (int ictr = 0; ictr < numberOfIterations; ictr++)
            {
                double[][] newT = evaporate(T);
                for (int ctr = 0; ctr<M; ctr++)
                {
                    pair = ant.Go(D, T, rand.Next(D.Length), ref newT);
                    if (pair.Key < newLmin)
                    {
                        newLmin = pair.Key;
                        bestPath = pair.Value;
                    }
                }
                T = newT;
                Lmin = newLmin;
                //sw.WriteLine(ictr+";"+Lmin);
            }
            //sw.Close();
            getResult();
        }

        private double[][] evaporate(double[][] T)
        {
            double[][] newT = MatrixFactory.Copy(T);
            for (int i = 0; i < T.Length; i++) for (int j = 0; j < T.Length; j++) newT[i][j] *= 1 - p;
            return newT;
        }
        
        public void getResult()
        {
            string path = $"[{bestPath[0]}";
            for(int i = 1; i<bestPath.Count; i++)
            {
                path += $" ==> {bestPath[i]}";
            }
            path += $"], {Lmin}";
            Console.WriteLine("\r"+path);
        }
        
        private static int greedy(int[][] D)
        {
            int Lmin = 0, currentVertice = 0, nextVertice;
            int[] visited = new int[graphSize];
            visited[0] = 1;
            for (int ctr = 1; ctr < graphSize; ctr++)
            {
                nextVertice = greedyOptimal(D[currentVertice], visited);
                visited[nextVertice] = 1;
                Lmin += D[currentVertice][nextVertice];
                currentVertice = nextVertice;
            }
            Lmin += D[currentVertice][0];
            return Lmin;
        }

        private static int greedyOptimal(int[] D, int[] visited)
        {
            KeyValuePair<int, int> optimal = new KeyValuePair<int, int>(0, D[0]+1000*visited[0]);
            for (int i = 1; i < D.Length; i++)
            {
                if (D[i]+1000*visited[i]<optimal.Value) optimal = new KeyValuePair<int, int>(i, D[i]+1000*visited[i]);
            }
            return optimal.Key;
        }
    }
}