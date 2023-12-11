using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Patterns
{
    public interface ITrafficLightState
    {
        void Handle(TrafficLight context);
    }

    // Состояние "Красный"
    public class RedState : ITrafficLightState
    {
        public void Handle(TrafficLight context)
        {
            Console.WriteLine("Светофор переключен в режим: Красный");
            // Логика для красного света
        }
    }

    // Состояние "Желтый"
    public class YellowState : ITrafficLightState
    {
        public void Handle(TrafficLight context)
        {
            Console.WriteLine("Светофор переключен в режим: Желтый");
            // Логика для желтого света
        }
    }

    // Состояние "Зеленый"
    public class GreenState : ITrafficLightState
    {
        public void Handle(TrafficLight context)
        {
            Console.WriteLine("Светофор переключен в режим: Зеленый");
            // Логика для зеленого света
        }
    }

    // Класс светофора
    public class TrafficLight
    {
        private ITrafficLightState currentState;

        public TrafficLight()
        {
            // По умолчанию устанавливаем начальное состояние - "Красный"
            currentState = new RedState();
        }

        // Метод для переключения состояний
        public void ChangeState(ITrafficLightState newState)
        {
            currentState = newState;
            currentState.Handle(this);
        }

        // Метод для выполнения действия светофора
        public void PerformAction()
        {
            currentState.Handle(this);
        }
    }
}
