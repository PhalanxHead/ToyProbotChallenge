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

        public bool TryParseCommand(string commandUnit, out string commandType)
        {
            string cleanedCommand = commandUnit.Trim();
            switch (true)
            {
                case bool _ when cleanedCommand.StartsWith(PLACE_COMMAND_PREFIX, _stringComparisonMethod):
                    commandType = "Place";
                    return true;

                case bool _ when cleanedCommand.StartsWith(MOVE_COMMAND_PREFIX, _stringComparisonMethod):
                    commandType = "Move";
                    return true;

                case bool _ when cleanedCommand.StartsWith(LEFT_COMMAND_PREFIX, _stringComparisonMethod):
                    commandType = "Left";
                    return true;

                case bool _ when cleanedCommand.StartsWith(RIGHT_COMMAND_PREFIX, _stringComparisonMethod):
                    commandType = "Right";
                    return true;

                case bool _ when cleanedCommand.StartsWith(REPORT_COMMAND_PREFIX, _stringComparisonMethod):
                    commandType = "Report";
                    return true;

                case bool _ when cleanedCommand.StartsWith(PRINT_COMMAND_PREFIX, _stringComparisonMethod):
                    commandType = "Print";
                    return true;

                default:
                    commandType = "InvalidCommand";
                    return false;
            }
        }
    }
}
