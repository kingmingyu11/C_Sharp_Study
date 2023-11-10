var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.Use(async (context, next) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    await context.Response.WriteAsync("<b>Main<b> ������ �Դϴ�.");
    await next(context);
});
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("�ȳ��ϼ���");
    await next(context);
});
app.Run(async (context) =>
{
    await context.Response.WriteAsync("ASP.NET Core~! �����սô�");
});

app.Run();
