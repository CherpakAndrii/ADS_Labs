using System;
using System.IO;

namespace Lab4
{
    public class MatrixFactory
    {
        private string filename;
        private int graphSize;
        public MatrixFactory(string filename)
        {
            this.filename = filename;
            if (filename.Length <= 4 || filename[filename.Length - 4] != '.') this.filename += ".csv";
            if (!checkFileIntegrity(this.filename))
            {
                NewFieldGenerator.GenerateNewField(this.filename);
                Console.WriteLine($"New file \"{this.filename}\" created!");
            }
        }

        public int[][] getD()
        {
            using (StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default))
            {
                graphSize = Int32.Parse(sr.ReadLine());
                int[][] D = new int[graphSize][];
                for (int i = 0; i < graphSize; i++)
                {
                    D[i] = new int[graphSize];
                    String[] strDistances = sr.ReadLine().Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < graphSize; j++) D[i][j] = Int32.Parse(strDistances[j]);
                }
                return D;
            }
        }

        public double[][] getT()
        {
            double[][] T = new double[graphSize][];
            Random rand = new();
            for (int i = 0; i < graphSize; i++)
            {
                T[i] = new double[graphSize];
                for (int j = 0; j < graphSize; j++)
                {
                    if (i == j) T[i][j] = 0;
                    else T[i][j] = /*Convert.ToDouble(rand.Next(1, 4)) / 10*/3;
                }
            }

            return T;
        }

        private bool checkFileIntegrity(string filename)
        {
            if (!File.Exists(filename)) return false;
            using (StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default))
            {
                int n;
                if (!int.TryParse(sr.ReadLine(), out n)) return false;
                int ctr = 0;
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    ctr++;
                    if (data.Length < n || ctr > n) return false;
                    int test;
                    foreach (String num in data)
                    {
                        if (!int.TryParse(num, out test)) return false;
                    }
                }
            }
            return true;
        }

        public static T[][] Copy<T>(T[][] original)
        {
            T[][] copy = new T[original.Length][];
            for (int i = 0; i<original.Length; i++)
            {
                copy[i] = new T[original[0].Length];
                for (int j = 0; j < original[0].Length; j++) copy[i][j] = original[i][j];
            }
            return copy;
        }
    }
}