var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.Use(async (context, next) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    await context.Response.WriteAsync("<b>Main<b> 페이지 입니다.");
    await next(context);
});
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("안녕하세요");
    await next(context);
});
app.Run(async (context) =>
{
    await context.Response.WriteAsync("ASP.NET Core~! 공부합시다");
});

app.Run();
