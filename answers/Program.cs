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


            ////Extension method
            //Console.WriteLine("Wayne".IsCapitalized());


            ////Anon Type
            ////Simple class created on the fly - mainly for LINQ queries.
            //var guy = new { Name = "Bill", Age = 44 };


            ////Tuples
            ////Return multiple values from method without out param
            //(string, int) bob = ("Bob", 23);
            //bob = GetPerson();


            //DynamicExample d = new DynamicExample();

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


    //Extension Method - static method of static class where 'this' modifier applied to first parameter.
    public static class StringHelper
    {
        public static bool IsCapitalized(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            return char.IsUpper(s[0]);
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

    //Dynamic - process of resolving types from compile time to runtime.
    //Custom binding on dynamic objects that implement IDynamicMetaObjectProvider(IDMOP) ... like IronPython or IronRuby.
    public class DynamicExample
    {
        public DynamicExample()
        {
            dynamic d = new Duck();
            d.Quack(); 
            d.Waddle();
        }

        public class Duck : DynamicObject
        {
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                Console.WriteLine(binder.Name + " was called");
                result = null;
                return true;
            }
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

        public async Task<int> GetIq()
        {
            await Task.Delay(100);
            return 72;
        }
    }

}
