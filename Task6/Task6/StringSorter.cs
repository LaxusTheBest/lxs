namespace Task6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Task6.Properties;

    /// <summary>
    /// Represent object for sorting strings.
    /// </summary>
    internal class StringSorter
    {
        public delegate int StringCompare(string st1, string str2);

        /// <summary>
        /// Sorting input string collection using as comparion input method. 
        /// </summary>
        /// <param name="collection">Input string collection.</param>
        /// <param name="comparer">Comaprion method.</param>
        /// <returns></returns>
        public  string[] Sort(string[] collection, StringCompare comparer)
        {
            for (int i = 0; i < collection.Length-1; i++)
            {
                for (int j = i+1; j < collection.Length; j++)
                {
                    if(comparer(collection[i], collection[j]) == 1)
                    {
                        string temp = collection[i];
                        collection[i] = collection[j];
                        collection[j] = temp;
                    }
                }
            }
            return collection.ToArray();
        }
        
        /// <summary>
        /// Method compares string.
        /// </summary>
        /// <param name="str1">First string.</param>
        /// <param name="str2">Secound string.</param>
        /// <returns></returns>
        public static int StringComparer(string str1,string str2)
        {
            int str1Greater = 1;
            int str2Greater = -1;

            if (str1.Length > str2.Length)
                return str1Greater;
            if (str2.Length > str1.Length)
                return str2Greater;

            return str1.CompareTo(str2);            
        }

        /// <summary>
        /// Creates random string array.
        /// </summary>
        /// <param name="count">Count of array.</param>
        /// <param name="maxLength">Max length for each word in array.</param>
        /// <returns></returns>
        public static string[] CreateRandomStringArray(int count,int maxLength)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            string[] result = new string[count];

            for (int i = 0; i < count; i++)
            {
                int range = rnd.Next(maxLength+1);
                for (int j = 0; j < range ; j++)
                {
                    sb.Append(Convert.ToChar(rnd.Next(1072,1104)));
                }
                result[i] = sb.ToString();
                sb.Clear();
            }

            return result;
        }
    }
}
