using System;
using System.Collections.Generic;
using System.Linq;

namespace ToyRobotChallenge.Collections
{
    /// <summary>
    /// Makes available a never-ending, ordered data structure.
    /// The order is preserved as it is input into the constructor.
    /// Based on a combination of a doubly-linked-list, and the Haskell 'cycle' function,
    /// the OrderedCycler will provide the current, next and previous items in the constructed collection,
    /// and when either end of the "list" is hit, it starts back at the other end.
    /// </summary>
    ///
    /// <typeparam name="T">The Type of the items held within the cycler</typeparam>
    ///
    /// <example>
    /// var cycledInts = new OrderedCycler<int>(new int[] {1,3,5,7})
    /// Console.WriteLine($"Current Int: {cycledInts.Current()}, Next Int: {cycledInts.PeekNext()}, Previous Int: {cycledInts.PeekPrevious()}");
    /// /// Outputs "Current Int: 1, Next Int: 3, Previous Int: 7"
    /// </example>
    public class OrderedCyclingCursor<T>
    {
        /// <summary>
        /// Array containing the ordered collection to cycle through
        /// </summary>
        private T[] _orderedArray { get; set; }

        /// <summary>
        /// Number of elements in the collection.
        /// Also indicates the upper reference bound - ie. `_orderedArray[_arraySize]` should throw an ArgumentOutOfBoundsException.
        /// </summary>
        private int _arraySize { get; set; }

        /// <summary>
        /// Current 0-indexed position of the cursor in the array
        /// </summary>
        private int _cursorPosition { get; set; }

        /// <summary>
        /// Creates a collection that preserves the order of "orderedArray", and sets the current cursor position over the 0th element in the sequence.
        /// Throws ArgumentNullException if orderedArray is null or empty.
        /// </summary>
        /// <param name="orderedArray"></param>
        /// <exception cref="ArgumentNullException">Thrown when input array is null or empty</exception>
        public OrderedCyclingCursor(T[] orderedArray)
        {
            if (orderedArray == null || orderedArray.Length == 0)
            {
                throw new ArgumentNullException($"Cannot create collection of size 0");
            }

            _orderedArray = orderedArray;
            _arraySize = orderedArray.Length;
            _cursorPosition = 0;
        }

        /// <summary>
        /// Creates a collection that preserves the order of "orderedArray", and sets the current cursor position over the first element in the sequence that matches the startingElement.
        /// Throws KeyNotFoundException if startingElement is not present.
        /// Throws ArgumentNullException if orderedArray is null or empty.
        /// </summary>
        /// <param name="orderedArray"></param>
        /// <exception cref="ArgumentNullException">Thrown when input array is null or empty</exception>
        /// <exception cref="KeyNotFoundException">Throws KeyNotFoundException if startingElement is not present.</exception>
        public OrderedCyclingCursor(T[] orderedArray, T startingElement)
        {
            if (orderedArray == null || orderedArray.Length == 0)
            {
                throw new ArgumentNullException($"Cannot create collection of size 0");
            }

            _orderedArray = orderedArray;
            _arraySize = orderedArray.Length;
            if (_orderedArray.Contains(startingElement))
            {
                _cursorPosition = Array.FindIndex(_orderedArray, x => x.Equals(startingElement));
            }
            else
            {
                throw new KeyNotFoundException($"orderedArray does not contain an element {startingElement}");
            }
        }

        /// <summary>
        /// Resets the cursor of the list to the first occurence of a specified element.
        /// </summary>
        /// <param name="newCurrentItem">The item to select as the current cursor value</param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException">Throws KeyNotFoundException if startingElement is not present.</exception>
        public T SetCursorToElement(T newCurrentItem)
        {
            if (_orderedArray.Contains(newCurrentItem))
            {
                _cursorPosition = Array.FindIndex(_orderedArray, x => x.Equals(newCurrentItem));
                return _orderedArray[_cursorPosition];
            }
            else
            {
                throw new KeyNotFoundException($"orderedArray does not contain an element {newCurrentItem}");
            }
        }

        /// <summary>
        /// Sets the cursor position to the nth element in the array used for construction.
        /// </summary>
        /// <param name="arrayIndex">The Index to set the cursor position to.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">If the supplied index goes beyond the original array bounds</exception>
        public T SetCursorToOriginalArrayIndex(int arrayIndex)
        {
            if (arrayIndex >= 0 && arrayIndex < _arraySize)
            {
                _cursorPosition = arrayIndex;
                return _orderedArray[_cursorPosition];
            }
            else
            {
                throw new ArgumentOutOfRangeException($"The input index must be between 0 and {_arraySize}");
            }
        }

        /// <summary>
        /// Returns the current element of the collection.
        /// </summary>
        /// <returns></returns>
        public T Current()
        {
            return _orderedArray[_cursorPosition];
        }

        /// <summary>
        /// Gets the next element of the collection, and sets it to be the current element under the cursor
        /// </summary>
        /// <returns></returns>
        public T Next()
        {
            if (_cursorPosition + 1 == _arraySize)
            {
                _cursorPosition = 0;
            }
            else
            {
                _cursorPosition += 1;
            }
            return _orderedArray[_cursorPosition];
        }

        /// <summary>
        /// Gets the previous element of the collection, and sets it to be the current element under the cursor
        /// </summary>
        /// <returns></returns>
        public T Previous()
        {
            if (_cursorPosition - 1 < 0)
            {
                // Account for the fact that _orderedArray is 0-offset
                _cursorPosition = _arraySize - 1;
            }
            else
            {
                _cursorPosition -= 1;
            }
            return _orderedArray[_cursorPosition];
        }

        /// <summary>
        /// Returns the next element of the collection without changing the current position of ther cursor
        /// </summary>
        /// <returns></returns>
        public T PeekNext()
        {
            var currentCursor = _cursorPosition;
            if (currentCursor + 1 == _arraySize)
            {
                currentCursor = 0;
            }
            else
            {
                currentCursor += 1;
            }
            return _orderedArray[currentCursor];
        }

        /// <summary>
        /// Returns the previous element of the collection without changing the current position of ther cursor
        /// </summary>
        /// <returns></returns>
        public T PeekPrevious()
        {
            var currentCursor = _cursorPosition;
            if (currentCursor - 1 < 0)
            {
                // Account for the fact that _orderedArray is 0-offset
                currentCursor = _arraySize - 1;
            }
            else
            {
                currentCursor -= 1;
            }
            return _orderedArray[currentCursor];
        }
    }
}