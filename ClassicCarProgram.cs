using System;
using System.Collections.Generic;

namespace Class
{

    class ClassicCar
    {
        public string m_Make;
        public string m_Model;
        public int m_Year;
        public int m_Value;



        public ClassicCar(string make, string model, int year, int val)
        {
            m_Make = make;
            m_Model = model;
            m_Year = year;
            m_Value = val;

        }
    }
    class program
    {
        static bool FindFords(ClassicCar car)
        {
            if (car.m_Make == "Ford") { 
            return true; }
        return false;
        }


    // }
    static int Search(List<ClassicCar> ls, string carName)
        {

            int count = 0;
            for (int i = 0; i < ls.Count; i++)
                if (ls[i].m_Make == carName)
                    count++;
            return count;
        }

        static int SearchExpen(List<ClassicCar> ls)
        {

            int count = 0;
            for (int i = 0; i < ls.Count; i++)
                if (ls[i].m_Value > count)
                    count = ls[i].m_Value;
                    return count;
        }

        static int CarsPrice(List<ClassicCar> ls)
        {

            int count = 0;
            for (int i = 0; i < ls.Count; i++)
                    count += ls[i].m_Value;
            return count;
        }

        static void populateData(List<ClassicCar> theList)
        {
            theList.Add(new ClassicCar("Alfa Romeo", "Spider Veloce", 1965, 15000));
            theList.Add(new ClassicCar("Alfa Romeo", "1750 Berlina", 1970, 20000));
            theList.Add(new ClassicCar("Alfa Romeo", "Giuletta", 1978, 45000));
            theList.Add(new ClassicCar("Ford", "Thunderbird", 1971, 15000));
            theList.Add(new ClassicCar("Ford", "Mustang", 1976, 15000));
            theList.Add(new ClassicCar("Ford", "Corsair", 1970, 15000));
            theList.Add(new ClassicCar("Ford", "LTD", 1969, 15000));
            theList.Add(new ClassicCar("Chevrolet", "Camaro", 1979, 15000));
            theList.Add(new ClassicCar("Chevrolet", "Corvette Stringray", 1966, 15000));
            theList.Add(new ClassicCar("Chevrolet", "Monte Carlo", 1984, 15000));
            theList.Add(new ClassicCar("Mercedes", "300SL Roadster", 1957, 15000));
            theList.Add(new ClassicCar("Mercedes", "SSKL", 1930, 15000));
            theList.Add(new ClassicCar("Mercedes", "130H", 1936, 15000));
            theList.Add(new ClassicCar("Mercedes", "250SL", 1968, 15000));

            Console.WriteLine("The cars amount:" + theList.Count);
            Console.WriteLine("Enter the name of the car you want to search about to check the amount:");
            string carNa = Console.ReadLine();
            Console.WriteLine("The amount of the car "+ carNa+ " is: "+ Search(theList, carNa));



        }


        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to add new car y/n ?!");
            string input = Console.ReadLine().Trim();
           
                List<ClassicCar> carList = new List<ClassicCar>();
                populateData(carList);

                Console.WriteLine("The entire collection worth: "+SearchExpen(carList));

                Console.WriteLine("The most valuable car: "+CarsPrice(carList));
                Predicate<ClassicCar> f = FindFords;

                List<ClassicCar> fordList = carList.FindAll(FindFords);

                Console.WriteLine("The Ford cars are: {0}", fordList.Count);


                Console.WriteLine("Thank you!");

            }
        }


        }
    
