﻿using System;
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

            // FIX: throw an exception if any two pieces have the same coordinates
        }

        private Piece PieceFromId(int x, int y, int id)
        {
            
            switch (id)
            {
                case 0: // Empty
                    return new Empty(x, y);
                case 1: // Black pawn
                    return new Prawn(x, y, false);
                case 2: // White pawn
                    return new Prawn(x, y, true);
                case 3: // Black rook
                    return new Rook(x, y, false);
                case 4: // White rook
                    return new Rook(x, y, true);
                case 5: // Black knight
                    return new Knight(x, y, false);
                case 6: // White knight
                    return new Knight(x, y, true);
                case 7: // Black bishop
                    return new Bishop(x, y, false);
                case 8: // White bishop
                    return new Bishop(x, y, true);
                case 9: // Black queen
                    return new Queen(x, y, false);
                case 10: // White queen
                    return new Queen(x, y, true);
                case 11: // Black king
                    return new King(x, y, false);
                case 12: // White king
                    return new King(x, y, true);
                
            }

            // In case an invalid Id is passed as a parameter
            throw new InvalidOperationException("Tried to create a piece object from an invalid Id.");
        }

        // Takes a board configuration and returns a list of pieces
        public List<Piece> ToListOfPieces()
        {
            List<Piece> pieces = new List<Piece>();

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    pieces.Add(PieceFromId(x, y, BoardConfiguration[y, x]));
                }
            }

            return pieces;
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

        // Function that takes in an x and y coordinate and returns whether the piece on that square is black or white or empty
        // Returns 1 for white piece, -1 for a black piece, and 0 for an empty square
        public int IsWhiteBlackOrEmpty(int x, int y)
        {
            // If requested square is off the board throw an exception
            if (x < 0 || x >= 8 || y < 0 || y >= 8)
                throw new InvalidOperationException("Square is off the board.");
            else
            {
                var pieceId = BoardConfiguration[y, x];

                if (pieceId == 0)
                    return 0;
                if (pieceId % 2 == 0)
                    return 1;
                else
                    return -1;
            }
        }

        // Returns true if a square in a board configuration is empty
        public bool IsEmpty(int x, int y)
        {
            // If requested square is off the board throw an exception
            if (x < 0 || x >= 8 || y < 0 || y >= 8)
                throw new InvalidOperationException("Square is off the board.");
            else
                return BoardConfiguration[y, x] == 0;
        }

        // Takes a piece and a square in a board object and returns true if the square is occupied by an opposite colored piece
        public bool OccupiedByDifferentColor(int x, int y, Piece piece)
        {
            // If requested square is off the board throw an exception
            if (x < 0 || x >= 8 || y < 0 || y >= 8)
                throw new InvalidOperationException("Square is off the board.");
            else
            {
                // If pieces are same color
                if ((piece.IsWhite && IsWhiteBlackOrEmpty(x, y) == 1) ||
                    (!piece.IsWhite && IsWhiteBlackOrEmpty(x, y) == -1))
                {
                    return false;
                }

                // If pieces are different color
                if ((piece.IsWhite && IsWhiteBlackOrEmpty(x, y) == -1) ||
                    (!piece.IsWhite && IsWhiteBlackOrEmpty(x, y) == 1))
                {
                    return true;
                }

                // If square is empty throw an exception
                else
                {
                    throw new InvalidOperationException("The square in question is empty. No comparison can be made.");
                }
            }
            
        }
        
    }
}