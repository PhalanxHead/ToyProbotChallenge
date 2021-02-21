using NUnit.Framework;
using System;
using ToyRobotChallenge;
using ToyRobotChallenge.Domain;

namespace UnitTests
{
    internal class ProgramArgumentParserTests
    {
        [Test]
        public void ParseBoardArgs_NoBoundsArgCreatesDefaultBoard()
        {
            string[] testArgs = new string[] { };

            Board StandardBoard = new Board();
            var testBoard = ProgramArgumentParser.ParseBoardSizeFromArgs(testArgs);

            Assert.AreEqual(StandardBoard.BoardUpperBoundX, testBoard.BoardUpperBoundX, "Upper Bound X is not correct");
            Assert.AreEqual(StandardBoard.BoardUpperBoundY, testBoard.BoardUpperBoundY, "Upper Bound Y is not correct");
            Assert.AreEqual(StandardBoard.BoardLowerBoundX, testBoard.BoardLowerBoundX, "Lower Bound X is not correct");
            Assert.AreEqual(StandardBoard.BoardLowerBoundY, testBoard.BoardLowerBoundY, "Lower Bound Y is not correct");
        }

        [Test]
        public void ParseBoardArgs_UpperBoundsArgCreatesCustomBoardWithDefaults()
        {
            string[] testArgs = new string[] { Domain.SetBoardBoundsArgument, "10", "8" };

            Board StandardBoard = new Board(10, 8);
            var testBoard = ProgramArgumentParser.ParseBoardSizeFromArgs(testArgs);

            Assert.AreEqual(StandardBoard.BoardUpperBoundX, testBoard.BoardUpperBoundX, "Upper Bound X is not correct");
            Assert.AreEqual(StandardBoard.BoardUpperBoundY, testBoard.BoardUpperBoundY, "Upper Bound Y is not correct");
            Assert.AreEqual(StandardBoard.BoardLowerBoundX, testBoard.BoardLowerBoundX, "Lower Bound X is not correct");
            Assert.AreEqual(StandardBoard.BoardLowerBoundY, testBoard.BoardLowerBoundY, "Lower Bound Y is not correct");
        }

        [Test]
        public void ParseBoardArgs_AllBoundsArgCreatesCustomBoard()
        {
            string[] testArgs = new string[] { Domain.SetBoardBoundsArgument, "15", "5", "-5", "-5" };

            Board StandardBoard = new Board(15, 5, -5, -5);
            var testBoard = ProgramArgumentParser.ParseBoardSizeFromArgs(testArgs);

            Assert.AreEqual(StandardBoard.BoardUpperBoundX, testBoard.BoardUpperBoundX, "Upper Bound X is not correct");
            Assert.AreEqual(StandardBoard.BoardUpperBoundY, testBoard.BoardUpperBoundY, "Upper Bound Y is not correct");
            Assert.AreEqual(StandardBoard.BoardLowerBoundX, testBoard.BoardLowerBoundX, "Lower Bound X is not correct");
            Assert.AreEqual(StandardBoard.BoardLowerBoundY, testBoard.BoardLowerBoundY, "Lower Bound Y is not correct");
        }

        [Test]
        public void ParseBoardArgs_AllBoundsArgCreatesCustomBoard_BoundSizesReversed()
        {
            string[] testArgs = new string[] { Domain.SetBoardBoundsArgument, "-5", "5", "15", "-5" };

            Board StandardBoard = new Board(-5, 5, 15, -5);
            var testBoard = ProgramArgumentParser.ParseBoardSizeFromArgs(testArgs);

            Assert.AreEqual(StandardBoard.BoardUpperBoundX, testBoard.BoardUpperBoundX, "Upper Bound X is not correct");
            Assert.AreEqual(StandardBoard.BoardUpperBoundY, testBoard.BoardUpperBoundY, "Upper Bound Y is not correct");
            Assert.AreEqual(StandardBoard.BoardLowerBoundX, testBoard.BoardLowerBoundX, "Lower Bound X is not correct");
            Assert.AreEqual(StandardBoard.BoardLowerBoundY, testBoard.BoardLowerBoundY, "Lower Bound Y is not correct");
        }

        [Test]
        public void ParseBoardArgs_AllBoundsArgCreatesCustomBoard_MoreBoundsCreatesBoardOffFirst4()
        {
            string[] testArgs = new string[] { Domain.SetBoardBoundsArgument, "15", "5", "15", "5", "5" };

            Board StandardBoard = new Board(15, 5, 15, 5);
            var testBoard = ProgramArgumentParser.ParseBoardSizeFromArgs(testArgs);

            Assert.AreEqual(StandardBoard.BoardUpperBoundX, testBoard.BoardUpperBoundX, "Upper Bound X is not correct");
            Assert.AreEqual(StandardBoard.BoardUpperBoundY, testBoard.BoardUpperBoundY, "Upper Bound Y is not correct");
            Assert.AreEqual(StandardBoard.BoardLowerBoundX, testBoard.BoardLowerBoundX, "Lower Bound X is not correct");
            Assert.AreEqual(StandardBoard.BoardLowerBoundY, testBoard.BoardLowerBoundY, "Lower Bound Y is not correct");
        }

        [Test]
        public void ParseBoardArgs_LowBoundsCountThrowsException_3Args()
        {
            string[] testArgs = new string[] { Domain.SetBoardBoundsArgument, "-5", "5", "15" };

            Assert.Throws<ArgumentException>(() =>
            {
                var testBoard = ProgramArgumentParser.ParseBoardSizeFromArgs(testArgs);
            });
        }

        [Test]
        public void ParseBoardArgs_LowBoundsCountThrowsException_1Arg()
        {
            string[] testArgs = new string[] { Domain.SetBoardBoundsArgument, "-5" };

            Assert.Throws<ArgumentException>(() =>
            {
                var testBoard = ProgramArgumentParser.ParseBoardSizeFromArgs(testArgs);
            });
        }

        [Test]
        public void ParseBoardArgs_LowBoundsCountThrowsException_0Arg()
        {
            string[] testArgs = new string[] { Domain.SetBoardBoundsArgument };

            Assert.Throws<ArgumentException>(() =>
            {
                var testBoard = ProgramArgumentParser.ParseBoardSizeFromArgs(testArgs);
            });
        }

        [Test]
        public void ParseBoardArgs_LowBoundsCountThrowsException_NonNumericArg()
        {
            string[] testArgs = new string[] { Domain.SetBoardBoundsArgument, "abc", "5" };

            Assert.Throws<ArgumentException>(() =>
            {
                var testBoard = ProgramArgumentParser.ParseBoardSizeFromArgs(testArgs);
            });
        }

        [Test]
        public void ParseBoardArgs_LowBoundsCountThrowsException_NonIntegerArg()
        {
            string[] testArgs = new string[] { Domain.SetBoardBoundsArgument, "9.9", "5" };

            Assert.Throws<ArgumentException>(() =>
            {
                var testBoard = ProgramArgumentParser.ParseBoardSizeFromArgs(testArgs);
            });
        }

        [Test]
        public void ParseCaseArgs_ArgumentPresenceIndicatesCaseInsensitivity()
        {
            string[] testArgs = new string[] { Domain.UseCaseInvariantArgument };

            Assert.False(ProgramArgumentParser.GetAreCommandsCaseSensitive(testArgs));
        }

        [Test]
        public void ParseCaseArgs_ArgumentPresenceInUppercaseIndicatesCaseInsensitivity()
        {
            string[] testArgs = new string[] { Domain.UseCaseInvariantArgument.ToUpper() };

            Assert.False(ProgramArgumentParser.GetAreCommandsCaseSensitive(testArgs));
        }

        [Test]
        public void ParseCaseArgs_ArgumentAbsenceIndicateCaseSensitivity()
        {
            string[] testArgs = new string[] { };

            Assert.True(ProgramArgumentParser.GetAreCommandsCaseSensitive(testArgs));
        }

        [Test]
        public void ParseCombinedBoardCaseArgs_PresenceOfBothSensed()
        {
            string[] testArgs = new string[] { Domain.SetBoardBoundsArgument, "15", "5", "15", "5", Domain.UseCaseInvariantArgument };

            Board StandardBoard = new Board(15, 5, 15, 5);
            var testBoard = ProgramArgumentParser.ParseBoardSizeFromArgs(testArgs);

            Assert.AreEqual(StandardBoard.BoardUpperBoundX, testBoard.BoardUpperBoundX, "Upper Bound X is not correct");
            Assert.AreEqual(StandardBoard.BoardUpperBoundY, testBoard.BoardUpperBoundY, "Upper Bound Y is not correct");
            Assert.AreEqual(StandardBoard.BoardLowerBoundX, testBoard.BoardLowerBoundX, "Lower Bound X is not correct");
            Assert.AreEqual(StandardBoard.BoardLowerBoundY, testBoard.BoardLowerBoundY, "Lower Bound Y is not correct");

            Assert.False(ProgramArgumentParser.GetAreCommandsCaseSensitive(testArgs));
        }

        [Test]
        public void ParseCombinedBoardCaseArgs_NocaseArgBetweenBoundsArgsThrowsException()
        {
            string[] testArgs = new string[] { Domain.SetBoardBoundsArgument, "15", "5", Domain.UseCaseInvariantArgument, "15", "5" };

            Assert.Throws<ArgumentException>(() =>
            {
                var testBoard = ProgramArgumentParser.ParseBoardSizeFromArgs(testArgs);
            });
        }
    }
}