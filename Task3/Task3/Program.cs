namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Task3.Properties;

    public class Program
    {
        static void Main(string[] args)
        {

            TaskObject.Test();
            //var arrayMethods = typeof(TaskObject).GetMethods().ToList();

            //while (true)
            //{
            //    Console.Clear();

            //    Console.WriteLine(Resources.Welcome);
            //    Console.WriteLine(Resources.ChooseMethod);
            //    Console.WriteLine($"To exit type {TaskObject.ExitString}");

            //    try
            //    {
            //        for (int i = 0; i < arrayMethods.Count - 5; i++)
            //        {
            //            Console.WriteLine($"{i}:  {arrayMethods[i].Name}");
            //        }

            //        object input = Console.ReadLine();
            //        if ((input as string) == TaskObject.ExitString)
            //        {
            //            Console.Clear();
            //            Console.ForegroundColor = ConsoleColor.Yellow;
            //            Console.WriteLine(Resources.Bye);
            //            Thread.Sleep(1000);
            //            break;
            //        }

            //        arrayMethods[int.Parse(input as string)].Invoke(arrayMethods[int.Parse((input as string))], new object[0]);
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //}
        }
    }
}