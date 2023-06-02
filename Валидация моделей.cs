using System;
using System.Windows;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace WpfApp7
{

    public class User
    {
        [Required(ErrorMessage = "Не указано, имя пользователя!")] // Но можно и не указывать
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Недопустимая длина имени!")]
        public string name { set; get; }
        [Range(-10, 100, ErrorMessage = "Недопустимый возраст!")]
        public int age { set; get; }
        public User(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

    }
    
    [UserValidation]
    public class User1
    {
        [UserName]
        public string Name { get; set; }

        public int Age { get; set; }

        public User1(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    public class UserValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is User1 user)
            {
                if (user.Name == "Tom" && user.Age == 37)
                {
                    ErrorMessage = "Имя не должно быть Tom и возраст одновременно не должен быть равен 37";
                    return false;
                }
                return true;
            }
            return false;
        }
    }
    public class UserNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string userName)
            {
                if (userName != "admin")    // если имя не равно admin
                    return true;
                else
                    ErrorMessage = "Некорректное имя: admin";
            }
            return false;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void getallmodules()
        {
            Process proc2 = Process.GetProcessesByName("devenv")[0]; // для Windows
                                                                     // Process proc = Process.GetProcessesByName("VisualStudio")[0]; // для MacOS
            ProcessModuleCollection modules = proc2.Modules;

            foreach (ProcessModule module in modules)
            {
                t1.Text += $"Name: {module.ModuleName}\r\n" +
                    $"FileName: {module.FileName}\r\n" +
                    $"Address: {module.EntryPointAddress} - адрес функции в памяти, которая запустила модуль\r\n" +
                    $"ModuleMemorySize: {module.ModuleMemorySize}\r\n" +
                    $"BaseAddress: {module.BaseAddress} - адрес модуля в памяти\r\n" +
                    $"\r\n";
            }
        }
        private void getallprocessthread()
        {
            Process proc = Process.GetProcessesByName("devenv")[0];  // Windows
                                                                     // Process proc = Process.GetProcessesByName("VisualStudio")[0];  // MacOS
            ProcessThreadCollection processThreads = proc.Threads;

            foreach (ProcessThread thread in processThreads)
            {
                t1.Text += $"ThreadId: {thread.Id}\r\n";
            }
        }
        private void getallidprocess() // Получим id процессов, который представляют запущенные экземпляры Visual Studio:
        {
            Process[] vsProcs = Process.GetProcessesByName("devenv");   // для Windows
                                                                        // Process[] vsProcs = Process.GetProcessesByName("VisualStudio"); //  для MacOS
            foreach (var proc1 in vsProcs)
                t1.Text += $"ID: {proc1.Id}\r\n";


        }
        private void getallproccess()
        {
            foreach (Process process1 in Process.GetProcesses())
            {
                // выводим id и имя процесса
                t1.Text += $"ID: {process1.Id}  Name: {process1.ProcessName}\r\n";
            }
        }
        private void showsomeproperty()
        {
            var process = Process.GetCurrentProcess();
            t1.Text += $"Id: {process.Id}\r\n";
            t1.Text += $"Name: {process.ProcessName}\r\n";
            t1.Text += $"VirtualMemory: {process.VirtualMemorySize64}\r\n";
            t1.Text += $"MachineName: {process.MachineName}\r\n";

        }
        private void domainapp()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            t1.Text += $"Name: {domain.FriendlyName} \r\n";
            t1.Text += $"BaseDirectory: {domain.BaseDirectory} \r\n";
            t1.Text += $"SetupInformation: {AppDomain.CurrentDomain} \r\n";
            t1.Text += $"SetupInformation: {domain.SetupInformation} \r\n";
        }
        private void showallassm()
        {
            // Получим имя и базовый каталог текущего домена и выведем все загруженные в домен сборки:
            AppDomain domain = AppDomain.CurrentDomain;
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly item in assemblies)
            {
                t1.Text += $"{item.GetName().Name}\r\n";
                //t1.text += $"{item}\r\n";
            }
        }
        private void loadandupload()
        {
            Square(8);

            // очистка памяти
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void Square(int number)
        {
            var context = new AssemblyLoadContext(name: "Square", isCollectible: true);
            context.Unloading += Context_Uploading;

            //t1.Text += Path.Combine(Directory.GetCurrentDirectory(), "ConsoleApp1.dll");
            //t1.Text += "\r\nC:\\Users\\User\\Code\\.NET projects\\WpfApp7\\WpfApp7\\ConsoleApp1.dll\r\n";
            //var assemblyPath = @"C:\Users\User\Code\.NET projects\WpfApp7\ConsoleApp1\bin\Debug\net5.0\ConsoleApp1.dll";
            var assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), "ConsoleApp1.dll");
            Assembly assembly = context.LoadFromAssemblyPath(assemblyPath);
            var type = assembly.GetType("ConsoleApp1.Program");
            if (type != null)
            {
                var squareMethod = type.GetMethod("Square", BindingFlags.Static | BindingFlags.NonPublic);
                var result = squareMethod.Invoke(null, new object[] { number });

                if (result is int)
                {
                    t1.Text += $"Квадрат числа {number} равен {result}\r\n";
                }


            }

            t1.Text += "\r\nСборки в проекте: \r\n";
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                t1.Text += $"\t{asm.GetName().Name}\r\n";
            }
            t1.Text += $"\r\nИтого сборок в проекте: {AppDomain.CurrentDomain.GetAssemblies().Length} \r\n";
            context.Unload();



        }
        private void CreateUser(string name, int age)
        {
            User user1 = new User(name, age);
            var context = new ValidationContext(user1);

            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(user1, context, results, true)) // 4 - надо ли валидировать все свойства. // if return -> false // failed validation
            {
                t1.Text += "Не удалось создать объект user!\r\n";
                foreach (var error in results)
                {
                    t1.Text += error+"\r\n";
                }
                t1.Text += "\r\n";

            }
            else
                t1.Text += $"Объект успешно создан name: {user1.name}\r\n";

        }
        void Validate(User1 user)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    t1.Text += error.ErrorMessage;
                }   
            }
            else
                t1.Text += "Пользователь прошел валидацию\r\n";
            t1.Text += "\r\n";
        }



        private void bu(object sender, RoutedEventArgs e)
        {
            //getallmodules();
            //domainapp();
            //showallassm();
            //loadandupload();
            //CreateUser("Tom", 37);
            //CreateUser("bdfggf", -4);
            //CreateUser("", 130);


            Validate(new User1("Tom", 37));
            Validate(new User1("Bob", 37));
            Validate(new User1("admin", 37));









        }
    }
}
