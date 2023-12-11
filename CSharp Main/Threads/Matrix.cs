using System.Security;

class Matrix
{
    // Объект блокировки для синхронизации доступа к ресурсам из разных потоков
    static readonly object locker = new();

    // Генератор случайных чисел для определения символов и других параметров
    Random rand;

    // Константы, определяющие размер окна консоли
    const int windowheight = 40, windowwidth = 60;

    // Свойство, представляющее номер столбца матрицы
    public int Column { get; private set; }

    // Конструктор класса Matrix, принимающий номер столбца
    public Matrix(int column)
    {
        Column = column;
        rand = new Random((int)DateTime.Now.Ticks);
    }

    // Метод для получения случайного символа
    private char GetRandomChar() => (char)(rand.Next(65, 90));

    // Метод для отображения матрицы
    public void Print()
    {
        int count;
        int length;

        // Бесконечный цикл для непрерывного отображения матрицы
        while (true)
        {
            // Генерация случайного количества символов в столбце
            count = (int)(rand.Next(3, 7));

            // Генерация случайной верхней позиции столбца
            int topPosition = (int)(rand.Next(0, windowheight / 2));

            length = 0;

            // Задержка для создания эффекта "медленного" падения символов
            Thread.Sleep(1000);

            // Цикл для отображения символов в столбце
            for (int i = topPosition; i < windowheight; ++i)
            {
                // Блокировка для синхронизации доступа к ресурсам из разных потоков
                lock (locker)
                {
                    Console.CursorTop = 0;
                    Console.ForegroundColor = ConsoleColor.Black;

                    // Очистка предыдущих символов в столбце
                    for (int j = 0; j < i; ++j)
                    {
                        Console.CursorLeft = Column;
                        Console.WriteLine(" ");
                    }

                    // Определение цвета символов в столбце
                    if (length < count) length++;
                    else if (length == count) count = 0;
                    if (windowheight - 1 - i < length) length--;

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.CursorTop = i - length + 1;

                    // Отображение случайных символов в столбце
                    for (int j = 0; j < length - 2; ++j)
                    {
                        Console.CursorLeft = Column;
                        Console.WriteLine(GetRandomChar());
                    }

                    if (length >= 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.CursorLeft = Column;
                        Console.WriteLine(GetRandomChar());
                    }

                    if (length >= 1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorLeft = Column;
                        Console.WriteLine(GetRandomChar());
                    }

                    // Задержка для создания эффекта "медленного" падения символов
                    Thread.Sleep(20);
                }
            }
        }
    }
}
