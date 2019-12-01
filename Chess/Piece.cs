using System.Collections.Generic;
using System.Net.Sockets;

namespace Chess
{
    public abstract class Piece
    {
        // Properties
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        public bool IsWhite { get; set; }
        public bool IsPieceSelected { get; set; }

        // Base constructor
        public Piece(int x, int y)
        {
            // Set the pieces position (on the board) 
            X = x;
            Y = y;

            // By default pieces are white and unselected.
            IsWhite = true; 
            IsPieceSelected = false;
        }

        public Piece(int x, int y, bool isWhite)
            :this(x, y)
        {
            IsWhite = isWhite;
        }

        // General methods
        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Abstract methods
        public abstract List<List<int>> ValidMoves(Board board);
        public abstract void SelectPiece();
        public abstract void DrawPiece(); 
    }
}