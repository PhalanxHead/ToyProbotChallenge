using System;
using System.Collections.Generic;
using ToyRobotChallenge.Collections;
using static ToyRobotChallenge.Domain.Domain;

namespace ToyRobotChallenge.Domain
{
    internal class Robot2DPrimaryCardinal : IRobot
    {
        private readonly Board _Board;

        private readonly OrderedCyclingCursor<Direction> _CurrentFacing_ClockwiseCycle;
        private int _CurrentX;
        private int _CurrentY;
        /// <summary>
        /// Indicates if the robot has been placed yet.
        /// </summary>
        private bool _IsPlaced = false;

        /// <summary>
        /// Creates a robot that can traverse a 2D board in the Primary Cardinal Directions (ie North, East, South, West)
        /// </summary>
        /// <param name="board">The board to place the robot onto</param>
        public Robot2DPrimaryCardinal(Board board)
        {
            _Board = board ?? throw new ArgumentNullException($"Cannot create a Robot from a Null Board!");
            _CurrentFacing_ClockwiseCycle = new OrderedCyclingCursor<Direction>(PrimaryCardinalDirections_ClockwiseOrder);
        }

        /// <inheritdoc/>
        public bool ExecuteCommand(IBaseCommand command)
        {
            var success = command switch
            {
                PlaceCommand cmd => TryPlaceRobotOnBoard(cmd),
                MoveCommand cmd => MoveRobotFowardIfPossible(),
                LeftCommand cmd => ExecuteLeftCommand(),
                RightCommand cmd => ExecuteRightCommand(),
                ReportCommand cmd => ExecuteReportCommand(),
                _ => false,
            };
            return success;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (_IsPlaced)
            {
                return $"{_CurrentX},{_CurrentY},{_CurrentFacing_ClockwiseCycle.Current()}";
            }
            else
            {
                return $"Robot has not yet been placed.";
            }
        }

        /// <inheritdoc/>
        public string ToStringFullDescription()
        {
            return "2D Robot with Primary Cardinal Directions \n" +
                    "Valid Direction Order: \n" +
                    $"{string.Join("\n", PrimaryCardinalDirections_ClockwiseOrder)} \n" +
                    "--------- \n" +
                    "Current State: \n" +
                    $"{this}";
        }

        /// <summary>
        /// Turns the robot 90 degrees to its left
        /// </summary>
        /// <returns></returns>
        private bool ExecuteLeftCommand()
        {
            if (_IsPlaced)
            {
                _CurrentFacing_ClockwiseCycle.Previous();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Reports the Robot's Position and Facing Direction
        /// </summary>
        /// <returns></returns>
        private bool ExecuteReportCommand()
        {
            Console.WriteLine(ToString());
            return true;
        }

        /// <summary>
        /// Turns the robot 90 degrees to its right
        /// </summary>
        /// <returns></returns>
        private bool ExecuteRightCommand()
        {
            if (_IsPlaced)
            {
                _CurrentFacing_ClockwiseCycle.Next();
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Moves the robot forward one space if it can.
        /// Returns True if it moved.
        /// </summary>
        /// <returns></returns>
        private bool MoveRobotFowardIfPossible()
        {
            if (!_IsPlaced)
            {
                return false;
            }
            var (futureX, futureY) = PeekForward();
            // Don't move if it would take it outside the board bounds.
            if (futureX < _Board.BoardLowerBoundX || futureX > _Board.BoardUpperBoundX)
            {
                return false;
            }

            if (futureY < _Board.BoardLowerBoundY || futureY > _Board.BoardUpperBoundY)
            {
                return false;
            }

            _CurrentX = futureX;
            _CurrentY = futureY;
            return true;
        }

        /// <summary>
        /// Returns the position of the robot if it moves forward in the current direction.
        /// Returns (INT.MIN, INT.MIN) if the robot isn't placed.
        /// </summary>
        /// <returns></returns>
        private (int futureX, int futureY) PeekForward()
        {
            if (!_IsPlaced)
            {
                return (int.MinValue, int.MinValue);
            }

            return (_CurrentFacing_ClockwiseCycle.Current()) switch
            {
                Direction.NORTH => (_CurrentX, _CurrentY + 1),
                Direction.EAST => (_CurrentX + 1, _CurrentY),
                Direction.SOUTH => (_CurrentX, _CurrentY - 1),
                Direction.WEST => (_CurrentX - 1, _CurrentY),
                _ => (_CurrentX, _CurrentY),
            };
        }

        /// <summary>
        /// Places the robot on the board. Returns True if successful.
        /// </summary>
        /// <param name="cmd">The command to execute</param>
        /// <returns>True if placement is successful</returns>
        private bool TryPlaceRobotOnBoard(PlaceCommand cmd)
        {
            // Don't place if outside the board bounds.
            if (cmd.X < _Board.BoardLowerBoundX || cmd.X > _Board.BoardUpperBoundX)
            {
                return false;
            }

            if (cmd.Y < _Board.BoardLowerBoundY || cmd.Y > _Board.BoardUpperBoundY)
            {
                return false;
            }

            // Set the robot position and direction.
            // If a bad direction was given, return false
            try
            {
                _CurrentX = cmd.X;
                _CurrentY = cmd.Y;
                _CurrentFacing_ClockwiseCycle.SetCursorToElement(cmd.FacingDirection);
                _IsPlaced = true;
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }
    }
}