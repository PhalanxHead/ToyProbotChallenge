using System;
using System.Linq;
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

        private static void StartRobot(string[] args)
        {
            // If `--nocase` is an argument, set commands to be case-insensitive.
            // Default to case sensitivity.
            bool areCommandsCaseSensitive = !args.Select(x => x.ToLower()).Contains(Domain.Domain.UseCaseInvariantArgument);
            var CommandParser = new SingleCommandPerLineParser(areCommandsCaseSensitive);

            var Board = new Board();
            var Robot = new Robot2DPrimaryCardinal(Board);
            ToyRobotLogger.LogDebug(Robot.ToStringFullDescription());

            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Enter one or more Commands (press CTRL+C to exit):");
                Console.WriteLine();
            }

            ReadCommandsUntilQuit(CommandParser, Robot);
        }

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