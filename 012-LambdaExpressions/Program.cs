using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Write();
        }

        //Basic units of data in LINQ are sequences and elements.

        //A sequence is any object that implements the generic IEnumerable interface
        //and an element is each item in the sequence.

        //names is a sequence
        static void Write()
        {
            string[] names = { "Bill", "Denise", "Grace", "Isaac" };

            //Bill, Denise, Grace and Isaac are elements in the names sequence.

            //Query operator
            //A query is an expression that transforms sequences with query operators.
            //The simplest query comprises one input and one operator.

            IEnumerable<string> filteredNames =
                Enumerable.Where(names, n => n.Length >= 5);

            Console.WriteLine("Results of lambda query in Linq.");
            foreach (string n in filteredNames)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine(Environment.NewLine);


            //Most query operators accept lambda expressions as an argument.
            //That's why you can pass it ...
            // n => n.Length >= 5

            //Lambda Queries Syntax
            //So, the above is an example of a Lambda Query.
            IEnumerable<string> filteredNames2 =
                Enumerable.Where(names, n => n.Length >= 4);

            Console.WriteLine("Repeating lambda query different criteria.");
            foreach (string x in filteredNames2)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine(Environment.NewLine);

            //Query Comprehension Syntax
            //Here is the same query written in query comprehension syntax instead of lambda syntax.

            IEnumerable<string> filteredNames3 =
                from x in names
                where x.Contains("a")
                select x;

            Console.WriteLine("Same query written using query comprehension syntax.");
            foreach (string x in filteredNames3)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine(Environment.NewLine);


            //Chaining additional query operators to build more complex queries.
            //For example, write a query that extracts all strings containing the letter a,
            //sorts them by length and then converts them to UPPERCASE.

            IEnumerable<string> filteredNames4 = names
                .Where(x => x.Contains("a"))
                .OrderBy(x => x.Length)
                .Select(x => x.ToUpper());

            Console.WriteLine("Chaining additional query operators to create more complex queries.");
            foreach (string x in filteredNames4)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine(Environment.NewLine);

            //Query operators never alter the sequence but instead return a new copy to be consistent
            //with the functional programming paradigm.

            //Composing Lambda Expressions

            // x => x.Contains("a")
            //In this example the input type is string.
            //The return type is bool.
            //An expression returing a bool value is called a predicate.

            //The purposeof the lambda expression depends on the particular query operator. With the
            //Where operator, it indicates whether an element should be included in the output sequence.
            //In the case of the OrderBy operator, the lambda expression maps each element in the input
            //sequence to its sorting key. With the Select operator, the lambda expression determines
            //how each element in the input sequence is transformed before being fed to the output 
            //sequence.

            //A lambda expression in a query operator always works on individual elements
            //in the input sequence -- not the sequence as a whole.

            //The lambda expression you supply acts as a callback. The query operator evaluates
            //your lambda expression on demand -- typically once per element in the input sequence.

            //Lambda Expressions and Func signatures
            //The standard query operators utilize generic Func delegates. Func is a family of
            //general purpose generic delegates in System.Linq defined with the following intent:

            //Func<TSource,bool> matches TSource => bool lambda expression.
            //One that accepts a TSource argument and returns a bool value.

            //Similarly, Func<TSource,TResult> matches TSource => TResult lambda expression.
            //Here are the Func delegate definitions.

            //delegate TResult Func<T>();
            //delegate TResult Func<T,TResult> (T arg1);
            //delegate TResult Func<T1,T2,TResult> (T1 arg1, T2 arg2);
            //delegate TResult Func<T1,T2,T3,TResult> (T1 arg1, T2 arg2, T3 arg3);
            //delegate TResult Func<T1,T2,T3,T4,TResult> (T1 arg1, T2 arg2, T3 arg3, T4 arg4);

            //The standard query operators use the following generic type names.
            //TSource - element type for the input sequence
            //TResult - element type for the output sequence - if different than TSource.
            //TKey - element type for the key used in sorting, grouping or joining.

            //Here is the signature for the Select query operator.
            //static IEnumerable<TResult> Select<TSource,TResult>(
            //this IEnumberable<TSource> source,
            //Func<TSource,TResult> selector)

            //So, Func<TSource,TResult> matches a TSource => TResultlambda expression.
            //One that maps an input element to an output element. TSource and TResult
            //are different types, so the lambda expression can change the type of each
            //element. Further, the lambda expression determines the output sequence type.

            //This query uses Select to transform string type elements to integer type elements.
            string[] names2 = { "Bill", "Denise" };
            IEnumerable<int> filteredNames5 = names2.Select(x => x.Length);
            Console.WriteLine("Using Select to transform string type elements to integer type elements.");
            foreach (int x in filteredNames5)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine(Environment.NewLine);


            //Natural Ordering
            //The original ordering of elements within an input sequence is significant in LINQ.
            //Some query operators, such as Take, Skip and Reverse rely on this behavior.
            //Operators such as Where and Select preserve the original order of an input
            //sequence. Linq tries to preserve the original order of elements in an input
            //sequence whenever possible.

            //Other Operators
            //Not all operators return a sequence. The element operators extract one element
            //from the input sequence. Examples of element operators in Linq are First, Last
            //Single and ElementAt.

            Console.WriteLine("Writing out other operator examples.");
            int[] numbers = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int firstNumber = numbers.First();
            Console.WriteLine(firstNumber);

            Console.WriteLine(Environment.NewLine);


            //Keep the console open.
            Console.ReadLine();
        }

    }
}
