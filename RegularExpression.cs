
using System;
using System.Text.RegularExpressions;

namespace RegularExpression
{

    class RegularExpression
    {
    
        static void Main(string[] args)
        {
        
            string has;
            Console.WriteLine("Write a number to check:");
            has = Console.ReadLine();

            string pattern = @"[#][0-9A-Fa-f]{6}";


            var result = Regex.IsMatch(has, pattern);

            if (result == true)
            { Console.WriteLine("True it contain #"); }
            else { Console.WriteLine("Nooo false it does not contain #");  } }}
