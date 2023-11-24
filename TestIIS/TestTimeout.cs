using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIIS
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestTimeout : ControllerBase
    {
        public TestTimeout()
        { 
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok("I am running");
        }
    }
}
