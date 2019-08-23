using System;
using System.Collections.Generic;

namespace _029_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            TestGList.Write();

            Console.ReadLine();
        }
    }

    //Generics introduce the .NET Framework to the concept of type parameters, which
    //make it possible to design classes and methods that defer the specification of
    //one or more types until the class or method is declared and instantiated by client
    //code. For example, by using a generic type parameter T you can write a single class
    //that other client code can use without incurring the cost or risk of runtime casts
    //or boxing operations.

    //Declare the generic class.
    public class GenericList<T>
    {
        public void Add(T input) { }
    }

    //Test the generic class.
    class TestGenericList
    {
        private class ExampleClass { }

        static void Write()
        {
            //Declare a list of type int.
            GenericList<int> list1 = new GenericList<int>();
            list1.Add(1);

            //Declare a list of type string.
            GenericList<string> list2 = new GenericList<string>();
            list2.Add("string");

            //Declare a list of type ExampleClass.
            GenericList<ExampleClass> list3 = new GenericList<ExampleClass>();
            list3.Add(new ExampleClass());
        }
    }

    //Generic classes and methods combine reusability, type safety and efficiency in a way
    //their con-generic counterparts cannot. Generics are most frequently used with collections
    //and methods that operate on them.

    //You can create your own custom generic types and methods to provide your own generalized
    //solutions and design patterns that are type-safe and efficient. The following example shows
    //a simple generic linked-list for demo purposes. (Instead of doing this, most of the time
    //you will use a List<T> which is provided by the .NET Framework or .NET Core. The type
    //parameter T is used in several locations where a concrete type would normally be used.

    //Type parameter T in angle brackets.
    public class GList<T>
    {
        //This nested class is also generic on T type parameter.
        private class Node
        {
            //T used in non-generic class constructor.
            public Node(T t)
            {
                next = null;
                data = t;
            }

            private Node next;
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            //T as private member data type.
            private T data;

            //T as return type of property.
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;

        //Constructor
        public GList()
        {
            head = null;
        }

        //T as method parameter type.
        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }

    //The following shows how to use the generic GList<T> class to create a list of integers.
    //Simply by changing the type argument, the following code can be easily modified to create
    //a list of strings or any other custom type.

    class TestGList
    {
        public static void Write()
        {
            //int is the type argument
            GList<int> list = new GList<int>();

            for (int x = 0; x < 10; x++)
            {
                list.AddHead(x);
            }

            foreach (int i in list)
            {
                System.Console.Write(i + " ");
            }

            System.Console.WriteLine("\nDone");
        }
    }
}
