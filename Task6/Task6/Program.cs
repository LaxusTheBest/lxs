namespace Task6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Task6.Properties;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Resources.Welcome);

            Console.WriteLine($"Do you want write strings by yourself? Enter it now!. Otherwise you can create random string massive enter {Resources.CreateRandomCommand} .");
            Console.WriteLine($"Enter {Resources.StopCommand} when you finished with your strings.");
            
            string input = Console.ReadLine();
            var strings = new string[] { };

            if (input.Equals(Resources.CreateRandomCommand))
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter massive count.(interget number)");
                        int count = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter max string length. (integer number)");
                        int maxLength = int.Parse(Console.ReadLine());
                        strings = StringSorter.CreateRandomStringArray(count, maxLength);
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(Resources.IntegerFormatException);
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine(Resources.IntegerArgException);
                    }
                }
            }
            else
            {
                List<string> inputstrings = new List<string>();
                inputstrings.Add(input.Trim());

                while (true)
                {
                    string current = Console.ReadLine().Trim();
                    if (current.Equals("!stop")) break;

                    inputstrings.Add(current);
                }

                strings = inputstrings.ToArray();
            }

            Console.WriteLine("String array before sort.");
            StringSorter stringSorter = new StringSorter();
            Array.ForEach(strings, new Action<string>(Console.WriteLine));

            Console.WriteLine();
            Console.WriteLine("Array after sort.");
            var a = stringSorter.Sort(strings, StringSorter.StringComparer);
            Array.ForEach(a.ToArray(), new Action<string>(Console.WriteLine));

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            Office office = new Office();
        }
    }
}
