using System;
using System.Collections.Generic;

namespace Chess
{
    // Store a snapshot of the board in a board object.
    public class Board
    {
        //
        // Properties
        //

        public int[,] BoardConfiguration { get; set; }
        public bool WhiteCanCastleShort { get; set; }
        public bool WhiteCanCastleLong { get; set; }
        public bool BlackCanCastleShort { get; set; }
        public bool BlackCanCastleLong { get; set; }



        //
        // Constructors
        //

        public Board()
        {
            // Board convention [y, x]
            BoardConfiguration = new int[8,8];
        }



        //
        // Methods
        //

        public void DefaultBoardSetup()
        {
            // Setup pieces 
            // Pieces are identified by Empty: 0, BPawn: 1, WPawn: 2, BRook:3, WRook: 5, BKnight: 6, etc.
            for (int x = 0; x < 8; x++)
            {
                // Setup empty squares
                BoardConfiguration[2, x] = 0;
                BoardConfiguration[3, x] = 0;
                BoardConfiguration[4, x] = 0;
                BoardConfiguration[5, x] = 0;

                // Setup pawns
                BoardConfiguration[1, x] = 1;
                BoardConfiguration[6, x] = 2;

                // Setup rooks
                if (x == 0 || x == 7)
                {
                    BoardConfiguration[0, x] = 3;
                    BoardConfiguration[7, x] = 4;
                }

                // Setup knights
                if (x == 1 || x == 6)
                {
                    BoardConfiguration[0, x] = 5;
                    BoardConfiguration[7, x] = 6;
                }

                // Setup bishops
                if (x == 2 || x == 5)
                {
                    BoardConfiguration[0, x] = 7;
                    BoardConfiguration[7, x] = 8;
                }

                // Setup queens
                if (x == 3)
                {
                    BoardConfiguration[0, x] = 9;
                    BoardConfiguration[7, x] = 10;
                }

                // Setup kings
                if (x == 4)
                {
                    BoardConfiguration[0, x] = 11;
                    BoardConfiguration[7, x] = 12;
                }
            }
        }

        public void FromListOfPieces(List<Piece> pieces)
        {
            // Populate board as empty
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    BoardConfiguration[y, x] = 0;
                }
            }

            // Add the pieces from the list of pieces parsed to it.
            foreach (var piece in pieces)
            {
                BoardConfiguration[piece.Y, piece.X] = piece.Id;
            }
        }

        public void Show()
        {
            for (int y = 0; y < BoardConfiguration.GetLength(0); y++)
            {
                for (int x = 0; x < BoardConfiguration.GetLength(1); x++)
                {
                    Console.Write(string.Format($"  {BoardConfiguration[y, x]}  "));
                }
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
            }
        }
    }
}