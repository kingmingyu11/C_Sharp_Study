var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


string mainPage = "MainPage";

app.MapGet("/", () => mainPage);
app.MapGet("/Home", () => "반갑습니다.Home 입니다.");
app.MapGet("/About", () => "About Page");

app.Run();
