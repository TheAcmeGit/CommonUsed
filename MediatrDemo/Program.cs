using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrDemo.Applications.Behaviors;
using MediatrDemo.Applications.Commamds;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MediatrDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging(logBuilder =>
            {
                logBuilder.AddConsole();
            });
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MyLoggerBehavior<,>));
            var sp = services.BuildServiceProvider();
            var mediator = sp.GetRequiredService<IMediator>();

            Console.WriteLine("Hello World!");
            while (true)
            {
                var ss = Console.ReadLine();
                Console.WriteLine("------------------注册流程开始-------------------------------------");
                mediator.Send(new RegisterCommand("Admin", "123", "123@163.com"));
            }
        }
    }


}
