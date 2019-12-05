using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Chess
{
    // Don't worry, I know how to spell pawn ;) --> https://www.youtube.com/watch?v=M3kzZclpO_I
    public class Prawn : Piece
    {
        private List<List<int>> _prawnRange = new List<List<int>>();
        private bool _movedTwoSquaresLastMove = false;
        private bool _hasMoved;

        public Prawn(int x, int y, bool isWhite) : base(x, y, isWhite)
        {
            if (!IsWhite)
            {
                Id = 1;
                // If black and on 7th rank pawn has not moved yet
                if (y == 1)
                    _hasMoved = false;
                else
                    _hasMoved = true;
            }

            else
            {
                Id = 2;
                // If white and on 2nd rank pawn has not moved yet
                if (y == 6)
                    _hasMoved = false;
                else
                    _hasMoved = true;
            }

            // throw an exception if pawn is instantiated on an illegal square
            if ((isWhite && y == 7) || (!isWhite && y == 0))
                throw new InvalidOperationException("Attempted to instantiate a pawn on an illegal square.");
        }

        private bool IsOnBackRank()
        {
            if ((IsWhite && Y == 0) || (!IsWhite && Y == 7))
                return true;
            else
                return false;
        }
        public override List<List<int>> ValidMoves(Board board)
        {
            // Set direction multiplier to 1 or -1 depending on whether the pawn is white or black
            var directionMultiplier = new int();
            if (IsWhite)
                directionMultiplier = -1;
            else
                directionMultiplier = 1;

            // If pawn has moved it can move forward one square granted there is no piece in the way
            if (_hasMoved)
            {
                // If no piece is in front of the pawn the pawn can move to that square
                if (board.IsEmpty(X, Y + 1 * directionMultiplier))
                    _prawnRange.Add(new List<int>() { Y + 1 * directionMultiplier, X });
            }

            // If pawn has not moved then it can move one or two squares granted there is no piece in the way
            if (!_hasMoved)
            {
                if (board.IsEmpty(X, Y + 1 * directionMultiplier))
                {
                    _prawnRange.Add(new List<int>() {Y + 1 * directionMultiplier, X});
                    
                    if (board.IsEmpty(X, Y + 2 * directionMultiplier))
                        _prawnRange.Add(new List<int>() { Y + 2 * directionMultiplier, X });
                }

            }

            // If there is a piece diagonally in front of the pawn which is not the same color the pawn can capture it
            try
            {
                // If square is occupied
                if (!board.IsEmpty(X - 1, Y + 1 * directionMultiplier))
                {
                    // If square is occupied by a different colored piece
                    if (board.OccupiedByDifferentColor(X - 1, Y + 1 * directionMultiplier, this))
                        _prawnRange.Add(new List<int>() { Y + 1 * directionMultiplier, X - 1 });
                }
            }
            catch (InvalidOperationException e)
            {
                // If square is off the board don't add it
            }

            try
            {
                // If square is occupied
                if (!board.IsEmpty(X + 1, Y + 1 * directionMultiplier))
                {
                    // If square is occupied by a different colored piece
                    if (board.OccupiedByDifferentColor(X + 1, Y + 1 * directionMultiplier, this))
                        _prawnRange.Add(new List<int>() { Y + 1 * directionMultiplier, X + 1 });
                }
            }
            catch (InvalidOperationException e)
            {
                // If square is off the board don't add it
            }
            
            /*
            // FIX: Add En Passant rule (temporarily switch id of a pawn that moved two squares?)
            // If there is an opposite colored pawn directly to the side of the piece that just moved two squares the pawn can
            // capture diagonally according to En Passant rule. For white pawns this can only happen on the 5th rank and for
            // black pawns only on the 4th rank
            if (IsWhite && Y == 3)
            {
                try
                {
                    if (!board.IsEmpty(X + 1, Y))
                    {
                        if (board.OccupiedByDifferentColor(X + 1, Y, this))
                        {
                            // If that piece is a pawn
                            if (board)
                        }
                    }
                }
                catch (InvalidOperationException e)
                {
                    // If square is off the board don't add it
                }
            }
            */

            return _prawnRange;
        }

        public override void SelectPiece()
        {
            throw new System.NotImplementedException();
        }

        public override void DrawPiece()
        {
            throw new System.NotImplementedException();
        }
    }
}