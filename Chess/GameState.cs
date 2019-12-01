using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class GameState
    {
        // Properties that describe the state of the game.
        public int HasWon { get; set; }
        public bool WhiteToMove { get; set; }
        public bool Stalemate { get; set; }
        public bool ThreeFoldRepetition { get; set; }
        public bool FiftyMoveRuleApplies { get; set; }
        public List<Board> BoardHistory { get; set; }

        // REVIEW: Maybe add WhiteCanCastleShort, WhiteCanCastleLong, etc.
        
        

        // Base constructor.
        public GameState()
        {
            //HasWon will be 0 for an ongoing game, 1 for white's win, 2 for black's win, and 3 for a draw.
            HasWon = 0;
            WhiteToMove = true;

            Stalemate = false;
            ThreeFoldRepetition = false;
            FiftyMoveRuleApplies = false;
        }

        // Updates the game state after every move
        public void Update(Board board)
        {
            BoardHistory.Append(board);
        }
    }
}