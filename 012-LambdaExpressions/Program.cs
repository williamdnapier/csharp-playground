using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _012_LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Write();
            WriteProgressiveApproach();

            //Keep the console open.
            Console.ReadLine();
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
            Console.WriteLine("Element operators in Linq are First, Last, Single and ElementAt.");
            int[] numbers = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            foreach (int x in numbers)
            {
                Console.WriteLine(x);
            }
            int firstNumber = numbers.First();
            Console.WriteLine("firstNumber in the sequence " + firstNumber);
            int lastNumber = numbers.Last();
            Console.WriteLine("lastNumber in the sequence " + lastNumber);
            int secondNumber = numbers.ElementAt(1);
            Console.WriteLine("secondNumber in the sequence " + secondNumber);

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Aggregation operators in Linq are Count and Min.");
            int count = numbers.Count();
            Console.WriteLine("count of numbers in the sequence " + count);
            int min = numbers.Min();
            Console.WriteLine("min of numbers in the sequence " + min);

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Quantifier operators Contains, Any return a bool value.");
            bool hasTheNumberNine = numbers.Contains(9);
            Console.WriteLine("hasTheNumberNine is " + hasTheNumberNine);
            bool hasMoreThanZeroElements = numbers.Any();
            Console.WriteLine("hasMoreThanZeroElements is " + hasMoreThanZeroElements);
            bool hasAnOddElement = numbers.Any(x => x % 2 == 1);
            Console.WriteLine("hasAnOddElement is " + hasAnOddElement);

            Console.WriteLine(Environment.NewLine);

            //Because these operators don't return a collection, you can't further call operations
            //on their results. In other words, they must be the last operator in the chain.

            //Some operators accept 2 input sequences. Examples are Concat - which appends one
            //sequence to another sequence. Also Union does the same but with the duplicates removed.
            //The joining operators fall into this category.

            //Deferred Execution
            //An important feature of most query operators is that they execute not when constructed
            //but when enumerated.

            //An example of deferred execution.
            var numbers2 = new List<int>();
            numbers2.Add(1);

            //Build query
            IEnumerable<int> numbers2Query = numbers2.Select(x => x * 10);
            numbers2.Add(2); //sneak in an extra element

            Console.WriteLine("Deferred execution example.");
            foreach (int x in numbers2Query)
            {
                Console.WriteLine("numbers2Query number is " + x);
            }

            Console.WriteLine(Environment.NewLine);

            //Reevaluation
            //Deferred execution also has a consequence - deferred execution is reevaluated when
            //you reenumerate.

            //There are 2 reasons why this is sometimes not ideal.
            //1. Sometimes you want to freeze or cache the results at a certain point in time.
            //2. Some queries are CPU intensive and you don't want to repeat them.

            //You can avoid reevaluation by calling a conversion operator, such as
            //ToArray or ToList.
            //ToArray copies output of the query from the IEnumerable sequence to an array.
            //ToList copies output to a generic List<>.

            //Outer Variables
            //If the query lambda expresssion uses local variables, these variables are
            //captured and are subject to outer variable semantics. That means what matters
            //most is what is the variable's value when the query is executed and not at the
            //time when it was captured.

            int[] numbers3 = { 1, 2 };
            int factor = 10; //We capture this variable below.
            var queryOuterVariable = numbers3.Select(x => x * factor);

            //Now, change the factor variable's value.
            factor = 20;

            Console.WriteLine("Writing outer variables example.");
            foreach (int x in queryOuterVariable)
            {
                Console.WriteLine(x); //The output for this is 20, 40.
                //Instead of outputting 10, 20 as you might expect.
                //This is because the query is executed during the enumeration.
                //The variable's value is 20 when this foreach loop is executed.
            }

            Console.WriteLine(Environment.NewLine);

            //Chaining Decorators
            //When you chain query operators, you create a layering of decorators.

            IEnumerable<int> queryChainingDecorators = new int[] { 5, 12, 3 }
            .Where(x => x < 10)
            .OrderBy(x => x)
            .Select(x => x * 10);

            Console.WriteLine("Writing out chaining decorators example.");
            foreach (int x in queryChainingDecorators)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine(Environment.NewLine);

            //Linq follows a demand driven pull model rather a supply drive push model.

            //Subqueries
            //A subquery is a query contained within another query's lambda expression.
            //Here is an example of a subquery sorting the members of Pink Floyd.

            string[] musicians = { "Nick Mason", "David Gilmour", "Rick Wright", "Roger Waters" };

            IEnumerable<string> querySubquery = musicians
                .OrderBy(x => x.Split().Last());

            Console.WriteLine("Writing out first subquery example.");
            foreach (string x in querySubquery)
            {
                Console.WriteLine(x);
            }

            //x.Split() converts each string to a collection of words
            //upon which we then call the Last operator.
            //Last() is the subquery.
            Console.WriteLine(Environment.NewLine);


            //More complicated subqueries ...

            string[] names7 = { "Bill", "Denise", "Richard", "Peggy", "Gracie", "IZ", "Randy", "Cheryl" };
            IEnumerable<string> outerQuery = names7
                .Where(x => x.Length ==
                    names7.OrderBy(x2 => x2.Length)
                        .Select(x2 => x2.Length).First()
                        );

            Console.WriteLine("More complicated subquery example.");
            foreach (string x in outerQuery)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine(Environment.NewLine);

            //The above query is a great candidate for a database query. A query that would make 1 round
            //trip to the database and get what it needed and comes back.
            //However, if you have local collections, it is better to avoid the inefficiency of excuting
            //the subquery with each iteration through the loop.

            //So, it is better to write local collection subqueries like this ...

            int shortest = names7.Min(x => x.Length);

            IEnumerable<string> query7 = names7
                .Where(x => x.Length == shortest);

            Console.WriteLine("Writing out subquery executed after initial query on local collection.");
            foreach (string x in query7)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine(Environment.NewLine);


            Console.WriteLine(Environment.NewLine);
        }

        static void WriteProgressiveApproach()
        {
            //In order to restore a bit of sanity to my variables in this
            //project, I'm splitting these other concepts out as their
            //own methods.

            Console.WriteLine(Environment.NewLine);

            string[] names = { "Bill", "Denise", "Gracie", "Isaac", "Richard", "Peggy", "MaryBeth" };


            //This is how you can progressively write a query using the 
            //query comprehension syntax.

            IEnumerable<string> query =
                from n in names
                select Regex.Replace(n, "[aeiou]", "")
                into noVowel
                where noVowel.Length > 2
                orderby noVowel
                select noVowel;

            Console.WriteLine("Writing out the Progressive Approach example.");

            foreach (string n in query)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine(Environment.NewLine);

            //Note, because this example uses the 'into' keyword that the query variable
            //is out of scope after the 'into' keyword.

            //This example will not compile because n1 is out of scope.
            //var query = 
            //from n1 in names
            //select n1.ToUpper()
            //into n2
            //where n1.Contains("x") //Illegal n1 is out of scope.
            //select n2;

            //Wrapping Queries
            //A query built progressively can be formulated into a single statement by wrapping
            //one query around another.

            IEnumerable<string> queryWrapped =
                from n1 in
                    (
                        from n2 in names
                        select Regex.Replace(n2, "[aeiou]", "")
                    )
                where n1.Length > 2
                orderby n1
                select n1;

            //Same query written in lambda syntax instead of comprehension query syntax.
            IEnumerable<string> queryWrappedLambda = names
                .Select(n => Regex.Replace(n, "[aeiou]", ""))
                .Where(n => n.Length > 2)
                .OrderBy(n => n);


            Console.WriteLine(Environment.NewLine);
        }
    }
}
