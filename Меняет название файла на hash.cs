using System;
using System.IO;
using System.Security.Cryptography;
using System.Text; // ASCIIEncoding
using gethash;



namespace hensyuukakutyousi
{
    class Program
    {
       

        static void Main(string[] args)
        {
            string curdir = @"C:\Users\User\Downloads\";

            DirectoryInfo dir1 = new DirectoryInfo(curdir);
            if (dir1.Exists)
            {
                Console.WriteLine("Список каталогов: ");
                string[] dirs = Directory.GetDirectories(curdir);
                foreach(var dir in dirs)
                {
                    Console.WriteLine(dir);
                }
                Console.WriteLine("Список файлов: ");
                string[] files = Directory.GetFiles(curdir);
                
                foreach (var fil in files)
                {
                    FileInfo fi = new FileInfo(fil);
                    if (fi.Extension.ToLower() == ".jpg" | fi.Extension.ToLower() == ".png" | fi.Extension.ToLower() == ".jpeg")
                    {
                        Console.WriteLine(fil);
                        File.Move($"{curdir}{fi.Name} ", $"{curdir}{Class1.GetHashMD5(fi.Name)}{fi.Extension}");
                        
                    }
                }
            }

            








        }
    }
}
