using Microsoft.EntityFrameworkCore;
using App.Middleware;
using App.Data;
using App;
using App.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ����������� �����������
builder.Services.AddMemoryCache();
builder.Services.AddScoped<CachedService>();

// ����������� ������
builder.Services.AddSession();

// ����������� ��������� ���� ������ � �������������� ������ �����������
builder.Services.AddDbContext<AutoRepairWorkshopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// ��������� ������
app.UseSession();

// ��������� ������������� ���� ������ ����� middleware
app.UseDbInitializer();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
