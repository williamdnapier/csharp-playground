using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _018_GenericTypes
{
    class Program
    {
        static void Main(string[] args)
        {

            TestBill tb = new TestBill();

            //Stop the console.
            Console.ReadLine();
        }
    }

    public class BillDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            //throw new NotImplementedException();
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //throw new NotImplementedException();
            return null;
        }
    }

    //Generic types and type parameters
    //There are two forms of generics in C#
    //1. Generic Types - classes, interfaces, delegates and structs (no generic enums).
    //2. Generic Methods
    //Both of these are essentially ways of expressing an API such that in some places
    //where you would see a normal type, you'll see a type parameter instead.

    //Type parameters
    //Type parameters appear within angle brackets within a generic declaration, using
    //commas to separate them. So, in Dictionary<TKey,TValue> the type parameters are
    //TKey and TValue. When you use a generic type or method, you specify the real types
    //you want to use. These are called the type arguments - for example, using string 
    //for TKey and int for TValue.

    //The form of a generic type where none of the type parameters have been provided with
    //type arguments is called an unbound generic type. When type arguments are specified,
    //the type is said to to be a constructed type. Unbound generic types are effectively
    //blueprints for constructed types, much like how types (generic or not) can be regarded
    //as blueprints for objects.

    //Unbound generic types act as blueprints for constructed types, which then act as
    //blueprints for actual objects, just as nongeneric types do. The only time you
    //will see an unbound generic type is within the typeof operator.

    //The idea of a type parameter receiving information and a type argument providing
    //the information is exactly the same as with method parameters and arguments -
    //although type arguments have to be types rather than just arbitrary values.
    //The type argument has to be known at compile time.

    //You can think of a closed type as having the API of the open type with the type
    //parameters being replaced with their corresponding type arguments.

    //Examples of how method signatures in generic types contain placeholders, which
    //are replaced when the type arguments are specified.

    //void Add(TKey key, TValue value)      void Add(string key, int value)
    //TValue this[TKey key] { get; set; }   int this[string key] { get; set; }
    //bool ContainsValue(TValue value)      bool ContainsValue(int value)
    //bool ContainsKey(TKey key)            bool ContainsKey(string key)

    //The methods above are not generic methods they just use type parameters as part
    //of the type.

    public class Bill<TKey, TValue> : IEnumerable<string>
    {
        private Dictionary<TKey, TValue> mData;

        public Bill()
        {
            mData = new Dictionary<TKey, TValue>();
        }

        public void Add(TKey key, TValue value)
        {
            mData.Add(key, value);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (KeyValuePair<TKey, TValue> kvp in mData)
            {
                yield return kvp;
            }
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class TestBill
    {
        public TestBill()
        {
            Bill<string, int> b = new Bill<string, int>();
            b.Add("key", 0);
            b.Add("key2", 1);
            b.Add("key3", 2);

            foreach (KeyValuePair<string, int> kvp in b)
            {
                Console.WriteLine(kvp.Value);
            }

            Bill<string, string> b2 = new Bill<string, string>();
            b2.Add("key", "value");
            b2.Add("key2", "value2");
            b2.Add("key3", "value3");
            b2.Add("key4", "value4");

            foreach (KeyValuePair<string, string> kvp in b2)
            {
                Console.WriteLine(kvp.Value);
            }

        }
    }

}
