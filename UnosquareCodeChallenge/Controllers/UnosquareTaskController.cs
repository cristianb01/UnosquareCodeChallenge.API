using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnosquareCodeChallenge.Application.Features;

namespace UnosquareCodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnosquareTaskController(IUnosquareTaskService taskService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll([FromQuery] bool isCompleted, CancellationToken cancellationToken)
        {
            return Ok(taskService.GetAll(cancellationToken));
        }
    }
}
