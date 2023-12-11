using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Patterns
{
    public interface IRequestHandler
    {
        void SetNextHandler(IRequestHandler handler);
        void HandleRequest(LoanRequest request);
    }

    // Конкретный обработчик - проверка кредитного рейтинга
    public class CreditRatingHandler : IRequestHandler
    {
        private IRequestHandler nextHandler;

        public void SetNextHandler(IRequestHandler handler)
        {
            nextHandler = handler;
        }

        public void HandleRequest(LoanRequest request)
        {
            if (request.CreditRating >= 700)
            {
                Console.WriteLine("Кредитный рейтинг высокий. Заявка принята.");
            }
            else if (nextHandler != null)
            {
                Console.WriteLine("Кредитный рейтинг низкий. Передаем запрос следующему обработчику.");
                nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("Кредитный рейтинг низкий, но нет следующего обработчика. Заявка отклонена.");
            }
        }
    }

    // Конкретный обработчик - проверка стажа работы
    public class EmploymentHandler : IRequestHandler
    {
        private IRequestHandler nextHandler;

        public void SetNextHandler(IRequestHandler handler)
        {
            nextHandler = handler;
        }

        public void HandleRequest(LoanRequest request)
        {
            if (request.YearsEmployed >= 2)
            {
                Console.WriteLine("Стаж работы достаточный. Заявка принята.");
            }
            else if (nextHandler != null)
            {
                Console.WriteLine("Стаж работы недостаточный. Передаем запрос следующему обработчику.");
                nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("Стаж работы недостаточный, но нет следующего обработчика. Заявка отклонена.");
            }
        }
    }

    // Класс, представляющий заявку на кредит
    public class LoanRequest
    {
        public int CreditRating { get; set; }
        public int YearsEmployed { get; set; }
    }
}
