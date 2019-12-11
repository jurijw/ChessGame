using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            board.DefaultBoardSetup();
            var pieces = board.ToListOfPieces();
            board.Show();
            foreach (var piece in pieces)
            {
                Console.WriteLine(piece);
            }

            var board2 = new Board();
            board2.FromListOfPieces(pieces);
            board2.Show();





            //            var whiteRook1 = new Rook(1,4, true);
            //            var blackRook1 = new Rook(3, 4, false);
            //            var whiteBishop = new Bishop(1, 2, true);
            //            var blackQueen = new Queen(4, 4, false);
            //            var whiteKnight = new Knight(3, 3, true);
            //            var whitePawn = new Prawn(3, 6, true);
            //            var blackPawn = new Prawn(0, 1, false);
            //            var pieces = new List<Piece> {whiteRook1, blackRook1, whiteBishop, blackQueen, whiteKnight, whitePawn, blackPawn};
            //            
            //
            //            foreach (var moves in blackPawn.ValidMoves(board))
            //            {
            //                // Prints validMoves in the form Y, X
            //                Console.WriteLine($"{moves[0]}, {moves[1]}");
            //            }
        }
    }
}
