using System;

namespace anonimType
{
    class Program
    {
        class милфа
        {
            public int объём_сисек;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            // Анонимный объект
            var user = new { name = "Alex", age = 123 };

            Console.WriteLine($"user name: {user.name}\nuser age: {user.age}");


            // Массив анонимных объектов
            var people = new[]
            {
                new {Name = "Sam" },
                new {Name = "Alex" }
            };
            foreach(var item in people)
            {
                Console.WriteLine(item.Name);
            }


            // кортежи
            var tuple = (Л1:123, 123, "sdjfsdf", 34323); // неявное объявление кортежа
            var милфа = 123;

            Console.WriteLine(милфа);
            Console.WriteLine(tuple);
            Console.WriteLine(tuple.Л1); // Дефолтное поле
            Console.WriteLine(tuple.Item2);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);
            (int, double, int) tuple_explicit = (3, 3, 3);
            Console.WriteLine(tuple_explicit);
            милфа милфа1 = new милфа();
            милфа1.объём_сисек = 123123;
            Console.WriteLine(милфа1.объём_сисек);

            var tuple2 = (K1: 123, K2: 6456);
            Console.WriteLine(tuple2.Item1);
            Console.WriteLine(tuple2.K2);

            Console.WriteLine("------");
            (string, string) tuple3 = ("C++", "C#");
            Console.WriteLine(tuple3);
            tuple3 = (tuple3.Item2, tuple3.Item1);
            Console.WriteLine(tuple3);
            Console.WriteLine("\n");
            int[] nums = { 54, 7, -41, 2, 4, 2, 89, 33, -5, 12 };
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"{nums[i]} ");
            }
            Console.WriteLine();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        (nums[i], nums[j]) = (nums[j], nums[i]);
                    }
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"{nums[i]} ");
            }
            Console.WriteLine();



        }
    }
}
