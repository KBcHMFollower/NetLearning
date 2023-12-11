var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
//ILogger logger = loggerFactory.CreateLogger<Program>();

app.Map("/", async (context) =>
{
    app.Logger.LogInformation($"Processing request {context.Request.Path}");

    await context.Response.WriteAsync("Hello World!");
});

app.Map("/hello", (ILogger<Program> logger) =>
{
    logger.LogInformation($"Path: /hello  Time: {DateTime.Now.ToLongTimeString()}");
    return "Hello World";
});

app.Map("/helloDJ", (ILoggerFactory loggerFactory) => {

    ILogger logger = loggerFactory.CreateLogger("MapLogger");
    logger.LogInformation($"Path: /hello   Time: {DateTime.Now.ToLongTimeString()}");
    return "Hello World!";
});

app.Run();
