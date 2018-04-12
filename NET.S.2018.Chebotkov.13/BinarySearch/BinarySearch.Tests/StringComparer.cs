using System.Collections.Generic;

namespace BinarySearch.Tests
{
    /// <summary>
    /// Implements IComparer.
    /// </summary>
    public class StringComparer : IComparer<string>
    {
        private SymWorker symWorker = new SymWorker();

        /// <summary>
        /// Compares two strings.
        /// </summary>
        /// <param name="x">First string.</param>
        /// <param name="y">Second string.</param>
        /// <returns>1 if first string greater than second. 0 if they are equal. -1 - another cases.</returns>
        public int Compare(string x, string y)
        {
            int minLength = x.Length < y.Length ? x.Length : y.Length;
            for (int i = 0; i < minLength; i++)
            {
                int xSymPosition = symWorker.GetPositionOfSymbol(x[i]);
                int ySymPosition = symWorker.GetPositionOfSymbol(y[i]);
                if (xSymPosition < ySymPosition)
                {
                    return -1;
                }
                else if (xSymPosition > ySymPosition)
                {
                    return 1;
                }
            }
            
            if (x.Length == y.Length)
            {
                return 0;
            }

            return x.Length < y.Length ? -1 : 1;
        }
    }
}
