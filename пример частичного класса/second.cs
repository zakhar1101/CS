using System;
using System.Net;
using System.Collections.Generic;



namespace struct_part_two
{

    struct Person
    {
        // fields be default private
        public string name;
        public int age;
        //public Person(string name, int age)
        //{
        //    this.name = name;
        //    this.age = age;
        //}

    }

    partial class Test {
        public string model;
        public Test(string model, int speed, int radius, string color)
        {
            this.speed = speed;
            this.model = model;
            this.radius = radius;
            this.color = color;
        }
        public void ShowCharacteristics()
        {
            Console.WriteLine($"Model: {model}\nSpeed: {speed}\nRadius: {radius}\nColor: {color}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Person person1 = new Person("Алексей", 43);
            Person person2 = new Person { name = "Даша", age = 43 }; // только поля должны быть public
            // При использовании инициализатора сначала вызывается конструктор без параметров:
            // если мы явным образом не определили конструктор без параметров,
            // то вызывается конструктор по умолчанию.А затем его полям присваиваются соответствующие значения.

            // Копирование структуры с помощью with
            // Если нам необходимо скопировать в один объект структуры значения из другого с небольшими изменениями,
            // то мы можем использовать оператор with:
            Person tom = new Person { name = "Tom", age = 22 };
            // Person bob = tom with { name = "Bob" }; // В моей версии не поддерживается
            Test test1 = new Test("Audi", 333, 34, "Red");
            test1.ShowCharacteristics();
            //test1.radius = 3;
            //test1.model = "Audi";
            //test1.speed = 453;


        }
    }
}
