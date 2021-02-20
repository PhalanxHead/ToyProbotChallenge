using System;
using System.Linq;
using ToyRobotChallenge.Domain;

namespace ToyRobotChallenge
{
    class Program
    {
        const string UseageText = "Useage: ToyRobotChallenge.exe [--nocase] [--bounds xUpper yUpper [xLower yLower]]";

        static void Main(string[] args)
        {
            // If `--nocase` is an argument, set commands to be case-insensitive.
            // Default to case sensitivity.
            bool areCommandsCaseSensitive = !args.Select(x => x.ToLower()).Contains(Domain.Domain.UseCaseInvariantArgument);
            var CommandParser = new CommandParser(areCommandsCaseSensitive);

            var Board = new Board();
            var Robot = new Robot2DPrimaryCardinal(Board);
            ToyRobotLogger.LogDebug(Robot.ToStringFullDescription());

            Console.WriteLine("Enter one or more Commands (press CTRL+C to exit):");
            Console.WriteLine();

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
