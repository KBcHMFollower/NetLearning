using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generating_Patterns
{
    interface IShape
    {
        IShape Duplicate();
        void Display();
    }

    class Square : IShape
    {
        int sideA;
        int sideB;
        public Square(int a, int b)
        {
            sideA = a;
            sideB = b;
        }

        public IShape Duplicate()
        {
            return new Square(this.sideA, this.sideB);
        }
        public void Display()
        {
            Console.WriteLine("Square with side A {0} and side B {1}", sideA, sideB);
        }
    }

    class Oval : IShape
    {
        int radius;
        public Oval(int r)
        {
            radius = r;
        }

        public IShape Duplicate()
        {
            return new Oval(this.radius);
        }
        public void Display()
        {
            Console.WriteLine("Oval with radius {0}", radius);
        }
    }
}
