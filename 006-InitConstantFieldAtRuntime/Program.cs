using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_InitConstantFieldAtRuntime
{
    class Program
    {
        static void Main(string[] args)
        {

            //Calling instance readonly field.
            //Bottom example in this file.
            Foo3 obj3 = new Foo3(100);
            Console.WriteLine(obj3.x);

            Console.ReadLine();
        }
    }

    //You have (2) choices to declare a constant in code.
    //01. Use the READONLY field.
    //02. Use the const field.

    //If you need to initialize the constant at runtime, you have to use READONLY.
    //const can only be initialized at compile time.
    public class Foo
    {
        public readonly int bar;

        public Foo() { }

        public Foo(int constInitValue)
        {
            bar = constInitValue;
        }

        //Rest of class ...
    }

    //There are (2) ways to initialize a readonly field.
    //01. Add an initialized to the field itself.
    public class Foo2
    {
        public readonly int bar = 100;
    }

    //02. Initialize the readonly field through a constructor.
    public class Foo3
    {
        public readonly int x;
        public const int y = 1;

        public Foo3() { }
        public Foo3(int roInitValue)
        {
            x = roInitValue;
        }

        //Rest of class ...
    }
}
