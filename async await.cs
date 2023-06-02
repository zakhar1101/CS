using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newAppProject
{
    class kali
    {
        private string name = "undefined";
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                Console.WriteLine("Anime");
                name = value;
            }
        }
    }



    class Program
    {
        static void Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал равен {result}");
        }


        // определение асинхронного метода
        static async Task FactorialAsync(int n)
        {
            await Task.Run(() => Factorial(n));
        }


        static void Main(string[] args)
        {
            kali p1 = new kali();
            Console.WriteLine(p1.Name);
            p1.Name = "Water";
            Console.WriteLine(p1.Name);


            Console.ReadKey();
        }
    }
}
