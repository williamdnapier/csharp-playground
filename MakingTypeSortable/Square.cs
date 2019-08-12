using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingTypeSortable
{
    //Example 1-1. Making a type sortable by implementing IComparable<T>

    public class Square : IComparable<Square>
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Square() { }

        public Square(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int CompareTo(object obj)
        {
            Square square = obj as Square;

            if (square != null)
            {
                return CompareTo(square);
            }
            throw new ArgumentException("Both objects being compared must be of type Square.");
        }

        public override string ToString() => ($"Height: {this.Height} Width: {this.Width}");

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Square square = obj as Square;
            if (square != null)
            {
                return this.Height == square.Height;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Height.GetHashCode() | this.Width.GetHashCode();
        }

        public static bool operator ==(Square x, Square y) => x.Equals(y);
        public static bool operator !=(Square x, Square y) => !(x == y);
        public static bool operator <(Square x, Square y) => (x.CompareTo(y) < 0);
        public static bool operator >(Square x, Square y) => (x.CompareTo(y) > 0);

        public int CompareTo(Square other)
        {
            long area1 = this.Height * this.Width;
            long area2 = other.Height * other.Width;

            if (area1 == area2)
            {
                return 0;
            }
            else if (area1 > area2)
            {
                return 1;
            }
            else if (area1 < area2)
            {
                return -1;
            }
            else
            {
                return -1;
            }
        }

        //Discussion:
        //When you implement IComparable<T> interface on your class or struct, you can take
        //advantage of the sorting routines of the List<T> and the SortedList<K,V> classes.
        //The algorithms for sorting are built into those classes but you have to tell them
        //how to sort your classes via the code implemented in the IComparable<T>.CompareTo
        //method.

        //When you sort a list of the Square objects by calling the List<Square>.Sort method,
        //the list is sorted via the IComparable<Square> interface of the Square objects.
        //The Add method of the SortedList<K,V> class uses this interface to sort the objects
        //as they are being added to the SortedList<K,V>.

        //IComparer<T> is designed to solve the problem of allowing objects to be sorted based
        //on different criteria in different contexts. This interface allows you to sort types
        //you did not write.

        //So, if you wanted to sort the Square objects by height, you could create a new class
        //called CompareHeight.
    }

    public class CompareHeight : IComparer<Square>
    {
        public int Compare(object firstSquare, object secondSquare)
        {
            Square square1 = firstSquare as Square;
            Square square2 = secondSquare as Square;

            if (square1 == null || square2 == null)
            {
                throw (new ArgumentException("Both parameters must be of type Square."));
            }
            else
            {
                return Compare(firstSquare, secondSquare);
            }
        }

        public int Compare(Square x, Square y)
        {
            if (x.Height == y.Height)
            {
                return 0;
            }
            else if (x.Height > y.Height)
            {
                return 1;
            }
            else if (x.Height < y.Height)
            {
                return -1;
            }
            else
            {
                return -1;
            }
        }
    }

    //The above class is passed in to the IComparer parameter of the Sort routine.
    //Now, you can specify different ways to sort your Square objects. The comparison
    //method implemented in the comparer must be consistent and apply a total ordering
    //so that when the comparison function declares equality for two items, it is
    //absolutely ture and not a result of one item not being greater than another
    //or one item not being less than another.

    public class TestSortClass
    {
        public static void TestSort()
        {
            List<Square> listOfSquares = new List<Square>()
            {
                new Square(1,3),
                new Square(4, 3),
                new Square(2,1),
                new Square(6,1)
            };

            //Test a List<String>
            Console.WriteLine("List<String>");

            Console.WriteLine("Original list");
            foreach (Square square in listOfSquares)
            {
                Console.WriteLine(square.ToString());
            }

            Console.WriteLine();

            IComparer<Square> heightCompare = new CompareHeight();
            listOfSquares.Sort(heightCompare);
            Console.WriteLine("Sorted list using IComparer<Square>=heightCompare");
            foreach (Square square in listOfSquares)
            {
                Console.WriteLine(square.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Sorted list using IComparable<Square>");
            listOfSquares.Sort();
            foreach (Square square in listOfSquares)
            {
                Console.WriteLine(square.ToString());
            }

            //Test a SortedList

            var sortedListOfSquares = new SortedList<int, Square>()
            {
                { 0, new Square(1,3) },
                { 2, new Square(3,3) },
                { 1, new Square(2,1) },
                { 3, new Square(6,1) }
            };

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("SortedList<Square>");
            foreach (KeyValuePair<int, Square> kvp in sortedListOfSquares)
            {
                Console.WriteLine($"{kvp.Key} : {kvp.Value}");
            }
        }
    }
}
