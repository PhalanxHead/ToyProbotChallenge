using static ToyRobotChallenge.Domain.Domain;

namespace ToyRobotChallenge
{
    /// <summary>
    /// Interface to apply to all commands.
    /// </summary>
    public interface IBaseCommand
    {
        string ToString();
    }

    /// <summary>
    /// Used to indicate that the robot should execute its Move command.
    /// </summary>
    public struct MoveCommand : IBaseCommand
    {
        public override string ToString()
        {
            return $"MOVE";
        }
    }

    /// <summary>
    /// Usesd to indicate that the robot should execute its Left command.
    /// </summary>
    public struct LeftCommand : IBaseCommand
    {
        public override string ToString()
        {
            return $"LEFT";
        }
    }

    /// <summary>
    /// Usesd to indicate that the robot should execute its Right command.
    /// </summary>
    public struct RightCommand : IBaseCommand
    {
        public override string ToString()
        {
            return $"RIGHT";
        }
    }

    /// <summary>
    /// Used to indicate that the robot should execite its Report command.
    /// </summary>
    public struct ReportCommand : IBaseCommand
    {
        public override string ToString()
        {
            return $"REPORT";
        }
    }

    /// <summary>
    /// Used to execute a PRINT statement. Stores the related string.
    /// </summary>
    public struct PrintCommand : IBaseCommand
    {
        public string OutputString { get; private set; }

        public PrintCommand(string outputString)
        {
            OutputString = outputString;
        }

        public override string ToString()
        {
            return $"PRINT \"{OutputString}\"";
        }
    }

    /// <summary>
    /// Used to attempt to place the robot at an X,Y Position facing in some direction.
    /// No validation is applied to the bounds of the command at creation.
    /// </summary>
    public struct PlaceCommand : IBaseCommand
    {
        /// <summary>
        /// The X Position to attempt to place the robot on
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// The Y Position to attempt to place the robot on
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// The Direction the bot should attempt to face when placed
        /// </summary>
        public Direction FacingDirection { get; private set; }

        public PlaceCommand(int x, int y, Direction facingDirection)
        {
            X = x;
            Y = y;
            FacingDirection = facingDirection;
        }

        public override string ToString()
        {
            return $"PLACE {X} {Y} {FacingDirection}";
        }
    }
}