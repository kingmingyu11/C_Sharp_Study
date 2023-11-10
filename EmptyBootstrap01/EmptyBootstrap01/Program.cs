var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles(); // 이거 없으면안됨.
app.MapControllerRoute(
    name : "default",
    pattern :"{controller=Home}/{action=Index}/{Id?}"
    );
app.Run();
