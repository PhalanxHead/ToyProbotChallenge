using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ToyRobotChallenge.Domain.Domain;

namespace ToyRobotChallenge
{
    class CommandParser
    {
        private StringComparison _stringComparisonMethod;

        public CommandParser(bool isUsingCaseInsensitivity = false)
        {
            _stringComparisonMethod = isUsingCaseInsensitivity ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        }

        public bool TryParseCommand(string commandUnit, out IBaseCommand commandType)
        {
            string cleanedCommand = commandUnit.Trim();
            switch (true)
            {
                case bool _ when cleanedCommand.StartsWith(PLACE_COMMAND_PREFIX, _stringComparisonMethod):
                    commandType = new PlaceCommand(0,0,Direction.NORTH);
                    return true;

                case bool _ when cleanedCommand.StartsWith(MOVE_COMMAND_PREFIX, _stringComparisonMethod):
                    commandType = new MoveCommand();
                    return true;

                case bool _ when cleanedCommand.StartsWith(LEFT_COMMAND_PREFIX, _stringComparisonMethod):
                    commandType = new LeftCommand();
                    return true;

                case bool _ when cleanedCommand.StartsWith(RIGHT_COMMAND_PREFIX, _stringComparisonMethod):
                    commandType = new RightCommand();
                    return true;

                case bool _ when cleanedCommand.StartsWith(REPORT_COMMAND_PREFIX, _stringComparisonMethod):
                    commandType = new ReportCommand();
                    return true;

                case bool _ when cleanedCommand.StartsWith(PRINT_COMMAND_PREFIX, _stringComparisonMethod):
                    commandType = new PrintCommand("Hello World!");
                    return true;

                default:
                    Console.WriteLine($"Invalid Command: \"{cleanedCommand}\"");
                    commandType = null;
                    return false;
            }
        }
    }
}
