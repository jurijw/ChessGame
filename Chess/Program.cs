using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            var whiteRook1 = new Rook(1,0, true);
            var blackRook1 = new Rook(3, 4, false);
            var pieces = new List<Piece> {whiteRook1, blackRook1};
            var board = new Board();
            board.FromListOfPieces(pieces);
            board.Show();

            foreach (var moves in blackRook1.ValidMoves(board))
            {
                Console.WriteLine($"{moves[0]}, {moves[1]}");
            }
        }
    }
}
