using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace answers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Struct
            Coords coords1 = new Coords(1,2);
            Console.WriteLine("x = {0}, y = {1}", coords1.x, coords1.y);

            //FizzBuzz
            FizzBuzz.WriteAnswer();

            //Stop
            Console.ReadLine();
        }
    }

    //Struct - lightweight value type object
    public struct Coords
    {
        public int x, y;

        public Coords(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }

    //FizzBuzz
    public static class FizzBuzz
    {
        public static void WriteAnswer()
        {
            List<int> collection = Enumerable.Range(1, 100).ToList();

            foreach (var x in collection)
            {
                if (x % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }

                if (x % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }

                if ((x % 3 == 0) && (x % 5 == 0))
                {
                    Console.WriteLine("FizzBuzz");
                }
            }
        }
    }
}
