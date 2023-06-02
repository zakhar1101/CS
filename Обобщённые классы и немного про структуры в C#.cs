using System;
using System.Collections.Generic;



namespace test4
{

    // Обобщённые классы
    class Plane<T>
    {
        private int speed;
        public T field;
        public Plane(int speed)
        {
            this.speed = speed;
        }
        public int Speed { get; set; }

    }

    class Plane1<T>
    {
        private int speed;
        public T field;
        public Plane1(int speed)
        {
            this.speed = speed;
        }
        public int Speed { get; set; }

    }

    class Person<T>
    {
        public T Id { get; }
        public Person(T id)
        {
            Id = id;
        }
    }

    // Первый вариант заключается в создание класса-наследника, который типизирован тем же типом, что и базовый:
    class UniversalPerson<T> : Person<T>
    {
        public UniversalPerson(T id) : base(id) { }
        
    }

    // Второй вариант представляет создание обычного необобщенного класса-наследника.
    // В этом случае при наследовании у базового класса надо явным образом определить используемый тип:
    class StringPerson : Person<string>
    {
        public StringPerson(string id) : base(id) { }
    }

    // Третий вариант представляет типизацию производного класса параметром совсем другого типа,
    // отличного от универсального параметра в базовом классе.
    // В этом случае для базового класса также надо указать используемый тип:
    class IntPerson<T> : Person<int>
    {
        public T Code { get; set; }

        public IntPerson(int id, T code) : base(id)
        {
            Code = code;
        }
    }


    class MixedPerson<T, K> : Person<T> where K: struct
    {
        public K Code;
        public MixedPerson(T id, K code) : base(id)
        {
            Code = code;
        }
    }
    
    class ClassA
    {
        public int tmp = 3; // а в класса так можно
    }


    //Конструкторы структуры
    //Как и класс, структура может определять конструкторы.
    //Однако, если в структуре определяется конструктор,
    //то в нем обязательно надо инициализировать все поля структуры.
    struct StructA
    {
        //public int tmp = 34; 
        // так можно только с версии шарпа 10 
        // Инициализация полей по умолчанию
        private int tmp;
        public int tmp2;

        public StructA(int tmp,int tmp2)
        {
            this.tmp = tmp;
            this.tmp2 = tmp2;
        }
    }
    
    
    
    
    
    
    
    
    
    class Program
    {
        static void func<T>(T obj) where T: Plane<int> //, Plane<int>
        {
            Console.WriteLine(obj.Speed);
        }
        static void Main(string[] args)
        {
            Person<string> person1 = new Person<string>("34");
            Person<int> person3 = new UniversalPerson<int>(45);
            UniversalPerson<int> person2 = new UniversalPerson<int>(33);
            StringPerson person4 = new StringPerson("12343");
            Person<string> person5 = new StringPerson("1421431");
            IntPerson<string> person6 = new IntPerson<string>(64, "sfds");
            Person<int> person7 = new IntPerson<string>(34, "gdfg");

            Console.WriteLine($"person1: {person1.Id}");
            Console.WriteLine($"person2: {person2.Id}");
            Console.WriteLine($"person3: {person3.Id}");
            Console.WriteLine($"person4: {person4.Id}");
            Console.WriteLine($"person5: {person5.Id}");
            Console.WriteLine($"person6: {person6.Id}");
            Console.WriteLine($"person7: {person7.Id}");
            Console.WriteLine($"person6 test with person6: {person6.Code}"); // person6

            // Здесь тип IntPerson типизирован еще одним типом, который может не совпадать с типом,
            // который используется базовым классом.Применение класса:
            // И также в классах-наследниках можно сочетать использование универсального параметра
            // из базового класса с применением своих параметров:
            MixedPerson<string, int> person8 = new MixedPerson<string, int>("bububu", 43);
            Person<string> person9 = new MixedPerson<string, int>("bubbubu4324u", 41233);
            Console.WriteLine($"person8: {person8.Id}");
            Console.WriteLine($"person9: {person9.Id}");

            ClassA ObjClassA;
            //ObjClassA.tmp = 3; // error don't do it // it is Class reaseon!

            ObjClassA = new ClassA();
            Console.WriteLine($"Объект класса классаА: {ObjClassA.tmp}");

            StructA ObjStructA;
            //ObjStructA.tmp = 33; // neace it work success // it is Struc reason! Error reason: private


            //Console.WriteLine($"person7 test with person7: {person7.Code}"); -- Error in a Person7 don't have Code




            //Plane<int> es1 = new Plane<int>(900);
            //Plane1<int> es2 = new Plane1<int>(990);


            // Для каждого типа создалось своё значение
            // Как в C++ можно создовать обобщённые методы
            //Plane<int, double>.id = 343;
            //Plane<string, decimal>.id = "some stirng numberr4234";

            //func<Plane>(es1);
            //func<Plane<int>>(es1);
            //////func<Plane1<int>>(es2);

            //Console.WriteLine(Plane<int, double>.id);
            //Console.WriteLine(Plane<string, decimal>.id) ;





        }
    }
}
