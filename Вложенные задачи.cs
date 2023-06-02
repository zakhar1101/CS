using System;
using System.Threading;
using System.Threading.Tasks;

namespace Вложенные_задачи
{
    class Program
    {
        static Random Rnd = new Random();
        static void somefunc()
        {
            Console.WriteLine("Начало");
            Thread.Sleep(Rnd.Next(200, 300));
            var outer = Task.Factory.StartNew(subsomefunc);

            outer.Wait();
            Console.WriteLine("Происходит какое-то действие!");
            Console.WriteLine("Конец");
        }

        static void subsomefunc()
        {
            Console.WriteLine("Виртуальный мир. Начало");
            Thread.Sleep(Rnd.Next(200, 300));
            Console.WriteLine("Происходит какое-то действие в моей виртуальной вселенной!");
            Console.WriteLine("Виртуальный мир. Конец");
        }


        static void Main(string[] args)
        {
            // Может быть лямбда выражение
            // Можно было сделать через лямбды ДА!, но мне похуй
            var outer = Task.Factory.StartNew(somefunc);

            outer.Wait();
        }
    }
}
