using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Patterns
{
    // Интерфейс для абстрактного выражения
    public interface IExpression
    {
        int Interpret(Dictionary<string, int> context);
    }

    // Конкретное выражение - терминальное (переменная)
    public class VariableExpression : IExpression
    {
        private string variableName;

        public VariableExpression(string variableName)
        {
            this.variableName = variableName;
        }

        public int Interpret(Dictionary<string, int> context)
        {
            if (context.ContainsKey(variableName))
            {
                return context[variableName];
            }
            else
            {
                throw new InvalidOperationException($"Переменная {variableName} не определена");
            }
        }
    }

    // Конкретное выражение - нетерминальное (сложение)
    public class AddExpression : IExpression
    {
        private IExpression leftExpression;
        private IExpression rightExpression;

        public AddExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public int Interpret(Dictionary<string, int> context)
        {
            return leftExpression.Interpret(context) + rightExpression.Interpret(context);
        }
    }

    // Конкретное выражение - нетерминальное (вычитание)
    public class SubtractExpression : IExpression
    {
        private IExpression leftExpression;
        private IExpression rightExpression;

        public SubtractExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public int Interpret(Dictionary<string, int> context)
        {
            return leftExpression.Interpret(context) - rightExpression.Interpret(context);
        }
    }

}
