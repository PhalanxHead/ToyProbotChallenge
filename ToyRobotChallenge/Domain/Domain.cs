namespace ToyRobotChallenge.Domain
{
    public static class Domain
    {
        public const int DEFAULT_BOARD_SIZE_X = 5;
        public const int DEFAULT_BOARD_SIZE_Y = 5;

        public enum Direction
        {
            NORTH,
            EAST,
            SOUTH,
            WEST
        }

        /// <summary>
        /// The collection of all valid directions in a meaningfully sorted order.
        /// </summary>
        public static readonly Direction[] OrderedDirections =
            new Direction[]
                {
                    Direction.NORTH,
                    Direction.EAST,
                    Direction.SOUTH,
                    Direction.WEST
                };

        public const string PLACE_COMMAND_PREFIX = "PLACE";
        public const string MOVE_COMMAND_PREFIX = "MOVE";
        public const string LEFT_COMMAND_PREFIX = "LEFT";
        public const string RIGHT_COMMAND_PREFIX = "RIGHT";
        public const string REPORT_COMMAND_PREFIX = "REPORT";
        public const string PRINT_COMMAND_PREFIX = "PRINT";

        /// <summary>
        /// The list of all valid commands that can be issued to the robot.
        /// </summary>
        public static readonly string[] validCommandPrefixes =
            new string[]
            {
                PLACE_COMMAND_PREFIX,
                MOVE_COMMAND_PREFIX,
                LEFT_COMMAND_PREFIX,
                RIGHT_COMMAND_PREFIX,
                REPORT_COMMAND_PREFIX,
                PRINT_COMMAND_PREFIX
            };

        public static readonly string[] validCommand_ArgumentDelimiters = new string[] { " " };

        public const string UseCaseInvariantArgument = "--nocase";
    }
}