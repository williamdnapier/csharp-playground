using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace answers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Struct
            //Light-weight value type object
            StructExample se = new StructExample(21, 21);
            se.Write();

            //Interface
            //Abstract spec for a class. Class can inherit multiple interfaces.
            InterfaceExample ie = new InterfaceExample();
            ie.Read();
            ie.Write();

            //Enum
            //A distinct listed of numeric named constants.
            EnumExample ee = EnumExample.Top;
            bool isTop = ee == EnumExample.Top;
            Console.WriteLine("ExampleEnum isTop value is " + isTop);

            //Generics
            //Increase type safety and reduce casting.
            //Alternative to inheritance.
            GenericExample<string> ge = new GenericExample<string>();
            ge.Add("string input");
            Console.WriteLine("GenericExample prop1 value is " + ge.prop1);


            //Delegate
            //Assign the delegate target method.
            DelegateExample de = DelegateExampleClass.Square;
            //Call the delegate caller method and get output.
            int r = de(2);
            Console.WriteLine("DelegateExample r variable value is " + r);


            //Lambda Expression
            //It is unnamed method in place of delegate.
            DelegateExample de2 = x => x * x;

            //Lambda expression with captured variable is a closure.
            int factor = 2;
            Func<int, int> multiplier = n => n * factor;


            //Extension Method
            //Static method of static class where 'this' modifier applied to first parameter.
            Console.WriteLine("ExtensionMethodExample output is " + "Bill".IsCapitalized());


            //Anon Type
            //Simple class created on the fly - mainly for LINQ queries.
            var guy = new { Name = "Bill", Age = 44 };


            //Tuples
            //Return multiple values from method without out param
            (string, int) iz = ("Iz", 9);
            iz = GetPerson();
            (int, int) tup = (9, 13);
            Console.WriteLine("TupleExample tup item1 value is " + tup.Item1);
            Console.WriteLine("TupleExample tup item2 value is " + tup.Item2);


            dynamic d2 = new DynamicExample2();
            d2.Walk();
            d2.Run();
            d2.Hide();


            //StuffToRemember s = new StuffToRemember();

            //AsyncExample a1 = new AsyncExample();
            //Task myTask = a1.Go();
            //Task<int> myInt = a1.GetIq();
            //Console.WriteLine(myInt.Result);

            //DoAsyncStuff();


            //FizzBuzz
            //FizzBuzz.WriteAnswer();


            //Stop
            Console.ReadLine();
        }

        //Tuple - return a tuple from a method
        static (string, int) GetPerson() => ("Bob", 23);

        async static void DoAsyncStuff()
        {
            AsyncExample a1 = new AsyncExample();
            await Task.WhenAll(a1.Go(), a1.Go());
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


    //LINQ
    public class LinqExample
    {
        public LinqExample()
        {
            string[] names = { "Tom", "Dick", "Harry" };

            List<string> filteredNames =
                names.Where(n => n.Length >= 4).ToList();

            int[] numbers = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            List<int> firstThree = numbers.Take(3).ToList();

            List<int> lastTwo = numbers.Skip(8).ToList();
        }
    }

    //Access modifiers, inheritance, etc.
    public class StuffToRemember
    {

        //Fully accessible.
        public int publicmember = 1;

        //Accessible only within containing assembly or friend assembly.
        internal int internalmember = 2;

        //Accessible only within the containing type.
        private int privatemember = 3;

        //Accessible only within the containing type and subclasses.
        protected int protectedmember = 4;

        //Accessible within containing assembly, friend assembly, containing type and subclasses.
        protected internal int protectedinternalmember = 5;

        public class BaseClass
        {
            public virtual string Name => "Base";
        }

        public class SubBaseClass: BaseClass
        {
            private string _Name = "Sub";
            public override string Name => _Name;
        }

        public StuffToRemember()
        {
            BaseClass d = new BaseClass();
            SubBaseClass b = new SubBaseClass();

            //Upcast. Create baseclass reference from subbaseclass.
            BaseClass a = b;

            //Downcast. Create subbaseclass from baseclass.
            SubBaseClass c = (SubBaseClass)a;

            Console.WriteLine(a.Name);
            Console.WriteLine(b.Name);
            Console.WriteLine(c.Name);
            Console.WriteLine(d.Name);

        }
    }

    //Async
    public class AsyncExample
    {
        async Task GetAnswerToLife()
        {
            await Task.Delay(3000);
            int answer = 42;
            Console.WriteLine(answer);
        }

        public async Task Go()
        {
            await GetAnswerToLife();
            Console.WriteLine("Done");
        }
    }

}
