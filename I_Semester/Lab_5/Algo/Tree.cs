using System;

namespace Lab5.Algo
{
    public partial class Tree
    {
        private Node _root;
        private static int _depthLvlCtr;
        
        public Tree(int[,] state, int firstI, int firstJ, int currentMaxDepth)
        {
            _depthLvlCtr = currentMaxDepth;
            _root = new(state, firstI, firstJ, 1);
        }

        public void ChooseNextMove(ref int i, ref int j, int depth)
        {
            int α = int.MinValue, β = int.MaxValue;
            int bestVal = AlphaBeta(_root, depth, α, β);
            foreach (var node in _root.PossibleNextMoves)
            {
                if (node.Value == bestVal)
                {
                    i = node.I;
                    j = node.J;
                    return;
                }
            }

            i = j = 0;
        }

        private int AlphaBeta(Node node, int depth, int α, int β)
        {
            if (depth == 0 || node.IsTerminal)
            {
                ratePosition(node);
            }
            else if (node.DepthLevel%2==1)
            {
                foreach (Node child in node.PossibleNextMoves)
                {
                    int nVal = AlphaBeta(child, depth-1, α, β);
                    if (nVal>node.Value) node.Value = nVal;
                    if (α < node.Value) α = node.Value;
                    if (node.Value >= β) break;
                }
            }
            else
            {
                foreach (Node child in node.PossibleNextMoves)
                {
                    int nVal = AlphaBeta(child, depth-1, α, β);
                    if (node.Value > nVal) node.Value = nVal;
                    if (β > node.Value) β = node.Value;
                    if (node.Value <= α) break;
                }
            }

            return node.Value;
        }

        private void ratePosition(Node node)
        {
            node.Value = Game.PositionIsWinning(node.CurrentState) ? Convert.ToInt32(1000*Math.Pow(-1, node.DepthLevel)) : Convert.ToInt32(node.PossibleNextMoves.Count*Math.Pow(-1, node.DepthLevel));
        }
        public void MoveIsDone(int i, int j)
        {
            foreach (Node n in _root.PossibleNextMoves)
            {
                if (n.I == i && n.J == j)
                {
                    _root = n;
                    if (_root.IsTerminal) Game.posIsTerminal = true;
                    _depthLvlCtr++;
                    _root.InitializeNewNodes();
                    return;
                }
            }
            throw new IndexOutOfRangeException();
}   }   }