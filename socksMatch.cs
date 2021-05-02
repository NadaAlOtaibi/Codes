using System;
namespace Nadawa
{

    class Program
    {
        static int count;


        //ABBA > 2
        //ABB  > 1
        public static int mep(string l)

        {
            char[] chars = l.ToCharArray();
            Array.Sort(chars);

            for (int i = 1; i < chars.Length; i++)
            {
                if(chars[i]== chars[i - 1])
                {
                    count++;
                    i++;

                }
            }
            return count;
                }


        static void Main(string[] args)
            {
            Console.WriteLine(mep("1122"));

            }
        } }

