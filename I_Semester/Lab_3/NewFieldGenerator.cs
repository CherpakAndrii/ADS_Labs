using System;
using System.IO;

namespace Lab3
{
    public class NewFieldGenerator
    {
        private const int StandartFieldSize = 150;
        private const int minDist = 5;
        private const int maxDist = 50;
        
        public static void GenerateNewField(string filename, int n = StandartFieldSize, bool symmetry = false)
        {
            Random rand = new Random();
            if (filename.Length > 4 && filename[filename.Length - 4] != '.') filename += ".csv";
            if (!File.Exists(filename))
            {
                using (File.Create(filename)) { }
            }

            if (!symmetry)
            {
                using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(n);
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (i == j) sw.Write(0);
                            else sw.Write(rand.Next(minDist, maxDist + 1));
                            if (j < n - 1) sw.Write(",");
                        }

                        if (i < n - 1) sw.WriteLine();
                    }
                }
            }
            else
            {
                int[,] matr = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        matr[i, j] = matr[j, i] = rand.Next(minDist, maxDist + 1);
                    }
                }
                
                using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(n);
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n-1; j++)
                        {
                            sw.Write(matr[i, j]+",");
                        }
                        sw.WriteLine(matr[i, n-1]);
                    }
                }
            }
        }
    }
}