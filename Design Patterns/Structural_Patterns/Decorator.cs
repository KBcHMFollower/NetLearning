using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Patterns
{
    // Компонент: Интерфейс напитка
    public interface IBeverage
    {
        string GetDescription();
        double GetCost();
    }

    // Конкретный компонент: Кофе
    public class Coffee : IBeverage
    {
        public string GetDescription()
        {
            return "Кофе";
        }

        public double GetCost()
        {
            return 2.0;
        }
    }

    // Декоратор: Базовый класс для декораторов
    public abstract class BeverageDecorator : IBeverage
    {
        protected IBeverage decoratedBeverage;

        public BeverageDecorator(IBeverage beverage)
        {
            decoratedBeverage = beverage;
        }

        public virtual string GetDescription()
        {
            return decoratedBeverage.GetDescription();
        }

        public virtual double GetCost()
        {
            return decoratedBeverage.GetCost();
        }
    }

    // Конкретный декоратор: Добавка к кофе - молоко
    public class MilkDecorator : BeverageDecorator
    {
        public MilkDecorator(IBeverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return $"{decoratedBeverage.GetDescription()}, Молоко";
        }

        public override double GetCost()
        {
            return decoratedBeverage.GetCost() + 0.5;
        }
    }

    // Конкретный декоратор: Добавка к кофе - сахар
    public class SugarDecorator : BeverageDecorator
    {
        public SugarDecorator(IBeverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return $"{decoratedBeverage.GetDescription()}, Сахар";
        }

        public override double GetCost()
        {
            return decoratedBeverage.GetCost() + 0.2;
        }
    }
}
