using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Collections
{
    
    class UserCollection : IEnumerable, IEnumerator
    {
        readonly Element[] elements = new Element[5];
        public Element this[int index]
        {
            get
            {
                if (index >= 0 && index < elements.Length) return elements[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < elements.Length) elements[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }

        int position = -1;
        object IEnumerator.Current {
            get
            {
                if (position == -1 || position >= elements.Length)
                    throw new ArgumentException();
                else return elements[position];
            }
        }
        bool IEnumerator.MoveNext()
        {
            if (position < elements.Length - 1)
            {
                ++position;
                return true;
            }
            ((IEnumerator)this).Reset();
            return false;
        }
        void IEnumerator.Reset() => position = -1;
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
    class Element
    {
        public DateOnly Date { get; set; }
        public string Name { get; set; }

        public Element()
        {
            Date = DateOnly.MinValue;
            Name = "Undefined";
        }

    }
}
