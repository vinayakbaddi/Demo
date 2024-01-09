using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog.Context;

namespace SpikeHangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly ILogger _logger;

        public MyController(ILogger logger)
        {
            _logger = logger;
        }

        public IActionResult MyControllerMethod()
        {
            // Initialize properties that you want to include in logs for this request
            var requestProperties = new
            {
                UserId = "user123",
                RequestId = Guid.NewGuid().ToString()
                // Add more properties as needed
            };

            // Enrich log context with properties specific to this request
            using (LogContext.PushProperty("UserId", requestProperties.UserId))
            using (LogContext.PushProperty("RequestId", requestProperties.RequestId))
            {
                _logger.LogInformation("Request received in the controller method");

                // Call methods in other layers passing the logger enriched with request-specific properties
                var service = new MyService(_logger);
                service.SomeServiceMethod();

                // Return your ActionResult here
                return Ok(service);
            }
        }
    }

    public class MyService
    {
        private readonly ILogger _logger;

        public MyService(ILogger logger)
        {
            _logger = logger;
        }

        public void SomeServiceMethod()
        {
            // Log something from the service layer using the enriched logger
            _logger.LogInformation("Service method called");

            // Perform service logic
        }
    }
}
