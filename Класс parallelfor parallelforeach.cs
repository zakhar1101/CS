using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Делегаты
{
    class Program
    {
        static void square(int n, ParallelLoopState pls)
        {
            if (n == 5) pls.Break();
            Console.WriteLine($"Выполняется задача: {Task.CurrentId}");
            Console.WriteLine($"square(n) = {n * n}");
        }
        static void func1()
        {
            Console.WriteLine("func1");
            Thread.Sleep(200);
        }
        static void func2()
        {
            Console.WriteLine("func2");
        }

        static void func3()
        {
            Console.WriteLine("func3");
        }



        static void Main(string[] args)
        {
            Parallel.For(1, 10, square);
            Parallel.Invoke(
                func1,
                func2,
                func3);

            ParallelLoopResult result = Parallel.ForEach<int>(
                new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 19, 19 },
                square
            );
            Console.WriteLine($"Успешно завершился: { ((result.IsCompleted)? "Да" : "Нет") }");
            Console.WriteLine($"Индекс на котором произошло прерывание: {result.LowestBreakIteration}");
        }
    }
}
