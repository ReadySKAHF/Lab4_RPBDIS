using Microsoft.EntityFrameworkCore;
using App.Middleware;
using App.Data;
using App;
using App.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Регистрация кэширования
builder.Services.AddMemoryCache();
builder.Services.AddScoped<CachedService>();

// Регистрация сессий
builder.Services.AddSession();

// Регистрация контекста базы данных с использованием строки подключения
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

// Включение сессии
app.UseSession();

// Включение инициализации базы данных через middleware
app.UseDbInitializer();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
