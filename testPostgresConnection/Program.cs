using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using testPostgresConnection.DAL;

namespace testPostgresConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string connectionString = "";
            using (StreamReader reader = new StreamReader("connectionString.txt"))
            {
                connectionString= reader.ReadToEnd();
            }

            builder.Services.AddDbContext<AppDBContext>(
                opt => opt.UseNpgsql(connectionString)
                );
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}