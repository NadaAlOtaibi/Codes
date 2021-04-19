using System;

namespace CheckingOrder
{
    class HSORDER
    {
        // function to check order
        static bool checkingOrder(string value)
        {
            if (value == null)
                if (value.Length == 0)
                    return false;
            string reverse = string.Empty;
            for (int i = value.Length - 1; i >= 0; i--)
            {
                reverse += value[i].ToString();
            }
            if (reverse == value) return true;
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            string userIn; 
            Console.WriteLine("Enter a numbers to check order: ");
            userIn = Console.ReadLine();

            HSORDER user = new HSORDER();
            // prints the result
            if (user.checkingOrder(userIn))
                Console.WriteLine("it is in Order");
            else 
                Console.WriteLine("it is not in Order");
        }
    }
}
    
