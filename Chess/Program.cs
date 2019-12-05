using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            var whiteRook1 = new Rook(1,4, true);
            var blackRook1 = new Rook(3, 4, false);
            var whiteBishop = new Bishop(1, 2, true);
            var blackQueen = new Queen(4, 4, false);
            var whiteKnight = new Knight(3, 3, true);
            var pieces = new List<Piece> {whiteRook1, blackRook1, whiteBishop, blackQueen, whiteKnight};
            var board = new Board();
//            board.DefaultBoardSetup();
            board.FromListOfPieces(pieces);
            board.Show();

            foreach (var moves in whiteKnight.ValidMoves(board))
            {
                // Prints validMoves in the form Y, X
                Console.WriteLine($"{moves[0]}, {moves[1]}");
            }
        }
    }
}
