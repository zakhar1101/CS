using System;
using System.Threading;
using System.Collections.Generic;

namespace ConsoleApp5
{


    class Numbers
    {
        //В классе Numbers метод GetEnumerator() фактически представляет итератор.
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return i * i;
            }
        }
    }

    static class Int32Extension // В данном случае итератор реализован как метод расширения для типа int или System.Int32.
    {
        public static IEnumerator<int> GetEnumerator(this int number)
        {
            int k = (number > 0) ? number : 0;
            for (int i = number - k; i <= k; i++)
            {
                yield return i;
            }
        }
    }
    class Person
    {
        public string Name { get; }
        public Person(string name) => Name = name;
    }
    class Company
    {
        Person[] staff;
        public Company(Person[] staff) => this.staff = staff;
        public int length => staff.Length;
        public IEnumerable<Person> GetStaff(int max)
        {
            for (int i = 0; i < max; i++)
            {
                if (i == length)
                {
                    Console.WriteLine("Сработал оператор: \"yield break;\""); // not work
                    Thread.Sleep(3000); // not work too
                    yield break;
                }
                else
                {
                    yield return staff[i];
                }
            }
        }

    }


    class Program
    {

        static public IEnumerable<Person> GetStaff(int max, int length, Person[] staff)
        {
            for (int i = 0; i < max; i++)
            {
                if (i == length)
                {
                    Console.WriteLine("Сработал оператор: \"yield break;\""); // not work
                    Thread.Sleep(3000); // not work too
                    yield break;
                }
                else
                {
                    yield return staff[i];
                }
            }
        }

        static void Main(string[] args)
        {
            //Semaphore sp = new Semaphore(3, 3);
            Numbers numbers = new Numbers();
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(numbers);


            foreach (var n in 5) Console.WriteLine(n);
            foreach (var n in -5) Console.WriteLine(n);

            var people = new Person[]
            {
                new Person("Tom"),
                new Person("Sam"),
                new Person("Max"),
                new Person("Tom"),
                new Person("Sam"),
                new Person("Max"),
                new Person("Tom"),
                new Person("Sam"),
                new Person("Max"),
                new Person("Tom"),
                new Person("Sam"),
                new Person("Max")
            };


            var microsoft = new Company(people);
            int acc = 0;

            /*
            foreach (var employee in microsoft.GetStaff(10))
            {
                Console.WriteLine($"Employee name: {employee.Name}, index={acc++}");
            }
            */



            //GetStaff(10, people.Length, people)
            foreach (var employee in GetStaff(10, people.Length, people))
            {

                Console.WriteLine($"Employee name: {employee.Name}, index={acc++}");
            }
        }
    }
}
