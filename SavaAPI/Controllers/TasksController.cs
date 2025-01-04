using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SavaAPI.Data;

namespace SavaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TasksController> _logger;

        public TasksController(AppDbContext context, ILogger<TasksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTask()
        {

            return await _context.Tasks.ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTask(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                _logger.LogError("Failed to retrieve task. Task with ID {TaskId} not found. Make sure that the ID is valid and the task exists.", id);
                return NotFound();
            }

            _logger.LogInformation("Successfully retrieved task with ID {TaskId}.", id);
            return task;
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(Guid id, Tasks tasks)
        {
            if (id != tasks.Id)
            {
                _logger.LogError("PUT request failed.Task with ID {TaskId} does not exist.Please verify the ID or ensure the task is created before updating.", id);
                return BadRequest();
            }

            tasks.UpdatedDate = DateTime.Now;
            _context.Entry(tasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Task with ID {TaskId} successfully updated.", id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    _logger.LogError("PUT request failed. Task with ID {TaskId} does not exist.", id);
                    return NotFound();
                }
                else
                {
                    _logger.LogError("Unexpected error occurred while updating task with ID {TaskId}. Concurrency issue.", id);
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<Tasks>> PostTask(Tasks tasks)
        {

            try
            {
                tasks.CreatedDate = DateTime.Now;
                tasks.UpdatedDate = null;

                _context.Tasks.Add(tasks);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Task with ID {TaskId} successfully created.", tasks.Id);
                return CreatedAtAction("GetTask", new { id = tasks.Id }, tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create task. Error: {ErrorMessage}", ex.Message);
                return StatusCode(500, "Internal server error");
            }

        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                _logger.LogError("DELETE request failed. Task with ID {TaskId} not found.", id);
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Task with ID {TaskId} successfully deleted.", id);
            return NoContent();
        }

        private bool TaskExists(Guid id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
