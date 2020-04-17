using System;
using System.Threading;
using System.Threading.Tasks;

namespace _030_Async
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadTest.DoThreading();
            TaskTest.DoTasking();
            Console.ReadLine();
        }  
    }

    class ThreadTest
    {
        public static void DoThreading()
        {
            Thread t = new Thread(WriteY);  //Kicking off a new thread
            t.Start();                      //Running WriteY()

            for (int i = 0; i < 1000; i++)  //Simultaneously, do something on the main thread.
            {
                Console.Write("x");
            }
        }

        public static void WriteY()
        {
            Console.WriteLine(Thread.CurrentThread.Name);

            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
            }
        }
    }

    class TaskTest
    {
        public static void DoTasking()
        {
            Task.Run(() => Console.WriteLine("Foo"));

            Action a = GetAction();

            Task.Run(a);
        }

        public static Action GetAction()
        {
            return () => Console.WriteLine("Bar");
        }
    }
}
