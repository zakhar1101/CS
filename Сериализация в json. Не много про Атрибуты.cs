using System;
using System.Threading.Tasks; // Task, Parallel.{For,Foreach,Invoke}
using System.Threading; // Thread
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Text; // Encoding
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApp8
{

    [AttributeUsage(AttributeTargets.Class)]
    class AgeValidationAttribute : Attribute
    {
        public int Age { get; }
        public AgeValidationAttribute() { }
        public AgeValidationAttribute(int age) => Age = age;
    }



    //[AgeValidation(18)]
    //[AgeValidationAttribute(18)] // аттрибут созданный мной
    [AgeValidation(18)]
    public class Person //: IEnumerator
    {
        [JsonPropertyName("AGE")]
        public int Age { get; set; }
        [JsonPropertyName("NAME")]
        public string Name { get; } // в json объекте будет называться Name
        [JsonIgnore]
        public string sex { set; get; } // не сериализуется

        public Person(string name, int age)
        {
            Age = age;
            Name = name;
        }
    }
    class Program
    {
        static bool ValidateUser(Person person)
        {
            Type type = typeof(Person);
            object[] attributes = type.GetCustomAttributes(false); // turn on inheritance
            foreach (Attribute attr in attributes)
            {
                if (attr is AgeValidationAttribute ageAttribute)
                {
                    return person.Age >= ageAttribute.Age;
                }
            }
            return true;
        }
        static async void readwritefilejson(string persname="Tom", string filename="user.json")
        {
            //FileStream fs1 = new FileStream(filename, FileMode.OpenOrCreate);
            //byte[] somestring = Encoding.ASCII.GetBytes("парам парам ветер на корейском");
            //Thread.Sleep(5000);
            //Console.WriteLine($"111ffff{somestring} llle");
            
            //fs1.Write(somestring);
            //fs1.Close();
            
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                Person person = new Person(persname, 37);
                while (true)
                    await JsonSerializer.SerializeAsync<Person>(fs, person);
            }
            
            
        }
        static async void bubu1(string persname = "Bob", string filename = "company.json")
        {
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                Person person = new Person(persname, 37);
                while (true)
                    await JsonSerializer.SerializeAsync<Person>(fs, person);
            }
        }
        static void func(int i)
        {
            //Thread.CurrentThread.Name = ""
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} {i}");
        }
        static void Main(string[] args)
        {
            //Parallel.For(1, 10, func);   
            Person tom = new Person("Tom", 45);
            Person bob = new Person("Bob", 12);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // space
                AllowTrailingCommas = true, // Comma in end
                IgnoreReadOnlyProperties = false, // true - ignore read only properties
                // DefaultIgnoreCondition

            };

            readwritefilejson();
            bubu1();
            Console.WriteLine("123123123");

            string jsonserializer = JsonSerializer.Serialize(tom, options);
            Console.WriteLine(jsonserializer);


            

            Person personRestored = JsonSerializer.Deserialize<Person>(jsonserializer, options);
            Console.WriteLine(personRestored.Name);


            var resvaltom = ValidateUser(tom);
            var resvalbob = ValidateUser(bob);

            Console.WriteLine($"Том прошол валидацию: {resvaltom}");
            Console.WriteLine($"bob прошол валидацию: {resvalbob}");
        }
    }
}
