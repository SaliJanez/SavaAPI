using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using SavaAPI.Domain.Entities;
using SavaAPI.Domain.Interfaces;

namespace SavaAPI.Application.Commands
{
    public record UpdateTaskCommand(Guid TaskId, TasksEntity Tasks) : IRequest<TasksEntity>;

    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TasksEntity>
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly ILogger<UpdateTaskCommandHandler> _logger;

        public UpdateTaskCommandHandler(ITasksRepository tasksRepository, ILogger<UpdateTaskCommandHandler> logger)
        {
            _tasksRepository = tasksRepository;
            _logger = logger;
        }

        public async Task<TasksEntity> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var existingTask = await _tasksRepository.GetTasksByIdAsync(request.TaskId);

            if (existingTask == null)
            {
                _logger.LogError("Task with ID {TaskId} does not exist.", request.TaskId);
                throw new KeyNotFoundException($"Task with ID {request.TaskId} does not exist.");
            }

            var updatedTask = await _tasksRepository.UpdateTaskAsync(request.TaskId, request.Tasks);
            _logger.LogInformation("Task with ID {TaskId} has been updated.", request.TaskId);

            return updatedTask;
        }
    }
}
