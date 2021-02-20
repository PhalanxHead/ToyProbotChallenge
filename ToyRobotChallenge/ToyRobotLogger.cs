namespace ToyRobotChallenge
{
    public class ToyRobotLogger
    {
        /// <summary>
        /// Logs a debug string with the time if the program is being run with a debug target
        /// </summary>
        /// <param name="log">The string to print as part of the log</param>
        public static void LogDebug(string log)
        {
#if DEBUG
            Console.WriteLine($"{DateTime.Now} | DEBUG | {log}");
#endif
        }
    }
}