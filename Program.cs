using System;
using System.IO;
using System.Text.RegularExpressions;
namespace hwfirst
{
    class Program
    {
        static void hash(string input)
        {
            var regex = new Regex(@"@\w+");
            var regex1 = new Regex(@"#\w+");
            var matches = regex.Matches(input);
            var matches1 = regex1.Matches(input);

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


