using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_UsingDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate the delegate.
            Del handler = DelegateMethod;

            //Call the delegate.
            handler("Hi, there!");

            //You can also use delegates as parameters in methods.
            //Those methods can then call the delegate passed in as
            //a callback function.
            MethodWithCallback(1, 2, handler);

            //More delegate examples.
            Program2.Write();

            //Stop the console from closing.
            Console.ReadLine();
        }

        static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        static void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("The number is: " + (param1 + param2).ToString());
        }
    }

    public delegate void Del(string message);

    class Program2
    {
        public class MethodClass
        {
            public void Method1(string message) { }
            public void Method2(string message) { }
        }

        static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public static void Write()
        {
            MethodClass obj = new MethodClass();
            Del d1 = obj.Method1;
            Del d2 = obj.Method2;
            Del d3 = DelegateMethod;

            //Both types of assignment are valid.
            Del allMethodsDelegate = d1 + d2;
            allMethodsDelegate += d3;

            //You can also remove methods.
            //Remove Method1.
            allMethodsDelegate -= d1;

            //Copy allMethodsDelegate while removing d2.
            Del oneMethodDelegate = allMethodsDelegate - d2;

            //Because delegate types are derived from System.Delegate,
            //the methods and properties defined by that class can be 
            //called on the delegate.
            int invocationCount = d1.GetInvocationList().GetLength(0);
            Console.WriteLine("The invocation count of the d1 delegate is " + invocationCount);
        }
    }

    //Discussion.
    //Multicast delegates are used extensively in event handling. Event source
    //objects send event notifications to recipient objects that have registered
    //to receive that event. To register for an event, the recipient creates a
    //method designed to handle the event, then creates a delegate for that method
    //and passes the delegate to the event source.
    //1. The source calls the delegate.
    //2. The delegate calls the event handling method.

}
