using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Patterns
{
    // Memento: Снимок состояния заказа
    public class OrderMemento
    {
        public string OrderState { get; }

        public OrderMemento(string orderState)
        {
            OrderState = orderState;
        }
    }

    // Originator: Объект, состояние которого нужно сохранять
    public class Order
    {
        private string currentState;

        public Order(string initialState)
        {
            currentState = initialState;
        }

        public void AddProduct(string product)
        {
            currentState += $", {product}";
            Console.WriteLine($"Добавлен продукт: {product}");
        }

        public OrderMemento SaveState()
        {
            Console.WriteLine("Сохранение состояния заказа.");
            return new OrderMemento(currentState);
        }

        public void RestoreState(OrderMemento memento)
        {
            currentState = memento.OrderState;
            Console.WriteLine("Восстановление состояния заказа.");
        }

        public void PrintOrder()
        {
            Console.WriteLine($"Текущий заказ: {currentState}");
        }
    }

    // Caretaker: Объект, управляющий хранением снимков состояния
    public class OrderHistory
    {
        private List<OrderMemento> history = new List<OrderMemento>();

        public void AddMemento(OrderMemento memento)
        {
            history.Add(memento);
        }

        public OrderMemento GetMemento(int index)
        {
            return history[index];
        }
    }
}
