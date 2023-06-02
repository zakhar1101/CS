using System;
using System.Reflection; // рефлексия
using System.Linq; // linq
//using ClassLibrary1;


namespace ConsoleApp7
{
    public class Person
    {
        string name;
        public int Age { get; set; }
        public Person(string name, int age)
        {
            this.name = name;
            this.Age = age;
        }
        public void Print() => Console.WriteLine($"Name: {name}, Age: {Age}");
        public void Print1(string a1, string a2) => Console.WriteLine($"a1: {a1}, a2: {a2}");
        public void Show()
        {
            Console.WriteLine("SHow");
        }
    }


    class Program
    {


        static void Main(string[] args)
        {

            Assembly asm = Assembly.LoadFrom(@"ConsoleApp1.dll");  // Динамическое связывание
            Console.WriteLine(asm.FullName);
            Type[] types = asm.GetTypes();
            // получаем все типы из сборки
            foreach (var type in types)
            {
                Console.WriteLine(type.Name);
            }

            Type t = asm.GetType("ConsoleApp1.Program"); // Всегда использовать пространство имен
            Console.WriteLine($"t is {t}");
            if (t is not null)
            {
                MethodInfo square = t.GetMethod("Square", BindingFlags.NonPublic | BindingFlags.Static);
                object result = square?.Invoke(null, new object[] { 7 });
                Console.WriteLine(result);
            } 
            else
            {

            }
            Assembly asm1 = Assembly.LoadFrom(@"ClassLibrary1.dll");  // Динамическое связывание

            Console.WriteLine();
            Console.WriteLine(asm1.FullName);
            Type[] types1 = asm1.GetTypes();
            foreach (Type type in types1)
            {
                Console.WriteLine(type.Name);
            }
            //MethodInfo? square = testtype.GetMethod("say", BindingFlags.NonPublic | BindingFlags.Static);
            Type t1 = asm1.GetType("ClassLibrary1.test"); // Всегда использовать пространство имен
            Console.WriteLine();
            Console.WriteLine(t1);
            //test testclass = new test(0, 0, 0);
            //t1 b = new t1(0, 0, 0);
            var obj = Activator.CreateInstance(t1); 
            //object obj = 3;
            if (t1 is not null)
            {
                MethodInfo say = t1.GetMethod("say");
                say.Invoke(obj, null);
            }

            


            /*
            Type planetype = typeof(Plane);
            foreach (MemberInfo member in planetype.GetMembers())
            {
                Console.WriteLine($"{member.DeclaringType}...{member.MemberType}...{member.Name}");
            }
            */



            /*
            MethodInfo? typeinfo = type.GetMethod("say", BindingFlags.NonPublic | BindingFlags.Static);
            object? result = typeinfo?.Invoke(null, parameters: null);
            Console.WriteLine(result); // 49

            
            foreach (Type type in types)
            {
                Console.WriteLine(type);
            }
            Console.WriteLine();
            */

            /*
            Type planetype = typeof(Plane);
            foreach (MemberInfo member in planetype.GetMembers())
            {
                Console.WriteLine($"{member.DeclaringType}...{member.MemberType}...{member.Name}");
            }
            */


            //Person tom = new Person("Tom");

            //Type typeclass = typeof(Person); // Class
            // Type typeobject = tom.GetType(); // Object
            // Console.WriteLine(tom.somewhat);
            // DeclaringType - полное название типа
            /*
            foreach (MemberInfo member in typeclass.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                Console.WriteLine($"{member.DeclaringType}...{member.MemberType}...{member.Name}");
            Console.WriteLine();

            Person tom = new Person("Tom", 31);

            Console.WriteLine();
            var print = typeof(Person).GetMethod("Print");
            print.Invoke(tom, parameters: null);
            Console.WriteLine();

            Console.WriteLine();
            var print1 = typeof(Person).GetMethod("Print1");
            print1.Invoke(tom, parameters: new[]{ "bu1", "bu2" });
            Console.WriteLine();



            foreach (MethodInfo method in typeclass.GetMethods().Where(m => !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_"))) // Linq
            {
                string modificator = "";

                // если метод статический
                if (method.IsStatic) modificator += "static ";
                // если метод виртуальный
                if (method.IsVirtual) modificator += "virtual ";

                Console.WriteLine($"{modificator}{method.ReturnType.Name} {method.Name} ()");
            }
            Console.WriteLine();

            Type interface_type = typeof(IEater);
            Console.WriteLine($"Interface FullName: {interface_type.FullName}");

            Type typenameclass = Type.GetType("ConsoleApp7.Person", true, false); // 1 - генерировать исключения, 2 - учитавать регистр

            Console.WriteLine($"Name:      {typenameclass.Name}");         // получаем краткое имя типа
            Console.WriteLine($"Full Name: {typenameclass.FullName}");     // получаем полное имя типа
            Console.WriteLine($"Namespace: {typenameclass.Namespace}");    // получаем пространство имен типа
            Console.WriteLine($"Is struct: {typenameclass.IsValueType}");  // является ли тип структурой
            Console.WriteLine($"Is class:  {typenameclass.IsClass}");      // является ли тип классом
                
            Console.WriteLine("Реализованные интерфейсы:");
            foreach (Type i in typenameclass.GetInterfaces())
                Console.WriteLine(i.Name);
            
            Type myType = Type.GetType("PeopleTypes.Person, MyLibrary", false, true); // Cпособ получить тип из другой библиотеки
            //TypeLoadException)
            */

            //Console.WriteLine(typeclass);
            //Console.WriteLine(typeobject);

            ///То есть основная задача рефлексии - это исследование типов.

            // Assembly: класс, представляющий сборку и позволяющий манипулировать этой сборкой
            // AssemblyName: класс, хранящий информацию о сборке
            // MemberInfo: базовый абстрактный класс, определяющий общий функционал для классов EventInfo, FieldInfo, MethodInfo и PropertyInfo
            // EventInfo: класс, хранящий информацию о событии
            // FieldInfo: хранит информацию об определенном поле типа
            // MethodInfo: хранит информацию об определенном методе
            // PropertyInfo: хранит информацию о свойстве
            // ConstructorInfo: класс, представляющий конструктор
            // Module: класс, позволяющий получить доступ к определенному модулю внутри сборки
            // ParameterInfo: класс, хранящий информацию о параметре метода
            // Эти классы представляют составные блоки типа и приложения: методы, свойства и т.д.Но чтобы получить информацию о членах типа, нам надо воспользоваться классом System.Type.
            // Класс Type представляет изучаемый тип, инкапсулируя всю информацию о нем.С помощью его свойств и методов можно получить эту информацию. Некоторые из его свойств и методов:
            // Метод FindMembers() возвращает массив объектов MemberInfo данного типа
            // Метод GetConstructors() возвращает все конструкторы данного типа в виде набора объектов ConstructorInfo
            // Метод GetEvents() возвращает все события данного типа в виде массива объектов EventInfo
            // Метод GetFields() возвращает все поля данного типа в виде массива объектов FieldInfo
            // Метод GetInterfaces() получает все реализуемые данным типом интерфейсы в виде массива объектов Type
            // Метод GetMembers() возвращает все члены типа в виде массива объектов MemberInfo
            // Метод GetMethods() получает все методы типа в виде массива объектов MethodInfo
            // Метод GetProperties() получает все свойства в виде массива объектов PropertyInfo
            // Свойство Name возвращает имя типа
            // Свойство Assembly возвращает название сборки, где определен тип
            // Свойство Namespace возвращает название пространства имен, где определен тип
            // Свойство IsArray возвращает true, если тип является массивом
            // Свойство IsClass возвращает true, если тип представляет класс
            // Свойство IsEnum возвращает true, если тип является перечислением
            // Свойство IsInterface возвращает true, если тип представляет интерфейс








        }
    }
}
