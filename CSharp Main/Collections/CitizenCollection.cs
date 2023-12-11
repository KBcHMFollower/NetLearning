using System.Collections;

namespace Collections
{
    // Класс CitizenCollection реализует коллекцию граждан и предоставляет основные операции с ней.
    class CitizenCollection : IEnumerable
    {
        // Массив граждан.
        Citizen[] citizens;

        // Свойство для получения общей вместимости коллекции.
        public int Capacity { get { return citizens.Length; } }

        // Длина (количество элементов) текущей коллекции.
        public int Length { get; private set; } = 0;

        // Индексатор для доступа к гражданину по индексу.
        public Citizen this[int index]
        {
            get
            {
                if (index >= 0 && index < citizens.Length) return citizens[index];
                else return null;
            }
        }

        // Реализация интерфейса IEnumerable для поддержки итерации по коллекции.
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return citizens[i];
            }
        }

        // Конструктор класса CitizenCollection, принимающий начальную вместимость коллекции.
        public CitizenCollection(int capacity = 1)
        {
            citizens = new Citizen[capacity];
        }

        // Метод для добавления гражданина в коллекцию.
        public int Add(Citizen citizen)
        {
            int index;

            // Если гражданин уже присутствует в коллекции, возвращаем его индекс.
            if (Contains(citizen, out index))
            {
                Console.WriteLine("Такой человек уже есть. ");
                return index;
            }

            Citizen[] temp;

            // Если гражданин - пенсионер, осуществляем добавление на определенную позицию.
            if (citizen is Pensioner)
            {
                index = IndexOfPensioner(citizen);
                ++Length;

                // Если длина меньше вместимости, то копируем элементы перед и после добавленного.
                if (Length < Capacity)
                {
                    temp = new Citizen[Capacity];
                    Array.ConstrainedCopy(citizens, 0, temp, 0, index);
                    temp[index] = citizen;
                    Array.ConstrainedCopy(citizens, index, temp, index + 1, Length - index);
                    citizens = temp;
                }
                // Если длина стала равна вместимости, увеличиваем вместимость вдвое.
                else if (Length >= Capacity)
                {
                    temp = new Citizen[Capacity * 2];
                    Array.ConstrainedCopy(citizens, 0, temp, 1, Length);
                    temp[index] = citizen;
                    citizens = temp;
                }

                return index;
            }

            // Если гражданин не пенсионер, просто добавляем его в конец коллекции.
            ++Length;

            // Если длина меньше вместимости, просто добавляем в конец.
            if (Length < Capacity)
            {
                citizens[Length - 1] = citizen;
            }
            // Если длина стала равна вместимости, увеличиваем вместимость вдвое.
            if (Length >= Capacity)
            {
                temp = new Citizen[Capacity * 2];
                Array.Copy(citizens, temp, Length);
                temp[Length - 1] = citizen;
                citizens = temp;
            }

            return index;
        }

        // Метод для проверки, содержится ли гражданин в коллекции.
        public bool Contains(Citizen citizen, out int index)
        {
            for (int i = 0; i < Length; ++i)
            {
                if (citizen == citizens[i])
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        // Метод для удаления первого гражданина из коллекции.
        public void Remove()
        {
            Citizen[] temp = new Citizen[Capacity - 1];
            Array.ConstrainedCopy(citizens, 1, temp, 0, Length - 1);
            citizens = temp;
            --Length;
        }

        // Метод для удаления конкретного гражданина из коллекции.
        public void Remove(Citizen citizen)
        {
            for (int i = 0; i < Length; ++i)
            {
                if (citizens[i] == citizen)
                {
                    Citizen[] temp = new Citizen[Capacity];
                    Array.ConstrainedCopy(citizens, 0, temp, 0, i);
                    Array.ConstrainedCopy(citizens, i + 1, temp, i, Length - i);
                    citizens = temp;
                    --Length;
                }
            }
        }

        // Приватный метод для поиска индекса пенсионера в коллекции.
        private int IndexOfPensioner(Citizen citizen)
        {
            for (int i = 0; i < Length; ++i)
            {
                if (citizens[i] == citizen) return i;
            }
            return 0;
        }

        // Метод для очистки коллекции.
        public void Clear() => citizens = new Citizen[0];

        // Метод для получения последнего гражданина в коллекции.
        public Citizen ReturnLast(out int index)
        {
            index = Length - 1;
            return citizens[index];
        }
    }

}
