var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
                options.ConstraintMap.Add("invalidnames", typeof(InvalidNamesConstraint)));
builder.Services.AddTransient<TimeService>();

var app = builder.Build();

app.Map(
    "{controller=Home}/{action=Index}/{id?}",
    (string controller, string action, string? id) =>
        $"Controller: {controller} \nAction: {action} \nId: {id}"
);
app.Map(
    "/users/{name:alpha:minlength(2)}/{age:int:range(1, 110)}",
    (string name, int age) => $"User Age: {age} \nUser Name:{name}"
);
app.Map(
    "/phonebook/{phone:regex(^7-\\d{{3}}-\\d{{3}}-\\d{{4}}$)}/",
    (string phone) => $"Phone: {phone}"
);
app.Map("/users/{name:invalidnames}", (string name) => $"Name: {name}");
app.Map("/time", (TimeService timeService) => SendTime);

app.Map("/", () => "Index Page");

app.Run();

string SendTime(TimeService timeService)
{
    return $"Time: {timeService.Time}";
}
public class TimeService
{
    public string Time => DateTime.Now.ToLongTimeString();
}
public class InvalidNamesConstraint : IRouteConstraint
{
    string[] names = new[] { "Tom", "Sam", "Bob" };
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
        RouteValueDictionary values, RouteDirection routeDirection)
    {
        return !names.Contains(values[routeKey]?.ToString());
    }
}