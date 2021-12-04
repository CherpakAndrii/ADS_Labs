using System;

namespace Lab4
{
    internal static class Program
    {
        public static void Main()
        {
            // NewFieldGenerator.GenerateNewField(@"test.csv", 10);
            MatrixFactory mf = new MatrixFactory(@"file1.csv");
            int[][] D = mf.getD();
            double[][] T = mf.getT();
            ACO aco = new(D, T);
            Console.WriteLine($"Lmin = {ACO.Lmin}");
            aco.Go(1000);
        }

        /*public static void outpMatrix(double[][] M)
        {
            for (int i = 0; i < M.Length; i++)
            {
                for (int j = 0; j < M[i].Length; j++)
                {
                    Console.Write($"{Math.Round(M[i][j], 3)}; ");
                }
                Console.WriteLine();
            }
        }*/
    }
}