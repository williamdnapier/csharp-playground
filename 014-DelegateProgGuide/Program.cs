using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014_DelegateProgGuide
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformCalculation performCalculation = MethodPerformCalculation;

            Console.WriteLine(performCalculation(2, 2));
            Console.WriteLine(Environment.NewLine);

            Speak speak = MethodSpeak;
            Console.WriteLine(speak("The secret to life is 42."));
            Console.WriteLine(Environment.NewLine);

            Console.ReadLine();
        }

        static int MethodPerformCalculation(int x, int y)
        {
            return x * y;
        }

        static string MethodSpeak(string words)
        {
            return "Hello. Here is your message: " + words;
        }
    }

    //A delegate is a type that represents references to methods with
    //a particular parameter list and return type. When you instantiate
    //a delegate, you can associate its instance with any method with a
    //compatible signature and return type. You can invoke or call the 
    //method through the delegate instance.

    //Delegates are used to pass methods as arguments to other methods.
    //Event handlers are nothing more than methods invoked through delegates.
    //You create a custom method and a class such as a window control
    //can call your method when a certain event occurs. The following
    //shows a delegate declaration.

    public delegate int PerformCalculation(int x, int y);
    public delegate string Speak(string words);

    //Any method from any accessible class or struct that matches this
    //delegate type can be assigned to the delegate.
}
