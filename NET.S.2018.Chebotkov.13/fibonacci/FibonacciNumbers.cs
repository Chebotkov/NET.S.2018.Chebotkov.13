using System;
using System.Collections.Generic;
using System.Text;

namespace fibonacci
{
    /// <summary>
    /// Contains generator of the fibonacci numbers.
    /// </summary>
    public static class FibonacciNumbers
    {
        #region Public Methods
        /// <summary>
        /// Generate array of Fibonacci numbers.
        /// </summary>
        /// <param name="count">Count of numbers.</param>
        /// <returns>ulong[] Array of Fibonacci numbers.</returns>
        public static ulong[] FibonacciGenerator(int count)
        {
            ulong[] array = new ulong[count];
            array[0] = 0;
            array[1] = 1;
            for (int i = 2; i < count; i++)
            {
                array[i] = array[i - 1] + array[i - 2];
            }

            return array;
        }
        
        /// <summary>
        /// Generate array of Fibonacci numbers.
        /// </summary>
        /// <param name="count">Count of numbers.</param>
        /// <returns>string[] Array of Fibonacci numbers.</returns>
        public static string[] StringFibonacciGenerator(int count)
        {
            string[] array = new string[count];
            array[0] = "0";
            array[1] = "1";
            int previousSurplus = 0, divisor = 1;
            for (int i = 2; i < count; i++)
            {
                previousSurplus = 0;
                int[] firstArr = GetParts(array[i - 1], divisor);
                int[] secondArr = GetParts(array[i - 2], divisor);
                List<int> currentNumber = new List<int>();

                for (int j = firstArr.Length - 1; j >= 0; j--)
                {
                    if (j == 0)
                    {
                        if (firstArr.Length > secondArr.Length)
                        {
                            previousSurplus = CheckLength(firstArr[0] + previousSurplus, divisor, out int num);
                            currentNumber.Add(num);
                        }
                        else
                        {
                            previousSurplus = CheckLength(firstArr[0] + secondArr[0] + previousSurplus, divisor, out int num);
                            currentNumber.Add(num);
                        }
                    }
                    else
                    {
                        if (firstArr.Length > secondArr.Length)
                        {
                            previousSurplus = CheckLength(firstArr[j] + secondArr[j - 1] + previousSurplus, divisor, out int num);
                            currentNumber.Add(num);
                        }
                        else
                        {
                            previousSurplus = CheckLength(firstArr[j] + secondArr[j] + previousSurplus, divisor, out int num);
                            currentNumber.Add(num);
                        }
                    }
                }

                if (previousSurplus > 0)
                {
                    currentNumber.Add(previousSurplus);
                }

                currentNumber.Reverse();
                StringBuilder firstNumber = new StringBuilder();
                for (int j = 0; j < currentNumber.Count; j++)
                {
                    firstNumber.Append(currentNumber[j]);
                }

                array[i] = firstNumber.ToString();
            }


            return array;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Returs divided by a divisor number.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <param name="divisor">Divisor.</param>
        /// <returns>Returs divided by a divisor number.</returns>
        private static int[] GetParts(string number, int divisor)
        {
            List<int> arr = new List<int>();
            int power = 1, count = 0, currentNumber = 0, index = number.Length - 1;
            while (true)
            {
                if (index < 0)
                {
                    arr.Add(currentNumber);
                    arr.Reverse();
                    return arr.ToArray();
                }
                if (count >= divisor)
                {
                    arr.Add(currentNumber);
                    count = 0;
                    currentNumber = 0;
                    power = 1;
                    continue;
                }
                else
                {
                    currentNumber += Int32.Parse(number.Substring(index, 1)) * power;
                }

                index--;
                count++;
                power *= 10;
            }
        }

        /// <summary>
        /// Calculates surplus and the number in the divisor limit.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <param name="divisor">divisor.</param>
        /// <param name="currentNumber">The number in the divisor limit.</param>
        /// <returns>Surplus of the number in dependence of divisor.</returns>
        private static int CheckLength(int number, int divisor, out int currentNumber)
        {
            int count = 0, power = 1;
            currentNumber = 0;
            while (number >= 1)
            {
                count++;
                if (count > divisor)
                {
                    return number;
                }
                else
                {
                    currentNumber += number % 10 * power;
                }
                power *= 10;
                number /= 10;
            }

            return 0;
        }
        #endregion
    }
}
