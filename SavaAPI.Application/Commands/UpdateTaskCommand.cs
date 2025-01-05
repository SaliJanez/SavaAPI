using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SavaAPI.Domain.Entities;
using SavaAPI.Domain.Interfaces;

namespace SavaAPI.Application.Commands
{
    public record UpdateTaskCommand(Guid TaskId, TasksEntity Tasks)
        :IRequest<TasksEntity>;
    public class UpdateTaskCommandHandler(ITasksRepository tasksRepository)
        : IRequestHandler<UpdateTaskCommand, TasksEntity>
    {
        public async Task<TasksEntity> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            return await tasksRepository.UpdateTaskAsync(request.TaskId, request.Tasks);
        }
    }
}
