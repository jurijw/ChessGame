using System;
using System.Collections.Generic;

namespace Chess
{
    public class Queen : Piece
    {
        private List<List<int>> _queenRange = new List<List<int>>();

        public Queen(int x, int y, bool isWhite) : base(x, y, isWhite)
        {
            if (!IsWhite)
                Id = 9;
            else
                Id = 10;
        }

        // Returns a 2 dimensional list of the legal moves the queen can move given the current board configuration
        public override List<List<int>> ValidMoves(Board board)
        {

            // FIX: Lots of repeated code --> Can be simplified!!!

            // The queen's valid moves are a combination of a rook and bishops valid moves if they were placed on the same square

            // Check all squares diagonally down and right from the queen.
            for (int i = 1; i < 8; i++)
            {
                // Square is empty and queen can move to it regardless of color
                try
                {
                    // If square is empty append it to the list of valid moves
                    if (board.IsEmpty(X + i, Y + i))
                        _queenRange.Add(new List<int>() { Y + i, X + i });
                    // Queen can move to a square of an opposite colored piece but not any farther
                    if (board.OccupiedByDifferentColor(X + i, Y + i, this))
                    {
                        _queenRange.Add(new List<int>() { Y + i, X + i });
                        break;
                    }
                    // Queen cannot move past pieces of the same color
                    else
                        break;
                }

                // Break out of loop if queen would go off board
                // This clause triggers when board.IsEmpty is called on a square that doesn't exist (i.e out of board range / e.g x:8 y:8)
                catch (InvalidOperationException e)
                {
                    if (e.Message == "Square is off the board.")
                        break;
                    //if (e.Message != "The square in question is empty. No comparisons can be made.")
                    //   continue;
                }


            }


            // Check all squares diagonally up and left from the queen.
            for (int i = -1; i > -8; i--)
            {
                // Square is empty and queen can move to it regardless of color
                try
                {
                    // If square is empty append it to the list of valid moves
                    if (board.IsEmpty(X + i, Y + i))
                        _queenRange.Add(new List<int>() { Y + i, X + i });
                    // Bishop can move to a square of an opposite colored piece but not any farther
                    if (board.OccupiedByDifferentColor(X + i, Y + i, this))
                    {
                        _queenRange.Add(new List<int>() { Y + i, X + i });
                        break;
                    }
                    // Bishop cannot move past pieces of the same color
                    else
                        break;
                }

                // Break out of loop if queen would go off board
                // This clause triggers when board.IsEmpty is called on a square that doesn't exist (i.e out of board range / e.g x:8 y:8)
                catch (InvalidOperationException e)
                {
                    if (e.Message == "Square is off the board.")
                        break;
                    //if (e.Message != "The square in question is empty. No comparisons can be made.")
                    //   continue;
                }


            }

            // Check all squares diagonally up and right from the queen.
            for (int i = 1; i < 8; i++)
            {
                // Square is empty and queen can move to it regardless of color
                try
                {
                    // If square is empty append it to the list of valid moves
                    if (board.IsEmpty(X + i, Y - i))
                        _queenRange.Add(new List<int>() { Y - i, X + i });
                    // Bishop can move to a square of an opposite colored piece but not any farther
                    if (board.OccupiedByDifferentColor(X + i, Y - i, this))
                    {
                        _queenRange.Add(new List<int>() { Y - i, X + i });
                        break;
                    }
                    // Bishop cannot move past pieces of the same color
                    else
                        break;
                }

                // Break out of loop if queen would go off board
                // This clause triggers when board.IsEmpty is called on a square that doesn't exist (i.e out of board range / e.g x:8 y:8)
                catch (InvalidOperationException e)
                {
                    if (e.Message == "Square is off the board.")
                        break;
                    //if (e.Message != "The square in question is empty. No comparisons can be made.")
                    //   continue;
                }


            }

            // Check all squares diagonally down and left from the queen.
            for (int i = 1; i < 8; i++)
            {
                // Square is empty and queen can move to it regardless of color
                try
                {
                    // If square is empty append it to the list of valid moves
                    if (board.IsEmpty(X - i, Y + i))
                        _queenRange.Add(new List<int>() { Y + i, X - i });
                    // Queen can move to a square of an opposite colored piece but not any farther
                    if (board.OccupiedByDifferentColor(X - i, Y + i, this))
                    {
                        _queenRange.Add(new List<int>() { Y + i, X - i });
                        break;
                    }
                    // Queen cannot move past pieces of the same color
                    else
                        break;
                }

                // Break out of loop if queen would go off board
                // This clause triggers when board.IsEmpty is called on a square that doesn't exist (i.e out of board range / e.g x:8 y:8)
                catch (InvalidOperationException e)
                {
                    if (e.Message == "Square is off the board.")
                        break;
                    //if (e.Message != "The square in question is empty. No comparisons can be made.")
                    //   continue;
                }


            }


            // Add side to side and up and down moves for the queen (taken from rook logic) 

            // Check all squares to the right of the rook.
            for (int x = X + 1; x < 8; x++)
            {
                // Square is empty and rook can move to it regardless of color
                if (board.IsEmpty(x, Y))
                    _queenRange.Add(new List<int>() { Y, x });
                // Is square is occupied by a piece of different color the rook can move to that square but no square behind it
                else if (board.OccupiedByDifferentColor(x, Y, this))
                {
                    _queenRange.Add(new List<int>() { Y, x });
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
                    _queenRange.Add(new List<int>() { Y, x });
                // Is square is occupied by a piece of different color the rook can move to that square but no square behind it
                else if (board.OccupiedByDifferentColor(x, Y, this))
                {
                    _queenRange.Add(new List<int>() { Y, x });
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
                    _queenRange.Add(new List<int>() { y, X });
                // Is square is occupied by a piece of different color the rook can move to that square but no square behind it
                else if (board.OccupiedByDifferentColor(X, y, this))
                {
                    _queenRange.Add(new List<int>() { y, X });
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
                    _queenRange.Add(new List<int>() { y, X });
                // Is square is occupied by a piece of different color the rook can move to that square but no square behind it
                else if (board.OccupiedByDifferentColor(X, y, this))
                {
                    _queenRange.Add(new List<int>() { y, X });
                    break;
                }
                // If square is occupied by a piece of the same color the rook cannot move to that square or any behind it
                else
                    break;
            }

            return _queenRange;

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