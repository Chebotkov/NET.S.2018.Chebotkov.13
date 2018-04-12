using System;

namespace BinarySearch.Tests
{
    /// <summary>
    /// Contains methods for working with symbols.
    /// </summary>
    public class SymWorker
    {
        private readonly char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        /// <summary>
        /// Initializes a new instance of <see cref="SymWorker"/>
        /// </summary>
        public SymWorker()
        { 
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SymWorker"/>
        /// </summary>
        public SymWorker (char[] alphabet)
        {
            this.alphabet = alphabet;
        }

        /// <summary>
        /// Returns index of symbol in the alphabet.
        /// </summary>
        /// <param name="symbol">Wanted symbol.</param>
        /// <returns>Returns index of symbol in the alphabet.</returns>
        public int GetPositionOfSymbol(char symbol)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (Char.ToUpper(symbol) == alphabet[i])
                {
                    return i;
                }
            }

            return -1; 
        }
    }
}
