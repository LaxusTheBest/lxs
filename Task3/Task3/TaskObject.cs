namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Task3.Properties;

    /// <summary>
    /// Static class which contains methods to work with
    /// </summary>
    public static class TaskObject
    {
        /// <summary>
        /// String which stops method's work
        /// </summary>
        public const string ExitString = "exit";

        /// <summary>
        /// Key for the continuation of the method
        /// </summary>
        private const char ContinueKey = 'y';

        /// <summary>
        /// Default value for integer parameters
        /// </summary>
        private const int StartValue = 0;

        /// <summary>
        /// Default values for char parameters
        /// </summary>
        private const char DefaultKey = ' ';

        /// <summary>
        /// Just zero
        /// </summary>
        private const int Zero = 0;

        /// <summary>
        /// Number to exit from methods
        /// </summary>
        private const int ExitValue = -1;

        /// <summary>
        /// Number as key to exit from method
        /// </summary>
        private const int ExitKey = 9;

        /// <summary>
        /// Number indicating the size of arrays in methods
        /// </summary>
        private const int ArrayLength = 30;

        /// <summary>
        /// Decoration items
        /// </summary>
        private enum Decorations
        {
            /// <summary>
            /// Font
            /// </summary>
            Italic = 1,

            /// <summary>
            /// Text decoration
            /// </summary>
            Bold,

            /// <summary>
            /// Text decoration
            /// </summary>
            Underline
        }

        /// <summary>
        /// Calculates square of rectangle based on data entered by user 
        /// and prints result in console
        /// </summary>
        public static void SquareCalc()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(Resources.SquareCalc);
                Console.WriteLine($"To exit enter [{ExitValue}] \n");
                Console.WriteLine(Resources.SquareCalcInput);
                string[] sides = Console.ReadLine().Split(' ');

                try
                {
                    double a = double.Parse(sides[0].Trim());
                    if (a == -1)
                    {
                        break;
                    }

                    double b = double.Parse(sides[1].Trim());
                    if ((a < Zero) || (b < Zero))
                    {
                        throw new Exception(Resources.SquareCalcSideValuesUnder0);
                    }

                    Console.WriteLine($"Square of rectanlge with sides {a} and {b} equals:{a * b}. \n");

                    Console.WriteLine(Resources.Continue);
                    if (Console.ReadKey().KeyChar != ContinueKey)
                    {
                        break;
                    }
                }
                catch (FormatException e)
                {
                    LogReisteration(e, Resources.FormatExc);
                }
                catch (ArgumentNullException e)
                {
                    LogReisteration(e, Resources.SquareCalcArgNullExc);
                }
                catch (Exception e)
                {
                    LogReisteration(e, $"Error:{e.Message}");
                }
            }
        }

        /// <summary>
        /// Prints in console right triangle picture of user's chosen height
        /// </summary>
        public static void RightTriangle()
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    Console.WriteLine(Resources.RightTriangle);
                    Console.WriteLine($"To exit enter {ExitValue}'");
                    Console.WriteLine(Resources.RightTriangeInput);

                    int n = int.Parse(Console.ReadLine());
                    if (n == ExitValue)
                    {
                        break;
                    }

                    int i = StartValue;

                    do
                    {
                        for (int j = 0; j < i; j++)
                        {
                            Console.Write("*");
                        }

                        Console.WriteLine();
                        i++;
                    }
                    while (i != n + 1);

                    Console.WriteLine(Resources.Continue);
                    if (Console.ReadKey().KeyChar != ContinueKey)
                    {
                        break;
                    }
                }
                catch (FormatException e)
                {
                    LogReisteration(e, Resources.FormatExc);
                }
                catch (ArgumentNullException e)
                {
                    LogReisteration(e, Resources.ArgNullExc);
                }
                catch (Exception e)
                {
                    LogReisteration(e, $"Error:{e.Message}");
                }
            }
        }

        /// <summary>
        /// Prints in console pyramid picture of user's chosen height
        /// </summary>
        public static void PyramidPicture()
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    Console.WriteLine(Resources.PyramidPicture);
                    Console.WriteLine($"To exti enter [{ExitValue}]");
                    Console.WriteLine(Resources.PyramidPictureInput);

                    int n = int.Parse(Console.ReadLine());
                    if (n == ExitValue)
                    {
                        break;
                    }

                    int i = StartValue;

                    do
                    {
                        i++;
                        for (int j = 0; j < n - i; j++)
                        {
                            Console.Write(" ");
                        }

                        for (int j = 0; j < ((i * 2) - 1); j++)
                        {
                            Console.Write("*");
                        }

                        Console.WriteLine();
                    }
                    while (i != n);

                    Console.WriteLine(Resources.Continue);
                    if (Console.ReadKey().KeyChar != ContinueKey)
                    {
                        break;
                    }
                }
                catch (FormatException e)
                {
                    LogReisteration(e, Resources.FormatExc);
                }
                catch (ArgumentNullException e)
                {
                    LogReisteration(e, Resources.ArgNullExc);
                }
                catch (Exception e)
                {
                    LogReisteration(e, $"Error: {e.Message}");
                }
            }
        }

        /// <summary>
        /// Prints in console some pyramids pictures of different heights (from 0 to entered by the user number)
        /// </summary>
        public static void ManyPyramidsPicture()
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    Console.WriteLine(Resources.ManyPyramidPicture);
                    Console.WriteLine($"To exit enter [{ExitValue}]");
                    Console.WriteLine(Resources.ManyPyramidPictureInput);
                    int n = int.Parse(Console.ReadLine());
                    if (n == ExitValue)
                    {
                        break;
                    }

                    int f = 0;
                    do
                    {
                        f++;
                        int i = 0;
                        do
                        {
                            i++;
                            for (int j = 0; j < n - i; j++)
                            {
                                Console.Write(" ");
                            }

                            for (int j = 0; j < ((i * 2) - 1); j++)
                            {
                                Console.Write("*");
                            }

                            Console.WriteLine();
                        }
                        while (i != f);
                    }
                    while (f != n);

                    Console.WriteLine(Resources.Continue);
                    if (Console.ReadKey().KeyChar != ContinueKey)
                    {
                        break;
                    }
                }
                catch (FormatException e)
                {
                    LogReisteration(e, Resources.FormatExc);
                }
                catch (ArgumentNullException e)
                {
                    LogReisteration(e, Resources.ArgNullExc);
                }
                catch (Exception e)
                {
                    LogReisteration(e, $"Error: {e.Message}");
                }
            }
        }

        /// <summary>
        /// Prints in console result of summing numbers less than 1000 and multiple of 3 and 5
        /// </summary>
        public static void DevidedNumbersSum()
        {
            Console.Clear();

            Console.WriteLine(Resources.DividedNumbersSum);

            int numberCount = 1000;
            int result = StartValue;
            int devideNumber1 = 3;
            int devideNumber2 = 5;

            for (int i = 1; i < numberCount; i++)
            {
                result = (i % devideNumber1 == 0) || (i % devideNumber2 == 0) ? i + result : result;
            }

            Console.WriteLine($"Sum of numbers less than 1000 and multiple of {devideNumber1} and {devideNumber2} equals {result}");

            Console.WriteLine(Resources.ToExit);
            Console.ReadKey();
        }

        /// <summary>
        /// Allows user to choose text decorations.
        /// </summary>
        public static void TextDecoration()
        {
            HashSet<Decorations> selected = new HashSet<Decorations>();
            int keyIndex = StartValue;
            do
            {
                Console.Clear();
                try
                {
                    Console.WriteLine(Resources.TextDecoration);
                    Console.WriteLine(Resources.TextDecoratinToExit);
                    Console.Write(Resources.TextDecorationOptions);
                    StringBuilder sb = selected.Select(p => p.ToString()).Aggregate(new StringBuilder(), (c, s) => c.Append(s + " "));
                    Console.WriteLine(sb.ToString());
                    Console.WriteLine(string.Format("{0,13} ", "Press:"));
                    for (int i = 0; i < Enum.GetNames(typeof(Decorations)).Length; i++)
                    {
                        Console.WriteLine($"{i + 1,20}: {((Decorations)i + 1).ToString()}");
                    }

                    keyIndex = int.Parse(Console.ReadKey().KeyChar.ToString());

                    if (keyIndex == ExitKey)
                    {
                        break;
                    }

                    if (selected.Contains((Decorations)keyIndex))
                    {
                        selected.Remove((Decorations)keyIndex);
                    }
                    else
                    {
                        selected.Add((Decorations)keyIndex);
                    }
                }
                catch (FormatException e)
                {
                    LogReisteration(e, Resources.FormatExc);
                    keyIndex = StartValue;
                }
                catch (ArgumentNullException e)
                {
                    LogReisteration(e, Resources.ArgNullExc);
                    keyIndex = StartValue;
                }
                catch (Exception e)
                {
                    LogReisteration(e, $"Error: {e.Message}");
                }
            }
            while (true);
            return;
        }

        /// <summary>
        /// Sorting randomly created single array 
        /// and prints both arrays in console (before and after sorting)
        /// </summary>
        public static void ArraySort()
        {
            do
            {
                Console.Clear();
                Random rnd = new Random();

                Console.WriteLine(Resources.ArraySort);

                int[] array = new int[ArrayLength];
                StringBuilder sb = new StringBuilder();

                sb.Append(Resources.ArraySortNotSorted);

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(0, 1000);
                    sb.Append($"{array[i]} ");
                }

                Console.WriteLine(sb.ToString());

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[i] > array[j])
                        {
                            int temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }

                sb.Clear();
                sb.Append(Resources.ArraySortSorted);

                for (int i = 0; i < array.Length; i++)
                {
                    sb.Append($"{array[i]} ");
                }

                Console.WriteLine(sb.ToString());

                Console.WriteLine(Resources.Continue);
                if (Console.ReadKey().KeyChar != ContinueKey)
                {
                    break;
                }
            }
            while (true);
        }

        /// <summary>
        /// Replacing every positive number in triple array on zero 
        /// and prints both arrays in console (before and after replacing) 
        /// </summary>
        public static void ReplacingOnZero()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(Resources.ReplacingOnZero);
                int[,,] array = new int[3, 3, 3];
                Random rnd = new Random();

                Console.WriteLine(Resources.ArrayValues);
                for (int i = 0; i < array.Length / 9; i++)
                {
                    Console.WriteLine($"Array[*,*,{i + 1}]");
                    for (int j = 0; j < array.Length / 9; j++)
                    {
                        for (int l = 0; l < array.Length / 9; l++)
                        {
                            array[l, j, i] = rnd.Next(-11, 11);
                            Console.Write($"{array[l, j, i]} ");
                        }

                        Console.WriteLine("\n");
                    }

                    Console.WriteLine("\n \n");
                }

                Console.WriteLine(Resources.ReplacingOnZeroAfter);
                for (int i = 0; i < array.Length / 9; i++)
                {
                    Console.WriteLine($"Array[*,*,{i + 1}]");
                    for (int j = 0; j < array.Length / 9; j++)
                    {
                        for (int l = 0; l < array.Length / 9; l++)
                        {
                            array[l, j, i] = array[l, j, i] > Zero ? Zero : array[l, j, i];
                            Console.Write($"{array[l, j, i]} ");
                        }

                        Console.WriteLine("\n");
                    }

                    Console.WriteLine("\n \n");
                }

                Console.WriteLine(Resources.Continue);
                if (Console.ReadKey().KeyChar != ContinueKey)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Calculate sum of each positive number in array and prints result in console
        /// </summary>
        public static void SumOfPositiveArrayElements()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(Resources.PosNumbersSum);

                int sum = Zero;
                int[] array = new int[ArrayLength];
                Random rnd = new Random();

                Console.WriteLine(Resources.ArrayValues);
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(-100, 100);
                    sum = array[i] > 0 ? array[i] + sum : sum;
                    Console.Write($"{array[i]} ");
                }

                Console.WriteLine($"Sum of positive numbers in array equals {sum}");

                Console.WriteLine(Resources.Continue);
                if (Console.ReadKey().KeyChar != ContinueKey)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Counts the sum of the elements of the double array located at an even place 
        /// (a place is considered as even if the sum of the indices is divisible by 2) 
        /// and prints result in console
        /// </summary>
        public static void SumOfEvenArrayElements()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(Resources.SumOfEvenElement);

                int colsCount = 10;
                int rowsCount = 10;
                int sum = 0;

                int[,] array = new int[rowsCount, colsCount];
                Random rnd = new Random();

                Console.WriteLine(Resources.SumOfEvenElementDoubleArray);

                for (int i = 0; i < rowsCount; i++)
                {
                    for (int j = 0; j < colsCount; j++)
                    {
                        array[i, j] = rnd.Next(-50, 50);
                        sum = ((i + j) % 2 == 0) ? array[i, j] + sum : sum;
                        Console.Write($"{array[i, j],4} ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine($"\n Sum of even numbers in array equals {sum}");

                Console.WriteLine(Resources.Continue);
                if (Console.ReadKey().KeyChar != ContinueKey)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Counts average word length in string entered by user.
        /// </summary>
        public static void AverageWordLength()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(Resources.AverageWordLength);
                Console.WriteLine($"To exit type {ExitString}.\n");
                Console.WriteLine(Resources.AverageWordLengthInput);

                string str = Console.ReadLine();
                if (str.ToLower() == ExitString)
                {
                    break;
                }

                char[] spitters = new char[] { ',', '.', ' ' };

                var splited = str.Split(spitters, StringSplitOptions.RemoveEmptyEntries);

                StringBuilder sb = Enumerable.Range(Zero, splited.Length).Aggregate(new StringBuilder(), (x, q) => x.Append(splited[q]));

                double averageCapacity = (double)sb.Length / splited.Length;

                Console.WriteLine($"Average word length in you sentense equals {Math.Round(averageCapacity, 2) } .\n");

                Console.WriteLine(Resources.Continue);
                if (Console.ReadKey().KeyChar != ContinueKey)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Doubles those letters in the first line that are in the second
        /// </summary>
        public static void DoubleLettrer()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(Resources.DoubleLetter);
                Console.WriteLine($"To exit type {ExitString}.\n");
                Console.WriteLine(Resources.DoubleLetter1st);

                StringBuilder sb = new StringBuilder(Console.ReadLine());
                if (sb.ToString() == ExitString)
                {
                    break;
                }

                Console.WriteLine(Resources.DoubleLetter2nd);
                string str2 = Console.ReadLine();

                foreach (char item in str2)
                {
                    sb.Replace(item.ToString(), item.ToString() + item.ToString());
                }

                Console.WriteLine($"First string with double letters from second string equals {sb.ToString()} \n");

                Console.WriteLine(Resources.Continue);
                if (Console.ReadKey().KeyChar != ContinueKey)
                {
                    break;
                }
            }
        }

        public static void Test()
        {
            string str = string.Empty;

            StringBuilder sb = new StringBuilder();

            Stopwatch stopwatch = new Stopwatch();
            var times = new int[] { 10, 100, 1000, 10000, 100000, 200000, 300000 };
            int tries = 70;
            Dictionary<int, double> resultsString = new Dictionary<int, double>();
            Dictionary<int, double> resultsBuilder = new Dictionary<int, double>();

            foreach (var item in times)
            {
                resultsString.Add(item, Zero);
                resultsBuilder.Add(item, Zero);
            }

            for (int j = 0; j < tries; j++)
            {
                foreach (var time in times)
                {
                    stopwatch.Reset();
                    str = string.Empty;
                    sb.Clear();

                    Console.Write($"{time,7}");

                    stopwatch.Start();
                    for (int i = 0; i < time; i++)
                    {
                        str += "*";
                    }

                    stopwatch.Stop();
                    resultsString[time] = resultsString[time] == 0 ?
                        stopwatch.Elapsed.TotalSeconds : (resultsString[time] + stopwatch.Elapsed.TotalSeconds) / 2;

                    stopwatch.Restart();
                    for (int i = 0; i < time; i++)
                    {
                        sb.Append("*");
                    }

                    stopwatch.Stop();

                    resultsBuilder[time] = resultsBuilder[time] == 0 ?
                        stopwatch.Elapsed.TotalSeconds : (resultsBuilder[time] + stopwatch.Elapsed.TotalSeconds) / 2;
                }
            }
            using (StreamWriter sw = new StreamWriter("String-StringBulderResults.txt", true))
            {
                sw.WriteLine("After 100 attempts for the values of the array taken as the number of adding elements in the resulting row, the resulting average values are:");
                sw.WriteLine("{0,10} {1,12} {2,15}", "N", "String", "String builder");
                sw.WriteLine("______________________________________________________");

                foreach (var item in times)
                {
                    sw.WriteLine($"{item,10}    {resultsString[item],12}    {resultsBuilder[item],15}");
                }
            }
        }

        /// <summary>
        /// Writes logs in logfile "Logs.txt" and shows message to user
        /// </summary>
        /// <param name="e">Exception data</param>
        /// <param name="message">Message which sends to user</param>
        private static void LogReisteration(Exception e, string message)
        {
            using (StreamWriter writer = new StreamWriter("Logs.txt", true))
            {
                writer.WriteLine($"ErrorMessage: {e.Message} Time:{DateTime.Now}   StackTrace: {e.StackTrace}");
            }

            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
