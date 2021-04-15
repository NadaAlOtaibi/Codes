// This code to get the input(tweet) from the user and display hash & mention in the tweet

using System;
using System.IO;
using System.Text.RegularExpressions;
namespace hwfirst
{
    class Program
    {
        static void hash(string input)
        {
            var at = new Regex(@"@\w+");
            var hash = new Regex(@"#\w+");
            var matches = at.Matches(input);
            var matches1 = hash.Matches(input);
            
            // loop to see the matches from the input
            foreach (var match in matches)
            {

             Console.WriteLine(match);

            }
            foreach (var match in matches1)
            {

                Console.WriteLine(match);

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter tweet");
            string tweet = Console.ReadLine();
            Console.WriteLine("The hashtags and mention are:");
            hash(tweet);

        }
    }
}
//uses of tokenizer:
// Compiler
// analysis
// learning in children game


