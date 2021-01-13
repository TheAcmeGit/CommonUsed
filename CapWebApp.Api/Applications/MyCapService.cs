using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;

namespace CapWebApp.Api.Applications
{
    public class MyCapService:ICapSubscribe
    {
        [CapSubscribe("MyCallBacklal")]
        public void TestCapSub(string info)
        {
            Console.WriteLine($"sssssssssssssssss--{info}");
        }
    }
}
