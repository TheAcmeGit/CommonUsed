using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyEFDBContext;
using MyEFDBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyEFDBContext.EnumTypes;
using System.Text;

namespace EFCroeUsedSample.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
      

        private readonly HelloWordDBContext   _dBContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(HelloWordDBContext dBContext, ILogger<HomeController> logger)
        {
            _dBContext = dBContext;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Query()
        {
            #region 非跟踪查询
            Console.WriteLine("非跟踪查询");
            var item3 = _dBContext.Blogs.AsNoTracking().FirstOrDefault(f => f.BlogId == 1);
            Console.WriteLine($"item3--HashCode：{item3.GetHashCode()}");

            var item4 = _dBContext.Blogs.AsNoTracking().FirstOrDefault(f => f.BlogId == 1);
            Console.WriteLine($"item4--HashCode：{item4.GetHashCode()}");
            Console.WriteLine($"当前跟踪实体的个数{_dBContext.ChangeTracker.Entries().Count()}");
            #endregion


            #region 跟踪查询
            Console.WriteLine("跟踪查询");
            var item1 = _dBContext.Blogs.AsTracking().FirstOrDefault(f => f.BlogId == 1);
            Console.WriteLine($"item1--HashCode：{item1.GetHashCode()}");

            var item2 = _dBContext.Blogs.AsTracking().FirstOrDefault(f => f.BlogId == 1);
            Console.WriteLine($"item2--HashCode：{item2.GetHashCode()}");
            Console.WriteLine($"当前跟踪实体的个数{_dBContext.ChangeTracker.Entries().Count()}");
            #endregion

            //分跟中查询，不进行标识解析
            _dBContext.Blogs.AsNoTracking().ToList();
            //EFCore 5.0 特性，标识解析分跟中查询
            _dBContext.Blogs.AsNoTrackingWithIdentityResolution().ToList();
            return Ok();
        }
        [HttpGet]
        public IActionResult QueryNoTrack()
        {
            //分跟中查询，不进行标识解析
            _dBContext.Blogs.AsNoTracking().ToList();
            //EFCore 5.0 特性，标识解析分跟中查询
            _dBContext.Blogs.AsNoTrackingWithIdentityResolution().ToList();
            return Ok();
        }

    }
}
