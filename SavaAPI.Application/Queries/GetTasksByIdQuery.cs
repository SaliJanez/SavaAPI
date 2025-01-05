using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SavaAPI.Domain.Entities;
using SavaAPI.Domain.Interfaces;

namespace SavaAPI.Application.Queries
{
    public record GetTasksByIdQuery(Guid taskId): IRequest<TasksEntity>;

    public class GetTasksByIdHandler(ITasksRepository tasksRepository)
        : IRequestHandler<GetTasksByIdQuery, TasksEntity>
    {
        public async Task<TasksEntity> Handle(GetTasksByIdQuery request, CancellationToken cancellationToken)
        {
           return await tasksRepository.GetTasksByIdAsync(request.taskId);
        }
    }
}
