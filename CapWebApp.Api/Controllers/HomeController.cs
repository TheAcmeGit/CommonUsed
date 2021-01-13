using CommonConfig.MyDBContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapWebApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly PlanBContext _planBContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(PlanBContext planBContext, ILogger<HomeController> logger)
        {
            _planBContext = planBContext;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _planBContext.JerryMouses.Update(new CommonConfig.Models.JerryMouse {  Name="hah",Gender="genhah"});
            var entitys = _planBContext.ChangeTracker.Entries();

            var num = _planBContext.SaveChanges();
            var entitys1 = _planBContext.ChangeTracker.Entries();
            return Ok(num);
        }

        [HttpPatch]
        public IActionResult Update()
        {
            var item = _planBContext.JerryMouses.Find(21);
            var entitys = _planBContext.ChangeTracker.Entries();
            item.Name = "kkdkdkd";
            var num = _planBContext.SaveChanges();
            var entitys1 = _planBContext.ChangeTracker.Entries();
            return Ok(num);
        }
    }
}
