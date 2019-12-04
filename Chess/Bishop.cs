using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Chess
{
    public class Bishop : Piece
    {
        private List<List<int>> _bishopRange = new List<List<int>>();

        public Bishop(int x, int y, bool isWhite) : base(x, y, isWhite)
        {
            if (!IsWhite)
                Id = 7;
            else
                Id = 8;
        }

        // Returns a 2 dimensional list of the legal moves the bishop can move given the current board configuration
        public override List<List<int>> ValidMoves(Board board)
        {

            // FIX: Lots of repeated code --> Can be simplified!!!

            // Check all squares diagonally down and right from the bishop.
            for (int i = 1; i < 8; i++)
            {
                // Square is empty and bishop can move to it regardless of color
                try
                {
                    // If square is empty append it to the list of valid moves
                    if (board.IsEmpty(X + i, Y + i))
                        _bishopRange.Add(new List<int>() { Y + i, X + i });
                    // Bishop can move to a square of an opposite colored piece but not any farther
                    if (board.OccupiedByDifferentColor(X + i, Y + i, this))
                    {
                        _bishopRange.Add(new List<int>() {Y + i, X + i});
                        break;
                    }
                    // Bishop cannot move past pieces of the same color
                    else
                        break;
                }

                // Break out of loop if bishop would go off board
                // This clause triggers when board.IsEmpty is called on a square that doesn't exist (i.e out of board range / e.g x:8 y:8)
                catch (InvalidOperationException e)
                {
                    if (e.Message == "Square is off the board.")
                        break;
                    //if (e.Message != "The square in question is empty. No comparisons can be made.")
                    //   continue;
                }

                
            }

            
            // Check all squares diagonally up and left from the bishop.
            for (int i = -1; i > -8; i--)
            {
                // Square is empty and bishop can move to it regardless of color
                try
                {
                    // If square is empty append it to the list of valid moves
                    if (board.IsEmpty(X + i, Y + i))
                        _bishopRange.Add(new List<int>() { Y + i, X + i });
                    // Bishop can move to a square of an opposite colored piece but not any farther
                    if (board.OccupiedByDifferentColor(X + i, Y + i, this))
                    {
                        _bishopRange.Add(new List<int>() {Y + i, X + i});
                        break;
                    }
                    // Bishop cannot move past pieces of the same color
                    else
                        break;
                }

                // Break out of loop if bishop would go off board
                // This clause triggers when board.IsEmpty is called on a square that doesn't exist (i.e out of board range / e.g x:8 y:8)
                catch (InvalidOperationException e)
                {
                    if (e.Message == "Square is off the board.")
                        break;
                    //if (e.Message != "The square in question is empty. No comparisons can be made.")
                    //   continue;
                }

                
            }

            // Check all squares diagonally up and right from the bishop.
            for (int i = 1; i < 8; i++)
            {
                // Square is empty and bishop can move to it regardless of color
                try
                {
                    // If square is empty append it to the list of valid moves
                    if (board.IsEmpty(X + i, Y - i))
                        _bishopRange.Add(new List<int>() { Y - i, X + i });
                    // Bishop can move to a square of an opposite colored piece but not any farther
                    if (board.OccupiedByDifferentColor(X + i, Y - i, this))
                    {
                        _bishopRange.Add(new List<int>() { Y - i, X + i });
                        break;
                    }
                    // Bishop cannot move past pieces of the same color
                    else
                        break;
                }

                // Break out of loop if bishop would go off board
                // This clause triggers when board.IsEmpty is called on a square that doesn't exist (i.e out of board range / e.g x:8 y:8)
                catch (InvalidOperationException e)
                {
                    if (e.Message == "Square is off the board.")
                        break;
                    //if (e.Message != "The square in question is empty. No comparisons can be made.")
                    //   continue;
                }


            }

            // Check all squares diagonally down and left from the bishop.
            for (int i = 1; i < 8; i++)
            {
                // Square is empty and bishop can move to it regardless of color
                try
                {
                    // If square is empty append it to the list of valid moves
                    if (board.IsEmpty(X - i, Y + i))
                        _bishopRange.Add(new List<int>() { Y + i, X - i });
                    // Bishop can move to a square of an opposite colored piece but not any farther
                    if (board.OccupiedByDifferentColor(X - i, Y + i, this))
                    {
                        _bishopRange.Add(new List<int>() { Y + i, X - i });
                        break;
                    }
                    // Bishop cannot move past pieces of the same color
                    else
                        break;
                }

                // Break out of loop if bishop would go off board
                // This clause triggers when board.IsEmpty is called on a square that doesn't exist (i.e out of board range / e.g x:8 y:8)
                catch (InvalidOperationException e)
                {
                    if (e.Message == "Square is off the board.")
                        break;
                    //if (e.Message != "The square in question is empty. No comparisons can be made.")
                    //   continue;
                }


            }

            return _bishopRange;

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
 