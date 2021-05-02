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

            StreamWriter in = new StreamWriter("/Users/nadaalotaibi/Desktop/NadaFile/" + Fname + ".txt");
            in.WriteLine(name);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(History), true))
            {
                outputFile.WriteLine($" {name} created {Fname}.txt {DateTime.Now} \n");
            }
        
            in.Flush();

            Console.WriteLine("Edit an existed File");
            in.WriteLine(Console.ReadLine());
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(History), true))
            {
                outputFile.WriteLine($" {name} edited {Fname}.txt {DateTime.Now} \n");
            }
            in.Flush();
            in.Close();
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
