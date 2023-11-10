var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles(); // �̰� ������ȵ�.
app.MapControllerRoute(
    name : "default",
    pattern :"{controller=Home}/{action=Index}/{Id?}"
    );
app.Run();
