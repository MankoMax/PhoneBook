using System;

namespace PhoneBook.Managers
{
    class ConsoleManager
    {
        public static void Clear() => Console.Clear();

        public static string ShowMenu()
        {
            Clear();

            Console.WriteLine("1 - Add new number");
            Console.WriteLine("2 - Delete one of the numbers");
            Console.WriteLine("3 - Edit one of the numbers");
            Console.WriteLine("4 - List of all numbers");
            Console.WriteLine("\n5 - Exit the program");

            return GetDataFromUser("\nType the command and press Enter : > ");
        }

        public static string GetDataFromUser(string messageToShow, bool shouldAddNewLine = false)
        {
            if (shouldAddNewLine)
            {
                Console.WriteLine(messageToShow);
            }
            else
            {
                Console.Write(messageToShow);
            }

            var userResult = Console.ReadLine();

            return userResult;
        }
    }
}
