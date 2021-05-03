using System;
using System.Collections.Generic;

namespace ShopProject
{
    class Item
    {
       static List<string> theList = new List<string>();
        static int choice;
        static int count;
        public string Iphone;
        public string macP;
        public string macA;
        public string Airpods;



        public Item(string Iphone, string macP, string macA, string Airpods)
        {
            Iphone = this.Iphone;
            macP = this.macP;
            macA = this.macA;
            Airpods = this.Airpods;

        }



        static void Main(string[] args)
        {
        Find:
            Console.WriteLine("Hello customre choose what do you want to buy! \n 1- IPhone\n 2- Macbook Pro\n  3- Macbook Air\n 4- Airbods \n 5-  to count your items  \n 6- to edit \n  7- to exit");
            choice = Convert.ToInt32(Console.ReadLine());



            do
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("IPhone! would cost you 6000 Do you want it y/n?");
                        string res = Console.ReadLine();
                        if (res.Equals("Y") || res.Equals("y"))
                        {
                            Console.WriteLine("IPhone! added");
                            count += 6000;

                            theList.Add("IPhone");

                            goto Find;

                        }
                        else
                        {
                            Console.WriteLine("AS YOU WISH!");
                            goto Find;

                        }

                        break;

                    case 2:
                        Console.WriteLine("Macbook Pro! would cost you 7000 Do you want it y/n?");
                        string res1 = Console.ReadLine();
                        if (res1.Equals("Y") || res1.Equals("y"))
                        {
                            Console.WriteLine("Macbook Pro! added ");
                            count += 7000;
                            theList.Add("Macbook pro");


                            goto Find;

                        }
                        else
                        {
                            Console.WriteLine("AS YOU WISH!");
                            goto Find;

                        }
                        break;



                    case 3:
                        Console.WriteLine("Macbook Air! would cost you 5500 Do you want it y/n?");
                        string res2 = Console.ReadLine();
                        if (res2.Equals("Y") || res2.Equals("y"))
                        {
                            Console.WriteLine("Macbook Air! added");
                            count += 5500;
                            theList.Add("Macbook Air");

                            goto Find;


                        }
                        else
                        {
                            Console.WriteLine("AS YOU WISH!");
                            goto Find;

                        }

                        break;

                    case 4:
                        Console.WriteLine("Airbods! would cost you 550 Do you want it y/n?");
                        string res3 = Console.ReadLine();
                        if (res3.Equals("Y") || res3.Equals("y"))
                        {
                            Console.WriteLine("Airbods ! added");
                            count += 550;
                            theList.Add( "Airbods");


                            goto Find;

                        }
                        else
                        {
                            Console.WriteLine("AS YOU WISH!");
                            goto Find;

                        }

                        break;

                    case 5:
                        Console.WriteLine("Your items are:");
                        Console.WriteLine(theList.Count);
                        foreach (var i in theList)
                        {
                            Console.WriteLine(i);
                        }
                        Console.WriteLine("Your total is:");
                        Console.WriteLine(count);
                        if(count >= 10000)
                        {
                            Console.WriteLine("You got a discount:");
                         int afterDiscount = count - (count * 10 / 100);
                            Console.WriteLine(afterDiscount);


                        }
                        goto Find;

                        break;
                    case 6:
                        Console.WriteLine("Do you want to edit item y/n?");
                        string resp = Console.ReadLine();
                        if (resp.Equals("Y") || resp.Equals("y"))
                        {
                            Console.WriteLine("What do you want to delete?");
                            Console.WriteLine(" write the name of the item IPhone  , Macbook pro , Macbook air ,   Airbods");
                            string resi  = Console.ReadLine();
                            if (resi.Equals("IPhone")){
                                theList.Remove("IPhone");
                                Console.WriteLine("item deleted");
                            }

                            else if (resi.Equals("Macbook pro"))
                            {
                                theList.Remove("Macbook pro");
                                Console.WriteLine("item deleted");

                            }
                            else if (resi.Equals("Macbook Air"))
                            {
                                theList.Remove("Macbook Air");
                                Console.WriteLine("item deleted");

                            }

                            else if (resi.Equals("Airbods"))
                            {
                                theList.Remove("Airbods");
                                Console.WriteLine("item deleted");

                            }


                        }
                        goto Find;

                        break;

                }
            } while (choice != 7);
       
        }
    }
}
