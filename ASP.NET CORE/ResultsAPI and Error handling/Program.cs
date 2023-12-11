var builder = WebApplication.CreateBuilder();
var app = builder.Build();

#region Обработка ошибок
//app.Environment.EnvironmentName = "Production";
//// Обработка ошибок HTTP
////app.UseStatusCodePages("text/plain", "Error: Resource Not Found. Status code: {0}");
//app.UseStatusCodePages(async statusCodeContext =>
//{
//    var response = statusCodeContext.HttpContext.Response;
//    var path = statusCodeContext.HttpContext.Request.Path;

//    response.ContentType = "text/plain; charset=UTF-8";
//    if (response.StatusCode == 403)
//    {
//        await response.WriteAsync($"Path: {path}. Access Denied ");
//    }
//    else if (response.StatusCode == 404)
//    {
//        await response.WriteAsync($"Resource {path} Not Found");
//    }
//});

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler(app => app.Run(async context =>
//    {
//        context.Response.StatusCode = 500;
//        await context.Response.WriteAsync("Error 500. DivideByZeroException occurred!");
//    }));
//}
//app.Run(async (context) =>
//{
//    int a = 5;
//    int b = 0;
//    int c = a / b;
//    await context.Response.WriteAsync($"c = {c}");
//});
#endregion

app.Map("/hello", () => Results.Text("Hello ASP.NET Core"));
app.Map("/chinese", () => Results.Content("你好", "text/plain", System.Text.Encoding.Unicode));
app.Map("/sam", () => Results.Json(new Person("Sam", 25),
        new()
        {
            PropertyNameCaseInsensitive = false,
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.WriteAsString
        }));

app.Map("/bob", () => Results.Json(new Person("Bob", 41),
        new(System.Text.Json.JsonSerializerDefaults.Web)));

app.Map("/tom", () => Results.Json(new Person("Tom", 37),
         new(System.Text.Json.JsonSerializerDefaults.General)));
app.Map("/error", () => Results.Json(new { message = "Unexpected error" }, statusCode: 500));
//Переадресация
app.Map("/old", () => Results.Redirect("/new"));
app.Map("/new", () => "Hello World");
app.Map("/about", () => Results.StatusCode(401));
app.Map("/contacts", () => Results.NotFound(new { message = "Resource Not Found" }));
app.Map("/panel/{age:int}", (int age) =>
{
    if (age < 18)
        return Results.BadRequest(new { message = "Invalid age" });
    else
        return Results.Content("Access is available");
});
app.Map("/download", () => Results.Unauthorized());
// отправляем html-код при обращении по пути "/"
app.Map("/", () => Results.Extensions.Html(@"<!DOCTYPE html>
<html>
<head>
<title>TestApp</title>
<meta charset='utf-8' />
</head>
<body>
<h1>Hello World!</h1>
</body>
</html>
"));
app.Run();
class HtmlResult : IResult
{
    string htmlCode = "";
    public HtmlResult(string htmlCode) => this.htmlCode = htmlCode;

    public async Task ExecuteAsync(HttpContext context)
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.WriteAsync(htmlCode);
    }
}
static class ResultsHtmlExtension
{
    public static IResult Html(this IResultExtensions ext, string htmlCode) => new HtmlResult(htmlCode);
}

record class Person(string Name, int Age);