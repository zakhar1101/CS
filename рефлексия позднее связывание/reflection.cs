using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{

    // Также начиная с версии C# 8.0 интерфейсы поддерживают реализацию методов и свойств по умолчанию.
    // Это значит, что мы можем определить в интерфейсах полноценные методы и свойства,
    // которые имеют реализацию как в обычных классах и структурах.
    // Например, определим реализацию метода Move по умолчанию:
    interface IMovable1
    {
        // реализация метода по умолчанию
        void Move()
        {
            Console.WriteLine("Walking");
        }
    }
    interface IEater // по умолчанию интрефейс имеет модификатор доступа Internal, если не указать public
    {
        void Eat();
    }

    interface IMovable // по умолчанию интрефейс имеет модификатор доступа Internal, если не указать public
    {
        public void Move();
        public int somewhat { get; set; }

    }
    class Class1
    {




    }


    class Person1 : IEater, IMovable1
    {
        private string name { get; }
        public Person1(string name) => this.name = name;
        public void Move() => Console.WriteLine($"name {name} eats");
        public void Eat() => Console.WriteLine($"name {name} moves;");
        public int somewhat { set; get; }

    }
}
