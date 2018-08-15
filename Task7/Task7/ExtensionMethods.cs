namespace Task7
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Class contains extension methods for my 7th task.
    /// </summary>
    internal static class ExtensionMethods 
    {
        /// <summary>
        /// Calculating sum of collection elements.
        /// </summary>
        /// <typeparam name="T"> Type has "+" operator </typeparam>
        /// <param name="array">Collection of T items</param>
        /// <returns>Collection sum</returns>
        public static double GetSum<T>(this IEnumerable<T> array) 
        {
            try
            {
                double sum = 0; 

                foreach (var item in array)
                {
                    sum += Convert.ToDouble(item);
                }

                return sum;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                Console.Read();
                return 0;
            }
        }

        /// <summary>
        /// Determine whether the string is positive integer number.
        /// </summary>
        /// <param name="str">input string</param>
        /// <returns>Returns true if string positive integer number, otherwise returns false.</returns>
        public static bool IsPositive(this string str)
        {
            if (str.Length == 0) return false;
            return Regex.IsMatch(str, @"^\d*$");            
        }

        /// <summary>
        /// Calculating count of negative numbers in input collection
        /// </summary>
        /// <param name="collections">Input collection.</param>
        /// <returns>Negative numbers count.</returns>
        public static int CountOfNegativeNumbers(IEnumerable<int> collections)
        {
            int count = 0;

            foreach (var item in collections)
            {
                if (item < 0) count++;
            }
           
            return count;
        }

        /// <summary>
        /// Calculating count of negative numbers in input collection.
        /// </summary>
        /// <param name="collection">Input collection.</param>
        /// <param name="comparer">Comparison delegate.</param>
        /// <returns>Negative numbers count.</returns>
        public static int CountOfNegativeNumbers(IEnumerable<int> collection, Func<int, bool> comparer)
        {
            int count = 0;

            foreach (var item in collection)
            {
                if (comparer(item)) count++;
            }

            return count;
        }

        /// <summary>
        /// Calculating count of negative numbers in input collection with LINQ.
        /// </summary>
        /// <param name="collection">Input collection.</param>
        /// <returns>Negative numbers count.</returns>
        public static int CountOfNegativeNumbersLINQ(IEnumerable<int> collection)
        {
            return collection.Select(n => n < 0).Count();
        }

        /// <summary>
        /// Determinate if input integer number is negative.
        /// </summary>
        /// <param name="i">Input number.</param>
        /// <returns>Returns true if negative, false if positive or equals zero.</returns>
        public static bool IsNegative(int i)
        {
            if (i < 0) return true;
            else return false;
        }
    }
}
