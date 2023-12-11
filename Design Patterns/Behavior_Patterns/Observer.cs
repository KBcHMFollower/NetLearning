using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Patterns
{
    interface IObserver
    {
        void Update(float temperature);
    }
    interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    // Реализация наблюдаемого объекта
    class RoomTemperature : IObservable
    {
        List<IObserver> observers;
        float temperature;
        public float Temperature
        {
            get { return temperature; }
            set
            {
                if (temperature != value)
                {
                    temperature = value;
                    NotifyObservers();
                }
            }
        }
        public RoomTemperature()
        {
            observers = new List<IObserver>();
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(temperature);
            }
        }  
    }

    public class TemperatureObserver : IObserver
    {
        private string name;

        public TemperatureObserver(string name)
        {
            this.name = name;
        }

        public void Update(float temperature)
        {
            Console.WriteLine($"{name} получил уведомление: Текущая температура в комнате - {temperature} градусов.");
        }
    }
}
