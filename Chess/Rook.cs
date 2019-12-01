using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Chess
{
    public class Rook : Piece
    {
        private List<List<int>> RookRange { get; set; }

        public Rook(int y, int x, bool isWhite) : base(y, x, isWhite)
        {
            if (!IsWhite)
                Id = 3;
            else
                Id = 4;
        }

        // Returns a 2 dimensional list of rook moves (the range of where the rook could move if no other pieces were on the board)
        private List<List<int>> Range()
        {
            // Add all moves within the rooks range (ignoring other pieces) aside from the rooks position itself
            for (int i = 0; i < 8; i++)
            {
                if (i != Y)
                    RookRange.Add(new List<int>() {Y, i});
                if (i != X)
                    RookRange.Add(new List<int>() { i, X });
            }

            return RookRange;
        }

        public override void ValidMoves(Board board)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i != Y)
                    RookRange.Add(new List<int>() { Y, i });
                if (i != X)
                    RookRange.Add(new List<int>() { i, X });
            }

            throw new NotImplementedException();
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