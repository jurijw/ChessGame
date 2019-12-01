using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            var whiteRook1 = new Rook(7,7, true);
            var whiteRook2 = new Rook(3, 4, true);
            var pieces = new List<Piece> {whiteRook1, whiteRook2};
            var board = new Board();
            board.FromListOfPieces(pieces);
            board.Show();
        }
    }
}
