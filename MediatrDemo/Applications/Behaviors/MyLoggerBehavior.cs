using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatrDemo.Applications.Behaviors
{
    public class MyLoggerBehavior<TRequest,TResponse>:IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<MyLoggerBehavior<TRequest, TResponse>>  _logger;

        public MyLoggerBehavior(ILogger<MyLoggerBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"命令执行前=={DateTime.Now}");
            var result= await next();
            _logger.LogInformation($"命令执行后=={DateTime.Now}");
            return result;
        }
    }
}
