using NUnit.Framework;
using System.Linq;
using ToyRobotChallenge;
using ToyRobotChallenge.Domain;
using ToyRobotChallenge.Interfaces;
using static ToyRobotChallenge.Domain.Domain;

namespace UnitTests
{
    internal class Robot2DPrimaryCardinalTests
    {
        private Board board;
        private IRobot testRobot;

        [SetUp]
        public void SetUp()
        {
            board = new Board(10, 10, 0, 0);
            testRobot = new Robot2DPrimaryCardinal(board);
        }

        [Test]
        public void RobotCanBePlaced()
        {
            var testX = 2;
            var testY = 2;
            var testDir = Direction.NORTH;

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.True(testRobot.ExecuteCommand(new PlaceCommand(testX, testY, testDir)));

            Assert.True(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it hasn't been placed after we placed it.");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");
        }

        [Test]
        public void RobotCanBePlaced_OnBoardEdge_UX_UY()
        {
            var testX = 10;
            var testY = 10;
            var testDir = Direction.NORTH;

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.True(testRobot.ExecuteCommand(new PlaceCommand(testX, testY, testDir)));

            Assert.True(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it hasn't been placed after we placed it.");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");
        }

        [Test]
        public void RobotCanBePlaced_OnBoardEdge_UX_LY()
        {
            var testX = 10;
            var testY = 0;
            var testDir = Direction.NORTH;

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.True(testRobot.ExecuteCommand(new PlaceCommand(testX, testY, testDir)));

            Assert.True(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it hasn't been placed after we placed it.");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");
        }

        [Test]
        public void RobotCanBePlaced_OnBoardEdge_LX_UY()
        {
            var testX = 0;
            var testY = 10;
            var testDir = Direction.NORTH;

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.True(testRobot.ExecuteCommand(new PlaceCommand(testX, testY, testDir)));

            Assert.True(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it hasn't been placed after we placed it.");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");
        }

        [Test]
        public void RobotCanBePlaced_OnBoardEdge_LX_LY()
        {
            var testX = 0;
            var testY = 0;
            var testDir = Direction.NORTH;

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.True(testRobot.ExecuteCommand(new PlaceCommand(testX, testY, testDir)));

            Assert.True(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it hasn't been placed after we placed it.");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");
        }

        [Test]
        public void RobotCannotBePlacedOutsideBoardBounds_OverUX_OverUY()
        {
            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.False(testRobot.ExecuteCommand(new PlaceCommand(100, 100, Direction.NORTH)), "Robot indicating it was placed successfully outside bounds of board");

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed when placement failed.");
        }

        [Test]
        public void RobotCannotBePlacedOutsideBoardBounds_UnderLX_OverUY()
        {
            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.False(testRobot.ExecuteCommand(new PlaceCommand(-100, 100, Direction.NORTH)), "Robot indicating it was placed successfully outside bounds of board");

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed when placement failed.");
        }

        [Test]
        public void RobotCannotBePlacedOutsideBoardBounds_OverUX_UnderLY()
        {
            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.False(testRobot.ExecuteCommand(new PlaceCommand(100, -100, Direction.NORTH)), "Robot indicating it was placed successfully outside bounds of board");

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed when placement failed.");
        }

        [Test]
        public void RobotCannotBePlacedOutsideBoardBounds_UnderLX_UnderLY()
        {
            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.False(testRobot.ExecuteCommand(new PlaceCommand(-100, -100, Direction.NORTH)), "Robot indicating it was placed successfully outside bounds of board");

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed when placement failed.");
        }

        [Test]
        public void RobotCannotMovePastEdge_UX()
        {
            var testX = 10;
            var testY = 10;
            var testDir = Direction.EAST;

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.True(testRobot.ExecuteCommand(new PlaceCommand(testX, testY, testDir)));

            Assert.True(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it hasn't been placed after we placed it.");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");

            Assert.False(testRobot.ExecuteCommand(new MoveCommand()), "Moving marked as succeeded when it should have failed");

            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");

            Assert.False(testRobot.ExecuteCommand(new MoveCommand()), "Moving marked as succeeded when it should have failed");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");
        }

        [Test]
        public void RobotCannotMovePastEdge_UY()
        {
            var testX = 10;
            var testY = 10;
            var testDir = Direction.NORTH;

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.True(testRobot.ExecuteCommand(new PlaceCommand(testX, testY, testDir)));

            Assert.True(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it hasn't been placed after we placed it.");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");

            Assert.False(testRobot.ExecuteCommand(new MoveCommand()), "Moving marked as succeeded when it should have failed");

            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");

            Assert.False(testRobot.ExecuteCommand(new MoveCommand()), "Moving marked as succeeded when it should have failed");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");
        }

        [Test]
        public void RobotCannotMovePastEdge_LX()
        {
            var testX = 0;
            var testY = 10;
            var testDir = Direction.WEST;

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.True(testRobot.ExecuteCommand(new PlaceCommand(testX, testY, testDir)));

            Assert.True(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it hasn't been placed after we placed it.");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");

            Assert.False(testRobot.ExecuteCommand(new MoveCommand()), "Moving marked as succeeded when it should have failed");

            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");

            Assert.False(testRobot.ExecuteCommand(new MoveCommand()), "Moving marked as succeeded when it should have failed");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");
        }

        [Test]
        public void RobotCannotMovePastEdge_LY()
        {
            var testX = 10;
            var testY = 0;
            var testDir = Direction.SOUTH;

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.True(testRobot.ExecuteCommand(new PlaceCommand(testX, testY, testDir)));

            Assert.True(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it hasn't been placed after we placed it.");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");

            Assert.False(testRobot.ExecuteCommand(new MoveCommand()), "Moving marked as succeeded when it should have failed");

            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");

            Assert.False(testRobot.ExecuteCommand(new MoveCommand()), "Moving marked as succeeded when it should have failed");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");
        }

        [Test]
        public void RobotCanTurnLeftContinously()
        {
            var testX = 2;
            var testY = 2;
            var testDir = Direction.NORTH;

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.True(testRobot.ExecuteCommand(new PlaceCommand(testX, testY, testDir)));

            Assert.True(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it hasn't been placed after we placed it.");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");

            foreach (var _ in Enumerable.Range(0, 10))
            {
                var lastFacing = testRobot.DescribeSelfObjectively().currentFacing;
                Assert.True(testRobot.ExecuteCommand(new LeftCommand()), "Robot indicating that it cannot turn left");
                Assert.AreNotEqual(lastFacing, testRobot.DescribeSelfObjectively().currentFacing, "Robot didn't turn!");
            }
        }

        [Test]
        public void RobotCanTurnRightContinously()
        {
            var testX = 2;
            var testY = 2;
            var testDir = Direction.NORTH;

            Assert.False(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it has been placed before we placed it.");

            Assert.True(testRobot.ExecuteCommand(new PlaceCommand(testX, testY, testDir)));

            Assert.True(testRobot.DescribeSelfObjectively().isPlaced, "Robot indicating it hasn't been placed after we placed it.");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentX, testX, "X Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentY, testY, "Y Placement is incorrect");
            Assert.AreEqual(testRobot.DescribeSelfObjectively().currentFacing, testDir, "Facing is incorrect");

            foreach (var _ in Enumerable.Range(0, 10))
            {
                var lastFacing = testRobot.DescribeSelfObjectively().currentFacing;
                Assert.True(testRobot.ExecuteCommand(new RightCommand()), "Robot indicating that it cannot turn right");
                Assert.AreNotEqual(lastFacing, testRobot.DescribeSelfObjectively().currentFacing, "Robot didn't turn!");
            }
        }
    }
}