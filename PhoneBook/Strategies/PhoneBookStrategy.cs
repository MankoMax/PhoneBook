using System;
using PhoneBook.Managers;
using PhoneBook.Services;
using PhoneBook.Repositories;

namespace PhoneBook.Strategies
{
    class PhoneBookStrategy
    {
        public static void MainProgram()
        {
            while (true)
            {
                ConsoleManager.Clear();

                switch (ConsoleManager.ShowMenu())
                {
                    case "1":
                        RecordRepository.AddNumber();

                        break;

                    case "2":
                        RecordRepository.DeleteNumber();

                        break;

                    case "3":
                        RecordRepository.EditNumber();

                        break;

                    case "4":
                        ValidationService.TryToPrintNumbers();

                        Console.ReadKey();

                        break;

                    case "5":
                        Environment.Exit(0);

                        break;

                    default:
                        ConsoleManager.Clear();

                        break;
                }
            }
        }
    }
}
