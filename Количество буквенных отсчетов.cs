using System;
using System.Collections.Generic;

namespace ConsoleApp11
{
    class Program
    {
        static int func(int number)
        {
            int acc = 0;
            int num;
            int tmp = number;
            while (tmp > 0)
            {
                num = tmp % 10;



                
                Console.WriteLine(num);
                tmp /= 10;
                acc++;
            }
            return acc;
        }

        static int func1(int number)
        {
            
            List<int> dec0part = new List<int>() { 3, 3, 5, 4, 4, 3, 5, 5, 4, 3 }; // 1-10
            List<int> dec1part = new List<int>() { 6, 6, 8 }; // 11-13
            List<int> dec2part = new List<int>() { 8, 7, 7, 9, 8, 8 }; // 14-19
            List<int> dec3part = new List<int>() { 6, 6, 5, 5, 5, 7, 6, 6 }; //20,30..90

            int handred = 7;
            int one_thousand = 11;
            int result = 0;
            if (number > 99 && number < 1000)
                if (number % 100 == 0)
                {
                    result += dec0part[number / 100 - 1] + handred;
                    return result;
                }
                else
                    result += dec0part[number / 100 - 1] + handred + 3;
            else if (number == 1000)
            {
                result += one_thousand;
                return result;
            }

            int i1 = number % 100;
            if (i1 <= 10)
            {
                result += dec0part[i1 - 1];
            }
            else if (i1 > 10 && i1 <= 13)
            {
                result += dec1part[i1 - 11];
            }
            else if (i1 > 13 && i1 <= 19)
            {
                result += dec2part[i1 - 14];
            }
            else if (i1 > 19 && i1 < 100)
            {
                if (i1 % 10 == 0)
                    result += dec3part[i1 / 10 - 2];
                else
                    result += dec3part[i1 / 10 - 2] + dec0part[i1 % 10 - 1];
            }
            return result;
        }
        static void Main(string[] args)
        {
            int number = 1000;
            int result = 0;
            int test = 342;
            result += func1(test);
            Console.WriteLine(result);
            return;
            //for (int i = 1; i <= number; i++)
            //{
            //    result += func1(i);

            //}

            Console.WriteLine(result);

            
            



            //Fourteen, Fiveteen, Sixteen, Seventeen", "Eighteen", "Nineteen"
            /*
            if (i <= 10)W
            {
                result += arr0_10[i].Length;  
            }
            else if (i > 10 && i <= 13)
            {
                result += "Eleven".Length;
                result += "Twelve".Length;
                result += "Thirteen".Length;
            }
            else if (i > 14 && i < 20 && i % 100 > 14 && i % 100 < 20)
            {
                result += arr0_10[i % 10].Length + 4;
            }
            else if (i >= 20 && i < 100 && i % 100 >= 20 && i % 100 < 100)
            {

            }*/
            //Console.WriteLine($"result: {func(334635)}");

            /*
            for (int i = 1; i <= 1000; i++)
            {
                // 935
                tmp = i;
                Console.WriteLine(func(tmp));
                

            }
            */

        }
    }
}
