using System;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PolicyDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
           // var t1 = Task.Run(() =>
           //   {
           //       while (true)
           //       {
           //           Task.Delay(1000).Wait();
           //       }
           //   });
           // Console.WriteLine("Hello World!");
           // IServiceCollection services = new ServiceCollection();

           // services.AddScoped<IService1, Service1>();
           // services.AddScoped<IService2, Service2>();
           // services.AddScoped<IContext, Context>();
           // //引用程序集：MediatR.Extensions.Microsoft.DependencyInjection
           // services.AddMediatR(Assembly.GetExecutingAssembly());
           // services.AddLogging(logBuilder =>
           // {
           //     logBuilder.AddConsole();
           // });
           // var sp = services.BuildServiceProvider();
           ////var s1= sp.GetRequiredService<IService1>();
           //// s1.Method();
           // var _mediator = sp.GetRequiredService<IMediator>();
           // _mediator.Send(new SayHelloCommand("张三"));
           // //_mediator.Publish(new SomeEvent());
           // //_mediator.Publish(new SayHelloOkEvent());
           // Console.WriteLine("命令发送完成");
           // t1.Wait();

        }
    }
}
