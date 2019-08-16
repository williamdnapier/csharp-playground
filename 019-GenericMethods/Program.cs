using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_GenericMethods
{
    class Program
    {
        static void Main(string[] args)
        {

            //Call Program2 which has a generic method.
            Program2.Write();

            //Keep the console open.
            Console.ReadLine();
        }
    }

    class Program2
    {
        //Generic method
        static void Swap<T>(ref T a, ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        public static void Write()
        {

            //Swap of two integers
            int a = 40;
            int b = 60;

            Console.WriteLine("Before swap: {0}, {1}", a, b);

            Swap<int>(ref a, ref b);

            Console.WriteLine("After swap: {0}, {1}", a, b);


        }

        //Discussion.
        //Most developers will use generic types within the base class libraries, it is 
        //certainly possible to build your own generic members and custom generic types.

        //The objective of this example is to build a swap method that can operate on any
        //possible data type (value-based or reference-based) using a single type parameter.
        //Due to the nature of swapping algorithms, the incoming parameters will be sent by
        //reference via ref keyword.
    }

    //Generic Methods
    //Here is an example of a generic method declaration.
}
