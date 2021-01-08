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
    public class RegisterSucEventHandler : INotificationHandler<RegisterSucEvent>
    {
        private readonly ILogger<RegisterSucEventHandler> _logger;

        public RegisterSucEventHandler(ILogger<RegisterSucEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(RegisterSucEvent notification, CancellationToken cancellationToken)
        {
            await Task.Delay(5000);
            _logger.LogInformation($"RegisterSucEventHandler处理开始时间：{DateTime.Now}==模拟延时5秒");
            _logger.LogInformation($"时间：{DateTime.Now}=====发送电子邮件给{notification.Email}");
            _logger.LogInformation($"RegisterSucEventHandler处理结束时间：{DateTime.Now}");
        }
    }

    public class RegisterSucEventHandlerV2 : INotificationHandler<RegisterSucEvent>
    {
        private readonly ILogger<RegisterSucEventHandlerV2> _logger;

        public RegisterSucEventHandlerV2(ILogger<RegisterSucEventHandlerV2> logger)
        {
            _logger = logger;
        }

        public async Task Handle(RegisterSucEvent notification, CancellationToken cancellationToken)
        {
            await Task.Delay(5000);
            _logger.LogInformation($"RegisterSucEventHandlerV2处理开始时间：{DateTime.Now}==模拟延时5秒");
            _logger.LogInformation($"吼了两嗓子，用时5秒！");
            _logger.LogInformation($"RegisterSucEventHandlerV2处理结束时间：{DateTime.Now}");
        }
    }

}
