using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    public class ACO
    {
        private static double p = 0.4;
        private static int M = 35, graphSize;
        private static Random rand = new();
        public int Lmin;
        /*private*/public double[][] T;
        private int[][] D;
        private List<int> bestPath;
        private int bestL;
        //private StreamWriter sw, sw2;

        public ACO(int[][] D, double[][] T)
        {
            graphSize = D.Length;
            Lmin = greedy(D);
            this.D = MatrixFactory.Copy(D);
            this.T = MatrixFactory.Copy(T);
            bestPath = new List<int>();
            bestL = Int32.MaxValue;
            /*if (!File.Exists(@"statistics.csv"))
            {
                using (File.Create(@"statistics.csv")) { }
            }
            if (!File.Exists(@"statistics2.csv"))
            {
                using (File.Create(@"statistics2.csv")) { }
            }
            sw = new StreamWriter(@"statistics.csv", false, System.Text.Encoding.Default);
            sw2 = new StreamWriter(@"statistics2.csv", false, System.Text.Encoding.Default);/**/
        }

        public void Go(int numberOfIterations)
        {
            for (int ictr = 0; ictr < numberOfIterations; ictr++)
            {
                List<Ant> ants = new();
                while (ants.Count<M)
                {
                    int p = rand.Next(D.Length);
                    ants.Add(new Ant(D, T, p));
                }
                updateT(ants);
                //sw.WriteLine(bestL);
                if ((ictr + 1) % 20 == 0)
                {
                    //getResult(ictr);
                    Console.WriteLine("\r"+ictr+" : "+bestL);
                    //sw2.WriteLine(ictr+";"+bestL);
                }
            }
            /*sw.Close();
            sw2.Close();*/
            getResult();
        }

        private void updateT(List<Ant> ants)
        {
            for (int i = 0; i<T.Length; i++) for (int j = 0; j < T[i].Length; j++) T[i][j] *= 1 - p;
            foreach (Ant ant in ants)
            {
                if (ant.Lk < bestL)
                {
                    bestL = ant.Lk;
                    bestPath = ant.path;
                }
                for (int i = 1; i < ant.path.Count; i++)
                {
                    T[ant.path[i - 1]][ant.path[i]] += (double)Lmin / ant.Lk;
                    T[ant.path[i]][ant.path[i-1]] += (double)Lmin / ant.Lk;
                }
            }
        }

        /*public void getResult(int ictr)
        {
            string path = $"{ictr}: [0";
            int vctr = 0;
            bool[] visited = new bool [T.Length];
            int curentVertice = 0, L = 0, nextVertice;
            do
            {
                nextVertice = maxIndex(T[curentVertice], path);
                path += $" ==> {nextVertice}";
                vctr++;
                L += D[curentVertice][nextVertice];
                visited[curentVertice] = true;
                curentVertice = nextVertice;
            } while (vctr<D.Length);
            L += D[curentVertice][0];
            path += $" ==> 0], {L}, {{{vctr}}}";
            Console.WriteLine("\r"+path);
        }*/
        
        public void getResult()
        {
            string path = $"[{bestPath[0]}";
            for(int i = 1; i<bestPath.Count; i++)
            {
                path += $" ==> {bestPath[i]}";
            }
            path += $"], {bestL}";
            Console.WriteLine("\r"+path);
        }

        /*private static int maxIndex(double[] T, string path)
        {
            KeyValuePair<int, double> max = new KeyValuePair<int, double>(0, 0);
            for (int i = 1; i < T.Length; i++)
            {
                if (T[i]>max.Value && !path.Contains(" "+Convert.ToString(i))) max = new KeyValuePair<int, double>(i, T[i]);
            }
            return max.Key;
        }*/
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