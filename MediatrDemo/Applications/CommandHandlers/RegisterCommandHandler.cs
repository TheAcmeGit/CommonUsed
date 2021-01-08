using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrDemo.Applications.Commamds;
using MediatrDemo.Applications.Events;
using Microsoft.Extensions.Logging;

namespace MediatrDemo.Applications.CommandHandlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand,bool>
    {
        private readonly ILogger<RegisterCommandHandler> _logger;
        private readonly IMediator _mediator;

        public RegisterCommandHandler(ILogger<RegisterCommandHandler> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            await Task.Delay(1000);
            _logger.LogInformation($"注册命令处理开始时间：{DateTime.Now}==模拟1秒注册");

            if (DateTime.Now.Second % 2 == 0)
            {
                _logger.LogInformation($"当前时间：{DateTime.Now}=====注册成功==用户名：{request.UserName}");
                _mediator.Publish(new RegisterSucEvent(request.Email));
            }
            else {
                _logger.LogInformation($"当前时间：{DateTime.Now}=====注册失败==用户名：{request.UserName}");
                _mediator.Publish(new RegisterFailEvent(request.UserName));
            }
           
            _logger.LogInformation($"注册命令处理结束时间：{DateTime.Now}");
            return true;
        }
    }
}
