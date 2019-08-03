using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            //The problem
            //You have a collection of integers, 1 to 100. I want you to cycle through this collection.
            //For each number found that is evenly divisible by 3, output the word "Fizz". For each
            //number that is evenly divisible by 5, output the word "Buzz". For each number that is
            //evenly divisble by both 3 and 5 output the word "FizzBuzz".

            // Basic solution 1.
            //FizzBuzz1 fb1 = new FizzBuzz1();
            //fb1.WriteAnswer();

            //Alternative solution 2.
            //FizzBuzz2 fb2 = new FizzBuzz2();
            //fb2.WriteAnswer();

            //Alternative solution 3.
            FizzBuzz3 fb3 = new FizzBuzz3();
            fb3.WriteAnswer();





            //Stop, collaborate and listen!
            //Ice is back with a brand new invention.
            //Something grabs a hold of me tightly.
            //Will it ever stop? Yo, I don't know ...
            Console.ReadLine();
        }
    }

    static class CollectionService
    {
        public static List<int> CreateCollection()
        {
            List<int> collection = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                collection.Add(i);
            }
            return collection;
        }
    }


    class FizzBuzz1
    {
        public void WriteAnswer()
        {
            var collection = CollectionService.CreateCollection();

            foreach (int i in collection)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz. i is " + i);
                }

                if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz. i is " + i);
                }

                if ((i % 3 == 0) && (i % 5 == 0))
                {
                    Console.WriteLine("FizzBuzz. i is " + i);
                }
            }
        }
    }

    class FizzBuzz2
    {
        public void WriteAnswer()
        {
            var collection = CollectionService.CreateCollection();

            foreach (int i in collection)
            {
                if (i % 3 == 0)
                {
                    Console.Write("Fizz");
                }

                if (i % 5 == 0)
                {
                    Console.Write("Buzz");
                }
            }
        }
    }

    class FizzBuzz3
    {
        public void WriteAnswer()
        {
            var collection = CollectionService.CreateCollection();

            foreach (int i in collection)
            {
                bool insertNewline = false;

                if (i % 3 == 0)
                {
                    //int is divisible by 3, so write Fizz.
                    Console.Write("Fizz");

                    //Insert a line break is true.
                    insertNewline = true;
                }

                if (i % 5 == 0)
                {
                    //int is divisible by 5, so write Buzz.
                    //If int is divisible by 3 and 5, this will write FizzBuzz.
                    Console.Write("Buzz");

                    //Insert a line break is true.
                    //Note, if divisible by 3 and 5 insertNewline is already true.
                    //This sets it to true again ... which is OK, I guess.
                    insertNewline = true;
                }

                if (insertNewline)
                {
                    //If insert line break == true, then we insert one.
                    //This gives us Fizz, Buzz or FizzBuzz.
                    Console.Write(Environment.NewLine);
                }
            }
        }
    }
}
