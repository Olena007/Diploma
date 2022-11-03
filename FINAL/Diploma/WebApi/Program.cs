using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

//using Microsoft.EntityFrameworkCore.SqlServer;
//using Application.Interfaces;
//using Application.Providers;
//using Domen.Models;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

////builder.Services.AddPersistence(Configuration);


////string connection = "Data Source=DESKTOP-6S01LM0\\MSSQLSERVER01;Initial Catalog=Store;Integrated Security=True";
////builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(connection));

////string connection = builder.Configuration.GetConnectionString("DefaultConnection");

//// Add services to the container.

//builder.Services.AddSingleton<IPhoneProvider, PhoneProvider>();

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//app.UseDefaultFiles();
//app.UseStaticFiles();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
