using System;

namespace NunitCh2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName(string.Empty);

            Console.WriteLine(result);

            //Stop the console from closing
            Console.ReadLine();
        }
    }
}
