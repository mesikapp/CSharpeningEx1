using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDateTime = DateTime.Now;

            // using "d" for short format of Date, without time 00:00:00
            Console.WriteLine($"Today is: {currentDateTime.Date.ToString("d")}");

            Console.WriteLine($"Day of the year: {currentDateTime.DayOfYear}");

            Console.WriteLine($"Next leap year starting with tuesday is: {NextLeapWithTuesday(currentDateTime.Year)}");

            Console.Write("Enter valid e-mail address: ");
            var userEmail = Console.ReadLine();
            if (!IsEmailValid(userEmail))
            {
                Console.WriteLine($"'{userEmail}' is not valid e-mail address! :(");
            }
            else
            {
                Console.WriteLine($"'{userEmail}' is indeed valid e-mail address.");
            }

            List<int> userSequence = new List<int>();
            userSequence = AskForNumbers();
            if (userSequence.Count() == 0)
            {
                Console.WriteLine($"No numbers were entered to calculate sum!");
            }
            else
            {
                Console.WriteLine($"Sum of entered numbers is: {userSequence.Sum()}");
            }
            
            Console.Write("\nPress any key to exit ...");
            Console.ReadKey();
        }

        static bool IsItLeapYear(int year)
        {
            if (year % 4 != 0)
            {
                return false;
            }
            else if (year % 100 == 0 && year % 400 != 0)
            {
                return false;
            }
            return true;
        }

        static int NextLeapWithTuesday(int currentYear)
        {
            bool isLeapWithTuesday = false;
            while (!isLeapWithTuesday)
            {
                if (!IsItLeapYear(currentYear))
                {
                    currentYear++;
                }
                else
                {
                    DateTime dt = new DateTime(currentYear, 01, 01);
                    if (dt.DayOfWeek.ToString() != "Tuesday")
                    {
                        currentYear++;
                    }
                    else
                    {
                        isLeapWithTuesday = true;
                    }
                }
            }
            return currentYear;
        }

        static bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        static List<int> AskForNumbers()
        {
            List<int> userSequence = new List<int>();
            bool userQuit = false;
            while (!userQuit)
            {
                Console.Write("Enter a number or 'e' to end: ");
                var userEntry = Console.ReadLine();
                if (userEntry.ToLower() == "e")
                {
                    Console.WriteLine("User quit!");
                    userQuit = true;
                }
                else
                {
                    if (!int.TryParse(userEntry, out int number))
                    {
                        Console.WriteLine($"'{userEntry}' is not a valid number (int)!");
                    }
                    else
                    {
                        userSequence.Add(number);
                    }
                }
            }
            return userSequence;
        }
    }
}
