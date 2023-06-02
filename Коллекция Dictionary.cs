using System;
using System.Collections.Generic;

namespace словарика
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> people = new Dictionary<int, string>();
            Dictionary<int, string> person = new Dictionary<int, string>()
            {
                { 123, "Tom" },
                { 34, "Sam" },
                { 35, "Alan" }

            };
            // При инициализации применяется инициализитор - в фигурных скобках после вызова конструктора объекту
            // передаются начальные данные.В случае со словаем мы можем передать в инициализаторе набор элементов,
            // где каждый элемент заключается в фигурные скобки

            Dictionary<int, string> people2 = new Dictionary<int, string>()
            {
                [0] = "Alla",
                [1] = "Anna",
                [2] = "Akitsuko"    
            };

            // При таком способе инициализации в квадратных скобках указывается ключ и ему
            // присваивается значение элемента.
            // Но в целом этот способ инициализации будет равноценен предыдущему.

            KeyValuePair<int, string> mike = new KeyValuePair<int, string>(13, "Mike");
            KeyValuePair<int, string> sam = new KeyValuePair<int, string>(2, "Sam");
            KeyValuePair<int, string> bill = new KeyValuePair<int, string>(3, "Bill");
            KeyValuePair<int, string> jack = new KeyValuePair<int, string>(4, "Jack");
            List<KeyValuePair<int, string>> name_list = new List<KeyValuePair<int, string>>() { mike,sam,bill,jack };

            Dictionary<int, string> people3 = new Dictionary<int, string>(name_list);
            people3[1] = "Elise"; // если такого элемента нет, то он добавится, иначе изменится
            people3[2] = "Agnes";
            people3.Add(32, "Alice");


            bool resultTryAdd = people3.TryAdd(33, "Iris"); // try if success false if error
            Console.WriteLine(resultTryAdd);
            Console.WriteLine(people3.Count); // Quantity of elements dictionary

            Console.WriteLine($"Are there key: {people3.ContainsKey(2)}");
            Console.WriteLine($"Are there Value: {people3.ContainsValue("1231")}");
            Console.WriteLine(people3.Remove(3)); // в случае успеха также возврщает истину, иначе ложь
            string res;
            people3.Remove(13, out res); // версия метода Remove номер 2 возвращает удалённое значение во второй параметр
            Console.WriteLine(res); // если элементом с данным ключом нет, то ничего не возвращается
            people3.Add(13, "Misaka Mikoto"); // Добавляем новый элемент словаря
            string res1;
            people3.TryGetValue(4, out res1); // если успешно вернет 1, иначе 0. В случае успеха запишет значение элемента в res1
            Console.WriteLine(res1);

            foreach (var pers in people3)
            {
                Console.WriteLine($"Person name: {pers.Value}, Person key: {pers.Key}");
            }
            
        }
    }
}
