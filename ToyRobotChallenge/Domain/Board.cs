using System;

namespace ToyRobotChallenge.Domain
{
    public class Board
    {
        public readonly int BoardUpperBoundX = Domain.DEFAULT_BOARD_UPPER_BOUND_X;
        public readonly int BoardUpperBoundY = Domain.DEFAULT_BOARD_UPPER_BOUND_Y;

        public readonly int BoardLowerBoundX = Domain.DEFAULT_BOARD_LOWER_BOUND_X;
        public readonly int BoardLowerBoundY = Domain.DEFAULT_BOARD_LOWER_BOUND_Y;

        /// <summary>
        /// Creates a board with the default bounds set in the Domain Class.
        /// </summary>
        public Board() { }

        /// <summary>
        /// Creates a rectangular board with the given upper bounds, and the default lower bounds set in the Domain Class.
        /// If the given bounds are smaller than the default lower bounds, it assumes you meant to set the lower bound instead. The upper bound will remain as default.
        /// For example, if default board size is (0,0) -> (5,5), and the input bounds are (-4, 4), the board will be of size (-4, 0) -> (5, 4).
        /// </summary>
        /// <param name="boardUpperBoundX">Upper bound for the X dimension of the board</param>
        /// <param name="boardUpperBoundY">Upper bound for the Y dimension of the board</param>
        public Board(int boardUpperBoundX, int boardUpperBoundY)
        {
            if (boardUpperBoundX < BoardLowerBoundX)
            {
                BoardLowerBoundX = boardUpperBoundX;
            }
            else
            {
                BoardUpperBoundX = boardUpperBoundX;
            }

            if (boardUpperBoundX < BoardLowerBoundX)
            {
                BoardLowerBoundY = boardUpperBoundY;
            }
            else
            {
                BoardUpperBoundY = boardUpperBoundY;
            }
        }

        /// <summary>
        /// Creates a rectangular board with the given upper and lower bounds.
        /// </summary>
        /// <param name="boardUpperBoundX">Upper bound for the X dimension of the board</param>
        /// <param name="boardUpperBoundY">Upper bound for the Y dimension of the board</param>
        /// <param name="boardLowerBoundX">Lower bound for the X dimension of the board</param>
        /// <param name="boardLowerBoundY">Lower bound for the Y dimension of the board</param>
        public Board(int boardUpperBoundX, int boardUpperBoundY, int boardLowerBoundX, int boardLowerBoundY)
        {
            BoardUpperBoundX = Math.Max(boardUpperBoundX, boardLowerBoundX);
            BoardUpperBoundY = Math.Max(boardUpperBoundY, boardLowerBoundY);
            BoardLowerBoundX = Math.Min(boardLowerBoundX, boardUpperBoundX);
            BoardLowerBoundY = Math.Min(boardLowerBoundY, boardUpperBoundY);
        }
    }
}