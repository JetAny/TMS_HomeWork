using DBmyGarage;
using DBmyGarage.Interfaces;
using MyGarage;
using MyGarage.Intrefaces;
using MyGarage.Middleware;
using MyGarage.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDbContext, mygarageContext>();

builder.Services.AddScoped<IGetAllTransport, GetAllTransport>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.UseMiddleware<LoginMiddleware>();
//app.UseMiddleware<PasswordMiddleware>();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}");

app.Run();

