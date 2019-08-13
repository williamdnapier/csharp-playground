using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011_ConstrainTypeArgs
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDisposableListClass.Write();
        }
    }

    //Problem
    //Your generic type needs to be created with a type argument that
    //must support the members of a particular interface, such as IDisposable.

    //Solution
    //Use constraints to force the type arguments of a generic type to be of a
    //type that implements one or more particular interfaces.

    public class DisposableList<T> : IList<T> where T : class, IDisposable
    {
        private List<T> _items = new List<T>();

        //Private method that will dispose of items in the list
        private void Delete(T item) => item.Dispose();

        //IList<T> Members
        public int IndexOf(T item) => _items.IndexOf(item);

        public void Insert(int index, T item) => _items.Insert(index, item);

        public T this[int index]
        {
            get { return (_items[index]); }
            set { _items[index] = value; }
        }

        public void RemoveAt(int index)
        {
            Delete(this[index]);
            _items.RemoveAt(index);
        }

        //ICollection<T> Members
        public void Add(T item) => _items.Add(item);

        public bool Contains(T item) => _items.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

        public int Count => _items.Count;

        public bool IsReadOnly => false;

        //IEnumberable<T> Members
        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

        //IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        //Other members
        public void Clear()
        {
            for (int index = 0; index < _items.Count; index++)
            {
                Delete(_items[index]);
            }

            _items.Clear();
        }

        public bool Remove(T item)
        {
            int index = _items.IndexOf(item);

            if (index >= 0)
            {
                Delete(_items[index]);
                _items.RemoveAt(index);

                return true;
            }
            else
            {
                return (false);
            }
        }
    }

    //This DisposableList class allows only an object that implements
    //IDisposable to be passed in as a type argument to this class. The
    //reason for this is that whatever an object is removed from a DisposableList
    //object, the Dispose method is always called on that object. This allows you
    //to handle the management of any object stored within this DisposableList object.

    public class TestDisposableListClass
    {
        public static void Write()
        {
            DisposableList<StreamReader> dl = new DisposableList<StreamReader>();

            //Create a few test objects.

            StreamReader tr1 = null;
            StreamReader tr2 = null;
            StreamReader tr3 = null;

            try
            {
                tr1 = new StreamReader("C:\\Windows\\system.ini");
            }
            catch (Exception)
            {
                Console.WriteLine("Could not read system.ini file.");
            }

            try
            {
                tr2 = new StreamReader("c:\\Windows\\vmgcoinstall.log");
            }
            catch (Exception)
            {
                Console.WriteLine("Could not read the vmgcoinstall.log file.");
            }

            try
            {
                tr3 = new StreamReader("c:\\Windows\\Starter.xml");
            }
            catch (Exception)
            {
                Console.WriteLine("Could not read the Starter.xml file.");
            }

            //Add the test object to the DisposableList.
            if (tr1 != null)
            {
                dl.Add(tr1);
            }

            if (tr2 != null)
            {
                dl.Insert(0, tr2);
            }

            if (tr3 != null)
            {
                dl.Add(tr3);
            }

            foreach (StreamReader sr in dl)
            {
                Console.WriteLine($"sr.ReadLine() == { sr.ReadLine() }");
            }

            //Call Dispose before any of the disposable objects are removed from the DisposableList.
            dl.RemoveAt(0);
            dl.Remove(tr1);
            dl.Clear();

            //Keep console open.
            Console.ReadLine();
        }
    }

    //Discussion
    //The where keyword is used to constrain a type parameter to accept only arguments
    //that satisfy the given constraint. For example, the DisposableList has the constraint
    //that any type argument T must implement the IDisposable interface.

    //public class DisposableList<T> : IList<T> where T : IDisposable

    //That means that this code will compile successfully.
    //DisposableList<StreamReader> dl = new DisposableList<StreamReader>();

    //But this code will NOT compile.
    //DisposableList<string> dl = new DisposableList<string>();

    //This is because string does NOT implement the IDisposable interface and the
    //StreamReader type does.

    //Other constraints on the type argument are allowed, in addition to requiring
    //one or more specific interfaces to be implemented. You can force a type
    //argument to be inherited from a specific base class, such as the TextReader class.

    //public class DisposableList<T> : IList<T> where T : System.IO.TextReader, IDisposable

    //You can also determine if the type argument is narrowed down to only value types
    //or only reference types. The following class declaration is constrained to using
    //only value types.

    //public class DisposableList<T> : IList<T> where T : class

    //In addition, you can also require any type argument to implement a public
    //default constructor.

    //public class DisposableList<T> : IList<T> where T : IDisposable, new()

    //Using constraints allows you to write generic types that accept a narrower
    //set of available type arguments. If the IDisposable constraint is omitted 
    //in the Solution for this recipe, a compile time error will occur. This is 
    //because not all of the types that can be used as the type argument for the
    //DisposableList will implement the IDisposable interface. If you skip the
    //compile time check, a DisposableList object may contain objects that do not
    //have public no argument Dispose method. In this case, a runtime exception
    //will occur. Generics and constraints in particular force strict type checking
    //of the class type arguments and allow you to catch these problems at compile 
    //time rather than at runtime.
}
