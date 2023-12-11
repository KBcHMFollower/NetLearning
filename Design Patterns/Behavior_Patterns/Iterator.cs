using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Patterns
{
    public class StringCollection : IEnumerable<string>
    {
        private List<string> collection = new List<string>();

        public void AddItem(string item)
        {
            collection.Add(item);
        }

        // Реализация интерфейса IEnumerable
        public IEnumerator<string> GetEnumerator()
        {
            return new StringIterator(collection);
        }

        // Реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // Итератор для коллекции строк
    public class StringIterator : IEnumerator<string>
    {
        private List<string> collection;
        private int currentIndex = -1;

        public StringIterator(List<string> collection)
        {
            this.collection = collection;
        }

        // Реализация интерфейса IEnumerator
        public string Current
        {
            get { return collection[currentIndex]; }
        }

        // Реализация интерфейса IEnumerator
        object IEnumerator.Current
        {
            get { return Current; }
        }

        // Реализация интерфейса IEnumerator
        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < collection.Count;
        }

        // Реализация интерфейса IEnumerator
        public void Reset()
        {
            currentIndex = -1;
        }

        // Реализация интерфейса IEnumerator
        public void Dispose()
        {
            // Ничего не делаем
        }
    }
}
