using System;

namespace Делегаты
{
    class Program
    {
        public delegate void myDelegate();
        public delegate double myDelegateDouble(double p1, double p2);
        
        static double funcdouble1(double v1, double v2)
        {
            return v1 + v2;
        }
        static double funcdouble2(double v1, double v2)
        {
            return v1 - v2;
        }
        static double funcdouble3(double v1, double v2)
        {
            return v1 * v2;
        }
        static double funcdouble4(double v1, double v2)
        {
            return v1 / v2;
        }

        static void somefunc()
        {
            Console.WriteLine("Hello All");
        }
        static void somefunc2()
        {
            Console.WriteLine("print something!!!");
        }
        static void somefunc3()
        {
            Console.WriteLine("anatahasukositsukaremasu!!!");
        }


        static void Main(string[] args)
        {
            myDelegate md = new myDelegate(somefunc);
            md += somefunc3;
            md += somefunc2;
            md += somefunc3;
            md += somefunc3;
            md.Invoke();
            Console.WriteLine("-0-0-0-0-0-0-0-");
            md -= somefunc3;
            md -= somefunc3;
            md();
            Console.WriteLine("-0-0-0-0-0-0-0-");

            //md();

            myDelegateDouble mdd1 = new myDelegateDouble(funcdouble3);
            mdd1 += funcdouble1;
            myDelegateDouble mdd2 = new myDelegateDouble(funcdouble2);
            myDelegateDouble mdd3 = new myDelegateDouble(funcdouble3);
            myDelegateDouble mdd4 = new myDelegateDouble(funcdouble4);

            // 3+8 = 11 
            // 3-3 = 0
            // 3*3 = 9
            // 6/2 = 3
            // = 23
            double result = mdd1(3, 8) + mdd2(3, 3) + mdd3(3, 3) + mdd4(6, 2);



            Console.WriteLine(result);
            
            
            Console.ReadKey();
        }
    }
}
