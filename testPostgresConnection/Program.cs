using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using testPostgresConnection.DAL;
using testPostgresConnection.DAL.Interfaces;
using testPostgresConnection.DAL.Repositories;
using testPostgresConnection.Domain.Entities;
using testPostgresConnection.Service.Implementations;
using testPostgresConnection.Service.Interfaces;

namespace testPostgresConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            AppDBContext.ConnectionString= builder.Configuration["ConnectionStrings"];
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            DbContextOptions<AppDBContext> dbContextOptions= new DbContextOptions<AppDBContext>();
            DbContextOptionsBuilder<AppDBContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDBContext>().UseNpgsql(AppDBContext.ConnectionString);
            AppDBContext appDBContext = new AppDBContext(dbContextOptions);
            //appDBContext.UpdateDatabase();

            builder.Services.AddDbContext<AppDBContext>(opt => opt.UseNpgsql(AppDBContext.ConnectionString));

            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();

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