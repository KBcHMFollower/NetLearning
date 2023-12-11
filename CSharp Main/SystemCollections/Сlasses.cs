
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net.Http.Headers;

namespace SystemCollections
{
    public static class MainClass
    {
        public static void List()
        {
            //SortedList<T> - Устаревший
            //Основной динамический массив. Это замена устаревшего ArrayList.
            //Позволяет хранить элементы одного типа и автоматически изменять размер массива.
            Console.WriteLine("List\n");
            List<string> list = new List<string>();

            list.Add("Test1");
            list.Add("Test2");
            list.Add("123Test");
            list.Add("Test3");
            list.Add("Test4");

            list.Capacity = 10;
            bool contains = list.Contains("Test1");
            list.RemoveAll(s => s.StartsWith("123Test"));
            int index = list.IndexOf("Test2");
            var templist = list.GetRange(1, 2);
            List<string> filteredList = list.Where(s => s.EndsWith('4')).ToList();

            foreach (var item in templist)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(index);
            Console.WriteLine(contains);
            Console.WriteLine(new string('-', 20));
            var listOfPeople = new List<Person>()
            {
                new Person ("Alice", 30),
                new Person ("Bob", 25),
                new Person ("Charlie", 35)
            };
            listOfPeople.Sort(new Comparer());
            foreach (var item in listOfPeople) { Console.WriteLine(item.Name); }
            Console.WriteLine(new string('=', 20));
        }
        public static void LinkedList()
        {
            Console.WriteLine("LinkedList\n");
            //Позволяет быстрые вставки и удаления в середине коллекции, 
            //но менее эффективен при доступе к элементам по индексу.
            var employees = new List<string> { "Tom", "Sam", "Bob" };
            var people = new LinkedList<string>(employees);
            //AddBefore, AddFirst, AddLast, RemoveFirst, RemoveLast
            people.AddAfter(people.First.Next, "John");
            var currentNode = people.First;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
            Console.WriteLine(new string('=', 20));
        }
        public static void MyArray()
        {
            Console.WriteLine("Array\n");
            Array myArr = Array.CreateInstance(typeof(string), /* Длина */ 5);
            myArr.SetValue("Name", 0);
            myArr.SetValue("Age", 1);
            myArr.SetValue("Gender", 2);
            string teststring = (string)myArr.GetValue(1); //Unboxing: object? -> string
            {
                //ICloneable - Clone создает новый массив
                string[] arr1 = (string[])myArr.Clone(); //Unboxing: object? -> string[]
                string[] arr2 = new string[5];
                //Copy - для существующего уже массива
                Array.Copy(/* Откуда */ myArr, /* Куда */ arr2, myArr.Length);
                Array.Sort(arr1);
                Array.BinarySearch(arr1, "Name"); //Эффективный поиск
                string resultstr = Array.Find(arr1, str => str == "Name");
            }
            //Min() Max()
            int[] numbers = { 5, 4, 1, 3, 5, 6, 4 };
            Console.WriteLine(numbers.Where(i => i % 2 == 0).Sum()); //Сумма четных элементов
            int[] result = numbers.Distinct().ToArray(); //Уникальные элементы
            numbers = numbers.OrderByDescending(i => i).ToArray(); //Сортировка без Array  
            int number = numbers.Where(i => i < 5).FirstOrDefault(); //Поиск первого элемента (без вызова исключения)
            Console.WriteLine(new string('=', 20));
        }
        public static void Dictionray()
        {
            //SortedDictionary<TKey, TValue> - Предоставляет пары "ключ-значение" в упорядоченной последовательности по ключу.
            //Предоставляет коллекцию пар "ключ-значение".
            //Позволяет быстро получать значение по ключу.
            Console.WriteLine("Dictionray\n");
            var people = new Dictionary<int, string>()
            {
                {1, "Tom" },
                {2, "Bob" },
                {3, "John" },
                {4, "Zelda" },
                {5, "Crosy" },
            };
            var mike = new KeyValuePair<int, string>(60, "Mike");
            people.Append(mike);
            Console.WriteLine(people[4]);
            bool containslist = people.ContainsValue("Crosy");
            Console.WriteLine(containslist);
        }
        public static void Queue()
        {
            var employees = new List<string> { "Tom", "Sam", "Bob" };
            Queue<string> people = new Queue<string>(employees);
            people.Enqueue("Tomas");
            var firstPerson = people.Peek();
            people.Dequeue();
            foreach (var person in people) { Console.WriteLine(person); }
        }
        public static void Stack()
        {
            Stack<string> people = new Stack<string>(16);
            people.Push("Tom");
            people.Push("Bob");
            people.Push("Tomas");
            var deletedPerson = people.Pop();
            var person = people.Peek();
            foreach (var item in people)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(person);
            Console.WriteLine(deletedPerson);
        }
        public static void HashSet()
        {
            //Хранит уникальные элементы в неупорядоченной форме
            //Выполняется за O(1) т. к. хранит кэши
            var numbers = new HashSet<int>();
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            bool contains30 = numbers.Contains(30);
            numbers.Remove(20);
            HashSet<int> otherNumbers = new HashSet<int> { 30, 40, 50 };
            numbers.UnionWith(otherNumbers);   // Объединение numbers и otherNumbers
            //IsSubsetOf, IntersectWith, ExceptWith, SymmetricExceptWith
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
        public static void ObservableCollection()
        {
            var people = new ObservableCollection<Person>(new Person[] { new Person("Mike", 22), new Person("Sam", 18) })
            {
                new Person("Anya", 13),
                new Person("Kolya", 19),
                new Person("Vasya", 40),
            };
            people.CollectionChanged += PeopleCollectinoChange;
            people.RemoveAt(1);
            people.Add(new Person("Tomas", 17));
            people[0] = new Person("John", 50);
            foreach (var item in people) Console.WriteLine(item.Name);
            void PeopleCollectinoChange(object? sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        if (e.NewItems?[0] is Person newPerson)
                        {
                            Console.WriteLine($"Добавлен новый объект: {newPerson.Name}");
                        }
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        if (e.OldItems?[0] is Person oldPerson)
                        {
                            Console.WriteLine($"Удален объект: {oldPerson.Name}");
                        }
                        break;
                    case NotifyCollectionChangedAction.Replace: 
                        if ((e.NewItems?[0] is Person replacingPerson) &&
                            (e.OldItems?[0] is Person replacedPerson))
                            Console.WriteLine($"Объект {replacedPerson.Name} заменен объектом {replacingPerson.Name}");
                        break;
                }
            }

        }

    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    public class Comparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            return p1.Age.CompareTo(p2.Age);
        }
    }
}
