using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using Ecommerce.ShippingExito.Tracking.Infrastructure.Data.Context;
using Ecommerce.ShippingExito.Tracking.Application.Services;
using Ecommerce.ShippingExito.Tracking.Domain.Services;
using Ecommerce.ShippingExito.Tracking.Domain.Repositories;
using Ecommerce.ShippingExito.Tracking.Infrastructure.Data.Repositories;
using Ecommerce.ShippingExito.Tracking.Task.Background;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Services;

namespace Ecommerce.ShippingExito.Tracking.Task
{
    public class Startup
    {
        //public IConfigurationRoot Configuration { get; }

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<DBContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("ShippingConnection")));
            
            //Services
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<ICarrierServices, CarrierServices>();            
            services.AddScoped<ITrackingService, TrackingService>();
            services.AddScoped<ITrackingDomainService, TrackingDomainService>();
            services.AddScoped<IWebIShipmentStatusServices, ShipmentStatusService>();


            //Repositories
            services.AddScoped<IDbShipping, DbShippingRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            //Principal
            
            services.AddScoped<IScopedProcessingService, ManagerServices>();
            services.AddHostedService<BackgroundService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

        }
    }
}
