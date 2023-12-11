var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    context.Items.Add("message", "Hello world!");
//    await next.Invoke();
//});

app.Run(async (context) =>
{
    if (context.Request.Cookies.ContainsKey("name"))
    {
        string? name = context.Request.Cookies["name"];
        await context.Response.WriteAsync($"Hello {name}!");
    }
    else
    {
        context.Response.Cookies.Append("name", "Tom");
        await context.Response.WriteAsync("Hello World!");
    }
});

//app.Run(async (context) =>
//{
//    if (context.Items.ContainsKey("message"))
//        await context.Response.WriteAsync($"Message: {context.Items["message"]}");
//    else
//        await context.Response.WriteAsync("Random Text");
//}); ;

app.Run();
