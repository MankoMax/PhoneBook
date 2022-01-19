using PhoneBook.Managers;
using PhoneBook.Repositories;
using System;

namespace PhoneBook.Services
{
    class ValidationService : RecordRepository
    {
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

        public static void TryToPrintNumbers()
        {
            ConsoleManager.Clear();

            if (_numbers.Count > 0)
            {
                RecordRepository.PrintNumbers();
            }
            else
            {
                Console.WriteLine("There are no numbers!");
            }
        }

        public static bool TryToDelete(int index, out string message)
        {
            ConsoleManager.Clear();

            try
            {
                _numbers.RemoveAt(index - 1);

                message = string.Empty;

                return true;
            }
            catch (Exception exception)
            {
                ConsoleManager.Clear();

                message = exception.Message;

                return false;
            }
        }
    }
}
