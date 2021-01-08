using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrDemo.Applications.Events;
using Microsoft.Extensions.Logging;

namespace MediatrDemo.Applications.EventHandlers
{
    public class RegisterFailEventHandler : INotificationHandler<RegisterFailEvent>
    {
        private readonly ILogger<RegisterFailEventHandler> _logger;

        public RegisterFailEventHandler(ILogger<RegisterFailEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(RegisterFailEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogError($"RegisterFailEventHandler处理开始时间：{DateTime.Now}");
            _logger.LogError($"时间：{DateTime.Now}=====用户名：{notification.UserName}注册失败");
            _logger.LogError($"RegisterFailEventHandler处理结束时间：{DateTime.Now}");
        }
    }
}
