using System;
using System.Collections.Generic;
using System.Text;

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
        /// </summary>
        /// <param name="boardUpperBoundX">Upper bound for the X dimension of the board</param>
        /// <param name="boardUpperBoundY">Upper bound for the Y dimension of the board</param>
        public Board(int boardUpperBoundX, int boardUpperBoundY)
        {
            BoardUpperBoundX = boardUpperBoundX;
            BoardUpperBoundY = boardUpperBoundY;
        }

        /// <summary>
        /// Creates a rectangular board with the given upper and lower bounds.
        /// </summary>
        /// <param name="boardUpperBoundX">Upper bound for the X dimension of the board</param>
        /// <param name="boardUpperBoundY">Upper bound for the Y dimension of the board</param>
        public Board(int boardUpperBoundX, int boardUpperBoundY, int boardLowerBoundX, int boardLowerBoundY)
        {
            BoardUpperBoundX = boardUpperBoundX;
            BoardUpperBoundY = boardUpperBoundY;
            BoardLowerBoundX = boardLowerBoundX;
            BoardLowerBoundY = boardLowerBoundY;
        }
    }
}
