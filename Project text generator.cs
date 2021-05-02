using System;
using System.IO;

namespace FileNada
{
    class Program
    {

        static void Main(string[] args)
        {


            Console.WriteLine("Welcome to text generator :D!");
            Console.WriteLine("Enter your name.");
            string name = Console.ReadLine();
            string History = "/Users/nadaalotaibi/Desktop/NadaFile/History.txt";
            Console.WriteLine("Enter your file name.");
            string Fname = Console.ReadLine();

            StreamWriter inp = new StreamWriter("/Users/nadaalotaibi/Desktop/NadaFile/" + Fname + ".txt");
            inp.WriteLine(name);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(History), true))
            {
                outputFile.WriteLine($" {name} created {Fname}.txt {DateTime.Now} \n");
            }
        
            inp.Flush();

            Console.WriteLine("Edit an existed File");
            inp.WriteLine(Console.ReadLine());
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(History), true))
            {
                outputFile.WriteLine($" {name} edited {Fname}.txt {DateTime.Now} \n");
            }
            inp.Flush();
            inp.Close();
            Console.WriteLine("Delete file?y/n");
            string ch = Console.ReadLine();
            if (ch == "y" || ch == "Y")
            {
                if (File.Exists("/Users/nadaalotaibi/Desktop/NadaFile/" + Fname + ".txt"))
                {
                    File.Delete("/Users/nadaalotaibi/Desktop/NadaFile/" + Fname + ".txt");

                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(History), true))
                    {
                        outputFile.WriteLine($" {name} deleted {Fname}.txt {DateTime.Now} \n");
                    }


                } }
            }
           

        }
    }
