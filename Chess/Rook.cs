using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Chess
{
    public class Rook : Piece
    {
        private List<List<int>> _rookRange = new List<List<int>>();

        public Rook(int x, int y, bool isWhite) : base(x, y, isWhite)
        {
            if (!IsWhite)
                Id = 3;
            else
                Id = 4;
        }

        // Returns a 2 dimensional list of the legal moves the rook can move given the current board configuration
        public override List<List<int>> ValidMoves(Board board)
        {

            // Fix: Lots of repeated code --> can be simplified!!!

            // Check all squares to the right of the rook.
            for (int x = X + 1; x < 8; x++)
            {
                // Square is empty and rook can move to it regardless of color
                if (board.IsEmpty(x, Y))
                    _rookRange.Add(new List<int>() { Y, x });
                // Is square is occupied by a piece of different color the rook can move to that square but no square behind it
                else if (board.OccupiedByDifferentColor(x, Y, this))
                {
                    _rookRange.Add(new List<int>() { Y, x });
                    break;
                }
                // If square is occupied by a piece of the same color the rook cannot move to that square or any behind it
                else
                    break;
            }


            // Check all squares to the left of the rook
            for (int x = X - 1; x >= 0; x--)
            {
                // Square is empty and rook can move to it regardless of color
                if (board.IsEmpty(x, Y))
                    _rookRange.Add(new List<int>() { Y, x });
                // Is square is occupied by a piece of different color the rook can move to that square but no square behind it
                else if (board.OccupiedByDifferentColor(x, Y, this))
                {
                    _rookRange.Add(new List<int>() { Y, x });
                    break;
                }
                // If square is occupied by a piece of the same color the rook cannot move to that square or any behind it
                else
                    break;
            }

            // Check all squares under rook
            for (int y = Y + 1; y < 8; y++)
            {
                // Square is empty and rook can move to it regardless of color
                if (board.IsEmpty(X, y))
                    _rookRange.Add(new List<int>() { y, X });
                // Is square is occupied by a piece of different color the rook can move to that square but no square behind it
                else if (board.OccupiedByDifferentColor(X, y, this))
                {
                    _rookRange.Add(new List<int>() { y, X });
                    break;
                }
                // If square is occupied by a piece of the same color the rook cannot move to that square or any behind it
                else
                    break;
            }

            // Check all squares above rook
            for (int y = Y - 1; y >= 0; y--)
            {
                // Square is empty and rook can move to it regardless of color
                if (board.IsEmpty(X, y))
                    _rookRange.Add(new List<int>() { y, X });
                // Is square is occupied by a piece of different color the rook can move to that square but no square behind it
                else if (board.OccupiedByDifferentColor(X, y, this))
                {
                    _rookRange.Add(new List<int>() { y, X });
                    break;
                }
                // If square is occupied by a piece of the same color the rook cannot move to that square or any behind it
                else
                    break;
            }

            /*
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

            // Check all squares above the rook.
            for (int y = Y - 1; y >= 0; y--)
            {
                // If square is occupied by a piece of the same color the rook cannot move to that square or any behind it
                if ((IsWhite && board.IsWhiteBlackOrEmpty(X, y) == 1) || (!IsWhite && board.IsWhiteBlackOrEmpty(X, y) == -1))
                    break;
                // Is square is occupied by a piece of different color the rook can move to that square but no square behind it
                if ((IsWhite && board.IsWhiteBlackOrEmpty(X, y) == -1) || (!IsWhite && board.IsWhiteBlackOrEmpty(X, y) == 1))
                {
                    _rookRange.Add(new List<int>() { y, X });
                    break;
                }
                // Square is empty and rook can move to it regardless of color
                _rookRange.Add(new List<int>() { y, X });
            }

            // Check all squares below the rook.
            for (int y = Y + 1; y < 8; y++)
            {
                // If square is occupied by a piece of the same color the rook cannot move to that square or any behind it
                if ((IsWhite && board.IsWhiteBlackOrEmpty(X, y) == 1) ||
                    (!IsWhite && board.IsWhiteBlackOrEmpty(X, y) == -1))
                    break;
                // Is square is occupied by a piece of different color the rook can move to that square but no square behind it
                if ((IsWhite && board.IsWhiteBlackOrEmpty(X, y) == -1) ||
                    (!IsWhite && board.IsWhiteBlackOrEmpty(X, y) == 1))
                {
                    _rookRange.Add(new List<int>() {y, X});
                    break;
                }

                // Square is empty and rook can move to it regardless of color
                _rookRange.Add(new List<int>() {y, X});

            }
            */
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