namespace ToyRobotChallenge.Interfaces
{
    public interface ICommandParser
    {
        /// <summary>
        /// Attempts to parse a "Command Unit" (ie a line or other delimited code block).
        /// Returns True if the parsing is successful, and outputs the command in "commandType" out variable.
        /// Returns False if the parsing fails, and "commandType" out variable will be null.
        /// </summary>
        /// <param name="commandUnit">The string to parse into a command</param>
        /// <param name="commandType">The output command as an IBaseCommand. Will be null if parsing is unsuccessful.</param>
        /// <returns>True if parsing is successful.</returns>
        bool TryParseCommand(string commandUnit, out IBaseCommand commandType);
    }
}