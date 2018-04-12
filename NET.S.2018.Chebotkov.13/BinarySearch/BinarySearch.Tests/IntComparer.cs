using System.Collections.Generic;

namespace BinarySearch.Tests
{
    /// <summary>
    /// Implements IComparer.
    /// </summary>
    public class IntComparer : IComparer<int>
    {
        /// <summary>
        /// Compares two int numbers.
        /// </summary>
        /// <param name="x">First number.</param>
        /// <param name="y">Second number.</param>
        /// <returns>1 if first string greater than second. 0 if they are equal. -1 - another cases.</returns>
        public int Compare(int x, int y)
        {
            if (x == y)
            {
                return 0; 
            }

            return x > y ? 1 : -1;
        }
    }
}
