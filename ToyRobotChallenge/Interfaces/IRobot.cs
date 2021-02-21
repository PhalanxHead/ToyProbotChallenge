using static ToyRobotChallenge.Domain.Domain;

namespace ToyRobotChallenge.Interfaces
{
    /// <summary>
    /// Defines the requirements for a Robot
    /// </summary>
    public interface IRobot
    {
        /// <summary>
        /// Attempts to execute a given command. Returns true if successful.
        /// </summary>
        /// <param name="command">The command to attempt to execute</param>
        /// <returns></returns>
        public bool ExecuteCommand(IBaseCommand command);

        /// <summary>
        /// Describes the current state of the Robot
        /// </summary>
        /// <returns></returns>
        public string ToString();

        /// <summary>
        /// Describes the Robot's full configuration including
        /// all the possible directions it can face, the bounds of its board,
        /// and its current state if it has been set.
        /// </summary>
        /// <returns></returns>
        public string ToStringFullDescription();

        /// <summary>
        /// Returns the robot's current state as a Tuple. X/Y/Facing will be default if the robot hasn't yet been placed.
        /// </summary>
        /// <returns></returns>
        public (bool isPlaced, int currentX, int currentY, Direction currentFacing) DescribeSelfObjectively();
    }
}