using MyGarageDB;
using MyGarageDB.Interfaces;
using MyGarageMVC.Intrefaces;
using MyGarageMVC.Models;
using MyGarageMVC.Servises;

namespace MyGarageMVC
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IDbContext, mygarageContext>();


            builder.Services.AddScoped<ICreateTransportService, CreateTransportService>();
            builder.Services.AddScoped<IGetTransportService, GetTransportService>();
            builder.Services.AddScoped<IUpdateTransportService, UpdateTransportService>();

            builder.Services.AddScoped<IGetAllGarageService, GetAllGarageService>();
            builder.Services.AddScoped<IMovingTransportService, MovingTransportService>();
            builder.Services.AddScoped<IReturnTransportService, ReturnTransportService>();
            builder.Services.AddScoped<IDeleteTransportService, DeleteTransportService>();




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
                pattern: "{controller=Transport}/{action=Input}/{Id?}");

            app.Run();
        }
    }
}
