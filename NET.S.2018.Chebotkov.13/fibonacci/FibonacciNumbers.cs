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
            int previousSurplus = 0, divider = 3;
            for (int i = 2; i < count; i++)
            {
                int[] firstArr = GetParts(array[i-1], divider);
                int[] secondArr = GetParts(array[i-2], divider);
                int[] currentNumber = new int[firstArr.Length];
                
                for (int j = firstArr.Length - 1; j >= 0; j--)
                {
                    if (j == 0)
                    {
                        if (firstArr.Length > secondArr.Length)
                        {
                            currentNumber[0] = firstArr[0] + previousSurplus;
                        }
                        else
                        {
                            currentNumber[0] = firstArr[0] + secondArr[0] + previousSurplus;
                        }
                    }
                    else
                    {
                        previousSurplus = CheckLength(firstArr[j] + secondArr[j - 1] + previousSurplus, divider, out currentNumber[j]);
                    }
                }

                StringBuilder firstNumber = new StringBuilder();
                for (int j = 0; j < currentNumber.Length; j++)
                {
                    firstNumber.Append(currentNumber[j]);
                }

                array[i] = firstNumber.ToString();
            }


            return array;
        }

        public static int[] GetParts(string number, int divider)
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
                if (count >= divider)
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

        public static int CheckLength(int number, int divider, out int currentNumber)
        {
            int count = 0, power = 1;
            currentNumber = 0;
            while (number >= 1)
            {
                count++;
                if (count > divider)
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
    }
}
