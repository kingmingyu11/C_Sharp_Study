var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapControllerRoute(
    name: "defalut",
    pattern:"{controller=My}/{action=Help}/{id?}"
);
//app.MapControllers();


app.Run();
