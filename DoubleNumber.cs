using System;

namespace doubleRef
{
    class Program
    {

        static void funv(ref int num ) {
            num *= num;
            Console.WriteLine(num);


        }
        static void Main(string[] args)
        {
     
     
           Console.WriteLine("Write a number to make it double");
           int num = Convert.ToInt32(Console.ReadLine());
               funv(ref num);


        }
    }
}
