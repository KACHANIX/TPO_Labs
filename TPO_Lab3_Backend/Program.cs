using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Linq;
using TPO_Lab3_Backend.Models;

namespace TPO_Lab3_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            //var asd = new DbContextOptionsBuilder<TPO3Context>().UseSqlServer("Server=PEKA;Database=TPO3;Integrated Security=True;").Options;
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}