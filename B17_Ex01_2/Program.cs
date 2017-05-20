using System;
using System.Text;

namespace B17_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            printSandWatchForBeginers();
        }

        private static void printSandWatchForBeginers()
        {
            string sandWatch = CreateSandWatchByHeight(5);

            Console.WriteLine(sandWatch);
        }

        public static string CreateSandWatchByHeight(int i_SandWatchHeight)
        {
            StringBuilder sandWatch = new StringBuilder();

            i_SandWatchHeight = IncreaseIfEven(i_SandWatchHeight, 1);
            sandWatch.Append(createTopHalfOfSandWatch(i_SandWatchHeight));
            sandWatch.Append(createBottomHalfOfSandWatch(i_SandWatchHeight));

            return sandWatch.ToString();
        }

        private static string createBottomHalfOfSandWatch(int i_SandWatchHeight)
        {
            StringBuilder bottomHalfSandWatch = new StringBuilder();
            int countNumberOfSpacesNeeded = (i_SandWatchHeight / 2) - 1;

            for (int i = 3; i <= i_SandWatchHeight; i++)
            {
                bottomHalfSandWatch.Append(createLineOfSandWatch(i, countNumberOfSpacesNeeded));
                countNumberOfSpacesNeeded--;
                i++;
            }

            bottomHalfSandWatch.Remove(bottomHalfSandWatch.Length - 1, 1);

            return bottomHalfSandWatch.ToString();
        }

        private static string createTopHalfOfSandWatch(int i_SandWatchHeight)
        {
            StringBuilder topHalfSandWatch = new StringBuilder();
            int countNumberOfSpacesNeeded = 0;

            for (int i = i_SandWatchHeight; i >= 1; i--)
            {
                topHalfSandWatch.Append(createLineOfSandWatch(i, countNumberOfSpacesNeeded));
                countNumberOfSpacesNeeded++;
                i--;
            }

            return topHalfSandWatch.ToString();
        }

        private static int IncreaseIfEven(int i_NumberToIncreaseIfEven, int i_NumberToAdd)
        {
            if (i_NumberToIncreaseIfEven % 2 == 0)
            {
                i_NumberToIncreaseIfEven += i_NumberToAdd;
            }

            return i_NumberToIncreaseIfEven;
        }

        private static string createLineOfSandWatch(int i_LineLength, int i_CountOfSpaces)
        {
            StringBuilder lineOfSandWatch = new StringBuilder();

            for (int i = 0; i < i_CountOfSpaces; i++)
            {
                lineOfSandWatch.Append(@" ");
            }

            for (int i = 0; i < i_LineLength; i++)
            {
                lineOfSandWatch.Append("*");
            }

            lineOfSandWatch.Append(@"
");

            return lineOfSandWatch.ToString();
        }
    }
}