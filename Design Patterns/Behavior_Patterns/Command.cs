using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Patterns
{
    // Интерфейс команды
    public interface ICommand
    {
        void Execute();
    }

    // Реализация конкретной команды - включение света
    public class LightOnCommand : ICommand
    {
        private Light light;
        public LightOnCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.TurnOn();
        }
    }

    // Реализация конкретной команды - выключение света
    public class LightOffCommand : ICommand
    {
        private Light light;

        public LightOffCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.TurnOff();
        }
    }

    // Класс, представляющий устройство - свет
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Свет включен");
        }
        public void TurnOff()
        {
            Console.WriteLine("Свет выключен");
        }
    }

    // Класс, представляющий удаленный контроллер
    public class RemoteControl
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void PressButton()
        {
            command.Execute();
        }
    }
}
