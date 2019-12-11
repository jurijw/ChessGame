using System.Collections.Generic;

namespace Chess
{
    public class Empty : Piece
    {

        // Empty squares will be treated as white pieces but have no ValidMoves function
        public Empty(int x, int y) : base(x, y, true)
        {

        }

        public override List<List<int>> ValidMoves(Board board)
        {
            throw new System.NotImplementedException();
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