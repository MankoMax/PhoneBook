using PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Program
{
    public static List<Record> _numbers = new List<Record>();

    public static void Main()
    {
        while (true)
        {
            Clear();

            switch (ShowMenu())
            {
                case "1":
                    AddNumber();

                    break;

                case "2":
                    DeleteNumber();

                    break;

                case "3":
                    EditNumber();

                    break;

                case "4":
                    TryToPrintNumbers();

                    Console.ReadKey();

                    break;

                case "5":
                    Environment.Exit(0);

                    break;

                default:
                    Clear();

                    break;
            }
        }
    }

    public static bool ValidateNumber(string number, out string message)
    {
        if (number.Length != 9)
        {
            message = "Invalid number of characters!";

            return false;
        }

        var arrayOfNumberSymbols = number.ToCharArray();

        foreach (var numberSymbol in arrayOfNumberSymbols)
        {
            if (!char.IsDigit(numberSymbol))
            {
                message = "Invalid input characters!";

                return false;
            }
        }

        message = string.Empty;

        return true;
    }

    public static void Clear()
    {
        Console.Clear();
    }

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

    public static void EditNumber()
    {
        Clear();

        if (_numbers.Count > 0)
        {
            Console.Write("Which of the numbers should you delete?:\n");

            PrintNumbers();

            var index = int.Parse(GetDataFromUser("\nEnter the sequence number : > "));
            var selectedNumber = _numbers.ElementAt(index - 1);
            var name = GetDataFromUser("Enter the name: ", true);
            var number = GetDataFromUser("\nEnter the number in the format ХХХ-ХХХ-ХХХ: ", true);
            var numberWithoutSpecialChars = ReplaceSymbols(number);
            var isNumberValid = ValidateNumber(numberWithoutSpecialChars, out var message);

            if (isNumberValid)
            {
                selectedNumber._number = numberWithoutSpecialChars;
                selectedNumber._name = name;
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

    public static void PrintNumbers()
    {
        Clear();

        Console.WriteLine("List of all numbers: \n");

        foreach (var number in _numbers)
        {
            Console.WriteLine($"{_numbers.IndexOf(number) + 1}) Name: {number._name}; \n  Number: {number._number}\n");
        }
    }

    public static void TryToPrintNumbers()
    {
        Clear();

        if (_numbers.Count > 0)
        {
            PrintNumbers();
        }
        else
        {
            Console.WriteLine("There are no numbers!");
        }
    }

    public static string ReplaceSymbols(string number)
    {
        var regEx = new Regex(" *[\\~#%&*{}()/:<>?|\"-]+ *");
        var numberWithoutSpecialCharacters = regEx.Replace(number, string.Empty);

        return numberWithoutSpecialCharacters;
    }

    public static void AddNumber()
    {
        var inputYN = string.Empty;

        do
        {
            Clear();

            var name = GetDataFromUser("Enter the name: ", true);
            var number = GetDataFromUser("\nEnter the number in the format ХХХ-ХХХ-ХХХ: ", true);
            var numberWithoutSpecialChars = ReplaceSymbols(number);
            var record = new Record(numberWithoutSpecialChars, name);
            var isNumberValid = ValidateNumber(numberWithoutSpecialChars, out var message);

            if (!isNumberValid)
            {
                Clear();

                Console.WriteLine(message);

                inputYN = GetDataFromUser("\n\nDo you want to continue y/n? : > ");
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

                var index = int.Parse(GetDataFromUser("\nEnter the sequence number : > "));

                var isDeleted = TryToDelete(index, out var message);

                if (isDeleted)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(message);

                    inputYN = GetDataFromUser("\n\nDo you want to continue y/n? : > ");
                }
            }
            while (inputYN == "y");
        }
        else
        {
            Clear();

            Console.WriteLine("There are no numbers!");
            Console.ReadKey();
        }
    }

    public static bool TryToDelete(int index, out string message)
    {
        Clear();

        try
        {
            _numbers.RemoveAt(index - 1);

            message = string.Empty;

            return true;
        }
        catch (Exception exception)
        {
            Clear();

            message = exception.Message;

            return false;
        }
    }
}

