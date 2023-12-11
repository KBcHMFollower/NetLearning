using Behavior_Patterns;
#region Strategy

IStrategy engine = new ElectricEngine();
Car car = new(engine);
car.Move();
#endregion

#region Observer

RoomTemperature room = new RoomTemperature();

// Создаем несколько наблюдателей
TemperatureObserver observer1 = new TemperatureObserver("Наблюдатель 1");
TemperatureObserver observer2 = new TemperatureObserver("Наблюдатель 2");

// Подписываем наблюдателей на уведомления
room.AddObserver(observer1);
room.AddObserver(observer2);

// Имитация изменения температуры
room.Temperature = 25.5f;
#endregion

#region Command

Light light = new Light();
LightOnCommand lightOn = new LightOnCommand(light);
LightOffCommand lightOff = new LightOffCommand(light);
RemoteControl remote = new RemoteControl();
remote.SetCommand(lightOn);
remote.PressButton(); // Вывод: "Свет включен"
remote.SetCommand(lightOff);
remote.PressButton(); // Вывод: "Свет выключен"
#endregion

#region Template Method

// Приготовление кофе
Console.WriteLine("Приготовление кофе:");
HotBeverageTemplate coffee = new Coffee();
coffee.PrepareBeverage();

Console.WriteLine();

// Приготовление чая
Console.WriteLine("Приготовление чая:");
HotBeverageTemplate tea = new Tea();
tea.PrepareBeverage();
#endregion

#region Iterator

StringCollection stringCollection = new StringCollection();
stringCollection.AddItem("One");
stringCollection.AddItem("Two");
stringCollection.AddItem("Three");

// Использование итератора для перебора коллекции
foreach (string item in stringCollection)
{
    Console.WriteLine(item);
}
#endregion

#region State

TrafficLight trafficLight = new TrafficLight();

// Имитация работы светофора
trafficLight.PerformAction(); // Начальное состояние: Красный
trafficLight.ChangeState(new GreenState()); // Переключение в состояние: Зеленый
trafficLight.PerformAction(); // Зеленый

// Можно продолжить имитацию переключения состояний
#endregion

#region Chain of Responsibility

// Создаем обработчики
IRequestHandler creditRatingHandler = new CreditRatingHandler();
IRequestHandler employmentHandler = new EmploymentHandler();

// Устанавливаем цепочку обработчиков
creditRatingHandler.SetNextHandler(employmentHandler);

// Создаем заявку на кредит
LoanRequest loanRequest = new LoanRequest
{
    CreditRating = 680,
    YearsEmployed = 3
};

// Обработка заявки начинается с первого обработчика
creditRatingHandler.HandleRequest(loanRequest);
#endregion

#region Interpreter

// Предположим, у нас есть выражение a + (b - c), и контекст переменных
Dictionary<string, int> context = new Dictionary<string, int>
{
    { "a", 5 },
    { "b", 10 },
    { "c", 3 }
};

// Строим дерево разбора для выражения
IExpression expression = new AddExpression(
    new VariableExpression("a"),
    new SubtractExpression(
        new VariableExpression("b"),
        new VariableExpression("c")
    )
);

// Вычисляем результат выражения
int result = expression.Interpret(context);

Console.WriteLine($"Результат выражения: {result}");
#endregion

#region Mediator

// Создаем посредника
IChatMediator chatMediator = new ChatMediator();

// Создаем пользователей и регистрируем их в чате
User user1 = new User(chatMediator, "Пользователь 1");
User user2 = new User(chatMediator, "Пользователь 2");
User user3 = new User(chatMediator, "Пользователь 3");

chatMediator.AddUser(user1);
chatMediator.AddUser(user2);
chatMediator.AddUser(user3);

// Пользователи отправляют сообщения через посредника
user1.SendMessage("Привет, есть кто-то?");
user2.SendMessage("Да, я здесь!");
user3.SendMessage("Привет вам обоим!");
#endregion

#region Memento

// Создаем заказ и сохраняем его состояния
Order order = new Order("Заказ в обработке");
OrderHistory history = new OrderHistory();

history.AddMemento(order.SaveState());
order.PrintOrder();

order.AddProduct("Товар 1");
history.AddMemento(order.SaveState());
order.PrintOrder();

order.AddProduct("Товар 2");
order.PrintOrder();

// Отменяем последнее действие и восстанавливаем предыдущее состояние
Console.WriteLine("Отмена последнего действия:");
order.RestoreState(history.GetMemento(0));
order.PrintOrder();
#endregion

#region Visitor

List<Patient> patients = new List<Patient>
{
    new HighBloodPressurePatient("Иван"),
    new DiabetesPatient("Мария"),
    new DiabetesPatient("Петр")
};

Doctor doctor = new Doctor();

foreach (var patient in patients)
{
    patient.Accept(doctor);
}
#endregion
