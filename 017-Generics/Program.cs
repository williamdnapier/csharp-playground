using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _017_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Program2.Write();

            //Keep the console open.
            Console.ReadLine();
        }
    }
    class Program2
    {
        static Dictionary<string, int> CountWords(string text)
        {
            //1. Creates new map from word to frequency.
            Dictionary<string, int> frequencies;
            frequencies = new Dictionary<string, int>();

            //2. Splits text into words.
            string[] words = Regex.Split(text, @"\W+");

            foreach (string word in words)
            {
                //3. Adds to or updates map.
                if (frequencies.ContainsKey(word))
                {
                    frequencies[word]++;
                }
                else
                {
                    frequencies[word] = 1;
                }
            }
            return frequencies;
        }

        public static void Write()
        {
            string text = @"Lorem Lorem ipsum dolor sit sit sit amet, consectetur adipiscing elit. Praesent molestie aliquet vulputate. Sed nec nec vestibulum sapien. Nunc Nunc bibendum dui erat. In sed semper nisl.";

            Dictionary<string, int> frequencies = CountWords(text);

            //4. Prints each key/value pair from the map.
            foreach (KeyValuePair<string, int> entry in frequencies)
            {
                string word = entry.Key;
                int frequency = entry.Value;
                Console.WriteLine("{0}: {1}", word, frequency);
            }
        }

        //Discussion.
        //The CountWords method first creates an empty map from a string to int.
        //1. This will effectively count how often each word is used in a given text.
        //2. Next, use a regex to split the text into words.
        //3. The incrementing code doesn't need to do a cast to int in order to perfor the addition.
        //The value retreived is known to be an int at compile time.
        //4. The final part of the listing is enumerating through a Hashtable.

        //So, this uses Dictionary<TKey,TValue> which are examples of generic types.
    }
}
