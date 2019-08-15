using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_GenericClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Example instantiating generic class.");

            //Example of instantiating generic class.
            MyGenericClass<int> intGenericClass = new MyGenericClass<int>(10);
            int val = intGenericClass.genericMethod(200);

            //Generic class
            GenericClass<string> genericStringClass = new GenericClass<string>();
            GenericClass<object> genericObjectClass = new GenericClass<object>();
            GenericClass<int> genericIntClass = new GenericClass<int>();
            GenericClass<sbyte> genericSbyteClass = new GenericClass<sbyte>();
            GenericClass<long> genericLongClass = new GenericClass<long>();
            GenericClass<decimal> genericDecimalClass = new GenericClass<decimal>();
            GenericClass<float> genericFloatClass = new GenericClass<float>();
            GenericClass<byte> genericByteClass = new GenericClass<byte>();

            GenericClass<int> g = new GenericClass<int>();
            Del d = g.DelMethod;
            d();

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Example with generic delegate.");

            Program2.Write();

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Another example with a generic class.");

            //Instantiate generic with integer.
            Program3<int> intObj = new Program3<int>();

            //Adding integer values into collection.
            //No boxing occurs below.
            intObj.Add(1);
            intObj.Add(2);
            intObj.Add(3);
            intObj.Add(4);
            intObj.Add(5);

            //Displaying values.
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(intObj[i]); //No unboxing.
            }


            //Stop the console from closing.
            Console.ReadLine();
        }
    }

    public delegate void Del();
    public delegate T Del2<T>(T param);
    //public delegate T Del3(int count);
    //public delegate T Del4(T TKey, T TValue);

    class MyGenericClass<T>
    {
        private T genericMemberVariable;

        public MyGenericClass(T value)
        {
            genericMemberVariable = value;
        }

        public T genericMethod(T genericParameter)
        {

            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), genericParameter);
            Console.WriteLine("Return type: {0}, value: {1}", typeof(T).ToString(), genericMemberVariable);

            return genericMemberVariable;
        }

        public T genericProperty { get; set; }
    }

    class GenericClass<T>
    {
        public GenericClass()
        {
            //empty constructor
        }

        public void DelMethod()
        {
            Console.WriteLine("DelMethod");
        }

        public T DelMethod(T param)
        {
            return param;
        }
    }

    class Program2
    {
        //Generic Delegate Example

        //Delegate definition
        private delegate T add<T>(T param1, T param2);

        //Method matching delegate definition
        private static int AddNumber(int val1, int val2)
        {
            return val1 + val2;
        }

        //Another method matching the delegate definition.
        private static string Concate(string str1, string str2)
        {
            return str1 + str2;
        }

        public static void Write()
        {
            //Assign delegate instance to actual method.
            add<int> sum = AddNumber;

            //Assign another delegate instance to actual method.
            add<string> conct = Concate;

            //Call first delegate instance which executes the actual method.
            Console.WriteLine(sum(2, 2));

            //Call second delegate instance which executes the actual method.
            Console.WriteLine(conct("Hey", "Yo"));

        }
    }

    class Program3<T>
    {
        //Define an Array of Generic type with length of 5
        T[] obj = new T[5];
        int count = 0;

        //Adding items mechanism into generic type.
        public void Add(T item)
        {
            //Checking length
            if (count + 1 < 6)
            {
                obj[count] = item;
            }
            count++;
        }

        //Indexer for foreach statement iteration.
        public T this[int index]
        {
            get { return obj[index]; }
            set { obj[index] = value; }
        }
    }
}
