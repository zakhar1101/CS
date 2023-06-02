using System;

namespace ConsoleApp1
{

    
    class Program
    {
        static void Main(string[] args)
        {
            var number = 5;
            var result = Square(number);
            Console.WriteLine($"Квадрат {number} равен {result}");
        }
        static int Square(int n) => n * n;
    }
}
