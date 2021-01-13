using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommonConfig.MyDBContexts;
using System.Reflection;
using DotNetCore.CAP;
using CapWebApp.Api.Applications;

namespace CapWebApp.Api
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

            services.AddTransient<ICapSubscribe, MyCapService>();
            services.AddDbContext<PlanBContext>(options =>
            {
                options.LogTo(Console.WriteLine).EnableSensitiveDataLogging();

                //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(5), new[] { 2 });
                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CapWebApp.Api", Version = "v1" });
            });

            services.AddCap(options => {
                options.UseRabbitMQ(mqOptions => {
                    mqOptions.HostName = "127.0.0.1";
                    mqOptions.UserName = "admin";
                    mqOptions.Password = "admin";
                    mqOptions.VirtualHost = "/";
                });
                options.UseSqlServer(sqlOptions =>
                {
                    sqlOptions.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                    sqlOptions.Schema = "dbo";
                    sqlOptions.UseSqlServer2008();
                });

                options.UseDashboard(DashboardOptions =>
                {
                
                });

                options.DefaultGroup = "CapTestGroup";
             
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CapWebApp.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
