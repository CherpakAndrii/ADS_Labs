using System;

namespace Lab1
{
    public class Statistic
    {
        public static int IterationCounter = 0, DeadEndCounter = 0,StateCounter = 1;
        public static DateTime StartTime, FinishTime;
        public static void ResetCounters()
        {
            IterationCounter = 0;
            DeadEndCounter = 0;
            StateCounter = 1;
        }
    }
}