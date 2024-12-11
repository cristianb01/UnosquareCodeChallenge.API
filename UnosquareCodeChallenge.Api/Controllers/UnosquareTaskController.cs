using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnosquareCodeChallenge.Application.Exceptions;
using UnosquareCodeChallenge.Application.Features;
using UnosquareCodeChallenge.Domain.Entities;

namespace UnosquareCodeChallenge.Api.Controllers
{
    [Route("api/tasks")]
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

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UnosquareTask task, CancellationToken cancellationToken)
        {
            try
            {
                var updatedTask = await taskService.UpdateTask(id, task, cancellationToken);
                return Ok(updatedTask);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                await taskService.DeleteTask(id, cancellationToken);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
