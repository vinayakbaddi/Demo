using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestIISTimeout
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeoutTest : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            Thread.Sleep(TimeSpan.FromMinutes(2));
            return Ok("I am running");
        }
    }
}
