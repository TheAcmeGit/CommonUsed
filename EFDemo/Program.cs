using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using System.Reflection;
using CommonConfig.MyDBContexts;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading.Tasks;
using CommonConfig.Models;
using Microsoft.Data.SqlClient;

namespace EFDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {

          var task=  Task.Run(() => {
              while (true)
              {
                  Task.Delay(1000).Wait();
                  Console.WriteLine(DateTime.Now);
              }
            
            });
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsetting.json");
            var root = builder.Build();
            IServiceCollection services = new ServiceCollection();
            services.AddLogging(logBuilder=>{
                logBuilder.AddConfiguration(root);
                logBuilder.AddConsole();
            });
            Console.WriteLine(root.GetConnectionString("DefaultConnection"));
            //services.AddDbContext<PlanAContext>(options =>
            //{
            //    options.UseSqlServer(root.GetConnectionString("DefaultConnection"));
            //});

            services.AddDbContext<PlanBContext>(options =>
            {
                options.UseSqlServer(root.GetConnectionString("DefaultConnection"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    //sqlOptions.EnableRetryOnFailure(10,TimeSpan.FromSeconds(5),new[] { 2});
                });
            });
            var sp = services.BuildServiceProvider();
            //var planADb = sp.GetRequiredService<PlanAContext>();
            //数据库不存在则创建数据库
           
            var planBDb = sp.GetRequiredService<PlanBContext>();
            var databaseCreator = planBDb.GetService<IRelationalDatabaseCreator>();
            //planADb.Database.EnsureCreated();
            //databaseCreator.CreateTables();

            planBDb.Database.BeginTransaction();

     //     await  RetryOnFailureCase(sp);

            task.Wait();


            Console.WriteLine("Hello World!");
        }

        public static async Task RetryOnFailureCase(IServiceProvider sp)
        {
            using (var db = sp.GetRequiredService<PlanBContext>())
            {
                var strategy = db.Database.CreateExecutionStrategy();

             
                strategy.Execute(() =>
                {
                    try
                    {
                        Console.WriteLine("数据库异常---" + DateTime.Now);
                        using (var context = sp.GetRequiredService<PlanBContext>())
                        {
                            using (var transaction = context.Database.BeginTransaction())
                            {
                                context.JerryMouses.Add(new JerryMouse { Id = 1, Name = "1", Gender = "1" });
                                context.SaveChanges();

                                //context.JerryMouses.Add(new JerryMouse { Name = "2", Gender = "2" });
                                //context.SaveChanges();

                                transaction.Commit();
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                });
            }



        }
    }
}
