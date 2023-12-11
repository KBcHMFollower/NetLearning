namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем список автомобилей
            var autos = new List<Auto>
    {
        new Auto
        {
            Mark = "Toyta",
            color = Color.Red,
            Year = 2011,
        },
        new Auto
        {
            Mark = "Lada",
            color = Color.Black,
            Year = 2007,
        },
        new Auto
        {
            Mark = "BMW",
            color = Color.White,
            Year = 2010,
        }
    };

            // Создаем список владельцев автомобилей
            var owners = new List<CarOwner>
    {
        new CarOwner
        {
            Id = 1,
            Name = "Tolik",
            auto = new Auto[]{ autos[0] },
            PhoneNumber = "+79159219512",
            Gender = 'M'
        },
        new CarOwner
        {
            Id = 2,
            Name = "Natalya",
            auto = new Auto[]{ autos[0], autos[1] },
            PhoneNumber = "+79112412312",
            Gender = 'W'
        },
        new CarOwner
        {
            Id = 3,
            Name = "Vitalik",
            auto = new Auto[]{ autos[2], autos[1] },
            PhoneNumber = "+79123412312",
            Gender = 'M'
        }
    };

            // Создаем список национальностей
            var nationality = new List<Nationality>
    {
        new Nationality
        {
            Id = 2,
            Contry = "Russia"
        },
        new Nationality
        {
            Id = 3,
            Contry = "Japan"
        },
        new Nationality
        {
            Id = 1,
            Contry = "USA"
        }
    };

            // LINQ-запрос для выборки владельцев автомобилей, у которых есть автомобиль с индексом 1 (Lada)
            var query = from x in owners
                        from y in x.auto
                        where autos[1] == y
                        orderby x.PhoneNumber
                        select new
                        {
                            Name = x.Name,
                            PhoneNumber = x.PhoneNumber,
                            Gender = x.Gender
                        };

            // LINQ-запрос для группировки владельцев по полу
            var query2 = from x in query
                         group x by x.Gender;

            // LINQ-запрос для объединения владельцев с их национальностью
            var query3 = from x in owners
                         join y in nationality
                         on x.Id equals y.Id
                         orderby x.Id
                         select new
                         {
                             Id = x.Id,
                             Name = x.Name,
                             Country = y.Contry
                         };

            // Вывод результатов первого запроса
            foreach (var item in query)
            {
                Console.WriteLine($"Name: {item.Name}, PhoneNumber: {item.PhoneNumber}");
            }
            Console.WriteLine(new string('-', 20));

            // Вывод результатов второго запроса
            foreach (var group in query2)
            {
                Console.WriteLine($"Gender: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"Name: {item.Name}, PhoneNumber: {item.PhoneNumber}");
                }
            }
            Console.WriteLine(new string('-', 20));

            // Вывод результатов третьего запроса
            foreach (var item in query3)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Country: {item.Country}");
            }
        }

    }
}