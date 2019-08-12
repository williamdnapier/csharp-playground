using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Numeric literals include underscores which are called digit separators.
            int million = 1_000_000;
            Console.WriteLine(million);

            //Binary literals can be specified with 0b prefix.
            var b = 0b1010_1011_1100_1101_1110_1111;
            Console.WriteLine(b);

            Console.WriteLine("Waiting ...");
            Console.ReadLine();
        }
    }
}
