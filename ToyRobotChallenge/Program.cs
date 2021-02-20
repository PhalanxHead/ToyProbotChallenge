using System;
using System.Linq;
using ToyRobotChallenge.Domain;

namespace ToyRobotChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isUsingCaseInsensitivity = args.Select(x => x.ToLower()).Contains(Domain.Domain.UseCaseInvariantArgument);
            var CommandParser = new CommandParser(isUsingCaseInsensitivity);

            string line = string.Empty;
            Console.WriteLine("Enter one or more Commands (press CTRL+C to exit):");
            Console.WriteLine();
            while (line != null)
            {
                line = Console.ReadLine();
                if (line != null)
                {
                    if (CommandParser.TryParseCommand(line, out IBaseCommand commandType))
                    {
                        switch (commandType) {
                            case PrintCommand cmd:
                                Console.WriteLine($"{cmd.OutputString}");
                                break;

                            default:
                                Console.WriteLine($"Parsed: {commandType}");
                                break;
                        }
                    }
                }
            };
        }
    }
}
