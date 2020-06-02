using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TPO_Lab3_Backend.Controllers;
using TPO_Lab3_Backend.Models;
using TPO_Lab3_Backend.Services;

namespace TPO_Lab3_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {  
            builder.RegisterType<TpoContext>();
            builder.RegisterType<AlmsgivingRepository>();
            builder.RegisterType<BearerRepository>();
            builder.RegisterType<BearerService>();
            builder.RegisterType<AlmsgivingService>();
            builder.RegisterType<Mapper>(); 
            // builder.RegisterControllers(typeof(BearerController).Assembly);
        } 


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
