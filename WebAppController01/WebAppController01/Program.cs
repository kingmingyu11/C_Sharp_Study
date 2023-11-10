var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();//mvc패턴으로
var app = builder.Build();
app.MapDefaultControllerRoute();


//app.MapGet("/", () => "Hello World!");
app.MapControllerRoute(
    name: "default",
    pattern : "{controller=Home}/{action=Index}/{id?}");

    //pattern : "{controller=First}/{action=First}/{id?}"
   // pattern: "{controller=Home}/{action=About}/{id?}" 
    

app.Run();
