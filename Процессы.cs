using System;
using System.Diagnostics; // процессы
using System.Runtime.Loader; // загрузка и выгрузка сборок
using System.Collections.Generic;

namespace ConsoleApp10
{



    class Program
    {


        static void Main(string[] args)
        {

            Console.WriteLine("Start program");
            //Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome");

            //Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome", "https://metanit.com");
            //Чтобы отделить настройку параметров запуска от самого запуска можно использовать класс ProcessStartInfo:
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = @"C:\Program Files\Google\Chrome\Application\chrome";
            psi.Arguments = @"https://metanit.com";
            Process.Start(psi);
            
        }
    }
}
