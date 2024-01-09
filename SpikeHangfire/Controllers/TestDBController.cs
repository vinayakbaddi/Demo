using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpikeHangfire.DB;

namespace SpikeHangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDBController : ControllerBase
    {
        private HangFireDBContext _dBContext;

        public TestDBController(HangFireDBContext dBContext) 
        {
            _dBContext = dBContext;
        }

        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public IActionResult Get()
        { 
            
        }
    }
}
