using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lab5.GUI;

namespace Lab5.Algo
{
    public class Game
    {
        public static bool SinglePlay;
        public static bool posIsTerminal;
        public static int FieldSize;
        public static int Difficulty;
        public int MoveCtr, Colored;
        private readonly Random _rand;
        private Tree _tree;
        private readonly Form2 _form;

        public Game(Form2 form)
        {
            _form = form;
            MoveCtr = 0;
            Colored = 0;
            _rand = new();
            posIsTerminal = false;
        }

        public void MoveDone(int i, int j)
        {
            MoveCtr++;
            if (Difficulty == 1||posIsTerminal) return;
            if (_tree == null)
            {
                int[,] pos = GetCurrentPosition(_form.Field);
                _tree = new(pos, i, j, Difficulty*2);
            }
            else
            {
                _tree.MoveIsDone(i, j);
            }
        }
        
        public void MakeMove()
        {
            if (posIsTerminal || Difficulty==1) MoveE();
            else MoveH();
        }
        private void MoveE()
        {
            int[,] currentPos = GetCurrentPosition(_form.Field);
            List<KeyValuePair<int, int>> possibleMoves = new();
            List<KeyValuePair<int, int>> losingMoves = new();
            for (int i = 0; i < FieldSize - 1; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    if (i == 0 && j == 0) continue;
                    if (currentPos[i, j]>0) break;
                    if (PositionIsWinning(GetNewPosition(currentPos, i, j)))
                    {
                        System.Threading.Thread.Sleep(700);
                        _form.MakeChoice(_form.Field[i,j], EventArgs.Empty);
                        return;
                    }
                    if (!PositionIsLosing(GetNewPosition(currentPos, i, j))) possibleMoves.Add(new(i, j));
                    else losingMoves.Add(new(i, j));
                }
            }
            List<KeyValuePair<int, int>> chooseFrom = possibleMoves.Count > 0 ? possibleMoves : losingMoves;
            int choice = _rand.Next(chooseFrom.Count);
            System.Threading.Thread.Sleep(700);
            _form.MakeChoice(_form.Field[chooseFrom[choice].Key, chooseFrom[choice].Value], EventArgs.Empty);
        }

        private void MoveH()
        {
            int i = 0, j = 0;
            _tree.ChooseNextMove(ref i, ref j, Difficulty*2-1);
            _form.MakeChoice(_form.Field[i, j], EventArgs.Empty);
            /*int[,] currentPos = GetCurrentPosition(form.Field);
            List<KeyValuePair<KeyValuePair<int, int>, double>> possibleMoves = new();
            for (int i = 0; i < FieldSize - 1; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    if (i == 0 && j == 0) continue;
                    if (currentPos[i, j]>0) break;
                    double Rating = RateMove(currentPos, i, j, 3);
                    possibleMoves.Add(new(new(i, j), Rating));
                }
            }

            possibleMoves.Sort((p1, p2) => p2.Value.CompareTo(p1.Value));
            System.Threading.Thread.Sleep(700);
            form.MakeChoice(form.Field[possibleMoves[0].Key.Key, possibleMoves[0].Key.Value], EventArgs.Empty);*/

        }

        private int[,] GetCurrentPosition(Button[,] field)
        {
            int[,] currentPos = new int[FieldSize - 1, FieldSize];

            for (int i = 0; i < FieldSize - 1; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    currentPos[i, j] = field[i, j].BackColor==Style.EmptyCellColor?0:1;
                }
            }

            return currentPos;
        }

        /*private double RateMove(int[,] field, int moveI, int moveJ, int Depth = 1)
        {
            int[,] nPos = GetNewPosition(field, moveI, moveJ);
            if (PositionIsWinning(nPos)) return 1;
            if (PositionIsLosing(nPos)) return -1;
            double rating = 0;

            if (Depth > 1)
            {
                List<KeyValuePair<KeyValuePair<int, int>, double>> possibleMoves = new();
                for (int i = 0; i < FieldSize - 1; i++)
                {
                    for (int j = 0; j < FieldSize; j++)
                    {
                        if (i == 0 && j == 0) continue;
                        if (nPos[i, j] > 0) break;
                        rating -= RateMove(nPos, i, j, Depth-1)/2;
                        possibleMoves.Add(new(new(i, j), rating));
                    }
                }
            }

            return rating;
        }*/
        
        private static int CountUncoloredInRow(int[,] field, int rowNum)
        {
            int ctr = 0;
            for (int j = 0; j < FieldSize; j++)
            {
                if (j==0 && rowNum==0) continue;
                if (field[rowNum, j] == 0) ctr++;
                else return ctr;
            }

            return ctr;
        }
        
        private static int CountUncoloredInColumn(int[,] field, int columnNum)
        {
            int ctr = 0;
            for (int i = 0; i < FieldSize-1; i++)
            {
                if (i==0 && columnNum==0) continue;
                if (field[i, columnNum] == 0) ctr++;
                else return ctr;
            }

            return ctr;
        }
        
        public static bool PositionIsWinning(int[,] field)
        {
            return ((field[1, 1] == 1 && CountUncoloredInColumn(field, 0) == CountUncoloredInRow(field, 0))||
                    (field[0, 2] == 1 && CountUncoloredInColumn(field, 0) == CountUncoloredInColumn(field, 1))||
                    (field[2, 0] == 1 && CountUncoloredInRow(field, 0) == CountUncoloredInRow(field, 1))||
                    (field[0, 3] == 1 && CountUncoloredInColumn(field, 0) == 3 && CountUncoloredInColumn(field, 1)==2&&CountUncoloredInColumn(field, 2)==2)||
                    (field[3, 0] == 1 && CountUncoloredInRow(field, 0) == 3 && CountUncoloredInRow(field, 1)==2&&CountUncoloredInRow(field, 2)==2));
        }

        public static int[,] GetNewPosition(int[,] field, int moveI, int moveJ)
        {
            int[,] newPos = new int[FieldSize - 1, FieldSize];

            for (int i = 0; i < FieldSize - 1; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    newPos[i, j] = field[i, j];
                }
            }
            for (int i = moveI; i < FieldSize - 1; i++)
            {
                for (int j = moveJ; j < FieldSize; j++)
                {
                    newPos[i, j] = 1;
                }
            }

            return newPos;
        }

        private bool PositionIsLosing(int[,] field)
        {
            for (int i = 0; i < FieldSize - 1; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    if (i == 0 && j == 0) continue;
                    if (field[i, j]>0) break;
                    if (PositionIsWinning(GetNewPosition(field, i, j))) return true;
                }
            }

            return false;
        }
    }
}