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
            Console.WriteLine("Calling struct");
            Coords coords1 = new Coords(1,2);
            Console.WriteLine("x = {0}, y = {1}", coords1.x, coords1.y);

            Console.WriteLine(Environment.NewLine);

            //Interface
            Console.WriteLine("Calling interface");
            Document doc = new Document();
            doc.Read();
            object o = new object();
            doc.Write(o);

            Console.WriteLine(Environment.NewLine);

            //Enum
            Console.WriteLine("Calling enum");
            BorderSide leftBorder = BorderSide.Left;
            bool isLeft = leftBorder == BorderSide.Left;
            Console.WriteLine(isLeft);

            Console.WriteLine(Environment.NewLine);

            //Generics
            Console.WriteLine("Calling generic");
            GenericList<int> list1 = new GenericList<int>();
            list1.Add(1);
            GenericList<string> list2 = new GenericList<string>();
            list2.Add("string");

            Console.WriteLine(Environment.NewLine);

            //Delegate
            Console.WriteLine("Calling delegate");
            Transformer t = Square;
            int result = t(3);
            Console.WriteLine(result);

            Console.WriteLine(Environment.NewLine);

            //FizzBuzz
            Console.WriteLine("Calling FizzBuzz");
            FizzBuzz.WriteAnswer();

            //Stop
            Console.ReadLine();
        }

        static int Square(int x) => x * x;
    }

    //Struct - value type object
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

    //Interface - abstract spec for a class. Classes can inherit multiple.
    interface IStorable
    {
        void Read();
        void Write(object o);
        int Status { get; set; }
    }

    public class Document : IStorable
    {
        public int Status { get; set; }

        public void Read()
        {
            Console.WriteLine("Document implementing IStorable Read");
        }

        public void Write(object o)
        {
            Console.WriteLine("Document implementing IStorable Write");
        }
    }

    //Enum - value type, group of numeric constants
    public enum BorderSide
    {
        Left,
        Right
    }

    //Generics - increase type safety and reduce casting
    public class GenericList<T>
    {
        public void Add(T input) { }
    }

    //Delegate - wires up caller method to target method at runtime.
    delegate int Transformer(int x);

}
