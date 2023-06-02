using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace ConsoleApp4
{
    class Program
    {

        static void show<T>(T lst) where T: ObservableCollection<string>
        {
            Console.WriteLine("Новый список или массив: ");
            
            foreach (var item in lst)
            {
                Console.WriteLine($"\t{item}");
            }
            Console.WriteLine("\n");
            //Console.ReadKey();

        }


        static bool somefunc(string item)
        {
            return (item.Length == 3) ? true : false;


        }
        static void Main(string[] args)
        {
            List<string> people = new List<string>() { "Мисако", "Мария" };

            people.Add("Misaka Mikoto"); // add to end
            people.Add("Zakhar Aramilev");
            people.Insert(1, "Алла Пугачёва"); // insert item to specified index
            people.InsertRange(2, new[] { "Kate" }); // insert array to specified index
            people.InsertRange(2, new string[] { "Kate" }); // so work too
            people.AddRange(new string[] { "Евгения", "Александра" });
            people.Insert(3, "Mike");

            List<string> people_tmp = new List<string>(people);


            people.RemoveAt(1); // remove specified item on index
            people.RemoveAt(2);
            people.Remove("Kate");
            people.Remove("Kate");
            people.RemoveAll(people => people.Contains("д") || people.Contains("г") || people.Contains("я"));

            
            //show(people.ToArray());
            

            List<string> employees = new List<string>(people);
            employees[1] = "BuBu";

            List<string> somepeople = new List<string>(people) { "Елена", "Екатерина", "Власта", "Тянфестофель", "Satan" };
            somepeople.RemoveRange(1, 5);
            //show(somepeople.ToArray());
            somepeople.Clear();
            //show(somepeople.ToArray());

            //Установка начальной емкости списка // вариант 1
            List<string> people_v1 = new List<string>(16);
            //show(people_v1);
            
            
            // Вариант 2
            List<string> people_v2 = new List<string>();
            people_v2.Capacity = 89;
            //Console.WriteLine(somepeople.Capacity);
            List<string> people_v3 = new List<string>(people);
            people_v3.Add("Akemi");
            people_v3.Add("Akatsuki");
            people_v3.Add("Amy");
            people_v3.Add("Akane");
            people_v3.Add("Akihiko");
            people_v3.Add("Akihiro");

            int tmp1 = 3;
            int tmp2 = 20;
            
            // return true or false
            //Console.WriteLine($"Quantity={tmp1}: {people_v3.Exists(someitem => someitem.Length == tmp1)}");
            //Console.WriteLine($"Quantity={tmp2}: {people_v3.Exists(someitem => someitem.Length > tmp2)}");
            //Console.WriteLine($"Quantity experiments experience: {people_v3.Exists(item1 => somefunc(item1))}");

            // return first item
            var res1 = people_v3.Find(item => item.Length == 8);
            //Console.WriteLine($"find a first element: {res1}");

            // return last item
            var res2 = people_v3.FindLast(item => item.Length == 7);
            //Console.WriteLine($"find a last element: {res2}");

            // return list item
            var listres = people_v3.FindAll(item => item.Length > 9);
            //show(listres.ToArray());

            // copy item from List<> to Array
            string[] partOfpeople = new string[3];
            people_v3.CopyTo(0, partOfpeople, 0, 1);
            //show(partOfpeople);
            //Console.WriteLine(partOfpeople.Length);
            //show(people_v3.ToArray());

            List<string> people_v4 = new List<string>(people_tmp);
            //show(people_v4.ToArray());
            people_v4.Reverse();
            //show(people_v4.ToArray());
            people_v4.Reverse(3, 6); // начальный индекс и колличество
            //show(people_v4.ToArray());


            ObservableCollection<string> people_v21 = new ObservableCollection<string>();
            ObservableCollection<string> people_v22 = new ObservableCollection<string>(new string[] { "Max", "Pavel", "Timon" });
            ObservableCollection<string> people_v23 = new ObservableCollection<string>(new string[] { "Sasha", "Masha", "Pasha" }) { "Max", "Alex", "Tim", "Pavel", "Igor" };
            
            //show(people_v21);
            //show(people_v22);
            show(people_v23);

            Console.WriteLine($"index 0 {people_v23[0]}");
            people_v23[0] = "Muhamed";
            Console.WriteLine($"index 0 {people_v23[0]}");
            Console.WriteLine($"is true: {people_v23.Contains("Masha")}");
            people_v23.CollectionChanged += People_v23_CollectionChanged; // наличие подобного обработчика отличает их от List
            
            
            people_v23.Add("Bob");
            show(people_v23);
            people_v23.Move(0, 1); // index 0 --> index 1 item
            show(people_v23);
            people_v23.Add("Hito");
            people_v23.Add("Anna");
            Console.WriteLine(people_v23.IndexOf("Hito"));
            
            people_v23.Clear();
            //show(people);
            //show(employees);
            //show(somepeople);
            //Console.WriteLine(people);
            //Console.WriteLine(employees);
            //Console.WriteLine(somepeople);
        }

        private static void People_v23_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is string newPerson)
                    {
                        Console.WriteLine($"(add)Добавлен новый объект: {newPerson}");
                    }
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is string oldPerson)
                    {
                        Console.WriteLine($"(delete)Удален объект: {oldPerson}");
                    }
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    if ((e.NewItems?[0] is string replacingPerson) && (e.OldItems?[0] is string replacedPerson))
                    {
                        Console.WriteLine($"(Replace)Объект {replacedPerson} заменен объектом {replacingPerson}");

                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    if ((e.OldItems[0] is string oldPerson1) && (e.NewItems?[0] is string newPerson1))
                    {
                        Console.WriteLine($"(Move)Перемещение старый элемент: {oldPerson1}, новый элемент: {newPerson1}");

                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Console.WriteLine("(Reset)Сработал метод Cleer()");
                    break;
                default:
                    Console.WriteLine(" 1 1 1 1 1 1 1 ");

                    break;
            }
        }
    }
}
