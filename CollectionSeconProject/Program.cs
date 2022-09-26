using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CollectionSeconProject
{
    class Student
    {
        public string Name { set; get; }
        public Student(string name) => Name = name;
    }
    internal class Program
    {
        static void GroupChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"In group add new student");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("In group remove student");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("In group replace student");
                    break;
                case NotifyCollectionChangedAction.Move:
                    Console.WriteLine("In group student is move");
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Console.WriteLine("group reset");
                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            //LinkedList<string> list = new LinkedList<string>();
            //Brackets.Run();

            //Dictionary<int, string> users = new Dictionary<int, string>(){
            //    {100, "Bob" },
            //    {200, "Sam"}
            //};



            //Console.WriteLine(users[100]);

            //var userKeys = users.Keys;
            //foreach (var key in userKeys)
            //    Console.WriteLine(key);

            //var userValues = users.Values;

            //foreach (var item in users)
            //    Console.WriteLine($"{item.Key} -> {item.Value}");

            //Console.WriteLine("\n---------------\n");
            //foreach (var key in users.Keys)
            //    Console.WriteLine($"{key} -> {users[key]}");

            //var group = new ObservableCollection<string>(new string[] {"Bob", "Joe", "Tom"});

            //for(int i = 0; i < group.Count; i++)
            //    Console.WriteLine(group[i]);
            //Console.WriteLine("\n---------------\n");
            //foreach(var item in group)
            //    Console.WriteLine(item);
            //Console.WriteLine("\n---------------\n");

            var group = new ObservableCollection<Student>()
            {
                new Student("Bob"),
                new Student("Joe"),
                //new Student("Sam"),
                //new Student("Tom"),
                //new Student("Tim"),
            };

            group.CollectionChanged += GroupChanged;

            group.Add(new Student("Sam"));
            group.Add(new Student("Tom"));

            group[group.Count - 1] = new Student("Tim");

            group.RemoveAt(1);

            group.Clear();
        }
    }
}