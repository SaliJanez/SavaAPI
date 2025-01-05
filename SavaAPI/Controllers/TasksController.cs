using MediatR;
using Microsoft.AspNetCore.Mvc;
using SavaAPI.Application.Commands;
using SavaAPI.Application.Queries;
using SavaAPI.Domain.Entities;

namespace SavaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ISender sender, ILogger<TasksController> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddTaskAsync([FromBody] TasksEntity tasks)
        {
            _logger.LogInformation("Received request to add a new task.");

            var result = await _sender.Send(new AddTaskComannd(tasks));

            _logger.LogInformation("Successfully added a new task with ID: {TaskId}.", result.Id);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllTasksAsync()
        {
            _logger.LogInformation("Received request to fetch all tasks.");

            var result = await _sender.Send(new GetAllTasksQuery());

            _logger.LogInformation("Successfully retrieved {TaskCount} tasks.", result.Count());
            return Ok(result);
        }

        [HttpGet("{taskID}")]
        public async Task<IActionResult> GetTasksById([FromRoute] Guid taskID)
        {
            _logger.LogInformation("Received request to fetch task with ID: {TaskId}.", taskID);

            var result = await _sender.Send(new GetTasksByIdQuery(taskID));

            if (result == null)
            {
                _logger.LogWarning("Task with ID: {TaskId} not found.", taskID);
                return NotFound();
            }

            _logger.LogInformation("Successfully retrieved task with ID: {TaskId}.", taskID);
            return Ok(result);
        }

        [HttpPut("{taskID}")]
        public async Task<IActionResult> UpdateTaskAsync([FromRoute] Guid taskID, [FromBody] TasksEntity tasks)
        {
            _logger.LogInformation("Received request to update task with ID: {TaskId}.", taskID);

            var result = await _sender.Send(new UpdateTaskCommand(taskID, tasks));

            if (result == null)
            {
                _logger.LogWarning("Failed to update task with ID: {TaskId}. Task not found.", taskID);
                return NotFound();
            }

            _logger.LogInformation("Successfully updated task with ID: {TaskId}.", taskID);
            return Ok(result);
        }

        [HttpDelete("{taskID}")]
        public async Task<IActionResult> DeleteTaskAsync([FromRoute] Guid taskID)
        {
            _logger.LogInformation("Received request to delete task with ID: {TaskId}.", taskID);

            var result = await _sender.Send(new DeleteTaskCommand(taskID));

            if (!result)
            {
                _logger.LogWarning("Failed to delete task with ID: {TaskId}. Task not found.", taskID);
                return NotFound();
            }

            _logger.LogInformation("Successfully deleted task with ID: {TaskId}.", taskID);
            return NoContent();
        }
    }
}
