using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Patterns
{
    // Интерфейс для реализации (способ доставки сообщения)
    public interface IMessageSender
    {
        void SendMessage(string message);
    }

    // Конкретная реализация: Отправка сообщения по электронной почте
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Отправка сообщения по электронной почте: {message}");
        }
    }

    // Конкретная реализация: Отправка сообщения по SMS
    public class SmsSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Отправка SMS: {message}");
        }
    }

    // Абстракция: Абстрактный класс для сообщения
    public abstract class Message
    {
        protected IMessageSender messageSender;

        public Message(IMessageSender sender)
        {
            messageSender = sender;
        }

        public abstract void Send();
    }

    // Расширенная абстракция: Конкретный тип сообщения
    public class TextMessage : Message
    {
        public TextMessage(IMessageSender sender) : base(sender) { }

        public override void Send()
        {
            Console.WriteLine("Отправка текстового сообщения:");
            messageSender.SendMessage("Привет, как дела?");
        }
    }
}
