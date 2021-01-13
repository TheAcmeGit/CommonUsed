using CommonConfig.MyDBContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using CommonConfig.Models;

namespace CapWebApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CapTestController : ControllerBase
    {

        private readonly PlanBContext _planBContext;
        private readonly ILogger<CapTestController> _logger;
        private readonly ICapPublisher _capPublisher;

        public CapTestController(PlanBContext planBContext, ILogger<CapTestController> logger, ICapPublisher capPublisher)
        {
            _planBContext = planBContext;
            _logger = logger;
            _capPublisher = capPublisher;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _planBContext.JerryMouses.Add(new CommonConfig.Models.JerryMouse {  Name="hah",Gender="genhah"});
           var num= _planBContext.SaveChanges();
            return Ok(num);
        }

        [HttpPost]
        public IActionResult SendFirst()
        {
            _capPublisher.Publish("SendFirst", new JerryMouse { Name= "SendFirst--张三", Gender= DateTime.Now .ToString() },"MyCallBacklal");
            return Ok("发送完成");
        }
        //[HttpPost]
        //public IActionResult Send()
        //{
        //    _capPublisher.Publish("SendSecond", new JerryMouse { Name = "SendSecond--张三", Gender = $"{DateTime.Now}" });
        //    return Ok("发送完成");
        //}

        [CapSubscribe("SendFirst")]
        //[CapSubscribe("SendSecond")]
        [NonAction]
        public string Receive(JerryMouse obj)
        {
            _logger.LogInformation("接收--" + obj.Name);
            return "接收完成回掉返回";
        }
        


    }
}
