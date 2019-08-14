using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Person bill = new Person("Bill");
            Person denise = new Person("Denise");

            StringProcessor billsVoice, denisesVoice, background; //4. Create three delegate instances.
            billsVoice = new StringProcessor(bill.Say);
            denisesVoice = new StringProcessor(denise.Say);
            background = new StringProcessor(Background.Note);

            billsVoice("Hi, there"); //5. Invoke the delegate instances.
            denisesVoice("Hey");
            background("A child says, Hey Mom!");
        }
    }

    delegate void StringProcessor(string input); //1. Declare delegate type.

    class Person
    {
        string name;
        public Person(string name)
        {
            this.name = name;
        }
        public void Say(string message) //2. Declare a compatible instance method.
        {
            Console.WriteLine("{0} says: {1}", name, message);
        }
    }

    class Background
    {
        public static void Note(string note) //3. Declare compatible static method.
        {
            Console.WriteLine("({0})", note);
        }
    }

    //Discusssion.
    //To start with, you declare a delegate type in Step 1.
    //Step 2 and Step 3 are both compatible with the delegate type.
    //Step 4 has 2 instances of the Person class.
    //Step 5 when billsVoice is invoked it calls the Say method on the Person named Bill.

    //Combining and Removing Delegates
    //This example has a single action but a delegate instance could have a list of actions
    //associated with it -- this is called an invocation list.

    //Delegates are immutable
    //Once you have created a delegate, it cannot be changed. This is what makes it safe
    //to pass around references to delegate instances and combine them with others. This is
    //like strings which are also immutable. Delegate.Combine is just like String.Concat.
    //They both combine existing instances and create a new without changing the original
    //one. 

    //Summary of value types and reference types
    //1. The value of a reference type expression (a variable) is a reference, not an object.
    //2. References are like URLs. Small pieces of data that let you access real information.
    //3. The value of a value type expression is the actual data.
    //4. There are times when value types are more efficient and times when reference types
    //are more efficient.
    //5. Reference type objects are always on the heap but value type values can be either on
    //the stack or the heap, depending on the context.
    //6. When a reference type is used as a method parameter, by default the argument is passed
    //by value, but the value itself is a reference.
    //7. Value type values are boxed when reference type behavior is needed. Unboxing is the reverse.


















}
