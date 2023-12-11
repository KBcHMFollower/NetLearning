using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Patterns
{
    // Абстрактный класс, представляющий базовый шаблон приготовления напитка
    public abstract class HotBeverageTemplate
    {
        // Шаблонный метод, определяющий структуру алгоритма приготовления напитка
        public void PrepareBeverage()
        {
            BoilWater();
            Brew();
            PourInCup();
            AddCondiments();
        }

        // Абстрактные методы, которые должны быть реализованы в подклассах
        protected abstract void Brew();
        protected abstract void AddCondiments();

        // Общие шаги, которые могут быть одинаковыми для всех подклассов
        private void BoilWater()
        {
            Console.WriteLine("Кипятим воду");
        }

        private void PourInCup()
        {
            Console.WriteLine("Наливаем напиток в чашку");
        }
    }

    // Конкретная реализация для приготовления кофе
    public class Coffee : HotBeverageTemplate
    {
        protected override void Brew()
        {
            Console.WriteLine("Процесс заваривания кофе");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Добавляем сахар и молоко");
        }
    }

    // Конкретная реализация для приготовления чая
    public class Tea : HotBeverageTemplate
    {
        protected override void Brew()
        {
            Console.WriteLine("Процесс заваривания чая");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Добавляем лимон");
        }
    }
}
