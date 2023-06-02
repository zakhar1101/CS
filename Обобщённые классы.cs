using System;
using System.Collections.Generic;
namespace test4
{

    // Обобщённые классы
    class Plane<T, D>
    {
        private int speed;
        public static T id;
        public Plane(int speed)
        {
            this.speed = speed;
        }
        public int Speed { get; set; }

    }

    class Program
    {
        static void func<T>(out int x1, out int x2)
        {
            x1 = 5;
            x2 = 5;
            Console.WriteLine(Convert.ToString(x1) + "_" + x2.ToString());
        }
        static void Main(string[] args)
        {
            //Plane<int> es1 = new Plane<int>(900);
            //Plane<string> es2 = new Plane<string>(990);


            // Для каждого типа создалось своё значение
            // Как в C++ можно создовать обобщённые методы
            Plane<int, double>.id = 343;
            Plane<string, decimal>.id = "some stirng numberr4234";

            int a;
            int b;

            func<int>(out a,out b);
            //Console.WriteLine(Plane<int, double>.id);
            //Console.WriteLine(Plane<string, decimal>.id) ;





        }
    }
}
