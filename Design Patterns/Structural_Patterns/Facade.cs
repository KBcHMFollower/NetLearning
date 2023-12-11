using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Patterns
{
    // Система доставки
    public class DeliveryService
    {
        public void DeliverProduct(string product, string address)
        {
            Console.WriteLine($"Доставка продукта '{product}' по адресу: {address}");
        }
    }

    // Система оплаты
    public class PaymentService
    {
        public void ProcessPayment(string product, double amount)
        {
            Console.WriteLine($"Оплата продукта '{product}' на сумму {amount}");
        }
    }

    // Система управления складом
    public class WarehouseService
    {
        public bool CheckStockAvailability(string product, int quantity)
        {
            Console.WriteLine($"Проверка наличия товара '{product}' в количестве {quantity}");
            // Логика проверки наличия товара на складе
            return true;
        }
    }

    // Фасад для клиента (покупателя)
    public class ShopFacade
    {
        private DeliveryService deliveryService;
        private PaymentService paymentService;
        private WarehouseService warehouseService;

        public ShopFacade()
        {
            deliveryService = new DeliveryService();
            paymentService = new PaymentService();
            warehouseService = new WarehouseService();
        }

        public void BuyProduct(string product, int quantity, double price, string address)
        {
            // Проверка наличия товара на складе
            bool isAvailable = warehouseService.CheckStockAvailability(product, quantity);

            if (isAvailable)
            {
                // Оплата товара
                paymentService.ProcessPayment(product, quantity * price);

                // Доставка товара
                deliveryService.DeliverProduct(product, address);

                Console.WriteLine($"Покупка товара '{product}' завершена успешно!");
            }
            else
            {
                Console.WriteLine($"Товар '{product}' недоступен на складе.");
            }
        }
    }

}
