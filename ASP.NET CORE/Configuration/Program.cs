using Configuration;
using Microsoft.Extensions.Options;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
//{
//    {"name", "Tom"},
//    {"age", "37"}
//});


builder.Configuration.AddJsonFile("config.json")
                     .AddJsonFile("person.json")
                     .AddXmlFile("config.xml")
                     .AddIniFile("config.ini")
                     .AddTextFile("config.txt");

builder.Services.Configure<Person>(builder.Configuration);

var app = builder.Build();

//Person? Elie = app.Configuration.Get<Person>();

//var tom = new Person();
//app.Configuration.Bind(tom);


// Определение конечных точек для различных запросов
app.Map("/", (IConfiguration appConfig) =>
{
    // Получение и возврат значения из секции ConnectionStrings
    IConfigurationSection connStrings = appConfig.GetSection("ConnectionStrings");
    string defaultConnection = connStrings.GetSection("DefaultConnection").Value;

    return defaultConnection;
});
app.Map("/json", (IConfiguration appConfig) => $"{appConfig["person:profile:name"]} - {appConfig["company:name"]}");
app.Map("/xml", (IConfiguration appConfig) => $"{appConfig["Name"]} - {appConfig["Company"]}");
app.Map("/ini", (IConfiguration appConfig) => $"{appConfig["User"]} - {appConfig["CompanyName"]}");
app.Map("/txt", (IConfiguration appConfig) => $"{appConfig["FirstName"]} - {appConfig["LastName"]}");
app.Map("/class", (IOptions<Person> options) =>
{
    // Получение и возврат объекта Person из конфигурации
    Person person = options.Value;
    return person;
});
app.Run();

//app.Map("/class", async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    string name = $"<p>Name: {tom.Name}</p>";
//    string age = $"<p>Age: {tom.Age}</p>";
//    string company = $"<p>Company: {tom.Company?.Title}</p>";
//    string langs = "<p>Languages:</p><ul>";
//    foreach (var lang in tom.Languages)
//    {
//        langs += $"<li><p>{lang}</p></li>";
//    }
//    langs += "</ul>";

//    await context.Response.WriteAsync($"{name}{age}{company}{langs}");
//});

// Определение класса Person и класса Company для десериализации конфигураций
public class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public List<string> Languages { get; set; } = new();
    public Company? Company { get; set; }
}
public class Company
{
    public string Title { get; set; } = "";
    public string Country { get; set; } = "";
}