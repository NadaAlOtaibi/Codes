 static void Main(string[] args)
        {

            object [] o  = new object[5];
            o[0] = "Hi";
            o[1] = 1;
            o[2] = "Hello";
            o[3] = 534.0;
            o[3] = null;

            for (int i = 0; i < o.Length; i++)
            {
                string str = o[i] as string;
                if(str != null)
                {
                Console.WriteLine(" ' "+ str + " ' ");
                }
                else
                {
                Console.WriteLine(" Not a string");

                }
