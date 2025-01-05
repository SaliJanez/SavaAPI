using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SavaAPI.Application.Commands;
using SavaAPI.Application.Queries;
using SavaAPI.Domain.Entities;

namespace SavaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController (ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddTaskAsync([FromBody] TasksEntity tasks) 
        {
            var result = await sender.Send(new AddTaskComannd(tasks));
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllTasksAsync()
        {
            var result = await sender.Send(new GetAllTasksQuery());
            return Ok(result);
        }

        [HttpGet("{taskID}")]
        public async Task<IActionResult> GetTasksById([FromRoute] Guid taskID)
        {
            var result = await sender.Send(new GetTasksByIdQuery(taskID));
            return Ok(result);
        }

        [HttpPut("{taskID}")]
        public async Task<IActionResult> UpdateTaskAsync([FromRoute] Guid taskID, [FromBody] TasksEntity tasks)
        {
            var result = await sender.Send(new UpdateTaskCommand(taskID, tasks));
            return Ok(result);
        }

        [HttpDelete("{taskID}")]
        public async Task<IActionResult> DeleteTaskAsync([FromRoute] Guid taskID)
        {
            var result = await sender.Send(new DeleteTaskCommand(taskID));
            return Ok(result);
        }
    }
}
