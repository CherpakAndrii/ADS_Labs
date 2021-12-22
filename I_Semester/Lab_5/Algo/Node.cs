using System;
using System.Collections.Generic;

namespace Lab5.Algo
{
    partial class Tree
    {
        public class Node
        {
            public readonly int[,] CurrentState;
            public readonly int I, J;
            public readonly int DepthLevel;
            public readonly bool IsTerminal;
            public int Value;
            public List<Node> PossibleNextMoves;
        
            public Node(int[,] state, int i, int j, int depthLvl)
            {
                CurrentState = Game.GetNewPosition(state, i, j);
                I = i;
                J = j;
                DepthLevel = depthLvl;
                Value = DepthLevel % 2 == 1 ? int.MinValue : int.MaxValue;
                if (Game.PositionIsWinning(CurrentState))
                {
                    IsTerminal = true;
                    Value = Convert.ToInt32(1000*Math.Pow(-1, DepthLevel));
                }
                InitializeNewNodes();
            }

            public void InitializeNewNodes()
            {
                if (IsTerminal) return;
                if (DepthLevel <= _depthLvlCtr)
                {
                    if (PossibleNextMoves != null)
                        foreach (Node n in PossibleNextMoves)
                            n.InitializeNewNodes();
                    else
                    {
                        PossibleNextMoves = new();
                        for (int i = 0; i < CurrentState.GetLength(0); i++)
                        {
                            for (int j = 0; j < CurrentState.GetLength(1); j++)
                            {
                                if (i == 0 && j == 0) continue;
                                if (CurrentState[i, j] > 0) break;
                                PossibleNextMoves.Add(new(Copy(CurrentState), i, j, DepthLevel + 1));
                            }
                        }
                    }
                }
            }

            private static int[,] Copy(int[,] orig)
            {
                int m = orig.GetLength(0), n = orig.GetLength(1);
                int[,] copy = new int[m,n];
                for (int i = 0; i < m; i++) for (int j = 0; j < n; j++) copy[i, j] = orig[i, j];
                return copy;
            } 
        }
    }
}