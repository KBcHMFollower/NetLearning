#region Decorator
// Заказ кофе без добавок
using Structural_Patterns;

IBeverage coffee = new Coffee();
Console.WriteLine($"Заказ: {coffee.GetDescription()}, Стоимость: {coffee.GetCost()}");

// Заказ кофе с молоком
IBeverage coffeeWithMilk = new MilkDecorator(new Coffee());
Console.WriteLine($"Заказ: {coffeeWithMilk.GetDescription()}, Стоимость: {coffeeWithMilk.GetCost()}");

// Заказ кофе с молоком и сахаром
IBeverage coffeeWithMilkAndSugar = new SugarDecorator(new MilkDecorator(new Coffee()));
Console.WriteLine($"Заказ: {coffeeWithMilkAndSugar.GetDescription()}, Стоимость: {coffeeWithMilkAndSugar.GetCost()}");
#endregion

#region Adapter
// Используем старую систему в адаптере
LegacyFileReader legacyFileReader = new LegacyFileReader();
LegacyFileReaderAdapter adapter = new LegacyFileReaderAdapter(legacyFileReader);

// Используем новую систему с адаптером
NewSystemClient newSystemClient = new NewSystemClient(adapter);

// Выполняем операцию чтения файла через новую систему
newSystemClient.PerformReadOperation("example.txt");
#endregion

#region Facade
// Используем фасад для упрощенного взаимодействия с магазином
ShopFacade shopFacade = new ShopFacade();

// Покупка товара с использованием фасада
shopFacade.BuyProduct("Ноутбук", 1, 1200.0, "Улица Пушкина, 10");
#endregion

#region Composite
// Создаем файлы
Structural_Patterns.File file1 = new Structural_Patterns.File("file1.txt");
Structural_Patterns.File file2 = new Structural_Patterns.File("file2.txt");

// Создаем директории
Structural_Patterns.Directory dir1 = new Structural_Patterns.Directory("Folder 1");
Structural_Patterns.Directory dir2 = new Structural_Patterns.Directory("Folder 2");

// Добавляем файлы в директории
dir1.Add(file1);
dir2.Add(file2);

// Создаем композитную структуру
Structural_Patterns.Directory rootDir = new Structural_Patterns.Directory("Root");
rootDir.Add(dir1);
rootDir.Add(dir2);

// Отображаем структуру файловой системы
rootDir.Display();
#endregion

#region Proxy
// Используем реальную систему управления финансами
IFinanceSystem realFinanceSystem = new RealFinanceSystem();
realFinanceSystem.AccessFinancialData();

Console.WriteLine();

// Используем Прокси для ограничения доступа
IFinanceSystem financeSystemProxy = new FinanceSystemProxy("user");
financeSystemProxy.AccessFinancialData();

Console.WriteLine();

// Используем Прокси для предоставления доступа
IFinanceSystem financeSystemProxyAdmin = new FinanceSystemProxy("admin");
financeSystemProxyAdmin.AccessFinancialData();
#endregion

#region Bridge
// Используем EmailSender для отправки текстового сообщения
Message textMessageWithEmail = new TextMessage(new EmailSender());
textMessageWithEmail.Send();

Console.WriteLine();

// Используем SmsSender для отправки текстового сообщения
Message textMessageWithSms = new TextMessage(new SmsSender());
textMessageWithSms.Send();
#endregion

#region Flyweight
ImageFactory imageFactory = new ImageFactory();

// Используем легковесные объекты (изображения)
IImage image1 = imageFactory.GetImage("cat.jpg");
image1.Display(10, 20);

IImage image2 = imageFactory.GetImage("dog.jpg");
image2.Display(30, 40);

IImage image3 = imageFactory.GetImage("cat.jpg");
image3.Display(50, 60);

// Обратите внимание, что для изображения "cat.jpg" не происходит повторная загрузка, так как оно уже было создано ранее
#endregion