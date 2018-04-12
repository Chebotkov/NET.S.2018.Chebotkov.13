using System;
using System.Collections.Generic;

namespace BinarySearch
{
    /// <summary>
    /// Contains binary search methods.
    /// </summary>
    public static class Searcher
    {
        #region Binary Search algorithms
        /// <summary>
        /// Implements binary search algorithm.
        /// </summary>
        /// <typeparam name="T">Necessary type.</typeparam>
        /// <param name="array">Array of objects.</param>
        /// <param name="wantedElement">Wanted element.</param>
        /// <param name="comparer">IComparer.</param>
        /// <exception cref="ArgumentNullException">Throws when one of the arguments is null.</exception>
        /// <returns>Position of wanted element. -1 if element doesn't exist.</returns>
        public static int BinarySearch<T>(T[] array, T wantedElement, IComparer<T> comparer)
        {
            if (array is null)
            {
                throw new ArgumentNullException("{0} is null.", nameof(array));
            }

            if (comparer is null)
            {
                throw new ArgumentNullException("{0} is null.", nameof(comparer));
            }

            if ((dynamic)wantedElement is null)
            {
                throw new ArgumentNullException("{0} is null.", nameof(wantedElement));
            }

            int currentPosition = (array.Length - 1) / 2, fartherPosition = array.Length, minimalPosition = 0;
            while (true)
            {
                Console.WriteLine("min = {0}, max = {1}, cur = {2}", minimalPosition, fartherPosition, currentPosition);
                if (comparer.Compare(array[currentPosition], wantedElement) == 0)
                {
                    return currentPosition;
                }

                if (currentPosition == 0 || currentPosition == array.Length - 1)
                {
                    return -1;
                }

                if (comparer.Compare(wantedElement, array[currentPosition]) < 0)
                {
                    fartherPosition = currentPosition;
                    currentPosition = (currentPosition + minimalPosition) / 2;
                }
                else
                {
                    minimalPosition = currentPosition;
                    currentPosition = (currentPosition + fartherPosition) / 2;
                }
            }
        }

        /// <summary>
        /// Implements binary search algorithm.
        /// </summary>
        /// <typeparam name="T">Necessary type.</typeparam>
        /// <param name="array">Array of objects.</param>
        /// <param name="wantedElement">Wanted element.</param>
        /// <param name="comparer">Delegate.</T> .</param>
        /// <exception cref="ArgumentNullException">Throws when one of the arguments is null.</exception>
        /// <returns>Position of wanted element. -1 if element doesn't exist.</returns>
        public static int BinarySearch<T>(T[] array, T wantedElement, Func <T, T, int> comparer)
        {
            if (array is null)
            {
                throw new ArgumentNullException("{0} is null.", nameof(array));
            }

            if (comparer is null)
            {
                throw new ArgumentNullException("{0} is null.", nameof(comparer));
            }

            if ((dynamic)wantedElement is null)
            {
                throw new ArgumentNullException("{0} is null.", nameof(wantedElement));
            }

            int currentPosition = (array.Length - 1) / 2, fartherPosition = array.Length, minimalPosition = 0;
            while (true)
            {
                if (comparer(array[currentPosition], wantedElement) == 0)
                {
                    return currentPosition;
                }

                if (currentPosition == 0 || currentPosition >= array.Length - 1)
                {
                    return -1;
                }

                if (comparer(wantedElement, array[currentPosition]) < 0)
                {
                    fartherPosition = currentPosition;
                    currentPosition = (currentPosition + minimalPosition) / 2;
                }
                else
                {
                    minimalPosition = currentPosition;
                    currentPosition = (currentPosition + fartherPosition) / 2;
                }
            }
        }
        #endregion
    }
}
