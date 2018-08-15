namespace Task7
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;


    class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            int count = 0;

            Console.WriteLine("Hello! I offer you to test my extension methods. The first of them is sum of the collection.");
            Console.WriteLine("To test this one lets create range.");
            Console.WriteLine("Enter integer number as index to start from.");
            int.TryParse(Console.ReadLine(), out index);
            
            Console.WriteLine("Enter integer number as count.");
            int.TryParse(Console.ReadLine(), out count);

            Console.WriteLine($"Created range is: from {index} to {index + count - 1} ");

            Console.WriteLine($"Resulting sum equals: {Enumerable.Range(index, count).GetSum()}");

            Console.WriteLine("Now lets check method which checks if input string is positive number.");

            while (true)
            {
                Console.WriteLine("Now enter string you want to check.");
                string inputNumber = Console.ReadLine();
                Console.WriteLine($"{inputNumber} Is positive? {inputNumber.IsPositive()}. ");

                Console.WriteLine("Wanna try again? Press enter, otherwise type \"1\"");

                if (Console.ReadLine() == "1") break;
            }
            
            Console.WriteLine("We try quickness of different way to calculate negative numbers count in collection.");

            while (true)
            {
                Console.WriteLine("Randomly created collection.");
                Random rnd = new Random();
                List<int> numbers = Enumerable.Range(10, 10).Aggregate(new List<int>(), (x, z) => { x.Add(rnd.Next(-100, 100)); return x; });
                Console.WriteLine(numbers.Aggregate(new StringBuilder(), (x, z) => { x.Append($"{z,5},"); return x; }).ToString());

                Stopwatch watch = new Stopwatch();

                watch.Start();
                ExtensionMethods.CountOfNegativeNumbers(numbers);
                
                watch.Stop();
                Console.WriteLine($"{watch.Elapsed.TotalMilliseconds,6}   - Straight.");


                watch.Restart();
                ExtensionMethods.CountOfNegativeNumbers(numbers, ExtensionMethods.IsNegative);
                watch.Stop();
                Console.WriteLine($"{watch.Elapsed.TotalMilliseconds,6}   - Through delegate.");

                watch.Restart();
                ExtensionMethods.CountOfNegativeNumbers(
                    numbers, 
                    delegate(int i)
                    {
                      if (i < 0) return true;
                      else return false;
                    });

                watch.Stop();
                Console.WriteLine($"{watch.Elapsed.TotalMilliseconds,6}   - Through anonymous method.");

                watch.Restart();
                ExtensionMethods.CountOfNegativeNumbers(numbers, (int i) => { if (i < 0) return true; else return false; });
                watch.Stop();
                Console.WriteLine($"{watch.Elapsed.TotalMilliseconds,6}    - Through lamba. ");

                watch.Restart();
                ExtensionMethods.CountOfNegativeNumbersLINQ(numbers);
                watch.Stop();
                Console.WriteLine($"{watch.Elapsed.TotalMilliseconds,6}    - Through LINQ method.");

                Console.WriteLine("Press enter to try again. To exit type \"1\" ");
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("Bye!");
                    Thread.Sleep(800);
                    break;
                }
            }
        }
    }
}
