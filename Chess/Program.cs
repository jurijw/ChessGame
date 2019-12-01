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
            Console.WriteLine(board.IsWhiteBlackOrEmpty(7, 7));
            Console.WriteLine(board.IsWhiteBlackOrEmpty(3, 4));
            Console.WriteLine(board.IsWhiteBlackOrEmpty(4, 3));

            foreach (var moves in whiteRook1.ValidMoves(board))
            {
                Console.WriteLine($"{moves[0]}, {moves[1]}");
            }
            Console.WriteLine(whiteRook1.ValidMoves(board)[0]);



            // FIX: x and y of pieces needs some adjusting somewhere!!!!



//            var board = new Board();
//            board.DefaultBoardSetup();
//            board.Show();
        }
    }
}
