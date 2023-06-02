using System;

namespace конструктор
{
    class Person
    {
        public string name;
        public int age;
        public Person() : this("Неизвестно")
        {
            Console.WriteLine("Cработал первый конструктор!");
        }
        public Person(string name) : this(name, 18)
        {
            Console.WriteLine("Cработал второй конструктор!");
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            Console.WriteLine("Cработал третий конструктор!");
        }
        public void print() => Console.WriteLine($"Name: {name}, Age: {age}");
        public void somemethod(out int v, out string v2)
        {
            v = 1;
            v2 = "А Настя!!! Анастасия!!! Ты просто Настя!!! Такое имя...";
            Console.WriteLine($"Address variable: {v}, {v2}");
        }

    }



    class Program
    {

        static void Main(string[] args)
        {
            // цепочка вызовов конструкторов
            Person max = new Person(); // (1)->(2)->(3)->3->2->1
            max.print();
            Person serg = new Person("SerGey"); // (2)->(3)->3->2
            serg.print();
            Person alan = new Person("Alan", 453); // (3)->3
            alan.print();
            Person tom = new Person { name = "Tom", age = 324 };
            tom.print();
            // out - позволяет передавать неинециалезированные переменные в функцию(по адресу)
            // ref - только инициализированные переменные(по адресу)


            int tmp;
            string name;
            //Console.WriteLine(tmp);
            tom.somemethod(out tmp, out name);
            Console.WriteLine(tmp);




        }

    }
}
