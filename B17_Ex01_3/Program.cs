namespace B17_Ex01_3
{
    using System;
    using ProgramOfSection2 = B17_Ex01_2.Program;

    public class Program
    {
        public static void Main()
        {
            printSandWatchForExperts();
        }

        private static void printSandWatchForExperts()
        {
            int sandWatchHeight = parsingInputSandWatchHeightFromConsole();

            if (sandWatchHeight == -1)
            {
                Console.WriteLine("Invalid Input, Exiting.");

                return;
            }

            Console.WriteLine(ProgramOfSection2.CreateSandWatchByHeight(sandWatchHeight));
        }

        private static int parsingInputSandWatchHeightFromConsole()
        {
            string sandWatchHeightStr;
            int sandWatchHeight;
            bool tryParseResult;

            Console.WriteLine("Please enter non-negetive sand watch height:");
            sandWatchHeightStr = Console.ReadLine();
            tryParseResult = int.TryParse(sandWatchHeightStr, out sandWatchHeight);
            if (!tryParseResult || sandWatchHeight < 0)
            {
                sandWatchHeight = -1;
            }

            return sandWatchHeight;
        }
    }
}
