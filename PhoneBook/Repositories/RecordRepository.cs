using PhoneBook.Managers;
using PhoneBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Repositories
{
    class RecordRepository 
    {
        public static List<Record> _numbers = new List<Record>();
        public static void EditNumber()
        {
            ConsoleManager.Clear();

            if (_numbers.Count > 0)
            {
                Console.Write("Which of the numbers should you edit?:\n");

                PrintNumbers();

                var index = int.Parse(ConsoleManager.GetDataFromUser("\nEnter the sequence number : > "));
                var selectedNumber = _numbers.ElementAt(index - 1);
                var name = ConsoleManager.GetDataFromUser("Enter the name: ", true);
                var number = ConsoleManager.GetDataFromUser("\nEnter the number in the format ХХХ-ХХХ-ХХХ: ", true);
                var isNumberValid = ValidationService.ValidateNumber(number, out var message);

                if (isNumberValid)
                {
                    selectedNumber.Number = number;
                    selectedNumber.Name = name;
                }
                else
                {
                    Console.WriteLine(message);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("There are no numbers!");
                Console.ReadKey();
            }
        }

        public static void PrintNumbers()
        {
            ConsoleManager.Clear();

            Console.WriteLine("List of all numbers: \n");

            foreach (var number in _numbers)
            {
                Console.WriteLine($"{_numbers.IndexOf(number) + 1}) {number.ToString()}");
            }
        }

        public static void AddNumber()
        {
            var inputYN = string.Empty;

            do
            {
                ConsoleManager.Clear();

                var name = ConsoleManager.GetDataFromUser("Enter the name: ", true);
                var number = ConsoleManager.GetDataFromUser("\nEnter the number in the format ХХХ-ХХХ-ХХХ: ", true);
                var record = new Record(number, name);
                var isNumberValid = ValidationService.ValidateNumber(record.Number, out var message);

                if (!isNumberValid)
                {
                    ConsoleManager.Clear();

                    Console.WriteLine(message);

                    inputYN = ConsoleManager.GetDataFromUser("\n\nDo you want to continue y/n? : > ");
                }
                else
                {
                    _numbers.Add(record);
                }
            }
            while (inputYN == "y");
        }

        public static void DeleteNumber()
        {
            if (_numbers.Count > 0)
            {
                var inputYN = string.Empty;

                do
                {
                    Console.Write("Which of the numbers should you delete?:\n");

                    PrintNumbers();

                    var index = int.Parse(ConsoleManager.GetDataFromUser("\nEnter the sequence number : > "));

                    var isDeleted = ValidationService.TryToDelete(index, out var message);

                    if (isDeleted)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(message);

                        inputYN = ConsoleManager.GetDataFromUser("\n\nDo you want to continue y/n? : > ");
                    }
                }
                while (inputYN == "y");
            }
            else
            {
                ConsoleManager.Clear();

                Console.WriteLine("There are no numbers!");
                Console.ReadKey();
            }
        }


    }
}
