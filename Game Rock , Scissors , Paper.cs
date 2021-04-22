using System;

namespace rsp
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Choose 1 FOR Rock 2 FOR Scissors 3 FOR Paper");
             int UserInput =   Convert.ToInt32(Console.ReadLine());


            Random RandomNumber = new Random();
           
            int ComputerInput= RandomNumber.Next(3);
            if (ComputerInput == 1)
            {
                Console.WriteLine("Computer choosse Rock");
            }
            if (ComputerInput == 2)
            {
                Console.WriteLine("Computer choosse Scissors");
            }

            if (ComputerInput == 3)
            {
                Console.WriteLine("Computer choosse Paper");
            }
            if (ComputerInput == 1 && UserInput ==1 || ComputerInput == 2 &&  UserInput == 2 || ComputerInput == 3 && UserInput == 3)
            {
         Console.WriteLine("Tie");

            }

            else if (ComputerInput == 2 && UserInput ==1 || ComputerInput == 3 && UserInput == 2 || ComputerInput == 1 && UserInput == 3)
            {

       Console.WriteLine("You win");
            }


            else if (ComputerInput == 3 && UserInput == 1 || ComputerInput == 2 && UserInput == 3 || ComputerInput == 1 && UserInput == 2)
            {
       Console.WriteLine("You lose");

            }
           
          


        }
    }
}
