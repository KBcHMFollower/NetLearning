namespace Dependency_Injection
{
    public class TimerMiddleware
    {
        RequestDelegate next;

        //TimeService timeService;

        //Можно использовать сервис в конструкторе но, тогда он будет использоваться
        //только один раз (В данном случае не подходит, желательно, чтобы сервис был singleton)
        public TimerMiddleware(RequestDelegate next /* TimeService timeService */)
        {
            this.next = next;
            //this.timeService = timeService;
        }
        //Чтобы объект пересоздавался при каждом вызове Invoke ->
        public async Task InvokeAsync(HttpContext context, TimeService timeService)
        {
            if (context.Request.Path == "/time")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Текущее время: {timeService?.Time}");
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}
