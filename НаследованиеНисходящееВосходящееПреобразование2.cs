using System;
using System.Threading.Tasks;
using System.Threading;



namespace ConsoleApp3
{

    class Person
    {
        private string name;
        private int age;
        public Person()
        {
            // 選択肢

        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
        }
        public void Print()
        {
            Console.WriteLine(Name);
        }
    }

    class Woman : Person // т.е. ДА! женщина - это человек
    {
        private double sizeboobs; // Дополнительные параметры
        public double SizeBoobs
        {
            set { sizeboobs = value; }
            get { return sizeboobs; }
        }
        public Woman(string name, int age, int sizeboobs) : base(name, age)
        {
            this.sizeboobs = sizeboobs;
        }


    }

    class Employee : Person
    {
        // Приватные поля родителя недоступны

        public Employee(string name, int age) : base(name, age)
        {

        }
        public Employee() : base("None", 0)
        {
            Console.WriteLine("Привет!");
        }
        void ShowSomeField()
        {
            //Console.WriteLine($"Name is {name}"); Не сработает по причине выше
            // Множественное наследование не работает, как в руби, так и в python, но я могу ошибаться
            Console.WriteLine($"Name is {Name}");
        }
    }

    sealed class Admin : Person // Запечатанный, запаянный, герметизированный - нельзя наследоваться - но может быть производным 
    {
        //То есть в классе Employee через ключевое слово base надо явным образом вызвать конструктор класса Person:

        public Admin(string name, int age) : base(name, age)
        {

        }

        public Admin() : base("None", 0)
        {

        }
    }
    class Man : Person
    {
        private int fucksize;
        private int cash;
        public Man(int fucksize) : base("Какой-то человек", 29)
        {
            this.fucksize = fucksize;
        }
        public Man(int fucksize, int cash) : this(int.MaxValue) // Не обязательно сюда писать fucksize
        {
            this.cash = cash;
        }

        public new void Print() // сокрытие метода (Бесполезно по сути своей) (можно смело удалить new и будет работать также)
        {
            Console.WriteLine($"Name is {Name}, cash: ${cash}, fucksize: {fucksize} sm");
        }
        
    }


    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Sasha", 12);
            p1.Print();
            Person p2 = new Employee(); // В обратную сторону не работает
            p2.Name = "Misha";
            
            p2.Print();

            Person a1 = new Admin();
            a1.Name = "Masha";
            a1.Print();

            /// Так метод ShowSomeFiled неработает - выдаст ошибку (Потому что Нисходящее преобразование(Downcasting) и Восходящее преобразование(Upcastinng)
            Person a2 = new Man(9999, 999999); // Upcasting/Восходящее


            Woman Nastya = new Woman("++++++++", 23, 1); // Переходим от человека к женщине
            Nastya.Print();
            Person nasty_person = Nastya; // upcasting
            Woman woman_nastya = (Woman)nasty_person; // downcasting

            Person p4 = new Person("People", 33);
            /// ошибка
            //Woman w4 = (Woman)p4;
            /// А так нет
            Woman w4 = p4 as Woman;
            Woman? w5 = null;

            woman_nastya.Print();


            // System.InvalidCastException: "Unable to cast object of type 'ConsoleApp3.Person' to type 'ConsoleApp3.Woman'."
            // Woman trap = (Woman)new Person("Генадий", 23); 

            // Можно так
            object obj = new Woman("++++", 22, 2);
            ((Woman)obj).Print(); // Видишь вначале Woman в скобка без этого бы не работало
            
            //a2.ShowSomeField();
            /// А так работает
            Man a3 = new Man(int.MaxValue, 999999);
            a3.Print();


        }
    }
}
