using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Chess
{
    public class Rook : Piece
    {
        private List<List<int>> _rookRange = new List<List<int>>();

        //private List<List<int>> _testRookRange = new List<List<int>>();

        public Rook(int y, int x, bool isWhite) : base(y, x, isWhite)
        {
            if (!IsWhite)
                Id = 3;
            else
                Id = 4;

            //_testRookRange.Add(item: new List<int> {1, 3});
            //Console.WriteLine($"{_testRookRange[0][0]}, {_testRookRange[0][1]}");

        }

        // Returns a 2 dimensional list of rook moves (the range of where the rook could move if no other pieces were on the board)
        private List<List<int>> Range()
        {
            // Add all moves within the rooks range (ignoring other pieces) aside from the rooks position itself
            for (int i = 0; i < 8; i++)
            {
                if (i != Y)
                    _rookRange.Add(new List<int>() { Y, i });
                if (i != X)
                    _rookRange.Add(new List<int>() { i, X });
            }

            return _rookRange;
        }

        public override List<List<int>> ValidMoves(Board board)
        {
            // Check all squares to the right of the rook.
            for (int x = X + 1; x < 8; x++)
            {
                // If square is occupied by a piece of the same color the rook cannot move to that square or any behind it
                if ((IsWhite && board.IsWhiteBlackOrEmpty(x, Y) == 1) ||
                    (!IsWhite && board.IsWhiteBlackOrEmpty(x, Y) == -1))
                    break;
                // Is square is occupied by a piece of different color the rook can move to that square but no square behind it
                if ((IsWhite && board.IsWhiteBlackOrEmpty(x, Y) == -1) ||
                    (!IsWhite && board.IsWhiteBlackOrEmpty(x, Y) == 1))
                {
                    _rookRange.Add(new List<int>() {Y, x});
                    break;
                }

                // Square is empty and rook can move to it regardless of color
                else
                    _rookRange.Add(new List<int>() {Y, x});
            }


            // Check all squares to the left of the rook.
            for (int x = X - 1; x >= 0; x--)
            {
                // If square is occupied by a piece of the same color the rook cannot move to that square or any behind it
                if ((IsWhite && board.IsWhiteBlackOrEmpty(x, Y) == 1) || (!IsWhite && board.IsWhiteBlackOrEmpty(x, Y) == -1))
                    break;
                // Is square is occupied by a piece of different color the rook can move to that square but no square behind it
                if ((IsWhite && board.IsWhiteBlackOrEmpty(x, Y) == -1) || (!IsWhite && board.IsWhiteBlackOrEmpty(x, Y) == 1))
                {
                    _rookRange.Add(new List<int>() { Y, x });
                    break;
                }
                // Square is empty and rook can move to it regardless of color
                _rookRange.Add(new List<int>() { Y, x });

            }

            return _rookRange;
        }

        public override void SelectPiece()
        {
            throw new NotImplementedException();
        }

        public override void DrawPiece()
        {
            throw new NotImplementedException();
        }
    }
}