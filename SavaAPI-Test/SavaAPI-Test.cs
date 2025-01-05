using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using SavaAPI.Application.Commands;
using SavaAPI.Domain.Entities;
using SavaAPI.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Xunit;

namespace SavaAPI.Tests
{
   

    // Tests for ITasksRepository (mocked CRUD operations)

    public class TasksRepositoryTests
    {
        private readonly Mock<ITasksRepository> _tasksRepositoryMock;

        public TasksRepositoryTests()
        {
            _tasksRepositoryMock = new Mock<ITasksRepository>();
        }

        [Fact]
        public async Task GetTasks_ReturnsTaskList()
        {
            // Arrange
            var taskList = new List<TasksEntity>
            {
                new TasksEntity { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1", IsCompleted = false, DueDate = DateTime.Now.AddDays(1), Priority = 1, CreatedDate = DateTime.Now },
                new TasksEntity { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2", IsCompleted = true, DueDate = DateTime.Now.AddDays(2), Priority = 2, CreatedDate = DateTime.Now }
            };

            _tasksRepositoryMock.Setup(repo => repo.GetTasks())
                                .ReturnsAsync(taskList);

            // Act
            var tasks = await _tasksRepositoryMock.Object.GetTasks();

            // Assert
            Assert.Equal(2, tasks.Count());
            Assert.Equal("Task 1", tasks.First().Title);
            Assert.Equal("Task 2", tasks.Last().Title);
        }

        [Fact]
        public async Task AddTaskAsync_ReturnsNewTask()
        {
            // Arrange
            var newTask = new TasksEntity
            {
                Id = Guid.NewGuid(),
                Title = "New Task",
                Description = "New task description",
                IsCompleted = false,
                DueDate = DateTime.Now.AddDays(5),
                Priority = 3,
                CreatedDate = DateTime.Now
            };

            _tasksRepositoryMock.Setup(repo => repo.AddTaskAsync(It.IsAny<TasksEntity>()))
                                .ReturnsAsync(newTask);

            // Act
            var result = await _tasksRepositoryMock.Object.AddTaskAsync(newTask);

            // Assert
            Assert.Equal("New Task", result.Title);
            Assert.Equal("New task description", result.Description);
        }

        [Fact]
        public async Task DeleteTaskAsync_ReturnsTrue()
        {
            // Arrange
            var taskId = Guid.NewGuid();
            _tasksRepositoryMock.Setup(repo => repo.DeleteTaskAsync(taskId))
                                .ReturnsAsync(true);

            // Act
            var result = await _tasksRepositoryMock.Object.DeleteTaskAsync(taskId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteTaskAsync_Fails_ReturnsFalse()
        {
            // Arrange
            var taskId = Guid.NewGuid();
            _tasksRepositoryMock.Setup(repo => repo.DeleteTaskAsync(taskId))
                                .ReturnsAsync(false);

            // Act
            var result = await _tasksRepositoryMock.Object.DeleteTaskAsync(taskId);

            // Assert
            Assert.False(result);
        }
    }
}
