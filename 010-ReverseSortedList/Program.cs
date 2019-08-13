using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010_ReverseSortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ReverseSortedListClass.Write();
        }
    }

    //Problem
    //You want to be able to reverse the contents of the sorted list of
    //items while maintaining the ability to access them in both array
    //and list styles like SortedList and the generic SortedList<T>
    //classes provide.

    //Solution.
    //Use Linq to objects to query the SortedList<T> and apply a descending
    //order to the information in the list.

    class ReverseSortedListClass
    {
        public static void Write()
        {
            SortedList<int, string> data = new SortedList<int, string>()
            {
                [2] = "two",
                [5] = "five",
                [3] = "three",
                [1] = "one"
            };

            Console.WriteLine("The default output order for the list is ASC order.");
            foreach (KeyValuePair<int, string> kvp in data)
            {
                Console.WriteLine($"\t {kvp.Key} \t {kvp.Value}");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Reverse the sort order by querying using Linq.");

            //query ordering by descending
            var query = from d in data
                        orderby d.Key descending
                        select d;

            foreach (KeyValuePair<int, string> kvp in query)
            {
                Console.WriteLine($"\t {kvp.Key} \t {kvp.Value}");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Add a new item to the list. By querying it again, you keep the DESC order.");

            data.Add(4, "four");

            //requery order by descending
            query = from d in data
                    orderby d.Key descending
                    select d;

            foreach (KeyValuePair<int, string> kvp in query)
            {
                Console.WriteLine($"\t {kvp.Key} \t {kvp.Value}");
            }

            Console.WriteLine(Environment.NewLine);

            //Just go against the original list for asc
            Console.WriteLine("Write the original ASC order for comparison.");
            foreach (KeyValuePair<int, string> kvp in data)
            {
                Console.WriteLine($"\t {kvp.Key} \t {kvp.Value}");
            }

            //Stop the console here.
            Console.ReadLine();
        }
    }
}
