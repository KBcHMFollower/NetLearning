namespace Garbage_Collector
{
    class SmallObject
    {
        byte[] array = new byte[1024]; //1 Kb
        public SmallObject()
        {
            Console.WriteLine($"Конструктор SmallObject.");
        }
        ~SmallObject()
        {
            Console.WriteLine($"Деструктор SmallObject.");
        }
    }
    class BigObject
    {
        byte[] array = new byte[1024 * 50]; //50 Kb
    }
    internal class Program
    {
        static void CreateBigObjects()
        {
            Console.WriteLine("Начало работы CreateBigObjects.");
            BigObject[] objects = new BigObject[1024]; //51,200 Kb = 50 Mb
            for(int i = 0; i < objects.Length; i++)
            {
                objects[i] = new BigObject();
                Thread.Sleep(5); //5s
            }
            Console.Write($"Поколения BigObject: {GC.GetGeneration(objects)} | ");
            Console.WriteLine($"Размер кучи: {GC.GetTotalMemory(false) / 1024} Кбайт");
            Console.WriteLine("Конец работы CreateBigObjects.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Система поддерживает: {GC.MaxGeneration + 1} поколения.");
            Console.WriteLine(new string('-', 40));

            //Куча будет заполнятся объектами BigObject, поэтому размер кучи будет расти
            //Потоки работают асинхронно, при этом вызванный поток возможно будет работать после завершения
            //метода Main(), о чём будет свидетельствовать сообщение

            SmallObject @object = new SmallObject();
            new Thread(CreateBigObjects).Start();
            for(int i = 0; i < 30; ++i)
            {
                Console.Write($"Поколения SmallObject: {GC.GetGeneration(@object)} | ");
                Console.WriteLine($"Размер кучи: {GC.GetTotalMemory(false) / 1024} Кбайт");
                Thread.Sleep(100);
            }
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Поколения 1 проверилось: {GC.CollectionCount(0)} раз.");
            Console.WriteLine($"Поколения 2 проверилось: {GC.CollectionCount(1)} раз.");
            Console.WriteLine($"Поколения 3 проверилось: {GC.CollectionCount(2)} раз.");
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("Конец метода Main().");
        }
    }
}