using NUnit.Framework;
using System;
using System.Collections.Generic;
using ToyRobotChallenge.Collections;
using static ToyRobotChallenge.Domain.Domain;

namespace UnitTests
{
    public class OrderedCyclingCursorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructingWithNullArrayThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => { var testCollection = new OrderedCyclingCursor<int>(null); });
        }

        [Test]
        public void ConstructingWithNullArrayAndStartingElementThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => { var testCollection = new OrderedCyclingCursor<int>(null, 1); });
        }

        [Test]
        public void ConstructingWithNotFoundStartingElementThrowsException()
        {
            Assert.Throws<KeyNotFoundException>(() => { var testCollection = new OrderedCyclingCursor<int>(new int[] { 1, 2, 3 }, 10); });
        }

        [Test]
        public void SingleElementAlwaysReturnsCurrent()
        {
            var singleElement = 13;
            var testCollection = new OrderedCyclingCursor<int>(new int[] { singleElement });

            Assert.AreEqual(singleElement, testCollection.Current(), "Current value was not the only element!");
            Assert.AreEqual(singleElement, testCollection.Next(), "Next value was not the only element!");
            Assert.AreEqual(singleElement, testCollection.PeekNext(), "Next Peeked value was not the only element!");
            Assert.AreEqual(singleElement, testCollection.Previous(), "Previous value was not the only element!");
            Assert.AreEqual(singleElement, testCollection.PeekPrevious(), "Previous peeked value was not the only element!");
        }

        [Test]
        public void MultipleNextElementsRestartsAtCollectionBeginning_TwoElements()
        {
            var initialCollection = new int[] { 7, 13 };
            var testCollection = new OrderedCyclingCursor<int>(initialCollection);

            Assert.AreEqual(initialCollection[0], testCollection.Current(), "Current value was not the first element!");
            Assert.AreEqual(initialCollection[1], testCollection.Next(), "Next value was not the second element!");
            Assert.AreEqual(initialCollection[0], testCollection.Next(), "Third value was not the first element!");
            Assert.AreEqual(initialCollection[1], testCollection.Next(), "Fourth value was not the second element!");
            Assert.AreEqual(initialCollection[0], testCollection.Next(), "Fifth value was not the first element!");
        }

        [Test]
        public void MultiplePeekNextElementsAlwaysReturnsItem2_NoCursorMutation()
        {
            var initialCollection = new int[] { 7, 13 };
            var testCollection = new OrderedCyclingCursor<int>(initialCollection);

            Assert.AreEqual(initialCollection[0], testCollection.Current(), "Current value was not the first element!");
            Assert.AreEqual(initialCollection[1], testCollection.PeekNext(), "Next value was not the second element!");
            Assert.AreEqual(initialCollection[1], testCollection.PeekNext(), "Third value was not the second element!");
            Assert.AreEqual(initialCollection[1], testCollection.PeekNext(), "Fourth value was not the second element!");
            Assert.AreEqual(initialCollection[1], testCollection.PeekNext(), "Fifth value was not the second element!");
        }

        [Test]
        public void MultiplePrevElementsRestartsAtCollectionEnd_TwoElements()
        {
            var initialCollection = new int[] { 7, 13 };
            var testCollection = new OrderedCyclingCursor<int>(initialCollection);

            Assert.AreEqual(initialCollection[0], testCollection.Current(), "Current value was not the first element!");
            Assert.AreEqual(initialCollection[1], testCollection.Previous(), "Next value was not the second element!");
            Assert.AreEqual(initialCollection[0], testCollection.Previous(), "Third value was not the first element!");
            Assert.AreEqual(initialCollection[1], testCollection.Previous(), "Fourth value was not the second element!");
            Assert.AreEqual(initialCollection[0], testCollection.Previous(), "Fifth value was not the first element!");
        }

        [Test]
        public void MultiplePeekPrevElementsAlwaysReturnsItemLast_NoCursorMutation_TwoElements()
        {
            var initialCollection = new int[] { 7, 13 };
            var testCollection = new OrderedCyclingCursor<int>(initialCollection);

            Assert.AreEqual(initialCollection[0], testCollection.Current(), "Current value was not the first element!");
            Assert.AreEqual(initialCollection[1], testCollection.PeekPrevious(), "Next value was not the second element!");
            Assert.AreEqual(initialCollection[1], testCollection.PeekPrevious(), "Third value was not the second element!");
            Assert.AreEqual(initialCollection[1], testCollection.PeekPrevious(), "Fourth value was not the second element!");
            Assert.AreEqual(initialCollection[1], testCollection.PeekPrevious(), "Fifth value was not the second element!");
        }

        [Test]
        public void MultipleNextElementsRestartsAtCollectionBeginning_ThreeElements()
        {
            var initialCollection = new int[] { 7, 13, 25 };
            var testCollection = new OrderedCyclingCursor<int>(initialCollection);

            Assert.AreEqual(initialCollection[0], testCollection.Current(), "Current value was not the first element!");
            Assert.AreEqual(initialCollection[1], testCollection.Next(), "Next value was not the second element!");
            Assert.AreEqual(initialCollection[2], testCollection.Next(), "Third value was not the third element!");
            Assert.AreEqual(initialCollection[0], testCollection.Next(), "Fourth value was not the first element!");
            Assert.AreEqual(initialCollection[1], testCollection.Next(), "Fifth value was not the second element!");
            Assert.AreEqual(initialCollection[2], testCollection.Next(), "Sixth value was not the third element!");
        }

        [Test]
        public void MultiplePeekNextElementsAlwaysReturnsItem2_NoCursorMutation_ThreeElements()
        {
            var initialCollection = new int[] { 7, 13, 25 };
            var testCollection = new OrderedCyclingCursor<int>(initialCollection);

            Assert.AreEqual(initialCollection[0], testCollection.Current(), "Current value was not the first element!");
            Assert.AreEqual(initialCollection[1], testCollection.PeekNext(), "Next value was not the second element!");
            Assert.AreEqual(initialCollection[1], testCollection.PeekNext(), "Third value was not the second element!");
            Assert.AreEqual(initialCollection[1], testCollection.PeekNext(), "Fourth value was not the second element!");
            Assert.AreEqual(initialCollection[1], testCollection.PeekNext(), "Fifth value was not the second element!");
        }

        [Test]
        public void MultiplePrevElementsRestartsAtCollectionEnd_ThreeElements()
        {
            var initialCollection = new int[] { 7, 13, 25 };
            var testCollection = new OrderedCyclingCursor<int>(initialCollection);

            Assert.AreEqual(initialCollection[0], testCollection.Current(), "Current value was not the first element!");
            Assert.AreEqual(initialCollection[2], testCollection.Previous(), "Prev value was not the Third element!");
            Assert.AreEqual(initialCollection[1], testCollection.Previous(), "Third value was not the Second element!");
            Assert.AreEqual(initialCollection[0], testCollection.Previous(), "Fourth value was not the First element!");
            Assert.AreEqual(initialCollection[2], testCollection.Previous(), "Fifth value was not the Third element!");
        }

        [Test]
        public void MultiplePeekPrevElementsAlwaysReturnsItemLast_NoCursorMutation_ThreeElements()
        {
            var initialCollection = new int[] { 7, 13, 25 };
            var testCollection = new OrderedCyclingCursor<int>(initialCollection);

            Assert.AreEqual(initialCollection[0], testCollection.Current(), "Current value was not the first element!");
            Assert.AreEqual(initialCollection[2], testCollection.PeekPrevious(), "Next value was not the last element!");
            Assert.AreEqual(initialCollection[2], testCollection.PeekPrevious(), "Third value was not the last element!");
            Assert.AreEqual(initialCollection[2], testCollection.PeekPrevious(), "Fourth value was not the last element!");
            Assert.AreEqual(initialCollection[2], testCollection.PeekPrevious(), "Fifth value was not the last element!");
        }

        [Test]
        public void ConstructingWithGivenStartElement_BeginsOrderCorrectly()
        {
            var initialCollection = new int[] { 7, 13, 25 };
            var testCollection = new OrderedCyclingCursor<int>(initialCollection, 13);

            Assert.AreEqual(initialCollection[1], testCollection.Current(), "Current value was not the given element!");
            Assert.AreEqual(initialCollection[0], testCollection.PeekPrevious(), "Previous value was not the first element!");
            Assert.AreEqual(initialCollection[2], testCollection.PeekNext(), "Third value was not the last element!");
        }

        [Test]
        public void ConstructingWithEnumsList_AcceptsEnums()
        {
            var initialCollection = new Direction[] { Direction.EAST, Direction.SOUTH, Direction.WEST };
            var testCollection = new OrderedCyclingCursor<Direction>(initialCollection);

            Assert.AreEqual(initialCollection[0], testCollection.Current(), "Current value was not the given element!");
            Assert.AreEqual(initialCollection[2], testCollection.PeekPrevious(), "Previous value was not the last element!");
            Assert.AreEqual(initialCollection[1], testCollection.PeekNext(), "Third value was not the second element!");
        }

        [Test]
        public void ConstructingWithEnumsList_StartingAtGivenElementBeginsCorrectly()
        {
            var initialCollection = new Direction[] { Direction.EAST, Direction.SOUTH, Direction.WEST };
            var testCollection = new OrderedCyclingCursor<Direction>(initialCollection, Direction.SOUTH);

            Assert.AreEqual(initialCollection[1], testCollection.Current(), "Current value was not the given element!");
            Assert.AreEqual(initialCollection[0], testCollection.PeekPrevious(), "Previous value was not the first element!");
            Assert.AreEqual(initialCollection[2], testCollection.PeekNext(), "Third value was not the last element!");
        }
    }
}