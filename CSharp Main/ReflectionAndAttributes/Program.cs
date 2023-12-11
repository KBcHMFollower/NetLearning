using System.Reflection;

namespace ReflectionAndAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект класса Photo с указанием имени файла, пути и срока действия
            Photo photo = new Photo("photo.png") { Path = @"C:\photo.png", LifeSpan = 40 };
            Console.WriteLine(new string('-', 40));

            // Проверяем, младше ли фото 20 лет с использованием функции ValidationPhoto
            bool isValidated = ValidationPhoto(photo);
            Console.WriteLine($"Младше ли фото чем 20 лет: {isValidated}");
            Console.WriteLine(new string('-', 40));

            // Получаем информацию о типе Photo
            Type type = typeof(Photo);
            Console.WriteLine($"Name: {type.Name}");
            Console.WriteLine($"FullName: {type.FullName}");
            Console.WriteLine($"Namespace: {type.Namespace}");
            Console.WriteLine($"Is struct: {type.IsValueType}");
            Console.WriteLine($"Is class: {type.IsClass}");
            Console.WriteLine(new string('-', 40));

            // Выводим реализованные интерфейсы
            Console.WriteLine("Реализованные интерфейсы:");
            foreach (Type i in type.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }
            Console.WriteLine(new string('-', 40));

            // Не будет выводиться информация о закрытых членах класса
            Console.WriteLine("Информация о членах класса: ");
            foreach (MemberInfo member in type.GetMembers())
            {
                Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
            }
            Console.WriteLine(new string('-', 40));

            // Выводим информацию о методе Print
            Console.WriteLine("Информация о методе Print: ");
            MemberInfo[] somefunc = type.GetMember("Print", BindingFlags.Instance | BindingFlags.Public);
            foreach (MemberInfo member in somefunc)
            {
                Console.WriteLine($"{member.MemberType} {member.Name}");
            }
            Console.WriteLine(new string('-', 40));

            // Выводим информацию о атрибутах класса
            Console.WriteLine("Информация о атрибутах класса: ");
            foreach (var item in type.GetCustomAttributes(false))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 40));

            // Выводим информацию о атрибутах свойств класса
            Console.WriteLine("Информация о атрибутах свойств класса: ");
            foreach (var item in type.GetProperties())
            {
                foreach (var prop in item.GetCustomAttributes(false))
                {
                    Console.WriteLine(prop.ToString());
                }
            }
        }

        // Функция для валидации фото по сроку жизни с использованием атрибутов
        public static bool ValidationPhoto(Photo photo)
        {
            Type type = typeof(Photo);
            var attributes = type.GetCustomAttributes(false);
            foreach (var attr in attributes)
            {
                if (attr is PhotoLifespanAttribute lifeSpanAttribute)
                    return photo.LifeSpan <= lifeSpanAttribute.LifeSpan;
            }
            return true;
        }
    }

}