﻿namespace BinaryNumbers
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            binarySeries();
        }

        private static void binarySeries()
        {
            int[] userInputs = getInputsFromUser();
            string[] binaryNumbers = convertToBinary(userInputs);
            int averageNumberOfDigitsAfterBinaryConvertion = findAverageNumberOfDigits(binaryNumbers);
            int countOfMonotonicallyIncreasingSequences = findMonotonicallyIncreasingSequences(userInputs);
            int countOfMonotonicallyDecreasingSequences = findMonotonicallyDecreasingSequences(userInputs);
            int averageOfInputtedNumbers = findAverageOfInputtedNumbers(userInputs);

            string numbersToPrint = string.Format(
                @"The Numbers in binary representation are: {0}, {1}, {2} ", binaryNumbers[0], binaryNumbers[1], binaryNumbers[2]);
            string messageToPrint = string.Format(
                @"The average number of digits in the binary representation is: {0}
    The number of monotonically increasing sequences is: {1}.
    The number of monotonically decreasing sequences is: {2}.
    The average of the Values is: {3}.",
    averageNumberOfDigitsAfterBinaryConvertion,
    countOfMonotonicallyIncreasingSequences,
    countOfMonotonicallyDecreasingSequences,
    averageOfInputtedNumbers);

            Console.WriteLine(numbersToPrint);
            Console.WriteLine(messageToPrint);
            Console.WriteLine("Please press enter to exit the program.");
            Console.ReadLine();
        }

        private static int findAverageOfInputtedNumbers(int[] i_UserInputs)
        {
            int sumOfInputsValue = 0;

            for (int i = 0; i < i_UserInputs.Length; i++)
            {
                sumOfInputsValue += i_UserInputs[i];
            }

            int averageOfInputtedNumbers = sumOfInputsValue / i_UserInputs.Length;

            return averageOfInputtedNumbers;
        }

        private static int findMonotonicallyDecreasingSequences(int[] i_UserInputs)
        {
            int countOfMonotonicallyDecreasingSequences = 0;

            for (int i = 0; i < i_UserInputs.Length; i++)
            {
                bool isAMonotonicallyDecreasingSequence = checkIfAMonotonicallyDecreasingSequence(i_UserInputs[i]);
                if (isAMonotonicallyDecreasingSequence == true)
                {
                    countOfMonotonicallyDecreasingSequences++;
                }
            }

            return countOfMonotonicallyDecreasingSequences;
        }

        private static bool checkIfAMonotonicallyDecreasingSequence(int i_PoteninalMonoticallyDecreasingSequence)
        {
            int unitDigit = i_PoteninalMonoticallyDecreasingSequence % 10;
            int tensDigit = (i_PoteninalMonoticallyDecreasingSequence / 10) % 10;
            int hundredsDigit = i_PoteninalMonoticallyDecreasingSequence / 100;
            bool isMonotonicallyDecreasingSequence = unitDigit < tensDigit && tensDigit < hundredsDigit;

            return isMonotonicallyDecreasingSequence;
        }

        private static int findMonotonicallyIncreasingSequences(int[] i_UserInputs)
        {
            int countOfMonotonicallyIncreasingSequences = 0;
            for (int i = 0; i < i_UserInputs.Length; i++)
            {
                bool isAMonotonicallyIncreasingSequence = checkIfAMonotonicallyIncreasingSequence(i_UserInputs[i]);
                if (isAMonotonicallyIncreasingSequence == true)
                {
                    countOfMonotonicallyIncreasingSequences++;
                }
            }

            return countOfMonotonicallyIncreasingSequences;
        }

        private static bool checkIfAMonotonicallyIncreasingSequence(int i_PoteninalMonoticallyIncreasingSequence)
        {
            int unitDigit = i_PoteninalMonoticallyIncreasingSequence % 10;
            int tensDigit = (i_PoteninalMonoticallyIncreasingSequence / 10) % 10;
            int hundredsDigit = i_PoteninalMonoticallyIncreasingSequence / 100;
            bool isMonotonicallyIncreasingSequence = hundredsDigit < tensDigit && tensDigit < unitDigit;

            return isMonotonicallyIncreasingSequence;
        }

        private static string[] convertToBinary(int[] i_UserInputs)
        {
            string[] binaryNumbers = new string[3];
            int[] arrayOfInputsToWorkOn = new int[3];
            Array.Copy(i_UserInputs, arrayOfInputsToWorkOn, 3);

            for (int i = 0; i < arrayOfInputsToWorkOn.Length; i++)
            {
                StringBuilder binaryNumber = new StringBuilder();
                while (arrayOfInputsToWorkOn[i] != 0)
                {
                    binaryNumber.Append(arrayOfInputsToWorkOn[i] % 2);
                    arrayOfInputsToWorkOn[i] /= 2;
                }

                char[] reversalArray = binaryNumber.ToString().ToCharArray();
                Array.Reverse(reversalArray);
                binaryNumbers[i] = new string(reversalArray);
            }

            return binaryNumbers;
        }

        private static int findAverageNumberOfDigits(string[] i_BinaryNumbers)
        {
            int sumOfDigitsInNumbers = 0;

            foreach (string binaryNumber in i_BinaryNumbers)
            {
                sumOfDigitsInNumbers += binaryNumber.Length;
            }

            int averageNumberOfDigits = sumOfDigitsInNumbers / i_BinaryNumbers.Length;

            return averageNumberOfDigits;
        }

        private static int[] getInputsFromUser()
        {
            string[] arrayOfInputsFromTheUser = new string[3];
            int[] arrayOfParsedIntegers = new int[3];
            Console.WriteLine("Please Enter three numbers with 3 digits each.");

            for (int i = 0; i < 3; i++)
            {
                arrayOfInputsFromTheUser[i] = Console.ReadLine();
                if (arrayOfInputsFromTheUser[i].Length != 3)
                {
                    string messegeToUser = string.Format("{0} is not a valid input! Please try again.", arrayOfInputsFromTheUser[i]);
                    Console.WriteLine(messegeToUser);
                    i--;
                    continue;
                }

                bool didParseWork = int.TryParse(arrayOfInputsFromTheUser[i], out arrayOfParsedIntegers[i]);
                if (didParseWork == false || arrayOfParsedIntegers[i] < 0)
                {
                    string messegeToUser = string.Format("{0} is not a valid input! Please try again.", arrayOfInputsFromTheUser[i]);
                    Console.WriteLine(messegeToUser);
                    i--;
                    continue;
                }
            }

            return arrayOfParsedIntegers;
        }
    }
}
