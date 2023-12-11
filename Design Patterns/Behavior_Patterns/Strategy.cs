using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Patterns
{
    class Car
    {
        IStrategy Engine { get; set; }
        protected string Mark { get; set; }
        protected string Model { get; set; }
        public Car(IStrategy engine)
        {
            this.Engine = engine;
        }
        public void Move()
        {
            Engine.Move();
        }
      
    }
    interface IStrategy
    {
        void Move();
    }
    class ElectricEngine : IStrategy
    {
        public void Move()
        {
            Console.WriteLine("Перемещается на электричестве.");
        }
    }
    class PetrolEngine : IStrategy
    {
        public void Move()
        {
            Console.WriteLine("Перемещается на бензине.");
        }
    }
}
