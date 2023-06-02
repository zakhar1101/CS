using System;
using System.Collections; // IEnumerator
using System.Collections.Generic; // List<>, Dictionary<>

namespace ConsoleApp6
{

    class Week : IEnumerable // необязатьно реализовывать интерфейс IEnumerable // : IEnumerable -- можно закомментировать
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                        "Friday", "Saturday", "Sunday" };
        public IEnumerator GetEnumerator() => days.GetEnumerator(); // можно прокручивать дни в foreach -- GetEnumerator()
    }



    class WeekEnumerator : IEnumerator
    {
        string[] days;
        int position = -1; // начальная точка которая, если будет индексом, то будет ошибка
        public WeekEnumerator(string[] days) => this.days = days;
        public object Current // свойство класса WeekEnumerator с типом, который самый главный
        {
            get
            {
                if (position == -1 || position >= days.Length) // конец или начало --> ошибка
                    throw new ArgumentException();
                return days[position]; // иначе вернет текущй день из массива
            }
        }
        public bool MoveNext()
        {
            if (position < days.Length - 1) // текущая позиция меньше конца
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset() => position = -1;
    }

    class Week1 : IEnumerable // необязатьно реализовывать интерфейс IEnumerable // : IEnumerable -- можно закомментировать
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                        "Friday", "Saturday", "Sunday" };
        public IEnumerator GetEnumerator() => new WeekEnumerator(days); // можно прокручивать дни в foreach -- GetEnumerator()
    }

    
    class WeekEnumerator3 : IEnumerator<string> // Обобщённая реализация
    {
        string[] days;
        int position = -1;
        public WeekEnumerator3(string[] days) => this.days = days;
        public string Current // string not object
        {
            get
            {
                if (position == -1 || position >= days.Length)
                    throw new ArgumentException();
                return days[position];
            }
        }
        object IEnumerator.Current => throw new NotImplementedException();
        public bool MoveNext()
        {
            if (position < days.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset() => position = -1;
        public void Dispose() { }
    }
    class Week3
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                            "Friday", "Saturday", "Sunday" };
        public IEnumerator<string> GetEnumerator() => new WeekEnumerator3(days);
    }


    class Program
    {
        static void Main(string[] args)
        {
            //string[] people = new string[] { "Akiko", "Misako", "Ann" }; // норм
            //string[] people = { "Akiko", "Misako", "Ann" }; // норм
            //var people = { "Akiko", "Misako", "Ann" }; // ошибка
            var people = new[] { "Akiko", "Misako", "Ann" }; // норм
            int acc = 0;
            IEnumerator peopleIEnumerator = people.GetEnumerator();



        m1:
            peopleIEnumerator.MoveNext();
            Console.WriteLine(peopleIEnumerator.Current);
            if (++acc < people.Length)
                goto m1;
            peopleIEnumerator.Reset(); // сбрасываем указатель в начало массива
            acc = 0;



        m2:
            peopleIEnumerator.MoveNext();
            Console.WriteLine(peopleIEnumerator.Current);
            if (++acc < people.Length)
                goto m2;
            peopleIEnumerator.Reset();



            while (peopleIEnumerator.MoveNext())
            {
                Console.WriteLine($"while: {peopleIEnumerator.Current}");
            }

            Console.WriteLine("\n");
            Week week = new Week();
            foreach (var day in week)
            {
                Console.WriteLine($"class Week: {day}");
            }



            //Здесь теперь класс Week использует не встроенный перечислитель, а WeekEnumerator,
            //который реализует IEnumerator. Обрати внимание на реализация класса Week1
            Week1 week1 = new Week1();
            foreach (var day in week1)
            {
                Console.WriteLine($"class Week1 и WeekEnumerator: {day}");
            }

            Week3 week3 = new Week3();
            foreach (var day in week3)
            {
                Console.WriteLine($"class Week3 и WeekEnumerator3 обобщённая реализация: {day}");
            }

        }
    }
}
