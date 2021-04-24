using System;
using System.Collections.Generic;
namespace list
{
    class Program
    {
        static int Search(List<studntL> ls, int grade)
        {

            int count = 0;
            for (int i = 0; i < ls.Count; i++)
                if (ls[i].Grade == grade)
                    count++;
            return count;
        }
        class studntL
        {
            public string Name;


            public int Grade;

        }
        static void Main(string[] args)
        {

            List<studntL> ListS = new List<studntL>();


            for (int i = 0; i <= ListS.Count; i++)
            {

                Console.WriteLine("Enter studnet name:");
                string SName = Console.ReadLine();
                ListS.Add(new studntL());
                ListS[i].Name = SName;


                Console.WriteLine("Enter your grade:");
                int Grade1 = Convert.ToInt32(Console.ReadLine());
                ListS[i].Grade = Grade1;
                Console.WriteLine("Do you want to enter another student? Write No to exit");
                string responce = Console.ReadLine();
                
                    if (responce == "No" || responce == "NO" || responce == "no")
                    {
                        break;
                    }

                }

                for (int j = 0; j < ListS.Count; j++)
                {
                    Console.WriteLine("Student name and grade: " + ListS[j].Name + " " + ListS[j].Grade);
                }

                Console.WriteLine("Enter grade to search:");
                int Grade2 = Convert.ToInt32(Console.ReadLine());
                int msearch = Search(ListS, Grade2);
                Console.Write("Number of students with grade " + Grade2 + " ");

                Console.Write("is: " + msearch);



            }
        }

    }
}
