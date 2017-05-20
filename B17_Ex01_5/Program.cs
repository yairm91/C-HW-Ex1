namespace B17_Ex01_5
{
    using System;

    public class Program
    {
        public static void Main()
        {
            numberesStatistics();
        }

        private static void numberesStatistics()
        {
            bool isInputValid;
            string stringNumberAfterValidation = getNaturalNumberInStringWithEightDigitsFromConsole(out isInputValid);
            if(!isInputValid)
            {
                Console.WriteLine("Invalid Input, Exiting.");

                return;
            }

            string toPrint;

            toPrint = string.Format(
                @"The maximal digit in the number is: {0}
The minimal digit in the number is: {1}
The number of digits larger then the units digit is {2}
The number of digits smaller then the units digit is {3}",
getMaxDigitInNumber(stringNumberAfterValidation),
getMinDigitInNumber(stringNumberAfterValidation),
numberOfDigitsLargerThenUnitsDigit(stringNumberAfterValidation),
numberOfDigitsSmallerThenUnitsDigit(stringNumberAfterValidation));
            Console.WriteLine(toPrint);
        }

        private static int numberOfDigitsLargerThenUnitsDigit(string i_StringOfTheNumberToCountOn)
        {
            int countNumberOfDigitsLargerThenUnitsDigit = 0;
            int unitsDigit = (int)char.GetNumericValue
                (i_StringOfTheNumberToCountOn[i_StringOfTheNumberToCountOn.Length - 1]);

            for (int i = 0; i < i_StringOfTheNumberToCountOn.Length - 1; i++)
            {
                if ((int) char.GetNumericValue(i_StringOfTheNumberToCountOn[i]) > unitsDigit)
                {
                    countNumberOfDigitsLargerThenUnitsDigit++;
                }
            }

            return countNumberOfDigitsLargerThenUnitsDigit;
        }

        private static int numberOfDigitsSmallerThenUnitsDigit(string i_StringOfTheNumberToCountOn)
        {
            int countNumberOfDigitsSmallerThenUnitsDigit = 0;
            int unitsDigit = (int)char.GetNumericValue
                (i_StringOfTheNumberToCountOn[i_StringOfTheNumberToCountOn.Length - 1]);

            for (int i = 0; i < i_StringOfTheNumberToCountOn.Length - 1; i++)
            {
                if ((int)char.GetNumericValue(i_StringOfTheNumberToCountOn[i]) < unitsDigit)
                {
                    countNumberOfDigitsSmallerThenUnitsDigit++;
                }
            }

            return countNumberOfDigitsSmallerThenUnitsDigit;
        }

        private static int getMaxDigitInNumber(string i_StringOfTheNumberToFindMaxDigitIn)
        {
            int maxDigit = 0;
            int currentDigit;

            for (int i = 0; i < i_StringOfTheNumberToFindMaxDigitIn.Length; i++)
            {
                currentDigit = (int) char.GetNumericValue(i_StringOfTheNumberToFindMaxDigitIn[i]);
                maxDigit = Math.Max(currentDigit, maxDigit);
            }        
        
            return maxDigit;
        }

        private static int getMinDigitInNumber(string i_StringOfTheNumberToFindMinDigitIn)
        {
            int minDigit = 10;
            int currentDigit;

            for (int i = 0; i < i_StringOfTheNumberToFindMinDigitIn.Length; i++)
            {
                currentDigit = (int)char.GetNumericValue(i_StringOfTheNumberToFindMinDigitIn[i]);
                minDigit = Math.Min(currentDigit, minDigit);
            }

            return minDigit;
        }

        private static string getNaturalNumberInStringWithEightDigitsFromConsole(out bool o_IsInputValid)
        {
            string inputFromUser;

            Console.WriteLine("Please enter a natural number with 8 digits:");
            inputFromUser = Console.ReadLine();
            o_IsInputValid = checkIfNaturalNumberWithEightDigits(inputFromUser);

            return inputFromUser;
        }

        private static bool checkIfNaturalNumberWithEightDigits(string i_inputFromUser)
        {
            int numberAfterParse;

            bool isInputValid = i_inputFromUser.Length == 8 &&
                int.TryParse(i_inputFromUser, out numberAfterParse) &&
                numberAfterParse >= 0;

            return isInputValid;
        }
    }
}
