//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using SavaAPI.Controllers;
//using SavaAPI.Data;
//using Xunit;


//namespace SavaAPI_Test
//{
//    public class TasksControllerTests
//    {
//        private readonly DbContextOptions<AppDbContext> _options;
//        private readonly ILogger<TasksController> _logger;

//        public TasksControllerTests()
//        {
//            // Configure the in-memory database
//            _options = new DbContextOptionsBuilder<AppDbContext>()
//                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
//                .Options;

//            _logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<TasksController>();
//        }

//        private TasksController CreateController()
//        {
//            var context = new AppDbContext(_options);
//            return new TasksController(context, _logger);
//        }

//        [Fact]
//        public async Task GetTask_ReturnsAllTasks()
//        {
//            // Arrange
//            using var context = new AppDbContext(_options);
//            context.Tasks.AddRange(new List<Tasks>
//            {
//                new Tasks { Id = Guid.NewGuid(), Title = "Task 1", IsCompleted = false },
//                new Tasks { Id = Guid.NewGuid(), Title = "Task 2", IsCompleted = true }
//            });
//            await context.SaveChangesAsync();

//            var controller = CreateController();

//            // Act
//            var result = await controller.GetTask();

//            // Assert
//            var actionResult = Assert.IsType<ActionResult<IEnumerable<Tasks>>>(result);
//            var tasks = Assert.IsAssignableFrom<List<Tasks>>(actionResult.Value);
//            Assert.Equal(2, tasks.Count);
//        }

//        [Fact]
//        public async Task GetTask_WithInvalidId_ReturnsNotFound()
//        {
//            // Arrange
//            var invalidId = Guid.NewGuid();
//            var controller = CreateController();

//            // Act
//            var result = await controller.GetTask(invalidId);

//            // Assert
//            Assert.IsType<NotFoundResult>(result.Result);
//        }

//        [Fact]
//        public async Task PostTask_CreatesNewTask_ReturnsCreatedAtAction()
//        {
//            // Arrange
//            using var context = new AppDbContext(_options);
//            var controller = CreateController();

//            var newTask = new Tasks
//            {
//                Id = Guid.NewGuid(),
//                Title = "New Task",
//                Description = "Task Description",
//                IsCompleted = false,
//                DueDate = DateTime.Now.AddDays(1),
//                Priority = 1
//            };

//            // Act
//            var result = await controller.PostTask(newTask);

//            // Assert
//            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
//            Assert.Equal("GetTask", createdResult.ActionName);
//            Assert.Equal(newTask.Id, createdResult.RouteValues["id"]);

//            var createdTask = await context.Tasks.FindAsync(newTask.Id);
//            Assert.NotNull(createdTask);
//            Assert.Equal("New Task", createdTask.Title);
//        }
//        [Fact]
//        public async Task DeleteTask_WithValidId_ReturnsNoContent()
//        {
//            // Arrange
//            var options = new DbContextOptionsBuilder<AppDbContext>()
//                .UseInMemoryDatabase(databaseName: "TestDatabase")
//                .Options;

//            // Use the same context to add the task and to perform the delete operation
//            using (var context = new AppDbContext(options))
//            {
//                // Add the task
//                var task = new Tasks { Id = Guid.NewGuid(), Title = "Task to Delete" };
//                context.Tasks.Add(task);
//                await context.SaveChangesAsync();

//                // Create the controller with the same context
//                var logger = new LoggerFactory().CreateLogger<TasksController>();
//                var controller = new TasksController(context, logger);

//                // Act
//                var result = await controller.DeleteTask(task.Id);

//                // Assert
//                Assert.IsType<NoContentResult>(result);

//                // Verify the task is deleted
//                var deletedTask = await context.Tasks.FindAsync(task.Id);
//                Assert.Null(deletedTask);
//            }
//        }


//        [Fact]
//        public async Task DeleteTask_WithInvalidId_ReturnsNotFound()
//        {
//            // Arrange
//            var invalidId = Guid.NewGuid();
//            var controller = CreateController();

//            // Act
//            var result = await controller.DeleteTask(invalidId);

//            // Assert
//            Assert.IsType<NotFoundResult>(result);
//        }


//        [Fact]
//        public async Task PutTask_WithValidData_ReturnsNoContent()
//        {
//            // Arrange
//            var options = new DbContextOptionsBuilder<AppDbContext>()
//                .UseInMemoryDatabase(databaseName: "TestDatabase_PutTask")
//                .Options;

//            // Add the existing task to the shared in-memory database
//            using (var context = new AppDbContext(options))
//            {
//                var existingTask = new Tasks
//                {
//                    Id = Guid.NewGuid(),
//                    Title = "Existing Task",
//                    IsCompleted = false,
//                    CreatedDate = DateTime.Now
//                };
//                context.Tasks.Add(existingTask);
//                await context.SaveChangesAsync();

//                // Create the controller with the same context
//                var logger = new LoggerFactory().CreateLogger<TasksController>();
//                var controller = new TasksController(context, logger);

//                // Prepare the updated task
//                var updatedTask = new Tasks
//                {
//                    Id = existingTask.Id,
//                    Title = "Updated Task",
//                    IsCompleted = true,
//                    CreatedDate = existingTask.CreatedDate,
//                    UpdatedDate = DateTime.Now
//                };

//                // Act
//                var result = await controller.PutTask(existingTask.Id, updatedTask);

//                // Assert the result type
//                Assert.IsType<NoContentResult>(result);

//                // Verify the task was updated in the database
//                var updatedEntity = await context.Tasks.FindAsync(existingTask.Id);
//                Assert.Equal("Updated Task", updatedEntity.Title);
//                Assert.True(updatedEntity.IsCompleted);
//            }
//        }

//        [Fact]
//        public async Task PutTask_WithInvalidId_ReturnsBadRequest()
//        {
//            // Arrange
//            var invalidId = Guid.NewGuid();
//            var taskToUpdate = new Tasks { Id = Guid.NewGuid(), Title = "Task" };
//            var controller = CreateController();

//            // Act
//            var result = await controller.PutTask(invalidId, taskToUpdate);

//            // Assert
//            Assert.IsType<BadRequestResult>(result);
//        }
//    }
//}