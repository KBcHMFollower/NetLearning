using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Patterns
{
    // Общий интерфейс для системы управления финансами
    public interface IFinanceSystem
    {
        void AccessFinancialData();
    }

    // Реальный сервис: Система управления финансами
    public class RealFinanceSystem : IFinanceSystem
    {
        public void AccessFinancialData()
        {
            Console.WriteLine("Доступ к финансовым данным предоставлен.");
            // Логика доступа к финансовым данным
        }
    }

    // Прокси: Заместитель для контроля доступа
    public class FinanceSystemProxy : IFinanceSystem
    {
        private RealFinanceSystem realFinanceSystem;
        private string userRole;

        public FinanceSystemProxy(string userRole)
        {
            this.userRole = userRole;
            realFinanceSystem = new RealFinanceSystem();
        }

        public void AccessFinancialData()
        {
            if (userRole == "admin")
            {
                realFinanceSystem.AccessFinancialData();
            }
            else
            {
                Console.WriteLine("Доступ к финансовым данным запрещен для данной роли.");
            }
        }
    }
}
