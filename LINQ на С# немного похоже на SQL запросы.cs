using System;
using System.Collections.Generic;
using System.Linq;


namespace console_linq_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

            // создаем новый список для результатов

            //Операторы запросов LINQ
            var selectedPeople1 = from p in people where p.ToUpper().StartsWith("T") orderby p select p;

            Console.WriteLine("Операторы запросов LINQ");
            foreach (string person in selectedPeople1)
                Console.WriteLine(person);


            //Методы расширения LINQ
            var selectedPeople2 = people.Where(p => p.ToUpper().StartsWith("T")).OrderBy(p => p);
            Console.WriteLine("Методы расширения LINQ");
            foreach (string person in selectedPeople2)
                Console.WriteLine(person);


            /*
            // создаем новый список для результатов
            var selectedPeople = from p in people // передаем каждый элемент из people в переменную p
                                 where p.ToUpper().StartsWith("T") //фильтрация по критерию
                                 orderby p  // упорядочиваем по возрастанию
                                 select p; // выбираем объект в создаваемую коллекцию

            */


        }
    }
}
