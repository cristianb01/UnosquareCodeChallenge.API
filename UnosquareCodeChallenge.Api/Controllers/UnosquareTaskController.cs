using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnosquareCodeChallenge.Application.Features;
using UnosquareCodeChallenge.Domain.Entities;

namespace UnosquareCodeChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnosquareTaskController(IUnosquareTaskService taskService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool? isCompleted, CancellationToken cancellationToken)
        {
            return Ok(await taskService.GetAll(cancellationToken, isCompleted));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UnosquareTask task, CancellationToken cancellationToken)
        {
            return Ok(await taskService.CreateTask(task, cancellationToken));
        }
        
        
    }
}
