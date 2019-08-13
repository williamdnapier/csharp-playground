using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_WhenWhereGenerics
{
    class Program
    {
        static void Main(string[] args)
        {

            //Regular class
            FixedSizeCollection A = new FixedSizeCollection(5);
            Console.WriteLine(5);

            FixedSizeCollection B = new FixedSizeCollection(5);
            Console.WriteLine(B);

            FixedSizeCollection C = new FixedSizeCollection(5);
            Console.WriteLine(C);


            //Generic class
            FixedSizeCollection<bool> gA = new FixedSizeCollection<bool>(5);
            Console.WriteLine(gA);

            FixedSizeCollection<int> gB = new FixedSizeCollection<int>(5);
            Console.WriteLine(gB);

            FixedSizeCollection<string> gC = new FixedSizeCollection<string>(5);
            Console.WriteLine(gC);

            FixedSizeCollection<string> gD = new FixedSizeCollection<string>(5);
            Console.WriteLine(gD);


            Console.ReadLine();
        }
    }

    //Problem
    //You want to use generic types in a new project or convert nongeneric types in an existing project to their
    //generic equivalents. However, you do not really know why you would want to do this, and you do not know
    //which nongeneric types should be converted.

    //Solution
    //When deciding to use generic types, consider the following:

    //01. Will your type contain or be operating on various unspecified data types? If so, creating a generic
    //type will offer several benefits over creating a nongeneric type. If your type will operate on only a single
    //specific type, then you may not need to create a generic type.

    //02. If your type will be operating on value types, so that boxing and unboxing will occur, you should
    //consider using generics to prevent performance penalties incurred from boxing and unboxing operations.

    //03. The stronger type checking associated with generics will aid in finding errors sooner -- during compile-time
    //instead of runtime. This will shorten your bug-fixing cycle.

    //04. Is your code suffering from 'code bloat'? For example, a specialized ArrayList to that stores only 
    //StreamReaders and another specialized ArrayList to store StreamWriters. It would be easier to write code once
    //and have it just work for each of the data types it operates on.

    //05. Generics allow for greater clarity of code. By eliminating bloat and forcing stronger type checking, 
    //they make code easier to read and understand.


    //Problem
    //You need to understand how the .NET types work for generics and how generic .NET types differ from the
    //regular .NET types.

    //Solution
    //A couple of experiments can show the differences between regular .NET types and generic .NET types.

    //Example 1-6 FixedSizeCollection: a regular .NET type.
    public class FixedSizeCollection
    {
        /// <summary>
        /// Constructor that increments static counter
        /// and sets the maximum number of items.
        /// </summary>
        /// <param name="maxItems"></param>
        public FixedSizeCollection(int maxItems)
        {
            FixedSizeCollection.InstanceCount++;
            this.Items = new object[maxItems];
        }

        /// <summary>
        /// Add an item to the class whose type
        /// is unknown as only object can hold any type.
        /// </summary>
        /// <param name="item">item to add</param>
        /// <returns>the index of the item added</returns>
        public int AddItem(object item)
        {
            if (this.ItemCount < this.Items.Length)
            {
                this.Items[this.ItemCount] = item;
                return this.ItemCount++;
            }
            else
            {
                throw new Exception("Item queue is full");
            }
        }

        /// <summary>
        /// Get an item from the class
        /// </summary>
        /// <param name="index">the index of the item to get</param>
        /// <returns>an item of type object</returns>
        public object GetItem(int index)
        {
            if (index >= this.Items.Length && index >= 0)
            {
                throw new ArgumentOutOfRangeException(Convert.ToString(index));
            }
            return this.Items[index];
        }

        /// <summary>
        /// Static instance counter hangs off of the Type for StandardClass
        /// </summary>
        public static int InstanceCount { get; set; }

        /// <summary>
        /// The count of the items the class holds.
        /// </summary>
        public int ItemCount { get; private set; }

        /// <summary>
        /// The items in the class.
        /// </summary>
        private object[] Items { get; set; }

        /// <summary>
        /// ToString override to provide class detail.
        /// </summary>
        /// <returns>formatted string with class details</returns>
        public override string ToString() => 
            $" There are {FixedSizeCollection.InstanceCount.ToString()} " +
            $"instances of {this.GetType(). ToString()} " +
            $"and this instance contains {this.ItemCount} items...";
    }

    //Example 1-7 FixedSizeCollection<T>: a generic .NET type.
    /// <summary>
    /// A generic class to show instance counting.
    /// </summary>
    /// <typeparam name="T">the type parameter used for the array storage</typeparam>
    public class FixedSizeCollection<T>
    {
        ///<summary>
        /// Static instance counter hangs off of the instantiated Type for GenericClass
        /// </summary>
        public static int InstanceCount { get; set; }

        ///<summary>
        /// The count of the items the classholds
        ///</summary>
        public int ItemCount { get; private set; }

        ///<summary>
        /// The items in the class
        /// </summary>
        private T[] Items { get; set; }

        /// <summary>
        /// Constructor that increments static counter and sets up internal storage.
        /// </summary>
        /// <param name="items"></param>
        public FixedSizeCollection(int items)
        {
            FixedSizeCollection<T>.InstanceCount++;
            this.Items = new T[items];
        }

        /// <summary>
        /// Add an item to the class whose type is determined by the instantiating type.
        /// </summary>
        /// <param name="item">item to add</param>
        /// <returns>the zero-based index of the item added</returns>
        public int AddItem(T item)
        {
            if (this.ItemCount < this.Items.Length)
            {
                this.Items[this.ItemCount] = item;
                return this.ItemCount++;
            }
            else
            {
                throw new Exception("Item queue is full");
            }
        }

        ///<summary>
        /// Get an item from the class.
        /// </summary>
        /// <param name="index">the zero-based index of the item to get</param>
        /// <returns>an item of the instantiating type</returns>
        public T GetItem(int index)
        {
            if (index >= this.Items.Length && index >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return this.Items[index];
        }

        ///<summary>
        /// ToString override to provide class detail
        /// </summary>
        /// <returns>
        /// formatted string with class details
        /// </returns>
        public override string ToString() =>
            $" There are " +
            $"{FixedSizeCollection<T>.InstanceCount.ToString()}" +
            $" instances of {this.GetType().ToString()} and " +
            $"this instance contains {this.ItemCount} items...";

    }
}
