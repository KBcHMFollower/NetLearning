using Dependency_Injection;

var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<TimeService>();

//��������� ��������� ����� ���������� ������� ��� ������� �������
//������ ICounter �� RandomCounter, �������� RandomCounter � ����������� CounterService
//����� ���������� �������� ������ ������� RandomCounter � CounterService
//(������� ��������� ������ CounterMiddleware)
//�. �. � Middleware CounterMiddleware ����� ������� 2 ����������� ������� RandomCounter

builder.Services.AddTransient<ICounter, RandomCounter>();
builder.Services.AddTransient<CounterService>();

//��������� ���� ��������� ������� ��� ����� �������� �������.
//���������� �����������, ������ ������ � ��� ����� �������������� 1 ����������� ������
//RandomCounter, ������� ����� ��������������� ��� ������ ����������

//builder.Services.AddScoped<ICounter, RandomCounter>();
//builder.Services.AddScoped<CounterService>();

//��������� ���� ��������� ������� ��� ���� ����������� ��������.

//builder.Services.AddSingleton<ICounter, RandomCounter>();
//builder.Services.AddSingleton<CounterService>();

var app = builder.Build();

app.UseMiddleware<TimerMiddleware>();

app.UseMiddleware<CounterMiddleware>();


app.Run();



