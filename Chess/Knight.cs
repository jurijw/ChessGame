using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Chess
{
    public class Knight : Piece
    {
        private List<List<int>> _knightRange = new List<List<int>>();
        private List<List<int>> _potentialKnightMoves = new List<List<int>>();

        public Knight(int x, int y, bool isWhite) : base(x, y, isWhite)
        {
            if (!IsWhite)
                Id = 5;
            else
                Id = 6;

            // Add the potential knight moves starting with 1 square to the right and two squares up and then going clockwise.
            _potentialKnightMoves.Add(new List<int>() { 1, 2 });
            _potentialKnightMoves.Add(new List<int>() { 2, 1 });
            _potentialKnightMoves.Add(new List<int>() { 2, -1 });
            _potentialKnightMoves.Add(new List<int>() { 1, -2 });
            _potentialKnightMoves.Add(new List<int>() { -1, -2 });
            _potentialKnightMoves.Add(new List<int>() { -2, -1 });
            _potentialKnightMoves.Add(new List<int>() { -2, 1 });
            _potentialKnightMoves.Add(new List<int>() { -1, 2 });
        }

        // Returns a 2 dimensional list of the legal moves the bishop can move given the current board configuration
        public override List<List<int>> ValidMoves(Board board)
        {
            foreach (var move in _potentialKnightMoves)
            {
                var newX = X + move[0];
                var newY = Y + move[1];

                try
                {
                    // If square is empty 
                    if (board.IsEmpty(newX, newY))
                        _knightRange.Add(new List<int>() { newY, newX });
                    // If square is occupied by opposite colored piece
                    else if (board.OccupiedByDifferentColor(newX, newY, this))
                        _knightRange.Add(new List<int>() { newY, newX });
                    // If square is occupied by same colored piece, knight cannot move there
                }
                catch (InvalidOperationException e)
                {
                    // If square is off board 
                    if (e.Message == "Square is off the board.")
                        continue;
                }
            }

            return _knightRange;
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