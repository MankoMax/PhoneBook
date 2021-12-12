using System;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
        var numbers = new List<string>();

        var input = string.Empty;

        var inputYN = string.Empty;

        while (true)
        {

            Console.Clear();
            Console.WriteLine("1 - Add new number");
            Console.WriteLine("2 - Delete one of the numbers");
            Console.WriteLine("3 - Edit one of the numbers");
            Console.WriteLine("4 - List of all numbers");
            Console.WriteLine("\n5 - Exit the program");
            Console.Write("\nType the command and press Enter: > ");

            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();

                    do
                    {
                        Console.Clear();

                        Console.WriteLine("Enter the number in the format ХХХ-ХХХ-ХХХ: ");

                        var number = Console.ReadLine();

                        var numberWithoutSpecialCharacters = number.Replace("+", "").Replace("-", "").Replace(":", "").Replace("(", "").Replace(")", "").Replace(" ", "");

                        var arrayOfNumberSymbols = numberWithoutSpecialCharacters.ToCharArray();


                        if (numberWithoutSpecialCharacters.Length != 9)
                        {
                            Console.Clear();

                            Console.WriteLine("Invalid number of characters! \n\nDo you want to continue y/n?");

                            inputYN = Console.ReadLine();

                            continue;
                        }

                        var numberContainsNonDigitCharacters = false;

                        foreach (var numberSymbol in arrayOfNumberSymbols)
                        {
                            if (!char.IsDigit(numberSymbol))
                            {
                                numberContainsNonDigitCharacters = true;

                                break;
                            }
                        }

                        if (numberContainsNonDigitCharacters)
                        {
                            Console.Clear();

                            Console.WriteLine("Invalid input characters!\n\nDo you want to continue y/n?");

                            inputYN = Console.ReadLine();

                            continue;
                        }
                        numbers.Add(numberWithoutSpecialCharacters);

                        break;
                    }
                    while (inputYN == "y");

                    break;

                case "2":

                    Console.Clear();

                    if (numbers.Count > 0)
                    {
                        var isExceptionOccured = false;

                        do
                        {
                            try
                            {
                                Console.Clear();

                                Console.WriteLine("Which of the numbers should you delete?: \n");

                                foreach (var number in numbers)
                                {
                                    Console.WriteLine($"{numbers.IndexOf(number) + 1}) {number};");
                                }

                                Console.WriteLine("\nEnter the sequence number: > ");

                                var index = int.Parse(Console.ReadLine());

                                numbers.RemoveAt(index - 1);

                                isExceptionOccured = false;

                            }
                            catch
                            {
                                isExceptionOccured = true;

                                Console.Clear();

                                Console.WriteLine("Invalid input!\n\nDo you want to continue y/n?");

                                inputYN = Console.ReadLine();
                            }
                        }
                        while (isExceptionOccured && inputYN == "y");

                    }
                    else
                    {
                        Console.WriteLine("There are no numbers!");

                        Console.ReadKey();
                    }

                    break;

                case "3":

                    Console.Clear();

                    if (numbers.Count > 0)
                    {
                        var isExceptionOccured = false;

                        do
                        {
                            try
                            {
                                Console.Clear();

                                Console.WriteLine("Which of the numbers should you edit?: \n");

                                foreach (var number in numbers)
                                {
                                    Console.WriteLine($"{numbers.IndexOf(number) + 1}) {number};");
                                }

                                Console.WriteLine("\nEnter the sequence number: > ");

                                var index = int.Parse(Console.ReadLine());

                                numbers.RemoveAt(index - 1);

                                do
                                {
                                    Console.Clear();

                                    Console.WriteLine("Enter the number in the format ХХХ-ХХХ-ХХХ: ");

                                    var number = Console.ReadLine();

                                    var numberWithoutSpecialCharacters = number.Replace("+", "").Replace("-", "").Replace(":", "").Replace("(", "").Replace(")", "").Replace(" ", "");

                                    var arrayOfNumberSymbols = numberWithoutSpecialCharacters.ToCharArray();


                                    if (numberWithoutSpecialCharacters.Length != 9)
                                    {
                                        Console.Clear();

                                        Console.WriteLine("Invalid number of characters! \n\nDo you want to continue y/n?");

                                        inputYN = Console.ReadLine();

                                        continue;
                                    }

                                    var numberContainsNonDigitCharacters = false;

                                    foreach (var numberSymbol in arrayOfNumberSymbols)
                                    {
                                        if (!char.IsDigit(numberSymbol))
                                        {
                                            numberContainsNonDigitCharacters = true;

                                            break;
                                        }
                                    }

                                    if (numberContainsNonDigitCharacters)
                                    {
                                        Console.Clear();

                                        Console.WriteLine("Invalid input characters!\n\nDo you want to continue y/n?");

                                        inputYN = Console.ReadLine();

                                        continue;
                                    }
                                    numbers.Add(numberWithoutSpecialCharacters);

                                    break;
                                }
                                while (inputYN == "y");

                                break;

                                isExceptionOccured = false;

                            }
                            catch
                            {
                                isExceptionOccured = true;

                                Console.Clear();

                                Console.WriteLine("Invalid input!\n\nDo you want to continue y/n?");

                                inputYN = Console.ReadLine();
                            }
                        }
                        while (isExceptionOccured && inputYN == "y");

                    }
                    else
                    {
                        Console.WriteLine("There are no numbers!");

                        Console.ReadKey();
                    }

                    break;

                case "4":
                    Console.Clear();

                    if (numbers.Count > 0)
                    {
                        Console.WriteLine("List of all numbers: \n");

                        foreach (var number in numbers)
                        {
                            Console.WriteLine($"{numbers.IndexOf(number) + 1}) {number};");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no numbers!");
                    }

                    Console.ReadKey();

                    break;

                case "5":

                    Console.Clear();

                    Environment.Exit(0);

                    break;

                default:

                    Console.Clear();

                    break;
            }
        }

    }
}

