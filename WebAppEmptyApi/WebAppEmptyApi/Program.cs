var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//App 초기화 후 설정
app.UseRouting();



//app.MapGet("/hi", () => "Home Page");
//app.MapGet("/Home", () => "Hello World~!!! --GEt");
//app.MapPost("/Home", () => "Hello World~!! --Post");
//app.MapPut("/Home", () => "Hello World~!! --put");
//app.MapDelete("/Home", () => "Hello World~!! --delete");

app.UseEndpoints(endpoints =>
{

    endpoints.MapGet("/Home", async (context) =>
    {
        context.Response.ContentType = "text/plain; charset=utf-8";
        await context.Response.WriteAsync("홈페이지 입니다");
    });
    endpoints.MapPost("/Home", async (context) =>
    {
        await context.Response.WriteAsync("POst");
    });
    endpoints.MapPut("/Home", async (context) =>
    {
        await context.Response.WriteAsync("Put");
    });
    endpoints.MapDelete("/Home", async (context) =>
    {
        await context.Response.WriteAsync("Delete");
    });

});

app.Run();
