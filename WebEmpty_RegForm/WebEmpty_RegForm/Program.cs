var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); //html���������
var app = builder.Build();

app.UseStaticFiles(); // ���������� ����ϱ�

app.MapGet("/", () => "Hello World!");

app.Run();
