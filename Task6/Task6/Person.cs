namespace Task6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents person as office worker.
    /// </summary>
    internal class Person 
    {
        /// <summary>
        /// Gets/Sets person's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Writes in console a "Greeting" for person based on current time. 
        /// </summary>
        /// <param name="person">Person for greeting.</param>
        /// <param name="dateTime">Current time.</param>
        public void Greeting(Person person, DateTime dateTime)
        {
            string defaultStr = "Morning";

            int hour = dateTime.Hour;
            string greeting = defaultStr;

            if (hour < 12) greeting = "Good morning";

            if (hour >= 12 && hour < 17) greeting = "Good afternoon!";

            if (hour >= 17) greeting = "Good evening";

            Console.WriteLine($"{greeting},{person.Name}! - said {this.Name}.");
        }

        /// <summary>
        /// Writes in console a "Goodbye" for person.
        /// </summary>
        /// <param name="person">Person for goodbye.</param>
        public void GoodBye(Person person) => Console.WriteLine($"Good buy,{person.Name}!  - said {this.Name}.");
    }
}
