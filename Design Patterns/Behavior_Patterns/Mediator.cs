using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Patterns
{
    // Интерфейс посредника
    public interface IChatMediator
    {
        public void AddUser(User user);
        void SendMessage(User sender, string message);
    }

    // Конкретный класс посредника
    public class ChatMediator : IChatMediator
    {
        private List<User> users = new List<User>();

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void SendMessage(User sender, string message)
        {
            foreach (var user in users)
            {
                // Игнорируем отправителя сообщения
                if (user != sender)
                {
                    user.ReceiveMessage(message);
                }
            }
        }
    }

    // Класс участника, который отправляет и получает сообщения через посредника
    public class User
    {
        private IChatMediator mediator;
        public string Name { get; }

        public User(IChatMediator mediator, string name)
        {
            this.mediator = mediator;
            this.Name = name;
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"{Name} отправляет сообщение: {message}");
            mediator.SendMessage(this, message);
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"{Name} получает сообщение: {message}");
        }
    }
}
