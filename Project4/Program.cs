namespace TextAnalayzing
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
            bool isStringValid = false;
            bool isInputNumber = false;
            string messegeToPrint = string.Empty;

            Console.WriteLine("Please enter a string consisting of 8 characters that are either digits only or english characters only:");
            string inputFromUser = getInputFromUser();
            isStringValid = checkStringValidatiy(inputFromUser, out isInputNumber);

            while (isStringValid == false)
            {
                Console.WriteLine("The input is invalid, try again.");
                inputFromUser = getInputFromUser();
                isStringValid = checkStringValidatiy(inputFromUser, out isInputNumber);
            }

            bool isStringPalindrome = checkIfStringIsPalindrome(inputFromUser);

            if (isStringPalindrome == true)
            {
                palindromeForPrint = "is";
            }

            if (isInputNumber == true)
            {
                double averageOfDigits = getAverageOfDigits(inputFromUser);
                messegeToPrint = string.Format(
                    @"This string {0} a palindrome.
The average value of the digits is : {1}.",
                    palindromeForPrint,
                    averageOfDigits);
            }
            else
            {
                int numberOfCamelCaseCharacters = getNumberOfCamelCaseCharacters(inputFromUser);
                messegeToPrint = string.Format(
                    @"This string {0} a palindrome.
The number of uppercase characters is : {1}.",
                    palindromeForPrint,
                    numberOfCamelCaseCharacters);
            }

            Console.WriteLine(messegeToPrint);
            Console.WriteLine("Please press enter to exit the program:");
            Console.ReadLine();
        }

        private static int getNumberOfCamelCaseCharacters(string i_InputFromUser)
        {
            int numberOfCamelCaseCharacters = 0;
            char[] characterArrayFromInput = i_InputFromUser.ToCharArray();

            for (int i = 0; i < i_InputFromUser.Length; i++)
            {
                if (char.IsUpper(i_InputFromUser[i]) == true)
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
                if (characterArrayOfInputString[i].Equals(characterArrayOfInputString[characterArrayOfInputString.Length - 1 - i]) == false)
                {
                    return !isPalindrome;
                }
            }

            return isPalindrome;
        }

        private static bool checkStringValidatiy(string i_InputFromUser, out bool i_IsInputNumber)
        {
            char[] characterArrayFromInputString = i_InputFromUser.ToCharArray();
            int numberOfDigits = 0;
            int numberOfEnglishCharacters = 0;
            bool stringIsValid = true;

            for (int i = 0; i < characterArrayFromInputString.Length; i++)
            {
                if (char.IsNumber(characterArrayFromInputString[i]) == true)
                {
                    numberOfDigits++;
                    continue;
                }

                bool isItAnEnglishLetter = Regex.IsMatch(characterArrayFromInputString[i].ToString(), @"[A-z]");
                if (isItAnEnglishLetter == true)
                {
                    numberOfEnglishCharacters++;
                    continue;
                }
            }

            if (numberOfDigits != characterArrayFromInputString.Length && numberOfEnglishCharacters != characterArrayFromInputString.Length)
            {
                i_IsInputNumber = false;
                return !stringIsValid;
            }
            else
            {
                if (numberOfDigits == characterArrayFromInputString.Length)
                {
                    i_IsInputNumber = true;
                }
                else
                {
                    i_IsInputNumber = false;
                }

                return stringIsValid;
            }
        }

        private static string getInputFromUser()
        {
            string lineReadFromUser = Console.ReadLine();
            while (lineReadFromUser.Length != 8)
            {
                Console.WriteLine("This input is not 8 characters long, try again.");
                lineReadFromUser = Console.ReadLine();
            }

            return lineReadFromUser;
        }
    }
}
