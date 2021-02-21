using System;
using System.Linq;
using ToyRobotChallenge.Domain;

namespace ToyRobotChallenge
{
    public static class ProgramArgumentParser
    {
        /// <summary>
        /// Finds if the case-insensitive flag has been included in the program command line arguments.
        /// </summary>
        /// <param name="args">Command Line Arguments</param>
        /// <returns></returns>
        public static bool GetAreCommandsCaseSensitive(string[] args) => !args.Select(x => x.ToLower()).Contains(Domain.Domain.UseCaseInvariantArgument);

        /// <summary>
        /// Calculates the desired size of the board based on the provided arguments.
        /// If `--bounds` is not set, returns the default board size.
        /// </summary>
        /// <param name="args">The input command line arguments</param>
        /// <returns></returns>
        public static Board ParseBoardSizeFromArgs(string[] args)
        {
            if (!args.Select(x => x.ToLower()).Contains(Domain.Domain.SetBoardBoundsArgument))
            {
                return new Board();
            }
            else
            {
                var boundsArgIndx = Array.FindIndex(args, 0, x => x.Equals(Domain.Domain.SetBoardBoundsArgument, StringComparison.OrdinalIgnoreCase));
                // Add one to index of `--bounds` so we don't take it.
                var boundsArgs = args.Skip(boundsArgIndx + 1).Take(4).ToArray();

                int xUpper = Domain.Domain.DEFAULT_BOARD_UPPER_BOUND_X;
                int xLower = Domain.Domain.DEFAULT_BOARD_LOWER_BOUND_X;
                int yUpper = Domain.Domain.DEFAULT_BOARD_UPPER_BOUND_Y;
                int yLower = Domain.Domain.DEFAULT_BOARD_LOWER_BOUND_Y;

                switch (boundsArgs.Count())
                {
                    case 2:
                        if (!int.TryParse(boundsArgs[0], out xUpper) || !int.TryParse(boundsArgs[1], out yUpper))
                        {
                            throw new ArgumentException($"Bounds Argument provided was not of type \"int\"");
                        }
                        break;

                    case 4:
                        if (!int.TryParse(boundsArgs[0], out xUpper) || !int.TryParse(boundsArgs[1], out yUpper)
                            || !int.TryParse(boundsArgs[2], out xLower) || !int.TryParse(boundsArgs[3], out yLower)
                        )
                        {
                            throw new ArgumentException($"Bounds Argument provided was not of type \"int\"");
                        }
                        break;

                    default:
                        throw new ArgumentException($"Invalid number of bounds provided.");
                }

                return new Board(xUpper, yUpper, xLower, yLower);
            }
        }
    }
}