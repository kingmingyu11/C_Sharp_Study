var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


string mainPage = "MainPage";

app.MapGet("/", () => mainPage);
app.MapGet("/Home", () => "�ݰ����ϴ�.Home �Դϴ�.");
app.MapGet("/About", () => "About Page");

app.Run();
