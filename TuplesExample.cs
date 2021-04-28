using System;

namespace _28apr
{
    class Program
    {

        static Tuple <int, string, string> Displayl()
        {
            return Tuple.Create(1, "FN", "LN");
        }

        static Tuple<int, string> Display2l(int id, string name) => Tuple.Create(id, name);

        static void Display(Tuple<int, string, string> person) {
            Console.WriteLine("ID: ",person.Item1);
            Console.WriteLine("First Name : ",person.Item2);
            Console.WriteLine("Last Name : ",person.Item3);

       }
        static void Main(string[] args)
        {

          var dis =  Displayl();
          Console.WriteLine(dis);

            var vr =  Display2l(5,"Nada");
         
            Console.WriteLine(vr);
             var person = Tuple.Create(1, "FN", "LN");
             Display(Tuple.Create(1, "FN", "LN"));
             Tuple<int, string, bool> myTuple = new Tuple<int, string, bool>(1, "Hello", true);
             var myTuplek = Tuple.Create(1, "sara", false);
             var myTuplef = Tuple.Create(1,2,3,4,5,6,7,Tuple.Create(8,9,10,11,12,13));
             Console.WriteLine(myTuplef.Rest.Item1.Item1);
        }
    }
}
