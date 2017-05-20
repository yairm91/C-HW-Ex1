namespace B17_Ex01_4
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            textAnalyzing();
        }

        private static void textAnalyzing()
        {
            string palindromeForPrint = "is not";
            bool isStringValid;
            bool isInputNumber;
            bool isStringEightCharacters;
            string messegeToPrint;

            Console.WriteLine("Please enter a string consisting of 8 characters that are either digits only or english characters only:");
            string inputFromUser = getInputFromUser(out isStringEightCharacters);
            isStringValid = checkStringValidatiy(inputFromUser, out isInputNumber);

            if (!isStringEightCharacters || !isStringValid)
            {
                Console.WriteLine("Invalid input, press Enter to exit...");

                return;
            }

            bool isStringPalindrome = checkIfStringIsPalindrome(inputFromUser);

            if (isStringPalindrome)
            {
                palindromeForPrint = "is";
            }

            messegeToPrint = getPrintMessege(palindromeForPrint, isInputNumber, inputFromUser);

            Console.WriteLine(messegeToPrint);
        }

        private static string getPrintMessege(string i_PalindromeForPrint, bool i_IsInputNumber, string i_InputFromUser)
        {
            string messegeToPrint;
            if (i_IsInputNumber)
            {
                double averageOfDigits = getAverageOfDigits(i_InputFromUser);
                messegeToPrint = string.Format(
                    @"This string {0} a palindrome.
The average value of the digits is : {1}.",
                    i_PalindromeForPrint,
                    averageOfDigits);
            }
            else
            {
                int numberOfCamelCaseCharacters = getNumberOfCamelCaseCharacters(i_InputFromUser);
                messegeToPrint = string.Format(
                    @"This string {0} a palindrome.
The number of uppercase characters is : {1}.",
                    i_PalindromeForPrint,
                    numberOfCamelCaseCharacters);
            }

            return messegeToPrint;
        }

        private static int getNumberOfCamelCaseCharacters(string i_InputFromUser)
        {
            int numberOfCamelCaseCharacters = 0;
            char[] characterArrayFromInput = i_InputFromUser.ToCharArray();

            for (int i = 0; i < i_InputFromUser.Length; i++)
            {
                if (char.IsUpper(i_InputFromUser[i]))
                {
                    numberOfCamelCaseCharacters++;
                }
            }

            return numberOfCamelCaseCharacters;
        }

        private static double getAverageOfDigits(string i_InputFromUser)
        {
            double sumOfDigits = 0;
            char[] characterArrayFromInput = i_InputFromUser.ToCharArray();

            for (int i = 0; i < characterArrayFromInput.Length; i++)
            {
                sumOfDigits = sumOfDigits + (int)char.GetNumericValue(characterArrayFromInput[i]);
            }

            return sumOfDigits / characterArrayFromInput.Length;
        }

        private static bool checkIfStringIsPalindrome(string i_InputFromUser)
        {
            char[] characterArrayOfInputString = i_InputFromUser.ToCharArray();
            bool isPalindrome = true;

            for (int i = 0; i < characterArrayOfInputString.Length / 2; i++)
            {
                if (!characterArrayOfInputString[i].Equals(characterArrayOfInputString[characterArrayOfInputString.Length - 1 - i]))
                {
                    return !isPalindrome;
                }
            }

            return isPalindrome;
        }

        private static bool checkStringValidatiy(string i_InputFromUser, out bool o_IsInputNumber)
        {
            char[] characterArrayFromInputString = i_InputFromUser.ToCharArray();
            int numberOfDigits = 0;
            int numberOfEnglishCharacters = 0;

            getCountOfCharactersAndDigits(characterArrayFromInputString, ref numberOfDigits, ref numberOfEnglishCharacters);

            bool stringIsValid = numberOfDigits == characterArrayFromInputString.Length || numberOfEnglishCharacters == characterArrayFromInputString.Length;
            o_IsInputNumber = numberOfDigits == characterArrayFromInputString.Length;

            return stringIsValid;
        }

        private static void getCountOfCharactersAndDigits(char[] i_CharacterArrayFromInputString, ref int i_NumberOfDigits, ref int i_NumberOfEnglishCharacters)
        {
            for (int i = 0; i < i_CharacterArrayFromInputString.Length; i++)
            {
                if (char.IsNumber(i_CharacterArrayFromInputString[i]))
                {
                    i_NumberOfDigits++;
                    continue;
                }

                bool isItAnEnglishLetter = Regex.IsMatch(i_CharacterArrayFromInputString[i].ToString(), @"[A-z]");
                if (isItAnEnglishLetter)
                {
                    i_NumberOfEnglishCharacters++;
                    continue;
                }
            }
        }

        private static string getInputFromUser(out bool o_IsTheStringEightCharacters)
        {
            string lineReadFromUser = Console.ReadLine();

            o_IsTheStringEightCharacters = lineReadFromUser.Length == 8;

            return lineReadFromUser;
        }
    }
}
