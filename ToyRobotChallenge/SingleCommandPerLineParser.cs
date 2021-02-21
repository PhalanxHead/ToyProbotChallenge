using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ToyRobotChallenge.Interfaces;
using static ToyRobotChallenge.Domain.Domain;

namespace ToyRobotChallenge
{
    /// <summary>
    /// Parses valid strings into IBaseCommands.
    /// </summary>
    public class SingleCommandPerLineParser : ICommandParser
    {
        /// <summary>
        /// Indicates the parser mode. Set at construction time.
        /// </summary>
        private readonly StringComparison _stringComparisonMethod;

        /// <summary>
        /// Indicates the use of case invariance. Set at construction time.
        /// </summary>
        private readonly bool _isUsingCaseSensitivity;

        /// <summary>
        /// Creates a new Command Parser with the given case sensitivity mode.
        /// </summary>
        /// <param name="isUsingCaseSensitivity">True if commands should not be read as case sensitive</param>
        public SingleCommandPerLineParser(bool isUsingCaseSensitivity = true)
        {
            _stringComparisonMethod = isUsingCaseSensitivity ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            _isUsingCaseSensitivity = isUsingCaseSensitivity;
        }

        /// <summary>
        /// Attempts to parse a "Command Unit" (ie a line or other delimited code block).
        /// Returns True if the parsing is successful, and outputs the command in "commandType" out variable.
        /// Returns False if the parsing fails, and "commandType" out variable will be null.
        /// </summary>
        /// <param name="commandUnit">The string to parse into a command</param>
        /// <param name="commandType">The output command as an IBaseCommand. Will be null if parsing is unsuccessful.</param>
        /// <returns>True if parsing is successful.</returns>
        public bool TryParseCommand(string commandUnit, out IBaseCommand commandType)
        {
            if (string.IsNullOrWhiteSpace(commandUnit))
            {
                commandType = null;
                return false;
            }

            string cleanedCommand = commandUnit.Trim();
            // Use C# 8 pattern matching for succinct-ness.
            // We want to match the outcome with a complex conditional (ie StartsWith), so we can
            // force the "pattern" to match bool each time so they are all tested.
            // Once all tests are performed, emit some IBaseCommand as a result.
            commandType = true switch
            {
                bool _ when cleanedCommand.StartsWith(PLACE_COMMAND_PREFIX, _stringComparisonMethod)
                    => ParsePlaceCommand(cleanedCommand),

                bool _ when cleanedCommand.StartsWith(MOVE_COMMAND_PREFIX, _stringComparisonMethod)
                    => new MoveCommand(),

                bool _ when cleanedCommand.StartsWith(LEFT_COMMAND_PREFIX, _stringComparisonMethod)
                    => new LeftCommand(),

                bool _ when cleanedCommand.StartsWith(RIGHT_COMMAND_PREFIX, _stringComparisonMethod)
                    => new RightCommand(),

                bool _ when cleanedCommand.StartsWith(REPORT_COMMAND_PREFIX, _stringComparisonMethod)
                    => new ReportCommand(),

                bool _ when cleanedCommand.StartsWith(PRINT_COMMAND_PREFIX, _stringComparisonMethod)
                    => new PrintCommand(GetPrintCommandString(cleanedCommand)),

                _ => null,
            };

            bool isValidCommand = commandType != null;
            if (!isValidCommand)
            {
                Console.WriteLine($"Invalid Command: \"{cleanedCommand}\"");
            }

            return isValidCommand;
        }

        /// <summary>
        /// Parses a command unit marked as PLACE into a PlaceCommand struct.
        /// Valid arguments have the form "X,Y,Direction", potentially with spaces after the commas.
        /// Returns null if the command is malformed.
        /// </summary>
        /// <param name="commandUnit">The command to extract a PlaceCommand struct from</param>
        /// <returns></returns>
        private PlaceCommand? ParsePlaceCommand(string commandUnit)
        {
            // Split Commands from Arguments.
            // Note that valid arguments may be split across sections, as the delimiter for an argument might be the same as
            // the delimiter for a command.
            var splitCommandUnit = commandUnit.Split(validCommand_ArgumentDelimiters, StringSplitOptions.RemoveEmptyEntries);

            // Split potential commands from arguments, and add all arguments to a list.
            var arguments = new List<string>();
            foreach (var argumentSegment in splitCommandUnit)
            {
                // If the segment is the command itself, skip it
                if (argumentSegment.Equals(PLACE_COMMAND_PREFIX, _stringComparisonMethod))
                {
                    continue;
                }

                // If the segment contains an allowed delimiter, split the segment and add all the entries that came with it.
                // Otherwise, if the list needs only 1 item to be able to complete the command, add this entry.
                foreach (var delim in validArgument_ArgumentDelimiters)
                {
                    if (argumentSegment.Contains(delim))
                    {
                        arguments.AddRange(argumentSegment
                                .Split(validArgument_ArgumentDelimiters, StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => x.Trim()));
                        break;
                    }
                    else if (arguments.Count == PLACE_COMMAND_ARGUMENT_COUNT_REQUIREMENT - 1)
                    {
                        arguments.Add(argumentSegment);
                        break;
                    }
                }
            }

            // Get the required number of arguments. Return null if there isn't enough.
            var requiredArguments = arguments.Take(PLACE_COMMAND_ARGUMENT_COUNT_REQUIREMENT).ToArray();
            if (requiredArguments.Length != PLACE_COMMAND_ARGUMENT_COUNT_REQUIREMENT)
            {
                return null;
            }

            // Try and parse the arguments in the canonical order (ie X, Y, Direction)
            // If it fails, return null.
            if (
                int.TryParse(requiredArguments[0], out int placeX)
                && int.TryParse(requiredArguments[1], out int placeY)
                && Enum.TryParse(value: requiredArguments[2], ignoreCase: !_isUsingCaseSensitivity, result: out Direction facingDirection))
            {
                return new PlaceCommand(placeX, placeY, facingDirection);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all strings inside quotes from a given string.
        /// If there is no quote pairs, an empty string will be returned.
        /// If there are multiple quote pairs, they will be joined by a comma.
        /// </summary>
        /// <param name="commandUnit">String to search for enquoted sections in</param>
        /// <returns></returns>
        private string GetPrintCommandString(string commandUnit)
        {
            return string.Join(", ", Regex.Matches(commandUnit, "\"([^\"]*)\"")).TrimStart('"').TrimEnd('"');
        }
    }
}