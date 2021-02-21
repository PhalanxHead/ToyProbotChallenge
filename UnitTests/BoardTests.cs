using NUnit.Framework;
using System;
using ToyRobotChallenge.Domain;

namespace UnitTests
{
    internal class BoardTests
    {
        [Test]
        public void TestStardardBoardHasDefaultBounds()
        {
            var testBoard = new Board();
            Assert.AreEqual(Domain.DEFAULT_BOARD_UPPER_BOUND_X, testBoard.BoardUpperBoundX, $"Upper X Bound is not correct");
            Assert.AreEqual(Domain.DEFAULT_BOARD_UPPER_BOUND_Y, testBoard.BoardUpperBoundY, $"Upper Y Bound is not correct");
            Assert.AreEqual(Domain.DEFAULT_BOARD_LOWER_BOUND_X, testBoard.BoardLowerBoundX, $"Lower X Bound is not correct");
            Assert.AreEqual(Domain.DEFAULT_BOARD_LOWER_BOUND_Y, testBoard.BoardLowerBoundY, $"Lower Y Bound is not correct");
        }

        [Test]
        public void TestCustomUpperBoardHas_CorrectUpper_DefaultLowerBounds()
        {
            var testUpperX = 10;
            var testUpperY = 300;
            var testBoard = new Board(testUpperX, testUpperY);
            Assert.AreEqual(testUpperX, testBoard.BoardUpperBoundX, $"Upper X Bound is not correct");
            Assert.AreEqual(testUpperY, testBoard.BoardUpperBoundY, $"Upper Y Bound is not correct");
            Assert.AreEqual(Domain.DEFAULT_BOARD_LOWER_BOUND_X, testBoard.BoardLowerBoundX, $"Lower X Bound is not correct");
            Assert.AreEqual(Domain.DEFAULT_BOARD_LOWER_BOUND_Y, testBoard.BoardLowerBoundY, $"Lower Y Bound is not correct");
        }

        [Test]
        public void TestCustomUpperBoard_AltersLowerrBoundIfInputIsBelowLowerDefault()
        {
            var testLowerX = -10;
            var testUpperY = 300;
            var testBoard = new Board(testLowerX, testUpperY);
            Assert.AreEqual(Domain.DEFAULT_BOARD_UPPER_BOUND_X, testBoard.BoardUpperBoundX, $"Lower X Bound is not correct");
            Assert.AreEqual(testLowerX, testBoard.BoardLowerBoundX, $"Lower X Bound is not correct");
            Assert.AreEqual(testUpperY, testBoard.BoardUpperBoundY, $"Upper Y Bound is not correct");
            Assert.AreEqual(Domain.DEFAULT_BOARD_LOWER_BOUND_Y, testBoard.BoardLowerBoundY, $"Lower Y Bound is not correct");
        }

        [Test]
        public void TestCustomAllBounds_CorrectUpper_CorrectLowerBounds()
        {
            var testUpperX = 10;
            var testUpperY = 300;
            var testLowerX = -10;
            var testLowerY = -300;
            var testBoard = new Board(testUpperX, testUpperY, testLowerX, testLowerY);
            Assert.AreEqual(testUpperX, testBoard.BoardUpperBoundX, $"Upper X Bound is not correct");
            Assert.AreEqual(testUpperY, testBoard.BoardUpperBoundY, $"Upper Y Bound is not correct");
            Assert.AreEqual(testLowerX, testBoard.BoardLowerBoundX, $"Lower X Bound is not correct");
            Assert.AreEqual(testLowerY, testBoard.BoardLowerBoundY, $"Lower Y Bound is not correct");
        }

        [Test]
        public void TestCustomAllBounds_UpperAlwaysGreater()
        {
            var testUpperX = -10;
            var testUpperY = -300;
            var testLowerX = 10;
            var testLowerY = 300;
            var testBoard = new Board(testUpperX, testUpperY, testLowerX, testLowerY);
            Assert.AreEqual(Math.Max(testUpperX, testLowerX), testBoard.BoardUpperBoundX, $"Upper X Bound is not correct");
            Assert.AreEqual(Math.Max(testUpperY, testLowerY), testBoard.BoardUpperBoundY, $"Upper Y Bound is not correct");
            Assert.AreEqual(Math.Min(testLowerX, testUpperX), testBoard.BoardLowerBoundX, $"Lower X Bound is not correct");
            Assert.AreEqual(Math.Min(testLowerY, testUpperY), testBoard.BoardLowerBoundY, $"Lower Y Bound is not correct");
        }
    }
}