using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;


namespace ConsoleApp1
{
    class Program
    {
        static int port = 8005; // порт для приема входящих запросов
        static void Main(string[] args)
        {
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            // tcp socket
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // udp socket
            //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // Метод Listen вызывается только после метода Bind.
                // В качестве параметра он принимает количество входящих подключений, 
                // которые могут быть поставлены в очередь сокета.

                // После вызова метода Listen начинается прослушивание входящих подключений, 
                // и если подключения приходят на сокет, то их можно получить с помощью метода Accept:


                // начинаем прослушивание
                listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    // получаем сообщение

                    // Метод Accept извлекает из очереди ожидающих запрос первый запрос и 
                    // создает для его обработки объект Socket. Если очередь запросов пуста, 
                    // то метод Accept блокирует вызывающий поток до появления нового подключения.

                    // Для обработки запроса сначала в цикле do..while получаем данные с помощью метода Receive:


                    StringBuilder builder = new StringBuilder();


                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[256]; // буфер для получаемых данных

                    do
                    {
                        bytes = handler.Receive(data);
                        // Метод Receive в качестве параметра принимает массив байтов, 
                        // в который считываются полученные данные, и возвращает количество полученных байтов.


                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);

                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());

                    // отправляем ответ
                    string message = "ваше сообщение доставлено";
                    data = Encoding.Unicode.GetBytes(message);

                    // После получения данных клиенту посылается ответное сообщение с помощью метода Send, 
                    // который в качестве параметра принимает массив байтов:
                    handler.Send(data);
                    // закрываем сокет
                    // В конце обработки запроса надо закрыть связанный с ним сокет:


                    // Вызов метода Shutdown() перед закрытием сокета гарантирует, 
                    // что не останется никаких необработанных данных.
                    // Этот метод в качестве параметра принимает значение из перечисления SocketShutdown:
                    // Both: остановка как отправки, так и получения данных сокетом
                    // Receive: остановка получения данных
                    // Send: остановка отправки данных
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }



            Console.ReadKey();

        }
    }
}
