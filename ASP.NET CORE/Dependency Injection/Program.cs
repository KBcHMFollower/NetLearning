using Dependency_Injection;

var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<TimeService>();

//Создается постоянно новые экземпляры объекта для КАЖДОГО запроса
//Замена ICounter на RandomCounter, передача RandomCounter в конструктор CounterService
//Также произойдет передача нового объекта RandomCounter в CounterService
//(Который находится внутри CounterMiddleware)
//Т. е. в Middleware CounterMiddleware будет создано 2 независимых объекта RandomCounter

builder.Services.AddTransient<ICounter, RandomCounter>();
builder.Services.AddTransient<CounterService>();

//Создается один экземпляр объекта для всего ТЕКУЩЕГО запроса.
//Аналогично предыдущему, только теперь у нас будет использоваться 1 независимый объект
//RandomCounter, который будет пересоздаваться при каждом обновлении

//builder.Services.AddScoped<ICounter, RandomCounter>();
//builder.Services.AddScoped<CounterService>();

//Создается один экземпляр объекта для ВСЕХ ПОСЛЕДУЮЩИХ запросов.

//builder.Services.AddSingleton<ICounter, RandomCounter>();
//builder.Services.AddSingleton<CounterService>();

var app = builder.Build();

app.UseMiddleware<TimerMiddleware>();

app.UseMiddleware<CounterMiddleware>();


app.Run();



