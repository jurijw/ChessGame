using System;
using System.Collections.Generic;

namespace Chess
{
    public class King : Piece
    {

        private List<List<int>> _kingRange = new List<List<int>>();
        private List<List<int>> _potentialKingMoves = new List<List<int>>();
        private bool _hasMoved;
        private bool _inCheck;
        private bool _canCastleShort;
        private bool _canCastleLong;

        public King(int x, int y, bool isWhite) : base(x, y, isWhite)
        {
            if (!IsWhite)
                Id = 11;
            else
                Id = 12;

            // Add the potential king moves (i.e all squares adjacent)
            _potentialKingMoves.Add(new List<int>() { 0, 1 });
            _potentialKingMoves.Add(new List<int>() { 1, 1 });
            _potentialKingMoves.Add(new List<int>() { 1, 0 });
            _potentialKingMoves.Add(new List<int>() { 1, -1 });
            _potentialKingMoves.Add(new List<int>() { 0, -1 });
            _potentialKingMoves.Add(new List<int>() { -1, -1 });
            _potentialKingMoves.Add(new List<int>() { -1, 0 });
            _potentialKingMoves.Add(new List<int>() { -1, 1 });
        }

        // Returns a 2 dimensional list of the legal moves the king can move given the current board configuration
        public override List<List<int>> ValidMoves(Board board)
        {
            foreach (var move in _potentialKingMoves)
            {
                var newX = X + move[0];
                var newY = Y + move[1];

                try
                {
                    // If square is empty 
                    if (board.IsEmpty(newX, newY))
                        _kingRange.Add(new List<int>() { newY, newX });
                    // If square is occupied by opposite colored piece
                    else if (board.OccupiedByDifferentColor(newX, newY, this))
                        _kingRange.Add(new List<int>() { newY, newX });
                    // If square is occupied by same colored piece, knight cannot move there
                }
                catch (InvalidOperationException e)
                {
                    // If square is off board 
                    if (e.Message == "Square is off the board.")
                        continue;
                }
            }

            return _kingRange;
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
