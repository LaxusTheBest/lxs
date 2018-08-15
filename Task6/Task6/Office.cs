namespace Task6
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading;
    using Task6.Properties;

    /// <summary>
    /// Represents office.
    /// </summary>
    internal class Office
    {        
        /// <summary>
        /// Default value for arguments and start value for variable.
        /// </summary>
        private const int DefaultInt = 0;
        
        /// <summary>
        /// A messages for user when Office has been opened.
        /// </summary>
        private readonly string officeOpenedString = "Office just has oppened. Let's start the work!"
            + " \n Use commads to work with office:"
            + $"\n {Resources.ComeCommand} [person name] - creating persons with entered name and delegate it to the office."
            + $"\n {Resources.OutCommand} [person name] - delegates person out of the office."
            + $"\n {Resources.GetPersonsCommand}- returns list of persons currently in the office."
            + $"\n {Resources.AddHoursCommand} [hours value] - add count of entered hours to the time of the office."
            + $"\n {Resources.AddMinutesCommand} [minutes value] - add count of entered hours to the time of the office."
            + $"\n {Resources.AddSecoundsCommand} [secounds value] - add count of entered secounds to the time of the office."
            + $"\n {Resources.TimeNowCommand} - shows current time in the office."
            + $"\n {Resources.CloseCommand} - closes the office";

        /// <summary>
        /// List of person who is currently in the office.
        /// </summary>
        private List<Person> persons = new List<Person>();

        /// <summary>
        /// Number of hours been added by user.
        /// </summary>
        private int addedHours = DefaultInt;

        /// <summary>
        /// Number of minutes been added by user.
        /// </summary>
        private int addedMinues = DefaultInt;

        /// <summary>
        /// Number of seconds been added by user.
        /// </summary>
        private int addedSecounds = DefaultInt;

        /// <summary>
        /// Initializes a new instance of the Office class.
        /// </summary>
        public Office()
        {
            this.OfficeOpened();
        }

        /// <summary>
        /// Initializes a new instance of the Office class.
        /// </summary>
        /// <param name="persons">persons in the office on open.</param>
        /// <param name="officeTime">Time in the office on open.</param>
        public Office(List<Person> persons, DateTime officeTime)
        {
            persons.AddRange(persons);
            this.OfficeOpened();
        }

        /// <summary>
        /// Invokes when someone come to the office
        /// </summary>
        private event EventHandler<Person> OnCome;

        /// <summary>
        /// Invokes when someone leave the office;
        /// </summary>
        private event EventHandler<Person> OnOut;

        /// <summary>
        /// Method imitates office work process.
        /// </summary>
        private void OfficeOpened()
        {
            Console.WriteLine(this.officeOpenedString);
            this.OnCome += this.Office_OnCome;
            this.OnOut += this.Office_OnOut;
            this.CurrentTime();

            while (true)
            {
                string str = Console.ReadLine().Trim();

                try
                {
                    if (Regex.IsMatch(str.ToLower(), string.Format(@"^{0} (\w*)", Resources.ComeCommand)))
                    {
                        this.Come(str.Substring(5));
                        continue;
                    }

                    if (Regex.IsMatch(str.ToLower(), string.Format(@"^{0} (\w*)", Resources.OutCommand)))
                    {
                        this.Out(str.Substring(4));
                        continue;
                    }

                    if (Regex.IsMatch(str.ToLower(), string.Format(@"^{0}$", Resources.GetPersonsCommand)))
                    {
                        this.Getpersons();
                        continue;
                    }

                    if (Regex.IsMatch(str.ToLower(), string.Format(@"^{0} (\d*)", Resources.AddHoursCommand)))
                    {
                        this.TimeManipulation(hours: Convert.ToInt32(str.Substring(9)));
                        continue;
                    }

                    if (Regex.IsMatch(str.ToLower(), string.Format(@"^{0} (\d*)", Resources.AddMinutesCommand)))
                    {
                        this.TimeManipulation(minutes: Convert.ToInt32(str.Substring(11)));
                        continue;
                    }

                    if (Regex.IsMatch(str.ToLower(), string.Format(@"^{0} (\d*)", Resources.AddSecoundsCommand)))
                    {
                        this.TimeManipulation(Convert.ToInt32(str.Substring(12)));
                        continue;
                    }

                    if (Regex.IsMatch(str.ToLower(), string.Format(@"^{0}$", Resources.TimeNowCommand)))
                    {
                        this.CurrentTime();
                        continue;
                    }

                    if (Regex.IsMatch(str.ToLower(), string.Format(@"^{0}$", Resources.CloseCommand)))
                    {
                        Console.WriteLine("Office closing...");
                        Thread.Sleep(700);
                        Console.WriteLine("It's closed.Bye!");
                        Thread.Sleep(1000);

                        break;
                    }

                    Console.WriteLine("Office did not understand what you want. Try again.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect input data. Try again");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error:{e.Message}");
                }
            }
        }

        /// <summary>
        /// Method manipulating time in the office.
        /// </summary>
        /// <param name="hours">Number of hours to add to current time.</param>
        /// <param name="minutes">Number of minutes to add to current time.</param>
        /// <param name="secounds">Number of seconds to add to current time.</param>
        private void TimeManipulation(int hours = DefaultInt, int minutes = DefaultInt, int secounds = DefaultInt)
        {
            this.addedHours += hours;
            this.addedMinues += minutes;
            this.addedSecounds += secounds;

            Console.WriteLine($"Added time: {hours} - hours , {minutes} - minutes, {secounds} -secounds.");

            this.CurrentTime();
        }

        /// <summary>
        /// Writes in console current time in the office.
        /// </summary>
        private void CurrentTime()
        {
            Console.WriteLine($"\nCurrent time in the office: {GetTime()}");
        }

        /// <summary>
        /// Creates new person and bring him to the office.
        /// </summary>
        /// <param name="name">Person name.</param>
        private void Come(string name)
        {
            Person cur = new Person() { Name = name.Trim() };
            this.OnCome(this, cur);
            this.persons.Add(cur);
        }

        /// <summary>
        /// Calculating time time in the office with added time.
        /// </summary>
        /// <returns>Current time in the office.</returns>
        private DateTime GetTime()
        {
            return DateTime.Now.AddHours(this.addedHours).AddMinutes(this.addedMinues).AddSeconds(this.addedSecounds);
        }

        /// <summary>
        /// Removes person from office.
        /// </summary>
        /// <param name="name">Person name.</param>
        private void Out(string name)
        {
            Person cur = this.persons.FindLast(n => n.Name.ToLower() == name.Trim().ToLower());
            if (cur == null)
            {
                Console.WriteLine($"\nPerson with name {name} was not found.");
                return;
            }

            this.persons.Remove(cur);

            this.OnOut(this, cur);            
        }

        /// <summary>
        /// Writes in console list of persons who currently is in the office.
        /// </summary>
        private void Getpersons()
        {
            Console.WriteLine("\nCurrently at the office:");

            foreach (var item in this.persons)
            {
                Console.WriteLine(item.Name);
            }
        }

        /// <summary>
        /// Imitates persons behavior when persons leaves from the office.
        /// </summary>
        /// <param name="sender">Office</param>
        /// <param name="e">Person</param>
        private void Office_OnOut(object sender, Person e)
        {
            foreach (var item in this.persons)
            {
                item.GoodBye(e);
            }

            Console.WriteLine($"\n{e.Name} left the office.");
        }

        /// <summary>
        /// Imitates persons behavior when person come to the office.
        /// </summary>
        /// <param name="sender">Office.</param>
        /// <param name="e">Person who came to the office.</param>
        private void Office_OnCome(object sender, Person e)
        {
            DateTime currentTime = this.GetTime();

            Console.WriteLine($"\n{e.Name} entered in the office.");
            foreach (Person item in this.persons)
            {
                item.Greeting(e, currentTime);
            }
        }
    }
}
