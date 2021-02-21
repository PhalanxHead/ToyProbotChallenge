using System;
using ToyRobotChallenge.Domain;
using ToyRobotChallenge.Interfaces;

namespace ToyRobotChallenge
{
    internal class Program
    {
        private const string UseageText = "Useage: ToyRobotChallenge.exe [--nocase] [--bounds xUpper yUpper [xLower yLower]]";

        private static void Main(string[] args)
        {
            StartRobot(args);
        }

        /// <summary>
        /// Parses Command Line Arguments to set up the robot, and reads commands in from STDIN until the applciation quits.
        /// </summary>
        /// <param name="args">Command Line Arguments</param>
        private static void StartRobot(string[] args)
        {
            // If `--nocase` is an argument, set commands to be case-insensitive.
            // Default to case sensitivity.
            bool areCommandsCaseSensitive = ProgramArgumentParser.GetAreCommandsCaseSensitive(args);
            var CommandParser = new SingleCommandPerLineParser(areCommandsCaseSensitive);

            // Create the board, and exit if the board arguments are not valid.
            Board Board;
            try
            {
                // If `--bounds xUpper yUpper [xLower yLower]` is set, change the default board size.
                Board = ProgramArgumentParser.ParseBoardSizeFromArgs(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine(UseageText);
                return;
            }

            // Create the Robot and output its description if the program is in DEBUG mode.
            var Robot = new Robot2DPrimaryCardinal(Board);
            ToyRobotLogger.LogDebug(Robot.ToStringFullDescription());

            // Output user directions for interactive mode.
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Enter one or more Commands (press CTRL+C to exit):");
                Console.WriteLine();
            }

            ReadCommandsUntilQuit(CommandParser, Robot);
        }

        /// <summary>
        /// Reads commands from STDIN and handles them until the program is quit.
        /// </summary>
        /// <param name="CommandParser">The Command Parser to use to parse commands</param>
        /// <param name="Robot">The Robot to send commands to</param>
        private static void ReadCommandsUntilQuit(ICommandParser CommandParser, IRobot Robot)
        {
            string line = string.Empty;
            while (line != null)
            {
                line = Console.ReadLine();
                if (line != null && CommandParser.TryParseCommand(line, out IBaseCommand newCommand))
                {
                    switch (newCommand)
                    {
                        case PrintCommand cmd:
                            Console.WriteLine($"{cmd.OutputString}");
                            break;

                        default:
                            ToyRobotLogger.LogDebug(newCommand.ToString());
                            _ = Robot.ExecuteCommand(newCommand);
                            ToyRobotLogger.LogDebug(Robot.ToString());
                            break;
                    }
                }
            }
        }
    }
}