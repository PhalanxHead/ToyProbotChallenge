namespace ToyRobotChallenge.Domain
{
    public static class Domain
    {
        // Default Board Bounds

        public const int DEFAULT_BOARD_UPPER_BOUND_X = 5;
        public const int DEFAULT_BOARD_UPPER_BOUND_Y = 5;
        public const int DEFAULT_BOARD_LOWER_BOUND_X = 0;
        public const int DEFAULT_BOARD_LOWER_BOUND_Y = 0;

        // End Default Board Bounds

        // Command Line Arguments

        public const string UseCaseInvariantArgument = "--nocase";
        public const string SetBoardBoundsArgument = "--bounds";

        // End Command Line Arguments

        /// <summary>
        /// Valid Directions in which a robot may face
        /// </summary>
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
        public static readonly Direction[] PrimaryCardinalDirections_ClockwiseOrder =
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

        /// <summary>
        /// Delimiters that may separate a command from an argument for it
        /// </summary>
        public static readonly string[] validCommand_ArgumentDelimiters = new string[] { " " };

        /// <summary>
        /// Delimiters that may separate two arguments for a command.
        /// </summary>
        public static readonly string[] validArgument_ArgumentDelimiters = new string[] { ",", ", " };

        /// <summary>
        /// The number of arguments for a valid PLACE command.
        /// </summary>
        public const int PLACE_COMMAND_ARGUMENT_COUNT_REQUIREMENT = 3;

        /// <summary>
        /// The string printed when trying to report on an un-placed robot
        /// </summary>
        public const string ROBOT_NOTE_PLACED_RESPONSE = "Robot has not yet been placed.";
    }
}